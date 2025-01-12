﻿using FluentValidation;

namespace Vertical_Slice_Architecture.Features.Events.Requests.CreateEvent;

public sealed class CreateEventValidator : AbstractValidator<CreateEventCommand>
{
    public CreateEventValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(500);

        RuleFor(x => x.Location)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Status)
            .IsInEnum();

        RuleFor(x => x.StartDate)
            .NotEmpty()
            .GreaterThan(DateTime.Now);

        RuleFor(x => x.EndDate)
            .NotEmpty()
            .GreaterThan(x => x.StartDate);
    }
}