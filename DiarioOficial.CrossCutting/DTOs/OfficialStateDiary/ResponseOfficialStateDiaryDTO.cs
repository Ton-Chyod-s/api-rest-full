using DiarioOficial.CrossCutting.Enums.OfficialStateDiaries;

namespace DiarioOficial.CrossCutting.DTOs.OfficialStateDiary
{
    public record ResponseOfficialStateDiaryDTO
        (
            string Number,
            string Day,
            string File,
            string Description,
            TypeDiaryEnum Type
        );
}
