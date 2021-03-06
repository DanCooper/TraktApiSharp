﻿namespace TraktApiSharp.Requests.Base.Delete
{
    using System.Net.Http;

    internal abstract class TraktDeleteRequest : TraktRequest<object, object, object>
    {
        protected TraktDeleteRequest(TraktClient client) : base(client) { }

        protected override HttpMethod Method => HttpMethod.Delete;

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;
    }
}
