using DiarioOficial.CrossCutting.Enums.OfficialStateDiaries;

namespace DiarioOficial.CrossCutting.DTOs.OfficialStateDiary
{
    public record ResponseOfficialMunicipalDiaryDTO
        (
            string Number,
            string Day,
            string File,
            string Description,
            TypeDiaryEnum Type,
            long? PersonId,
            long? SessionId
        );
}
