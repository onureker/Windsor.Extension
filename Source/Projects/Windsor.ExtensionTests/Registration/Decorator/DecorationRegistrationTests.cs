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
        private ExecutionStack executionStack;

        [TestInitialize]
        public void Initialize()
        {
            container = new WindsorContainer();
            container.Register(Component.For<ExecutionStack>());
            executionStack = container.Resolve<ExecutionStack>();
        }


        [TestMethod]
        public void Single_Component_Registration_For_NonGenericClass_With_One_Decorator_Should_Be_Successful()
        {
            container.Register(
                Component
                    .For<ICalculator>()
                    .ImplementedBy<Calculator1>()
                    .Decorated().By<LogDecorator>()
            );

            TestCalculator<Calculator1>(typeof(LogDecorator));
        }

        [TestMethod]
        public void Single_Component_Registration_For_NonGenericClass_With_Multiple_Decorator_Should_Be_Successful()
        {
            container.Register(
                Component
                    .For<ICalculator>()
                    .ImplementedBy<Calculator1>()
                    .Decorated().By<LogDecorator>()
                    .Decorated().By<ExceptionDecorator>()
            );

            TestCalculator<Calculator1>(typeof(ExceptionDecorator), typeof(LogDecorator));
        }

        [TestMethod]
        public void Multi_Component_Registration_For_NonGenericClass_With_Single_Decorator_Should_Be_Successful()
        {
            container.Register(
                Classes
                    .FromThisAssembly()
                    .BasedOn<ICalculator>()
                    .WithService
                    .FromInterface()
                    .Decorated().By<ExceptionDecorator>()
            );

            TestCalculator<Calculator1>(typeof(ExceptionDecorator));
            TestCalculator<Calculator2>(typeof(ExceptionDecorator));
        }

        [TestMethod]
        public void Multi_Component_Registration_For_NonGenericClass_With_Multiple_Decorator_Should_Be_Successful()
        {
            container.Register(
                Classes
                    .FromThisAssembly()
                    .BasedOn<ICalculator>()
                    .WithService
                    .FromInterface()
                    .Decorated().By<ExceptionDecorator>()
                    .Decorated().By<LogDecorator>()
            );

            TestCalculator<Calculator1>(typeof(LogDecorator), typeof(ExceptionDecorator));
            TestCalculator<Calculator2>(typeof(LogDecorator), typeof(ExceptionDecorator));
        }

        private void TestCalculator<TCalculator>(params Type[] decoratorTypes)
            where TCalculator: ICalculator
        {
            var calculator = container.Resolve<ICalculator>(typeof(TCalculator).FullName);
            Guid executionId = Guid.NewGuid();
            calculator.Sum(executionId, 1, 2);

            foreach (var decoratorType in decoratorTypes)
            {
                var instance = executionStack.PopInstance(executionId);
                Assert.AreEqual(instance.GetType(), decoratorType);
            }

            Assert.AreEqual(executionStack.PopInstance(executionId).GetType(), typeof(TCalculator));
        }
    }
}