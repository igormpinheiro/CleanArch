﻿using Application.Abstractions.Messaging;

namespace Application.Webinars.Commands.CreateWebinar;

public sealed record CreateWebinarCommand(string Name, DateTime ScheduleOn) : ICommand<Guid>;