namespace DiarioOficial.CrossCutting.DTOs.OfficialStateDiary
{
    public record ResponseOfficialStateDiaryDTO
        (
            string Number,
            string Day,
            string File,
            string Description,
            string DayCode
        );
}
