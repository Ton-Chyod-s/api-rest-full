using DiarioOficial.CrossCutting.Enums.OfficialStateDiaries;

namespace DiarioOficial.CrossCutting.DTOs.OfficialStateDiary
{
    public record ResponseOfficialDiaryDTO
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
