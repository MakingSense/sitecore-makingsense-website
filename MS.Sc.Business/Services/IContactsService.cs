namespace MS.Sc.Business.Helpers
{
    /// <summary>
    /// IContactsService Interface
    /// </summary>
    public interface IContactsService
    {
        #region methods

        /// <summary>
        /// Creates the update contact.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        bool CreateUpdateContact(string email);

        #endregion
    }
}
