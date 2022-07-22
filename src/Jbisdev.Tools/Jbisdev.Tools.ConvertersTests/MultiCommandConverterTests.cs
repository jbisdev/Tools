using Jbisdev.Tools.Helpers.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jbisdev.Tools.Converters.Tests
{
    [TestClass()]
    public class MultiCommandConverterTests
    {
        private int _nbExecutions;

        [TestInitialize]
        public void TestInitialize()
        {
            _nbExecutions = 0;
        }

        [TestMethod("Convert : When there are 2 relay commands in values," +
            " should add 2 commands and execute 2 when execute")]
        public void ConvertTwoRelayCommands()
        {
            var expected = 2;
            var command1 = new RelayCommand(param => Execute());
            var command2 = new RelayCommand(param => Execute());
            var values = new object[] { command1, command2 };
            var converter = new MultiCommandConverter();

            var result = ((RelayCommand)converter.Convert(values, null, null, null));
            result.Execute(null);

            Assert.AreEqual(expected, _nbExecutions);
        }

        [TestMethod("Convert : When there are 1 relay command and one random object in values," +
            " should add the relaycommand and execute this one when execute")]
        public void ConvertOneRelayCommandAndOneRandomObject()
        {
            var expected = 1;
            var command1 = new RelayCommand(param => Execute());
            var command2 = new object();
            var values = new object[] { command1, command2 };
            var converter = new MultiCommandConverter();

            var result = ((RelayCommand)converter.Convert(values, null, null, null));
            result.Execute(null);

            Assert.AreEqual(expected, _nbExecutions);
        }

        [TestMethod("Convert : When there are 1 relay command and one random null relaycommand in values," +
            " should add the relaycommand not null and execute this one when execute")]
        public void ConvertOneRelayCommandAndOneNullRelayCommand()
        {
            var expected = 1;
            var command1 = new RelayCommand(param => Execute());
            RelayCommand command2 = null;
            var values = new object[] { command1, command2 };
            var converter = new MultiCommandConverter();

            var result = ((RelayCommand)converter.Convert(values, null, null, null));
            result.Execute(null);

            Assert.AreEqual(expected, _nbExecutions);
        }

        [TestMethod("Convert : When there are 1 relay command and one async command in values," +
            " should add 2 commands and execute 2 when execute")]
        public void ConvertTest()
        {
            var expected = 2;
            var command1 = new RelayCommand(param => Execute());
            var command2 = new AsyncCommand(ExecuteTask);
            var values = new object[] { command1, command2 };
            var converter = new MultiCommandConverter();

            var result = ((RelayCommand)converter.Convert(values, null, null, null));
            result.Execute(null);

            Assert.AreEqual(expected, _nbExecutions);
        }

        internal void Execute()
        {
            _nbExecutions++;
        }

        internal async Task ExecuteTask()
        {
            await Task.Run(() => _nbExecutions++);
        }

        [TestMethod("Convert : When values is null, should return null")]
        public void ConvertValuesNull()
        {
            var converter = new MultiCommandConverter();

            var result = converter.Convert(null, null, null, null);

            Assert.IsNull(result);
        }

        [TestMethod("ConvertBack : When ConvertBack, should return null")]
        public void ConvertBack()
        {
            var converter = new MultiCommandConverter();

            var result = converter.ConvertBack(null, null, null, null);

            Assert.IsNull(result);
        }
    }
}