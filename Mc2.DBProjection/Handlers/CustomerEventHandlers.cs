// using System.Text;
// using Mc2.CrudTest.Presentation.Shared;
// using Mc2.Domain.Contracts.CustomerManagers;
// using Neo4j.Driver;
//
// namespace Mc2.DBProjection.Handlers;
//
// public class CustomerEventHandlers : IEventHandler<CustomerDefined>,
//     IEventHandler<CustomerModified>,
//     IEventHandler<CustomerRemoved>
// {
//     private readonly IAsyncTransaction _transaction;
//
//     public CustomerEventHandlers(IAsyncTransaction transaction)
//     {
//         _transaction = transaction;
//     }
//
//     public void Handle(CustomerDefined eventToHandle)
//     {
//         var query = new StringBuilder()
//             .Append("CREATE(c:Customer{" +
//                     "Id:$id, " +
//                     "FirstName : $firstName, " +
//                     "LastName : $lastName, " +
//                     "Email : $email, " +
//                     "PhoneNumber : $phoneNumber, " +
//                     "BankAccountNumber : $bankAccountNumber, " +
//                     "Deleted : $deleted, " +
//                     "CreateDate : $createDate, " +
//                     "LastUpdate : $createDate " +
//                     "})").ToString();
//         _transaction.RunAsync(query, new
//         {
//             id = eventToHandle.Id.Id.ToString(),
//             firstName = eventToHandle.FirstName,
//             lastName = eventToHandle.LastName,
//             email = eventToHandle.Email,
//             phoneNumber = eventToHandle.PhoneNumber,
//             bankAccountNumber = eventToHandle.BankAccountNumber,
//             createDate = eventToHandle.PublishDateTime.ToString("yyyy-MM-ddThh:mm:ss"),
//             deleted = false
//         });
//     }
//
//     public void Handle(CustomerModified eventToHandle)
//     {
//         var query = new StringBuilder().Append(
//                 "MATCH (c:Customer) " +
//                 " WHERE c.Id = $id " +
//                 "SET c.FirstName : $firstName, " +
//                 "c.LastName : $lastName, " +
//                 "c.Email : $email, " +
//                 "c.PhoneNumber : $phoneNumber, " +
//                 "c.BankAccountNumber : $bankAccountNumber, " +
//                 "c.Deleted : $deleted, " +
//                 "LastUpdate : $createDate " +
//                 "}")
//             .ToString();
//         _transaction.RunAsync(query, new
//         {
//             id = eventToHandle.Id.Id.ToString(),
//             firstName = eventToHandle.FirstName,
//             lastName = eventToHandle.LastName,
//             email = eventToHandle.Email,
//             phoneNumber = eventToHandle.PhoneNumber,
//             bankAccountNumber = eventToHandle.BankAccountNumber,
//             deleted = false,
//             lastUpdate = eventToHandle.PublishDateTime.ToString("yyyy-MM-ddThh:mm:ss")
//         });
//     }
//
//     public void Handle(CustomerRemoved eventToHandle)
//     {
//         var query = new StringBuilder()
//             .Append("MATCH (c:Customer) " +
//                     "WHERE c.Id = $id " +
//                     "SET c.Deleted = $deleted, " +
//                     "c.LastUpdate = $lastUpdate ").ToString();
//         _transaction.RunAsync(query, new
//         {
//             id = eventToHandle.Id.Id.ToString(),
//             lastUpdate = eventToHandle.PublishDateTime.ToString("yyyy-MM-ddThh:mm:ss")
//         });
//     }
// }