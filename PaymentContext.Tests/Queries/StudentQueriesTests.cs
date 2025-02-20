using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentQueriesTests
    {

        // Red, Green, REFACTOR

        private IList<Student> _students;


        public StudentQueriesTests()
        {
            for(var i=0;i<=10;i++)
            {
                _students.Add(new Student(new Name("Aluno", i.ToString()), new Document("12345678901" + i.ToString(), EDocumentType.CPF), new Email(i.ToString() + "Barry@gmail.com")));
            }
        }


        [TestMethod]
        public void ShouldReturnErrorWhenDocumentNotExists()
        {
            var exp = StudentQueries.GetStudentInfo("12345678911");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();


            Assert.AreNotEqual(null, studn);
        }


        [TestMethod]
        public void ShouldReturnStudentWhenDocumentExists()
        {
            var exp = StudentQueries.GetStudentInfo("12345678911");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();


            Assert.AreNotEqual(null, studn);
        }
    }
}