namespace STARAAPP
{
    public class AuthenticateUserResponse
    {
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public string Token { get; set; }

        public int RoleId { get; set; }
    }
}
