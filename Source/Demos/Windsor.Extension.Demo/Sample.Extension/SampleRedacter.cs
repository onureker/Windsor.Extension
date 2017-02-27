namespace Windsor.Extension.Demo.Sample.Extension
{
    public class SampleRedacter: IRedacter<SampleModel>
    {
        public string Redact(SampleModel model)
        {
            return model.Name;
        }
    }
}