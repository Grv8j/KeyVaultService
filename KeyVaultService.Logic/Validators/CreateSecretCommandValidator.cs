using FluentValidation;
using KeyVaultService.Framework.Dependency;
using KeyVaultService.Interface.Command;
using KeyVaultService.Interface.Services;
#pragma warning disable CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'

namespace KeyVaultService.Logic.Validators;

/// <summary>
/// Create secret command validator
/// </summary>
[RegisterService(typeof(IValidator<VmCreateSecretCommand>), EServiceLifetime.Scoped)]
internal class CreateSecretCommandValidator : AbstractValidator<VmCreateSecretCommand>
{
  
    /// <summary>
    /// C-tor
    /// </summary>
    /// <param name="validationHelperService">Validation helper service</param>
    public CreateSecretCommandValidator(ISecretsValidationHelperService validationHelperService)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithSeverity(Severity.Error)
            .WithMessage("Name is required");
        
        RuleFor(x => x.Value)
            .NotEmpty()
            .WithSeverity(Severity.Error)
            .WithMessage("Value is required");

        RuleFor(x => x.VaultId)
            .NotEmpty()
            .WithSeverity(Severity.Error)
            .WithMessage("Vault id is required");

        RuleFor(x => x.ActivationDate)
            .LessThanOrEqualTo(x => x.ExpirationDate)
            .WithSeverity(Severity.Error)
            .WithMessage("ActivationDate date must be earlier or equal to ExpirationDate date")
            .When(x => x.ActivationDate != null && x.ExpirationDate != null);
        
        RuleFor(x => x.ExpirationDate)
            .GreaterThanOrEqualTo(x => x.ActivationDate)
            .WithSeverity(Severity.Error)
            .WithMessage("Expiration date must be greater or equal to activation date")
            .When(x => x.ActivationDate != null && x.ExpirationDate != null);
        
        RuleFor(x => x.IsEnabled)
            .NotNull()
            .WithSeverity(Severity.Error)
            .WithMessage("Enable flag is required");
        
        RuleFor(x => x.VaultId)
            .Must(validationHelperService.DoesVaultExist)
            .When(x => x.VaultId != null)
            .WithSeverity(Severity.Error)
            .WithMessage("Vault with specified id doesn't exist");
    }
}