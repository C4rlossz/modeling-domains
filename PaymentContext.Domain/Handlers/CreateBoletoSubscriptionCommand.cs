using PaymentContext.Shared.Commands;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Domain.Enums;

namespace PaymentContext.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand : ICommand
    {
        public string PayerEmail;

        // Propriedades
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string BarCode { get; set; }
        public string BoletoNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string Payer { get; set; }
        public string PayerDocument { get; set; }
        public EDocumentType PayerDocumentType { get; set; }
        public bool Valid { get; set; }
        public string PaymentNumber { get; set; }

        public void Validate()
        {

        }

        internal bool IsInvalid()
        {
            throw new NotImplementedException();
        }
    }
}
