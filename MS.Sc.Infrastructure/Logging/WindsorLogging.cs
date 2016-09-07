namespace MS.Sc.Infrastructure.Logging
{
    /// <summary>
    /// WindsorLogging Class - Handle custom logging for application
    /// </summary>
    /// <seealso cref="MS.Sc.Infrastructure.Logging.BaseLogging" />
    public class WindsorLogging : BaseLogging
    {
        #region Methods

        /// <summary>
        /// Registers the logger.
        /// </summary>
        public override void RegisterLogger()
        {
            Log = log4net.LogManager.GetLogger("MS.Sc.Windsor");
        }

        #endregion Methods
    }
}
