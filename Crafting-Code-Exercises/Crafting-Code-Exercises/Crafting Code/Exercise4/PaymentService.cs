using Moq;

namespace Crafting_Code_Exercises.Exercise4
{
    public class PaymentService
    {
        private IUserValidator userValidator;
        private IPaymentGateway paymentGateway;

        public PaymentService(IUserValidator userValidator, IPaymentGateway paymentGateway)
        {
            this.userValidator = userValidator;
            this.paymentGateway = paymentGateway;
        }

        public void ProcessPayment(User user, PaymentDetails paymentDetails)
        {
            if (!userValidator.CheckUserExists(user))
            {
                throw new ArgumentException();
            }

            paymentGateway.SendPayment();
        }
    }
}