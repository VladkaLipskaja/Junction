using System;
using System.Collections.Generic;

namespace STARAAPP.Models
{
    public class OrderException : Exception
    {
        /// <summary>
        /// The unexpected error.
        /// </summary>
        private const string Unexpected = "Unexpected error.";

        /// <summary>
        /// Mapping the error codes to the default error messages.
        /// </summary>
        private static Dictionary<OrderErrorCode, string> errorCodeToMessage = new Dictionary<OrderErrorCode, string>
        {
            { OrderErrorCode.NoSuchOrder, "I can't find such order:(" }
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderException"/> class.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        public OrderException(OrderErrorCode errorCode)
            : base(GetErrorMessage(errorCode))
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        public OrderErrorCode ErrorCode { get; private set; }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <returns>
        /// The error message text.
        /// </returns>
        private static string GetErrorMessage(OrderErrorCode errorCode)
        {
            string message = errorCodeToMessage.ContainsKey(errorCode)
                ? errorCodeToMessage[errorCode] : Unexpected;

            return message;
        }
    }
}
