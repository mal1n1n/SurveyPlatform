﻿using FluentValidation;
using SurveyPlatform.API.DTOs.Requests;

namespace SurveyPlatform.DTOs.Requests.Validators;
public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
{
    public RegisterUserRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Имя обязательно для заполнения.")
            .MinimumLength(2).WithMessage("Длина имени должна быть больше 2 символов.")
            .MaximumLength(30).WithMessage("Максимальная длина имени - 30 символов.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Почта обязательна для заполнения.")
            .EmailAddress().WithMessage("Почта указана неверно.")
            .MaximumLength(50).WithMessage("Максимальная длина почты - 50 символов.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Пароль обязателен для заполнения.")
            .MinimumLength(8).WithMessage("Минимальная длина пароля - 8 символов.")
            .MaximumLength(32).WithMessage("Максимальная длина пароля - 32 символа.");
    }
}
