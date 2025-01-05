using DiarioOficial.CrossCutting.DTOs.OfficialStateDiary;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.CrossCutting.Errors.OfficialStateDiary;
using DiarioOficial.CrossCutting.Extensions;
using DiarioOficial.Domain.Interface.Repository;
using DiarioOficial.Domain.Interface.Services.OfficialElectronicDiary;
using DiarioOficial.Domain.Interface.Services.OfficialStateDiary;
using DiarioOficial.Domain.Interface.UseCases.SaveAndNotify;
using Microsoft.AspNetCore.Http;
using OneOf;

namespace DiarioOficial.Application.UseCases.SaveAndNotify
{
    internal class SaveAndNotifyUseCase 
        (
            IOfficialMunicipalDiaryService officialStateDiaryService,
            IOfficialStateDiaryService officialElectronicDiaryService,
            IHttpContextAccessor httpContextAccessor,
            IPersonRepository personRepository

        ) : ISaveAndNotifyUseCase
    {
        private readonly IOfficialMunicipalDiaryService _officialStateDiaryService = officialStateDiaryService;
        private readonly IOfficialStateDiaryService _officialElectronicDiaryService = officialElectronicDiaryService;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly IPersonRepository _personRepository = personRepository;

        public async Task<OneOf<bool, BaseError>> SaveAndNotify()
        {
            var userName = _httpContextAccessor.HttpContext.GetSystemIdentifierIdByContext();

            if (string.IsNullOrWhiteSpace(userName) || userName.Length < 3)
                return new InvalidName();

            var year = DateTime.Now.Year.ToString();

            var yearValid = year.EnsureValidYear();

            if (yearValid.IsError())
                return yearValid.GetError();

            var personData = await _personRepository.GetPersonDTOAsync(userName);

            var sessionData = await _personRepository.AddSession(personData.Id, yearValid.GetValue());

            if (sessionData.IsError())
                return sessionData.GetError();

            var fetchAndProcessDiaries = FetchAndProcessDiaries(personData.Name, year, personData.Id, sessionData.GetValue());



            // TODO: Enviar email

            return true;
        }


        internal async Task<OneOf<bool, BaseError>> FetchAndProcessDiaries(string name, string year, long personId, long sessionId)
        {
            var municipalDiaryResult = await FetchAndProcessDiaryData(() => _officialStateDiaryService.GetOfficialMunicipalDiaryResponse(name, year), personId, sessionId);

            if (municipalDiaryResult.IsError())
                return municipalDiaryResult.GetError();

            var electronicDiaryResult = await FetchAndProcessDiaryData(() => _officialElectronicDiaryService.GetOfficialStateDiaryResponse(name, year), personId, sessionId);

            if (electronicDiaryResult.IsError()) 
                return electronicDiaryResult.GetError();

            return true;
        }

        internal async Task<OneOf<List<Dictionary<string, string>>, BaseError>> FetchAndProcessDiaryData(Func<Task<OneOf<List<ResponseOfficialMunicipalDiaryDTO>, BaseError>>> fetchDiaryData, long personId, long sessionId) 
        {
            var diaryData = await fetchDiaryData();

            if (diaryData.IsError())
                    return diaryData.GetError();

            var newDiaries = diaryData.GetValue();

            var newList = newDiaries.Select(item => new Dictionary<string, string>
            {
                { "Number", item.Number },
                { "Day", item.Day },
                { "File", item.File },
                { "Description", item.Description },
                { "SessionId", sessionId.ToString() },
                { "PersonId", personId.ToString() }
            }).ToList();

            var addOfficialDiary = await _personRepository.addOfficialDiary(newList);

            if (addOfficialDiary.IsError())
                return addOfficialDiary.GetError(); 

            return newList;

        }

   


    }
}
