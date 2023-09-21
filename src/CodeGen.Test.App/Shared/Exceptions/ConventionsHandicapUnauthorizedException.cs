using Anabasis.Api;
using System;
using System.Net;
using System.Runtime.Serialization;

namespace ConventionsHandicap.Shared
{
    public class ConventionsHandicapUnauthorizedException : Exception, ICanMapToHttpError
    {
        public ConventionsHandicapUnauthorizedException()
        {
        }

        public ConventionsHandicapUnauthorizedException(string message) : base(message)
        {
        }

        public ConventionsHandicapUnauthorizedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ConventionsHandicapUnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public HttpStatusCode HttpStatusCode => HttpStatusCode.Unauthorized;
    }
}

