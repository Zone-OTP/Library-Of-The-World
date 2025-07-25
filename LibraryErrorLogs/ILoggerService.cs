using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryErrorLogs
{
    public interface ILoggerService
    {
        Task LogError(Exception ex, string message, params object[] args);
        Task LogInformation(string message, params object[] args);
    }
}
