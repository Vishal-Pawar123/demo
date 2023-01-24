using Microsoft.Extensions.DependencyModel;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace HotelListing.SellerportalService
{
    public class FailureResult : IHttpActionResult
    {
        
        private readonly HttpStatusCode _statusCode;
        public HttpRequestMessage Request { get; }
   
        public string ReasonPhrase { get; }
        public FailureResult(HttpStatusCode statusCode, string reasonPhrase ,HttpRequestMessage request)
        { 
            _statusCode = statusCode;
            Request = request;
            ReasonPhrase = reasonPhrase;
        }
        

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }
        private HttpResponseMessage Execute()
        {
            var response = new HttpResponseMessage(_statusCode) {
                RequestMessage = Request,
                ReasonPhrase = ReasonPhrase
            };
            return response;
        }
    }
}