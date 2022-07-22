using System;

namespace Jbisdev.Tools.Helpers.Commands
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}