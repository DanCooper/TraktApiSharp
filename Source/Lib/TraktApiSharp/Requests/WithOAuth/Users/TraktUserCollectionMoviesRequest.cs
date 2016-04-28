﻿namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Users.Collections;
    using System.Collections.Generic;

    internal class TraktUserCollectionMoviesRequest : TraktGetRequest<TraktListResult<TraktUserCollectionMovieItem>, TraktUserCollectionMovieItem>
    {
        internal TraktUserCollectionMoviesRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Optional;

        internal string Username { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "username", Username } };
        }

        protected override string UriTemplate => "users/{username}/collection/movies";

        protected override bool IsListResult => true;
    }
}
