﻿namespace TraktApiSharp.Requests.Base.Post
{
    using System;
    using System.Net.Http;

    internal abstract class TraktPostRequest<TResult, TItem, TRequestBody> : TraktRequest<TResult, TItem, TRequestBody>
    {
        protected TraktPostRequest(TraktClient client) : base(client) { }

        protected override HttpMethod Method => HttpMethod.Post;

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        protected override void Validate()
        {
            base.Validate();

            if (RequestBody == null)
                throw new ArgumentException("request body not set");
        }
    }
}
