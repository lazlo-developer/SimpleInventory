namespace SimpleInventory.Domain.Exceptions;

public abstract class BusinessRuleViolationException(string code, string message) : Exception(message)
{
    public string Code { get; } = code;
}
