namespace Windsor.Extension.Demo.Sample.Extension
{
    public interface IRedacter<in TModel>
    {
        string Redact(TModel model);
    }
}
