using FluentValidation;

namespace cashop.core.Validators;

public interface ICashopValidator<T>
{
    void ValidateAndThrow(T instance);
}