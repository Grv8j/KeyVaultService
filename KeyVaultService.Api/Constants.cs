namespace KeyVaultService;

/// <summary>
/// Constants related to API and configuration
/// </summary>
internal static class Constants
{
    /// <summary>
    /// API related constants
    /// </summary>
    public static class Api
    {
        /// <summary>
        /// API Title
        /// </summary>
        public const string API_TITLE = "Key Vault Service API";

        /// <summary>
        /// API Description
        /// </summary>
        public const string API_DESCRIPTION =
            "This API provides access points for Key Vault service, which is responsible for secure storing of secret keys and values";
    
        /// <summary>
        /// API Version
        /// </summary>
        public const string API_VERSION = "v1";
    
        /// <summary>
        /// URL of swagger file
        /// </summary>
        public const string SWAGGER_URL = "/swagger/v1/swagger.json";
    }

    /// <summary>
    /// Configuration related constants
    /// </summary>
    public static class Configuration
    {
        /// <summary>
        /// Connection string configuration key name
        /// </summary>
        public const string CONNECTION_STRING_KEY_NAME = "Database";
    }
}