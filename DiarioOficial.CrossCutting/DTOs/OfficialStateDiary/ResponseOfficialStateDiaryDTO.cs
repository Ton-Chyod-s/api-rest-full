using DiarioOficial.CrossCutting.Enums.OfficialStateDiaries;

namespace DiarioOficial.CrossCutting.DTOs.OfficialElectronicDiary
{
    public record ResponseOfficialStateDiaryDTO
        (
            string Number,
            string DateStartPublishedArchive,
            string FileName,
            string Description,
            TypeDiaryEnum Type
        );
}
