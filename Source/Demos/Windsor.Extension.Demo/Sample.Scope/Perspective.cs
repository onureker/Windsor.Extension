namespace Windsor.Extension.Demo.Sample.Scope
{
    public class Perspective
    {
        public static Perspective Debug = new Perspective("Debug");
        public static Perspective Release = new Perspective("Release");

        private readonly string name;

        private Perspective(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}