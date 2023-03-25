using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Shared;

namespace Application.Webinars.Commands.CreateWebinar;

public sealed class CreateWebinarCommandHandler : ICommandHandler<CreateWebinarCommand, Guid>
{
    private readonly IWebinarRepository _webinarRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateWebinarCommandHandler(IWebinarRepository webinarRepository, IUnitOfWork unitOfWork)
    {
        _webinarRepository = webinarRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreateWebinarCommand request, CancellationToken cancellationToken)
    {
        var webinar = new Webinar(Guid.NewGuid(), request.Name, request.ScheduleOn);

        _webinarRepository.Insert(webinar);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return webinar.Id;
    }
}