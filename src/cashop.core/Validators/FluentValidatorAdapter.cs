using FluentValidation;

namespace cashop.core.Validators;

public class FluentValidatorAdapter<T> : ICashopValidator<T>
{
    private readonly IValidator<T> _fluentValidator;

    public FluentValidatorAdapter(IValidator<T> fluentValidator)
    {
        _fluentValidator = fluentValidator;
    }

    public void ValidateAndThrow(T instance)
    {
        _fluentValidator.ValidateAndThrow(instance);
    }
}