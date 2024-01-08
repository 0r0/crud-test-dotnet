namespace Mc2.CrudTest.Presentation.Shared;

public interface ICommandValidator<in T>
{
    public void Validate(T command);
}