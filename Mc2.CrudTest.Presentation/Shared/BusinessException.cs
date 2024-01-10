namespace Mc2.CrudTest.Presentation.Shared;

public class BusinessException :Exception
{
    public BusinessException(Enum errorCode)
    {
        ErrorCode = errorCode;
    }

    public Enum ErrorCode { get; private set; }
    public override string ToString() => this.ErrorCode.ToString().Replace('_', '-');

}