namespace DiarioOficial.CrossCutting.DTOs.OfficialStateDiary
{
    public record QueryOfficialStateDiary 
        (
        string Action,
        string Name,
        string OfDate,
        string UntilDate
        );
}
