using Application.Abstractions.Messaging;
using Dapper;
using Domain.Abstractions;
using Domain.Exceptions;
using Domain.Shared;
using MediatR;
using System.Data;

namespace Application.Webinars.Queries.GetWebinarById;

internal sealed class GetWebinarQueryHandler : IQueryHandler<GetWebinarByIdQuery, WebinarResponse>
{
    private readonly IDbConnection _dbConnection;

    public GetWebinarQueryHandler(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Result<WebinarResponse>> Handle(GetWebinarByIdQuery request, CancellationToken cancellationToken)
    {
        const string sql = @"SELECT Id, Name, ScheduleOn FROM ""Webinars"" WHERE ""Id"" = @webinarId";
        var webinar = await _dbConnection.QueryFirstOrDefaultAsync<WebinarResponse>(sql, new { Id = request.webinarId });

        if (webinar is null)
            throw new WebinarNotFoundException(request.webinarId);

        return webinar;
    }
}