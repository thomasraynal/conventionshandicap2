using Microsoft.AspNetCore.Mvc;

namespace Anabasis.Api
{
    public interface IResponseBuilder<TChild> where TChild : IResponseBuilder<TChild>
    {
        object Content { get; }
        int StatusCode { get; }
        IActionResult BuildResult();
    }

    public class ResponseBuilder<TChild> : IResponseBuilder<TChild> where TChild : ResponseBuilder<TChild>
    {
        private int _statusCode;
        private object _content;

        protected ResponseBuilder()
        {
        }

        public object Content => _content;
        public int StatusCode => _statusCode;

        protected TChild WithStatusCode(int statusCode)
        {
            _statusCode = statusCode;
            return (TChild)this;
        }

        protected TChild WithContent(object content)
        {
            _content = content;
            return (TChild)this;
        }

        public IActionResult BuildResult()
        {
            var actionResult = (_content == null)
                ? (IActionResult)new StatusCodeResult(_statusCode)
                : new ObjectResult(_content) { StatusCode = _statusCode };

            return actionResult;
        }
    }
}
