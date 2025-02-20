using System.Reflection.Metadata;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;

namespace PaymentContext.Tests.Mocks
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string email, string subject, string body)
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            

         command.FirstName ="Barry";
         command.LastName ="Allen";
         command.Document ="99999999999";
         command.Email ="hello2@gmail.com";
         command.BarCode ="123456789";
         command.PaymentNumber ="1233456789";
         command.PaidDate = DateTime.Now;
         command.ExpireDate = DateTime.Now.AddMonths(1);
         command.Total =60;
         command.TotalPaid =60;
         command.Payer ="Laboratórios S.T.A.R.";
         command.PayerDocument ="12345678911";
         command.PayerDocumentType = EDocumentType.CPF;
         command.PayerEmail ="Barry@gmail.com";
         command.Street ="New York";
         command.Number ="123";
         command.Neighborhood ="Cisco";
         command.City ="Brooklyn";
         command.State ="NY";
         command.Country ="NY";
         command.ZipCode ="1234567";

         handler.Handle(command);
         Assert.AreEqual(false, handler.Valid);
        }
    }
}