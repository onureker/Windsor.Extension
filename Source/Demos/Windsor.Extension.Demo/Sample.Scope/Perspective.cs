namespace Windsor.Extension.Demo.Sample.Scope
{
    public class Perspective
    {
        public static Perspective Debug = new Perspective();
        public static Perspective Release = new Perspective();
    }
}