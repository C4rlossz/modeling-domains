using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;


namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler
    {
        private readonly IStudentRepository _repository;
        private readonly IEmailService _emailService;

        public SubscriptionHandler()
        {
        }

        public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public bool Invalid { get; private set; }
        public bool Valid { get; set; }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            command.Validate();
            if (command.IsInvalid())
            {
                AddNotifications(command);
                return new commandResult(false, "Não é possível realizar sua assinatura");
            }

            // Gerar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            // Gerar as Entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(command.BarCode, command.BoletoNumber, command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid, command.Payer, new Document(command.PayerDocument, command.PayerDocumentType), address, email);

            // Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            // Validar as Notificacoes
            if(Invalid)
                return new commandResult(false, "nao foi possivel realizar");

            // Salvar informações
            _repository.CreateSubscription(student);

            // Enviar E-mail de boas-vindas
            _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem-vindo!", "Sua assinatura foi criada");

            return new commandResult(true, "Assinatura realizada com sucesso");
        }

        private void AddNotifications(CreateBoletoSubscriptionCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
