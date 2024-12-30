using DiarioOficial.CrossCutting.Enums.OfficialStateDiaries;

namespace DiarioOficial.CrossCutting.DTOs.OfficialElectronicDiary
{
    public record ResponseOfficialElectronicDiaryDTO
        (
            string Number,
            string DateStartPublishedArchive,
            string FileName,
            string Description,
            TypeDiaryEnum Type
        );
}
