using System;
using Castle.MicroKernel;

namespace Windsor.Extension.Registration.Decorator
{
    public class DecorationRegistration<TSignature>: DecorationRegistration<TSignature, object>
    {
        public DecorationRegistration(TSignature signature, DecoratorApplier decoratorApplier) 
            : base(signature, decoratorApplier)
        {
        }
    }

    public class DecorationRegistration<TSignature, TService>
        where TService : class
    {
        private readonly TSignature signature;
        private readonly DecoratorApplier decoratorApplier;

        public DecorationRegistration(TSignature signature, DecoratorApplier decoratorApplier)
        {
            this.signature = signature;
            this.decoratorApplier = decoratorApplier;
        }

        public TSignature By<TDecorator>()
            where TDecorator: TService
        {
            decoratorApplier.Add(typeof(TDecorator));
            return signature;
        }

        public TSignature By(Type decoratorType)
        {
            decoratorApplier.Add(decoratorType);
            return signature;
        }

        public TSignature By(Func<IKernel, dynamic, dynamic> decoratorFunction)
        {
            decoratorApplier.Add(decoratorFunction);
            return signature;
        }
    }

}