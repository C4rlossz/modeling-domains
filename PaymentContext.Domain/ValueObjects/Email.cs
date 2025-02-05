using System.Diagnostics.Contracts;
using PaymentContext.Shared.ValuesObjects;
using Flunt.Notifications;
using Flunt.Validations;


namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {

        public Email(string address)
        {

            Address = address;


            AddNotifications(new Contract<Notification>()
            .Requires()
            .IsEmail(Address, "Email.Address", "E-mail invalido")
            );


        }

        public string Address { get; private set; }
    }
}