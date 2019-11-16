using System;
using System.Collections.Generic;

namespace STARAAPP.Models
{
    /// <summary>
    /// User exception
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class UserException : Exception
    {
        /// <summary>
        /// The unexpected error.
        /// </summary>
        private const string Unexpected = "Unexpected error.";

        /// <summary>
        /// Mapping the error codes to the default error messages.
        /// </summary>
        private static Dictionary<UserErrorCode, string> errorCodeToMessage = new Dictionary<UserErrorCode, string>
        {
            { UserErrorCode.InvalidLogin, "Oops! The login is invalid:(." },
            { UserErrorCode.InvalidPassword, "Sorry, the password is invalid. Try again!:)." },
            { UserErrorCode.ExistingLogin, "Hmmm... Somebody uses this login, try the other one:)." },
            { UserErrorCode.NoSuchUser, "I can't find you:( Try once more, please:)." }
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="UserException"/> class.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        public UserException(UserErrorCode errorCode)
            : base(GetErrorMessage(errorCode))
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        public UserErrorCode ErrorCode { get; private set; }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <returns>
        /// The error message text.
        /// </returns>
        private static string GetErrorMessage(UserErrorCode errorCode)
        {
            string message = errorCodeToMessage.ContainsKey(errorCode)
                ? errorCodeToMessage[errorCode] : Unexpected;

            return message;
        }
    }
}
