using Application.Abstractions.Messaging;

namespace Application.Webinars.Queries.GetWebinarById
{
    public sealed record GetWebinarByIdQuery(Guid webinarId) : IQuery<WebinarResponse>;
}