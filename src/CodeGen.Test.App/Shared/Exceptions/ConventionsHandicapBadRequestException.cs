using Anabasis.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConventionsHandicap.Shared
{
    public class ConventionsHandicapBadRequestException : Exception, ICanMapToHttpError
    {
        public ConventionsHandicapBadRequestException()
        {
        }

        public ConventionsHandicapBadRequestException(string message) : base(message)
        {
        }

        public ConventionsHandicapBadRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ConventionsHandicapBadRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public HttpStatusCode HttpStatusCode => HttpStatusCode.BadRequest;
    }
}
