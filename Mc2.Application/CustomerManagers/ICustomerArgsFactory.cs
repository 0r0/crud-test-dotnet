using Mc2.Application.Contracts.CustomerManagers;
using Mc2.Domain.CustomerManagers;

namespace Mc2.Application.CustomerManagers;

public interface ICustomerArgsFactory
{
    public CustomerArgs CreateFrom(DefineCustomerCommand command);
    public CustomerArgs CreateFrom(ModifyCustomerCommand command);
}