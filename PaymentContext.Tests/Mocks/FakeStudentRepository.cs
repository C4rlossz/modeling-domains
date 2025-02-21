using System.Reflection.Metadata;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Tests.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void CreateSubscription(Student student)
        {
            throw new NotImplementedException();
        }

        public bool DocumentExists(string document)
        {
            if(document == "12312312312")
            return true;
            
            return false;
        }

        public bool EmailExists(string email)
        {
            if(email == "BarryAllen@gmail.com")
            return true;
            
            return false;
        }
    }
}