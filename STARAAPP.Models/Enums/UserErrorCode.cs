namespace STARAAPP.Models
{
    /// <summary>
    /// User errors enum.
    /// </summary>
    public enum UserErrorCode
    {
        /// <summary>
        /// The login is invalid
        /// </summary>
        InvalidLogin = 1,

        /// <summary>
        /// The password is invalid
        /// </summary>
        InvalidPassword = 2,

        /// <summary>
        /// Such login already exists
        /// </summary>
        ExistingLogin = 3,

        /// <summary>
        /// There is no such user
        /// </summary>
        NoSuchUser = 4
    }
}