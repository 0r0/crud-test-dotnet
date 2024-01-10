﻿using Mc2.CrudTest.Presentation.Shared;
using Mc2.Query.Contracts.Requests;
using Mc2.Query.Contracts.Responses;

namespace Mc2.Query.CustomerManagers;

public class CustomerQueryHandlers : IQueryHandler<GetCustomerById,CustomerResponse>,
    IQueryHandler<GetAllCustomers,IReadOnlyCollection<CustomerResponse>>,
    IQueryHandler<IsSameEmailExist,bool>,
    IQueryHandler<IsCustomerWithSameFirstNameLastNameAndBirthDateExist,bool
    >
{
    public CustomerResponse Handle(GetCustomerById query)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyCollection<CustomerResponse> Handle(GetAllCustomers query)
    {
        throw new NotImplementedException();
    }

    public bool Handle(IsSameEmailExist query)
    {
        throw new NotImplementedException();
    }

    public bool Handle(IsCustomerWithSameFirstNameLastNameAndBirthDateExist query)
    {
        throw new NotImplementedException();
    }
}