using System.Diagnostics.Contracts;
using PaymentContext.Shared.ValuesObjects;
using Flunt.Notifications;


namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {

        public Email(string address)
        {
            Address = address;

            AddNotification(new Contract()
                .Requires()
                .IsEmail(Address, "Email.Address", "E-mail invalido")
            );
        }

        public string Address { get; private set; }
    }
}