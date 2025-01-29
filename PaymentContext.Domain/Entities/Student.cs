using System;

namespace PaymentContext.Domain.Entities
{
    public class Student
    {

        private IList<Subscription> _subscriptions;
        public Student(string? firtName, string? lastName, string? document, string? email)
        {
            FirtName = firtName;
            LastName = lastName;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            
        }

        public string? FirtName { get; private set; }
        public string? LastName { get; private set; }
        public string? Document { get; private set; }
        public string? Email { get; private set; }
        public string? Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }


        public void AddSubscription(Subscription subscription)
        {
            //Se ja tiver uma assinatura, cancela

            //Cancela todas as outras assinaturas, e coloca esta como principal
            foreach(var sub in Subscriptions){
                sub.Inactivate();


            _subscriptions.Add(subscription);
            }
        }
    }
}