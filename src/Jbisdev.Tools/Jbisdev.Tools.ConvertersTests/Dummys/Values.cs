using Jbisdev.Tools.Attributes;
using Jbisdev.Tools.ConvertersTests.Resources;

namespace Jbisdev.Tools.Converters.Tests.Dummys
{
    public enum Values
    {
        [LocalizableDescription(@"Value1", typeof(ResTests))]
        value1,

        value2,
        value3,
        value4,
        value5
    }
}