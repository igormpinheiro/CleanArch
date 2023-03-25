namespace Application.Webinars.Queries.GetWebinarById;

public sealed record WebinarResponse(Guid id, DateTime scheduleOn)
{
}