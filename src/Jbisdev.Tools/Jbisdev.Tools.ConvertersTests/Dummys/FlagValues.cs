using Jbisdev.Tools.Attributes;
using Jbisdev.Tools.ConvertersTests.Resources;

namespace Jbisdev.Tools.Converters.Tests.Dummys
{
    [Flags]
    public enum FlagValues
    {
        None,
        value1 = 1,

        [LocalizableDescription(@"Value2", typeof(ResTests))]
        value2 = 2,

        value3 = 4,

        [LocalizableDescription(@"Value4", typeof(ResTests))]
        value4 = 8,

        value5 = value1 | value2,
        all = None | value1 | value2 | value3 | value4 | value5
    }
}