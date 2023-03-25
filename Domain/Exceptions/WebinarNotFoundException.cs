namespace Domain.Exceptions;

public sealed class WebinarNotFoundException : Exception
{
	public WebinarNotFoundException(Guid webinarId)
		: base($"Webinar with id {webinarId} not found.")
	{
	}
}