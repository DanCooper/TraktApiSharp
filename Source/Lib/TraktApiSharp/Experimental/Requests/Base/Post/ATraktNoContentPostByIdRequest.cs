﻿namespace TraktApiSharp.Experimental.Requests.Base.Post
{
    using Interfaces;
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktNoContentPostByIdRequest<TRequestBody> : ATraktNoContentRequest, ITraktRequest, ITraktHasRequestBody<TRequestBody>, ITraktHasId
    {
        internal ATraktNoContentPostByIdRequest(TraktClient client) : base(client)
        {
            RequestBody = new TraktRequestBody<TRequestBody>();
            RequestId = new TraktRequestId();
        }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public HttpMethod Method => HttpMethod.Post;

        public TraktRequestBody<TRequestBody> RequestBody { get; set; }

        public TRequestBody RequestBodyContent
        {
            get { return RequestBody.RequestBody; }
            set { RequestBody.RequestBody = value; }
        }

        public string Id
        {
            get { return RequestId.Id; }
            set { RequestId.Id = value; }
        }

        public TraktRequestId RequestId { get; set; }
    }
}
