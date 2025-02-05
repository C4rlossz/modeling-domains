using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;
using Document = PaymentContext.Domain.ValueObjects.Document;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment : Entity
    {
        private System.Reflection.Metadata.Document document;

        protected Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string? payer, Document document, Address address, Email email)
        {
            Number = Guid.NewGuid().ToString().Replace("-","").Substring(0, 10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Payer = payer;
            Document = document;
            Address = address;
            Email = email;
        }

        protected Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, System.Reflection.Metadata.Document document, Address address, Email email)
        {
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Payer = payer;
            this.document = document;
            Address = address;
            Email = email;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsGreaterThan(0, Total, "Payment.Total", "O total nao pode ser zero")
                .IsGreaterOrEqualsThan(Total, TotalPaid, "Payment.TotalPaid", "O valor pago e menor que o valor do pagamento")
            );
        }

        public string? Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public string? Payer { get; private set; }
        public Document Document { get; private set; }
        public Address Address { get; private set; }
        public Email Email { get; private set; }
    }
}