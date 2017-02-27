using Castle.Windsor;

namespace Windsor.Extension.Demo.Sample.Extension
{
    public class GenericRedacter
    {
        private readonly IWindsorContainer container;

        public GenericRedacter(IWindsorContainer container)
        {
            this.container = container;
        }

        public string Redact<TModel>(TModel model)
        {
            var redacter = container.Resolve<IRedacter<TModel>>();
            var result = redacter.Redact(model);
            return result;
        }

    }
}
