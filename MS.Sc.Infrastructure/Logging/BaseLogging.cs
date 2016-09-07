namespace MS.Sc.Infrastructure.Logging
{
    using log4net;

    using System;
    using System.Globalization;

    /// <summary>
    /// BaseLogging Clas
    /// </summary>
    /// <seealso cref="MS.Sc.Infrastructure.Logging.ILoggingService" />
    public abstract class BaseLogging : ILoggingService
    {
        #region Fields

        private ILog _log;

        #endregion Fields

        #region Properties

        public ILog Log
        {
            get { return _log; }
            set { _log = value; }
        }

        #endregion Properties

        #region Methods

        #region Helpers

        public string FormatMessage(string type, string method, string message)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}.{1}(..): {2}", type, method, message);
        }

        #endregion

        #region Debug

        /// <summary>
        ///     Debugs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Debug(string message)
        {
            CheckLogger();
            _log.Debug(message);
        }

        /// <summary>
        ///     Debugs the specified message.
        /// </summary>
        /// <param name="type">The type name.</param>
        /// <param name="method">The method name.</param>
        /// <param name="message">The message.</param>
        public void Debug(string type, string method, string message)
        {
            message = FormatMessage(type, method, message);
            Debug(message);
        }

        /// <summary>
        ///     Debugs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="e">The e.</param>
        public void Debug(string message, Exception e)
        {
            CheckLogger();
            _log.Debug(message, e);
        }

        /// <summary>
        ///     Debugs the specified message.
        /// </summary>
        /// <param name="type">The type name.</param>
        /// <param name="method">The method name.</param>
        /// <param name="message">The message.</param>
        /// <param name="e">The e.</param>
        public void Debug(string type, string method, string message, Exception e)
        {
            message = FormatMessage(type, method, message);
            Debug(message, e);
        }

        /// <summary>
        ///     Debugs the format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void DebugFormat(string format, params object[] args)
        {
            var message = string.Format(CultureInfo.InvariantCulture, format, args);
            Debug(message);
        }

        /// <summary>
        ///     Debugs the format.
        /// </summary>
        /// <param name="type">The type name.</param>
        /// <param name="method">The method name.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void DebugFormat(string type, string method, string format, params object[] args)
        {
            var message = string.Format(CultureInfo.InvariantCulture, format, args);
            Debug(type, method, message);
        }

        /// <summary>
        ///     Debugs the format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="e">The e.</param>
        /// <param name="args">The arguments.</param>
        public void DebugFormat(string format, Exception e, params object[] args)
        {
            var message = string.Format(CultureInfo.InvariantCulture, format, args);
            Debug(message, e);
        }

        /// <summary>
        ///     Debugs the format.
        /// </summary>
        /// <param name="type">The type name.</param>
        /// <param name="method">The method name.</param>
        /// <param name="format">The format.</param>
        /// <param name="e">The e.</param>
        /// <param name="args">The arguments.</param>
        public void DebugFormat(string type, string method, string format, Exception e, params object[] args)
        {
            var message = string.Format(CultureInfo.InvariantCulture, format, args);
            Debug(type, method, message, e);
        }

        #endregion

        #region Error

        /// <summary>
        ///     Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Error(string message)
        {
            CheckLogger();
            _log.Error(message);
        }

        /// <summary>
        ///     Errors the specified message.
        /// </summary>
        /// <param name="type">The type name.</param>
        /// <param name="method">The method name.</param>
        /// <param name="message">The message.</param>
        public void Error(string type, string method, string message)
        {
            message = FormatMessage(type, method, message);
            Error(message);
        }

        /// <summary>
        ///     Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="e">The e.</param>
        public void Error(string message, Exception e)
        {
            CheckLogger();
            _log.Error(message, e);
        }

        /// <summary>
        ///     Errors the specified message.
        /// </summary>
        /// <param name="type">The type name.</param>
        /// <param name="method">The method name.</param>
        /// <param name="message">The message.</param>
        /// <param name="e">The e.</param>
        public void Error(string type, string method, string message, Exception e)
        {
            message = FormatMessage(type, method, message);
            Error(message, e);
        }

        /// <summary>
        ///     Errors the format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void ErrorFormat(string format, params object[] args)
        {
            var message = string.Format(CultureInfo.InvariantCulture, format, args);
            Error(message);
        }

        /// <summary>
        ///     Errors the format.
        /// </summary>
        /// <param name="type">The type name.</param>
        /// <param name="method">The method name.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void ErrorFormat(string type, string method, string format, params object[] args)
        {
            var message = string.Format(CultureInfo.InvariantCulture, format, args);
            Error(type, method, message);
        }

        /// <summary>
        ///     Errors the format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="e">The e.</param>
        /// <param name="args">The arguments.</param>
        public void ErrorFormat(string format, Exception e, params object[] args)
        {
            var message = string.Format(CultureInfo.InvariantCulture, format, args);
            Error(message, e);
        }

        /// <summary>
        ///     Errors the format.
        /// </summary>
        /// <param name="type">The type name.</param>
        /// <param name="method">The method name.</param>
        /// <param name="format">The format.</param>
        /// <param name="e">The e.</param>
        /// <param name="args">The arguments.</param>
        public void ErrorFormat(string type, string method, string format, Exception e, params object[] args)
        {
            var message = string.Format(CultureInfo.InvariantCulture, format, args);
            Error(type, method, message, e);
        }

        #endregion

        #region Fatal

        /// <summary>
        ///     Fatals the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Fatal(string message)
        {
            CheckLogger();
            _log.Fatal(message);
        }

        /// <summary>
        ///     Fatals the specified message.
        /// </summary>
        /// <param name="type">The type name.</param>
        /// <param name="method">The method name.</param>
        /// <param name="message">The message.</param>
        public void Fatal(string type, string method, string message)
        {
            message = FormatMessage(type, method, message);
            Fatal(message);
        }

        /// <summary>
        ///     Fatals the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="e">The e.</param>
        public void Fatal(string message, Exception e)
        {
            CheckLogger();
            _log.Fatal(message, e);
        }

        /// <summary>
        ///     Fatals the specified message.
        /// </summary>
        /// <param name="type">The type name.</param>
        /// <param name="method">The method name.</param>
        /// <param name="message">The message.</param>
        /// <param name="e">The e.</param>
        public void Fatal(string type, string method, string message, Exception e)
        {
            message = FormatMessage(type, method, message);
            Fatal(message, e);
        }

        /// <summary>
        ///     Fatals the format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void FatalFormat(string format, params object[] args)
        {
            var message = string.Format(CultureInfo.InvariantCulture, format, args);
            Fatal(message);
        }

        /// <summary>
        ///     Fatals the format.
        /// </summary>
        /// <param name="type">The type name.</param>
        /// <param name="method">The method name.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void FatalFormat(string type, string method, string format, params object[] args)
        {
            var message = string.Format(CultureInfo.InvariantCulture, format, args);
            Fatal(type, method, message);
        }

        /// <summary>
        ///     Fatals the format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="e">The e.</param>
        /// <param name="args">The arguments.</param>
        public void FatalFormat(string format, Exception e, params object[] args)
        {
            var message = string.Format(CultureInfo.InvariantCulture, format, args);
            Fatal(message, e);
        }

        /// <summary>
        ///     Fatals the format.
        /// </summary>
        /// <param name="type">The type name.</param>
        /// <param name="method">The method name.</param>
        /// <param name="format">The format.</param>
        /// <param name="e">The e.</param>
        /// <param name="args">The arguments.</param>
        public void FatalFormat(string type, string method, string format, Exception e, params object[] args)
        {
            var message = string.Format(CultureInfo.InvariantCulture, format, args);
            Fatal(type, method, message, e);
        }

        #endregion

        #region Info

        /// <summary>
        ///     Infos the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Info(string message)
        {
            CheckLogger();
            _log.Info(message);
        }

        /// <summary>
        ///     Infos the specified message.
        /// </summary>
        /// <param name="type">The type name.</param>
        /// <param name="method">The method name.</param>
        /// <param name="message">The message.</param>
        public void Info(string type, string method, string message)
        {
            message = FormatMessage(type, method, message);
            Info(message);
        }

        /// <summary>
        ///     Infos the format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void InfoFormat(string format, params object[] args)
        {
            var message = string.Format(CultureInfo.InvariantCulture, format, args);
            Info(message);
        }

        /// <summary>
        ///     Infos the format.
        /// </summary>
        /// <param name="type">The type name.</param>
        /// <param name="method">The method name.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void InfoFormat(string type, string method, string format, params object[] args)
        {
            var message = string.Format(CultureInfo.InvariantCulture, format, args);
            Info(type, method, message);
        }

        #endregion

        #region Warn

        /// <summary>
        ///     Warns the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Warn(string message)
        {
            CheckLogger();
            _log.Warn(message);
        }

        /// <summary>
        ///     Warns the specified message.
        /// </summary>
        /// <param name="type">The type name.</param>
        /// <param name="method">The method name.</param>
        /// <param name="message">The message.</param>
        public void Warn(string type, string method, string message)
        {
            message = FormatMessage(type, method, message);
            Warn(message);
        }

        /// <summary>
        ///     Warns the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="e">The e.</param>
        public void Warn(string message, Exception e)
        {
            CheckLogger();
            _log.Warn(message, e);
        }

        /// <summary>
        ///     Warns the specified message.
        /// </summary>
        /// <param name="type">The type name.</param>
        /// <param name="method">The method name.</param>
        /// <param name="message">The message.</param>
        /// <param name="e">The e.</param>
        public void Warn(string type, string method, string message, Exception e)
        {
            message = FormatMessage(type, method, message);
            Warn(message, e);
        }

        /// <summary>
        ///     Warns the format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void WarnFormat(string format, params object[] args)
        {
            var message = string.Format(CultureInfo.InvariantCulture, format, args);
            Warn(message);
        }

        /// <summary>
        ///     Warns the format.
        /// </summary>
        /// <param name="type">The type name.</param>
        /// <param name="method">The method name.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void WarnFormat(string type, string method, string format, params object[] args)
        {
            var message = string.Format(CultureInfo.InvariantCulture, format, args);
            Warn(type, method, message);
        }

        /// <summary>
        ///     Warns the format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="e">The e.</param>
        /// <param name="args">The arguments.</param>
        public void WarnFormat(string format, Exception e, params object[] args)
        {
            var message = string.Format(CultureInfo.InvariantCulture, format, args);
            Warn(message, e);
        }

        /// <summary>
        ///     Warns the format.
        /// </summary>
        /// <param name="type">The type name.</param>
        /// <param name="method">The method name.</param>
        /// <param name="format">The format.</param>
        /// <param name="e">The e.</param>
        /// <param name="args">The arguments.</param>
        public void WarnFormat(string type, string method, string format, Exception e, params object[] args)
        {
            var message = string.Format(CultureInfo.InvariantCulture, format, args);
            Warn(type, method, message, e);
        }

        #endregion

        #region Check / Register

        /// <summary>
        ///     Checks the logger.
        /// </summary>
        private void CheckLogger()
        {
            if (_log == null)
            {
                RegisterLogger();
            }
        }

        /// <summary>
        ///     Registers the logger.
        /// </summary>
        public abstract void RegisterLogger();

        #endregion

        #endregion Methods
    }
}