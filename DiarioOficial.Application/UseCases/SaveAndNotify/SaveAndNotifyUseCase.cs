using DiarioOficial.CrossCutting.DTOs.OfficialStateDiary;
using DiarioOficial.CrossCutting.DTOs.Person;
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

            var fetchAndProcessDiaries = FetchAndProcessDiaries(personData, year);



            // TODO: Enviar email

            return true;
        }


        internal async Task<OneOf<bool, BaseError>> FetchAndProcessDiaries(ResponsePersonDTO responsePersonDTO, string year)
        {
            var stateDiaryData = await _officialStateDiaryService.GetOfficialMunicipalDiaryResponse(responsePersonDTO.Name, year);

            if (stateDiaryData.IsError())
                return stateDiaryData.GetError();

            var officialStateDiaryData = ProcessDiaryData(stateDiaryData);


            var electronicDiaryData = await _officialElectronicDiaryService.GetOfficialStateDiaryResponse(responsePersonDTO.Name, year);

            if (electronicDiaryData.IsError())
                return electronicDiaryData.GetError();

            var officialElectronicDiaryData = ProcessDiaryData(electronicDiaryData);

            return true;
        }


        internal async Task<OneOf<bool, BaseError>> ProcessDiaryData(OneOf<List<ResponseOfficialMunicipalDiaryDTO>, BaseError> responseOfficialDiaryDTO) 
        {
            if (responseOfficialDiaryDTO.IsSuccess())
            {
                var officialMunicipalDiaryEntries = responseOfficialDiaryDTO.GetValue();

                return await _personRepository.addOfficialDiary(officialMunicipalDiaryEntries);
            }

            return false;
        }

    }
}
