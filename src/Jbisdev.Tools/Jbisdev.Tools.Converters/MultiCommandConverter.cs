using Jbisdev.Tools.Helpers.Commands;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

namespace Jbisdev.Tools.Converters
{
    public class MultiCommandConverter : IMultiValueConverter
    {
        private readonly List<object> _value = new();

        /// <summary>
        /// dobbin of the converter
        /// </summary>
        /// <param name="value">commands binded by means of multi-binding</param>
        /// <returns>compound Relay command</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values is null)
                return null;
            _value?.Clear();
            _value?.AddRange(values.Where(v => v is ICommand));
            return new RelayCommand(GetCompoundExecute(), GetCompoundCanExecute());
        }

        /// <summary>
        /// here - mandatory duty
        /// </summary>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }

        private Action<object> GetCompoundExecute()
        {
            return async (parameter) =>
            {
                foreach (ICommand command in _value)
                {
                    if (command is AsyncCommand async)
                    {
                        await async.ExecuteAsync();
                        continue;
                    }
                    if (command != default(RelayCommand))
                        command.Execute(parameter);
                }
            };
        }

        private Predicate<object> GetCompoundCanExecute()
        {
            return (parameter) =>
            {
                bool res = true;
                foreach (ICommand command in _value)
                    if (command != default(RelayCommand))
                        res &= command.CanExecute(parameter);
                return res;
            };
        }
    }
}