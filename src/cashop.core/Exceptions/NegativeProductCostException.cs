namespace cashop.core.Exceptions;

public class NegativeProductPriceException : Exception
{
    public NegativeProductPriceException()
    {
    }

    public NegativeProductPriceException(string? message) : base(message)
    {
    }
}