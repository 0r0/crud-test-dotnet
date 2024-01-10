namespace Mc2.Domain.CustomerManagers;

public class BusinessException :Exception
{
    public BusinessException(Enum errorCode)
    {
        ErrorCode = errorCode;
    }

    public Enum ErrorCode { get; private set; }
}