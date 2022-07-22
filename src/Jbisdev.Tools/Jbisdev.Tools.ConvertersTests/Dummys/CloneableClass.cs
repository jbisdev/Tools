namespace Jbisdev.Tools.ConvertersTests.Dummys
{
    public class CloneableClass : ICloneable
    {
        public string Property { get; set; }

        public object Clone()
        {
            var clone = MemberwiseClone() as CloneableClass;
            clone.Property = "isClone";
            return clone;
        }

        public override bool Equals(object obj)
        {
            return obj is CloneableClass other
                && other.Property == Property;
        }
    }
}