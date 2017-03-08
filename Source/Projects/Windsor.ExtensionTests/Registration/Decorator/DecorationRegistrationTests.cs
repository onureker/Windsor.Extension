using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Windsor.ExtensionTests.Registration.Decorator
{
    [TestClass]
    public class DecorationRegistrationTests
    {
        IWindsorContainer container = new WindsorContainer();

        [TestInitialize]
        public void Initialize()
        {
            container = new WindsorContainer();
            container.Register(Component.For<ExecutionRegistry>());
        }


        [TestMethod]
        public void Single_Component_Registration_For_NonGenericClass_With_One_Decoragtor_Should_Be_Successful()
        {
            container.Register(
                Component
                    .For<ICalculator>()
                    .ImplementedBy<DefaultCalculator>()
                    .Decorated().By<LogDecorator>()
            );

            var calculator = container.Resolve<ICalculator>();
            Guid executionId = Guid.NewGuid();
            calculator.Sum(executionId, 1, 2);

            var executionRegistry = container.Resolve<ExecutionRegistry>();
            Assert.AreEqual(executionRegistry.Pop(executionId).GetType(), typeof(LogDecorator));
            Assert.AreEqual(executionRegistry.Pop(executionId).GetType(), typeof(DefaultCalculator));
        }

        [TestMethod]
        public void Single_Component_Registration_For_NonGenericClass_With_Multiple_Decoragtor_Should_Be_Successful()
        {
            container.Register(
                Component
                    .For<ICalculator>()
                    .ImplementedBy<DefaultCalculator>()
                    .Decorated().By<LogDecorator>()
                    .Decorated().By<ExceptionDecorator>()
            );

            var calculator = container.Resolve<ICalculator>();
            Guid executionId = Guid.NewGuid();
            calculator.Sum(executionId, 1, 2);

            var executionRegistry = container.Resolve<ExecutionRegistry>();
            Assert.AreEqual(executionRegistry.Pop(executionId).GetType(), typeof(ExceptionDecorator));
            Assert.AreEqual(executionRegistry.Pop(executionId).GetType(), typeof(LogDecorator));
            Assert.AreEqual(executionRegistry.Pop(executionId).GetType(), typeof(DefaultCalculator));
        }

        [TestMethod]
        public void Multi_Component_Registration_For_NonGenericClass_With_Single_Decoragtor_Should_Be_Successful()
        {
            container.Register(
                Classes
                    .FromThisAssembly()
                    .BasedOn<ICalculator>()
                    .Unless(type => type.Name.StartsWith("Default"))
                    .WithService
                    .FromInterface()
                    .Decorated().By<ExceptionDecorator>()
            );

            var calculator = container.Resolve<ICalculator>();
            Guid executionId = Guid.NewGuid();
            calculator.Sum(executionId, 1, 2);

            var executionRegistry = container.Resolve<ExecutionRegistry>();
            Assert.AreEqual(executionRegistry.Pop(executionId).GetType(), typeof(ExceptionDecorator));
            Assert.AreEqual(executionRegistry.Pop(executionId).GetType(), typeof(LogDecorator));
            Assert.AreEqual(executionRegistry.Pop(executionId).GetType(), typeof(DefaultCalculator));
        }
    }
}