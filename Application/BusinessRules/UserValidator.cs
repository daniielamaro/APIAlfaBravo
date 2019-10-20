using Domain;
using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using Application.Repository;
using Application.Entity;
using System.Linq;

namespace Application.BusinessRules
{
    public class UserValidator : AbstractValidator<User>
    {
        private readonly IUserRepository userRepository;

        public UserValidator()
        {
            userRepository = new UserRepository();

            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("O Id não pode ser nulo.");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")
                .NotEmpty()
                .WithMessage("O Nome não pode estar em branco.")
                .Must(NameOnlyLetters)
                .WithMessage("O Nome não pode conter números ou caracteres especiais.");

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("O Email não pode ser nulo.")
                .NotEmpty()
                .WithMessage("O Email não pode ficar em branco.")
                .EmailAddress()
                .WithMessage("O Email está em um formato inválido.")
                .Must((user, email) => EmailNotExists(user, email))
                .WithMessage("Este Email já está registrado na base de dados");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("A senha não pode estar em branco.")
                .NotNull()
                .WithMessage("A senha não pode ser nula.")
                .MinimumLength(8)
                .WithMessage("A senha precisa conter entre 8 e 30 caracteres.");
        }

        private bool NameOnlyLetters(string name)
        {
            return (name.All(c => Char.IsLetter(c) || c == ' '));
        }

        private bool EmailNotExists(User user, string email)
        {
            List<User> listUsers = userRepository.GetAll();

            return !(listUsers.Exists(x => x.Email == email && x.Id != user.Id));
        }
    }
}
