namespace MS.Sc.Infrastructure.Logging
{
    /// <summary>
    /// LoggingService Interface
    /// </summary>
    public interface ILoggingService
    {
        #region Methods

        void Debug(string message);

        void Debug(string type, string method, string message);

        void Debug(string message, System.Exception e);

        void Debug(string type, string method, string message, System.Exception e);

        void DebugFormat(string format, params object[] args);

        void DebugFormat(string type, string method, string format, params object[] args);

        void DebugFormat(string format, System.Exception e, params object[] args);

        void DebugFormat(string type, string method, string format, System.Exception e, params object[] args);

        void Error(string message);

        void Error(string type, string method, string message);

        void Error(string message, System.Exception e);

        void Error(string type, string method, string message, System.Exception e);

        void ErrorFormat(string format, params object[] args);

        void ErrorFormat(string type, string method, string format, params object[] args);

        void ErrorFormat(string format, System.Exception e, params object[] args);

        void ErrorFormat(string type, string method, string format, System.Exception e, params object[] args);

        void Fatal(string message);

        void Fatal(string type, string method, string message);

        void Fatal(string message, System.Exception e);

        void Fatal(string type, string method, string message, System.Exception e);

        void FatalFormat(string format, params object[] args);

        void FatalFormat(string type, string method, string format, params object[] args);

        void FatalFormat(string format, System.Exception e, params object[] args);

        void FatalFormat(string type, string method, string format, System.Exception e, params object[] args);

        void Info(string message);

        void Info(string type, string method, string message);

        void InfoFormat(string format, params object[] args);

        void InfoFormat(string type, string method, string format, params object[] args);

        void Warn(string message);

        void Warn(string type, string method, string message);

        void Warn(string message, System.Exception e);

        void Warn(string type, string method, string message, System.Exception e);

        void WarnFormat(string format, params object[] args);

        void WarnFormat(string type, string method, string format, params object[] args);

        void WarnFormat(string format, System.Exception e, params object[] args);

        void WarnFormat(string type, string method, string format, System.Exception e, params object[] args);

        #endregion Methods
    }
}