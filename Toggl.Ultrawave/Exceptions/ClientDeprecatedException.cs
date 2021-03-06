﻿using System.Net;

namespace Toggl.Ultrawave.Exceptions
{
    public sealed class ClientDeprecatedException : ClientErrorException
    {
        // HTTP status code 418 "I Am A Teapot" is not included in the System.Net.HttpStatusCode enum
        public const HttpStatusCode CorrespondingHttpCode = (HttpStatusCode)418;

        private const string defaultMessage = "This version of client application is deprecated and must be updated to an up-to-date version.";

        public ClientDeprecatedException()
            : this(defaultMessage)
        {
        }

        public ClientDeprecatedException(string errorMessage)
            : base(errorMessage)
        {
        }
    }
}
