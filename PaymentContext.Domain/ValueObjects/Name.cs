using System.Diagnostics.Contracts;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValuesObjects;


namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        private string v1;
        private string v2;

        public Name(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public Name(string firstName, string lastName, Notifiable<Notification> item)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(item);
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}