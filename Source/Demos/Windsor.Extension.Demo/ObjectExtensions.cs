namespace Windsor.Extension.Demo
{
    public static class ObjectExtensions
    {
        public static dynamic ToDynamic(this object extended)
        {
            dynamic result = extended;
            return result;
        }
    }
}
