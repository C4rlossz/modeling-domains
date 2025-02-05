using PaymentContext.Shared.Entities;
using Flunt.Validations;
using Flunt.Notifications;


namespace PaymentContext.Domain.Entities
{
    public class Subscription : Entity
    {
        

        private IList<Payment> _payments;
        public Subscription(DateTime? expireDate)
        {
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            ExpireDate = ExpireDate;
            Active = true;
            _payments = new List<Payment>();
        }

        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public bool Active { get; private set; }
        public IReadOnlyCollection<Payment> Payments { get { return _payments.ToArray(); } }

        public void AddPayment(Payment payment)
        {
            AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterThan(payment.PaidDate, DateTime.Now, "Subscription.Payments", "A data do pagamento deve ser no futuro")
            );
            _payments.Add(payment);
        }

        public void Activate()
        {
            Active = true;
            LastUpdateDate = DateTime.Now;
        }

        public void Inactivate()
        {
            Active = false;
            LastUpdateDate = DateTime.Now;
        }
    }
}