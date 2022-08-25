using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Crafting_Code_Exercises.Exercise4
{
    [TestClass]
    public class PaymentServiceShould
    {
        [TestMethod]
        public void Throw_exception_when_user_does_not_exist()
        {
            var userValidator = new Mock<IUserValidator>();
            var paymentGateway = new Mock<IPaymentGateway>();

            userValidator.Setup(x => x.CheckUserExists(It.IsAny<User>())).Returns(false);

            var paymentService = new PaymentService(userValidator.Object, paymentGateway.Object);

            Assert.ThrowsException<ArgumentException>(() => paymentService.ProcessPayment(new User(), new PaymentDetails()));
        }

        [TestMethod]
        public void Not_throw_exception_when_any_user_does_exist()
        {
            var userValidator = new Mock<IUserValidator>();
            var paymentGateway = new Mock<IPaymentGateway>();

            userValidator.Setup(x => x.CheckUserExists(It.IsAny<User>())).Returns(true);

            var paymentService = new PaymentService(userValidator.Object, paymentGateway.Object);

            paymentService.ProcessPayment(new User(), new PaymentDetails());
        }

        [TestMethod]
        public void Send_payment_to_payment_gateway()
        {
            var userValidator = new Mock<IUserValidator>();
            var paymentGateway = new Mock<IPaymentGateway>();

            userValidator.Setup(x => x.CheckUserExists(It.IsAny<User>())).Returns(true);

            var paymentService = new PaymentService(userValidator.Object, paymentGateway.Object);

            paymentService.ProcessPayment(new User(), new PaymentDetails());

            paymentGateway.Verify(x => x.SendPayment(), Times.Once());
        }
    }
}
