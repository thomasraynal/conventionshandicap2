using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Anabasis.Api
{
    public interface IResponseBuilder<TChild> where TChild : IResponseBuilder<TChild>
    {
        object? Content { get; }
        int? HttpStatusCode { get; }
        IActionResult BuildResult();
    }

    public class ResponseBuilder<TChild> : IResponseBuilder<TChild> where TChild : ResponseBuilder<TChild>
    {
  
        public object? Content { get; private set; }
        public int? HttpStatusCode { get; private set; }

        protected TChild WithStatusCode(int httpStatusCode)
        {
            HttpStatusCode = httpStatusCode;
            return (TChild)this;
        }

        protected TChild WithContent(object content)
        {
            Content = content;
            return (TChild)this;
        }

        public IActionResult BuildResult()
        {

            if (null == HttpStatusCode)
            {
                throw new InvalidOperationException("HttpStatusCode must be set");
            }

            var actionResult = (Content == null)
                ? (IActionResult)new StatusCodeResult(HttpStatusCode.Value)
                : new ObjectResult(Content) { StatusCode = HttpStatusCode.Value };

            return actionResult;
        }
    }
}
