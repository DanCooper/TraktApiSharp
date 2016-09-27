﻿namespace TraktApiSharp.Experimental.Requests.Base.Put
{
    using Interfaces;
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktPaginationPutRequest<TItem, TRequestBody> : ATraktPaginationRequest<TItem>, ITraktRequest, ITraktHasRequestBody<TRequestBody>
    {
        internal ATraktPaginationPutRequest(TraktClient client) : base(client)
        {
            RequestBody = new TraktRequestBody<TRequestBody>();
        }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public HttpMethod Method => HttpMethod.Put;

        public TraktRequestBody<TRequestBody> RequestBody { get; set; }

        public TRequestBody RequestBodyContent
        {
            get { return RequestBody.RequestBody; }
            set { RequestBody.RequestBody = value; }
        }
    }
}
