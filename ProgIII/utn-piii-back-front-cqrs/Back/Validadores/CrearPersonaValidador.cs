using EjemploCQRS.Servicios.Personas;
using FluentValidation;

namespace EjemploCQRS.Validadores
{
    public class CrearPersonaValidador
        : AbstractValidator<GuardarPersonaCommand>
    {
        public CrearPersonaValidador()
        {
            RuleFor((regla) => regla.Apellido)
                .MaximumLength(10)
                .WithMessage("El campo apellido tiene más de 10 caracteres");

            RuleFor((regla) => regla.Nombre)
                .MinimumLength(10);
        }
    }
}
