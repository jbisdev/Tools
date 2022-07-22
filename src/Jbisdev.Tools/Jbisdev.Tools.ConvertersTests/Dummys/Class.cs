namespace Jbisdev.Tools.ConvertersTests.Dummys
{
    public class Class
    {
        public string Property { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Class other
                && other.Property == Property;
        }
    }
}