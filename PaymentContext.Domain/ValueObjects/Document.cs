using System.Diagnostics.Contracts;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValuesObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public bool Invalid;

        public Document(string number, EDocumentType type)
        {

            Number = number;
            Type = type;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsTrue(Validate(), "Document.Number", "Documento invalido")
            );
        }

        public string Number { get; private set; }

       public EDocumentType Type { get; private set; }

       private bool Validate()
       {
        if(Type == EDocumentType.CNPJ && Number.Length == 14)
        return true;

        if(Type == EDocumentType.CPF && Number.Length == 11)
        return true;

        return false;
       }
    }
}