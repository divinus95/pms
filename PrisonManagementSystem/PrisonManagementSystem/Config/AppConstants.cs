using System;
using System.Collections.Generic;
using System.Text;

namespace PrisonManagementSystem.Config
{
    public static class AppConstants
    {
        public const string EncryptionKey = "B1u315r4i19Ab51jE0G02xk16LTf4OKCyz123DasYW7hahbnan80172Lyf49";
        public const string ENABLE_CORS = "EnableCORS";
        public const string AUTH_TOKEN_HEADER_KEY = "AuthToken";


        //API response values
        public const string INVALID_CREDENTIALS = "Invalid credentials";
        public const string LOGIN_ERROR = "Error logging in. Please retry.";
        public const string OK_SUCCESS = "success";
        public const string FAILED_STATUS = "failed";
        public const string INVALID_REQUEST = "Invalid request";

        //DB return values
        public const string DB_SUCCESS = "SUCCESS";
        public const string TOKEN_EXISTS = "TOKEN EXISTS";
        public const string ACTIVE_LOGIN_OTP_EXISTS = "ACTIVE LOGIN OTP EXISTS";
        public const string DB_INVALID_REQUEST = "INVALID REQUEST";

    }
}
