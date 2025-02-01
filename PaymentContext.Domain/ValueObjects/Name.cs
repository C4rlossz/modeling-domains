using System.Diagnostics.Contracts;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValuesObjects;


namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FristName", "Nome deve conter pelo menos 3 caracteres")
                .HasMinLen(lastName, 3, "Name.lastName", "Sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 30, "Name.FristName", "Nome deve conter ate 40 caracteres")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}