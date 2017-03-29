namespace Windsor.Extension.Demo.Sample.Scope
{
    public class Environmentt
    {
        public static Environmentt Test = new Environmentt("Test");

        private readonly string name;

        private Environmentt(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}