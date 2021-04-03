using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Windsor.Extension.Tests.Registration.Decorator.Components;
using Windsor.Extension.Tests.Registration.Decorator.Components.NonGeneric;
using Windsor.Extension.Tests.Registration.Decorator.Components.SingleGeneric;
using Xunit;

namespace Windsor.Extension.Tests.Registration.Decorator
{
    public class DecorationRegistrationTests
    {
        private readonly IWindsorContainer container = new WindsorContainer();
        private readonly ExecutionStack executionStack;

        public DecorationRegistrationTests()
        {
            container = new WindsorContainer();
            container.Register(Component.For<ExecutionStack>());
            executionStack = container.Resolve<ExecutionStack>();
        }

        [Fact]
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

        [Fact]
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

        [Fact]
        public void Multi_Component_Registration_For_NonGenericClass_With_Single_Decorator_Should_Be_Successful()
        {
            container.Register(
                Classes
                    .FromAssemblyContaining<DecorationRegistrationTests>()
                    .BasedOn<ICalculator>()
                    .WithService
                    .FromInterface()
                    .Decorated().By<ExceptionDecorator>()
            );

            TestCalculator<Calculator1>(typeof(ExceptionDecorator));
            TestCalculator<Calculator2>(typeof(ExceptionDecorator));
        }

        [Fact]
        public void Multi_Component_Registration_For_NonGenericClass_With_Multiple_Decorator_Should_Be_Successful()
        {
            container.Register(
                Classes
                    .FromAssemblyContaining<DecorationRegistrationTests>()
                    .BasedOn<ICalculator>()
                    .WithService
                    .FromInterface()
                    .Decorated().By<ExceptionDecorator>()
                    .Decorated().By<LogDecorator>()
            );

            TestCalculator<Calculator1>(typeof(ExceptionDecorator), typeof(LogDecorator));
            TestCalculator<Calculator2>(typeof(ExceptionDecorator), typeof(LogDecorator));
        }

        [Fact]
        public void Single_Component_Registration_For_GenericClass_With_One_Decorator_Should_Be_Successful()
        {
            container.Register(
                Component
                    .For<IGenericCalculator<int>>()
                    .ImplementedBy<GenericCalculator2>()
                    .Decorated().By<GenericLogDecorator<int>>()
            );

            TestSingleGenericCalculator<GenericCalculator2, int>(1, 3, typeof(GenericLogDecorator<int>));
        }

        [Fact]
        public void Single_Component_Registration_For_GenericClass_With_Multiple_Decorator_Should_Be_Successful()
        {
            container.Register(
                Component
                    .For<IGenericCalculator<long>>()
                    .ImplementedBy<GenericCalculator1>()
                    .Decorated().By<GenericLogDecorator<long>>()
                    .Decorated().By<GenericExceptionDecorator<long>>()
            );

            TestSingleGenericCalculator<GenericCalculator1, long>(1L, 3L, typeof(GenericExceptionDecorator<long>), typeof(GenericLogDecorator<long>));
        }

        [Fact]
        public void Multi_Component_Registration_For_GenericClass_With_Single_Decorator_Should_Be_Successful()
        {
            container.Register(
                Classes
                    .FromAssemblyContaining<DecorationRegistrationTests>()
                    .BasedOn<IGenericCalculator<long>>()
                    .WithService
                    .FromInterface()
                    .Decorated().By<GenericExceptionDecorator<long>>()
            );

            TestSingleGenericCalculator<GenericCalculator1, long>(1L, 3L, typeof(GenericExceptionDecorator<long>));
            TestSingleGenericCalculator<GenericCalculator3, long>(1L, 3L, typeof(GenericExceptionDecorator<long>));
        }

        [Fact]
        public void Multi_Component_Registration_For_GenericClass_With_Multiple_Decorator_Should_Be_Successful()
        {
            container.Register(
                Classes
                    .FromAssemblyContaining<DecorationRegistrationTests>()
                    .BasedOn<IGenericCalculator<long>>()
                    .WithService
                    .FromInterface()
                    .Decorated().By<GenericExceptionDecorator<long>>()
                    .Decorated().By<GenericLogDecorator<long>>()
            );

            TestSingleGenericCalculator<GenericCalculator1, long>(1L, 3L, typeof(GenericExceptionDecorator<long>), typeof(GenericLogDecorator<long>));
            TestSingleGenericCalculator<GenericCalculator3, long>(1L, 3L, typeof(GenericExceptionDecorator<long>), typeof(GenericLogDecorator<long>));
        }

        private void TestCalculator<TCalculator>(params Type[] decoratorTypes)
            where TCalculator : ICalculator
        {
            var calculator = container.Resolve<ICalculator>(typeof(TCalculator).FullName);
            Guid executionId = Guid.NewGuid();
            calculator.Sum(executionId, 1, 2);

            foreach (var decoratorType in decoratorTypes)
            {
                var instance = executionStack.PopInstance(executionId);
                Assert.Equal(instance.GetType(), decoratorType);
            }

            Assert.Equal(typeof(TCalculator), executionStack.PopInstance(executionId).GetType());
        }

        private void TestSingleGenericCalculator<TGenericCalculator, TArg>(TArg first, TArg second, params Type[] decoratorTypes)
        {
            var calculator = container.Resolve<IGenericCalculator<TArg>>(typeof(TGenericCalculator).FullName);
            Guid executionId = Guid.NewGuid();
            calculator.Sum(executionId, first, second);

            foreach (var decoratorType in decoratorTypes)
            {
                var instance = executionStack.PopInstance(executionId);
                Assert.Equal(instance.GetType(), decoratorType);
            }

            Assert.Equal(typeof(TGenericCalculator), executionStack.PopInstance(executionId).GetType());
        }
    }
}