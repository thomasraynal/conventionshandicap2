using Anabasis.Api;
using System;
using System.Net;
using System.Runtime.Serialization;

namespace ConventionsHandicap.Shared
{
    public class ConventionsHandicapNotFoundException : Exception, ICanMapToHttpError
    {
        public ConventionsHandicapNotFoundException()
        {
        }

        public ConventionsHandicapNotFoundException(string message) : base(message)
        {
        }

        public ConventionsHandicapNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ConventionsHandicapNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public HttpStatusCode HttpStatusCode => HttpStatusCode.NotFound;
    }
}
