using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jbisdev.Tools.Attributes.Tests
{
    [TestClass()]
    public class LocalizableDescriptionExtentionsTests
    {
        [TestMethod("GetDescription should return PropertyName if description not exists")]
        public void GetDescriptionShouldReturnPropertyNameIfDescriptionNotExists()
        {
            //Arrange
            var value = DummyEnums.WithoutDescription;
            var expected = DummyEnums.WithoutDescription.ToString();
            //Act
            var result = value.GetDescription();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod("GetDescription should return resource if description not exists")]
        public void GetDescriptionShouldReturnPropertyNameIfResourceNotExists()
        {
            //Arrange
            var value = DummyEnums.None;
            var expected = DummyEnums.None.ToString();
            //Act
            var result = value.GetDescription();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod("GetDescription should return resource if exists")]
        public void GetDescriptionShouldReturnResourceIfExists()
        {
            //Arrange
            var value = DummyEnums.TestValue;
            var expected = AttributesTests.Resources.Tests.TestValue;
            //Act
            var result = value.GetDescription();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod("GetDescription should throw exception if resource type not exists")]
        [ExpectedException(typeof(MissingMethodException))]
        public void GetDescriptionShouldReturnNullIfResourceTypeNotExists()
        {
            //Arrange
            var value = DummyEnums.FakeResource;
            //Act
            value.GetDescription();
            // Assert - Expects exception
            Assert.Fail();
        }
    }

    internal enum DummyEnums
    {
        [LocalizableDescription(@"Not in resource file !", typeof(AttributesTests.Resources.Tests))]
        None,

        WithoutDescription,

        [LocalizableDescription(@"TestValue", typeof(AttributesTests.Resources.Tests))]
        TestValue,

        [LocalizableDescription(@"Not in resource file !", typeof(FakeResource))]
        FakeResource,
    }

    internal class FakeResource
    { }
}