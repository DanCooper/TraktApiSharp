﻿namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Episodes
{
    using Objects.Get.Shows.Episodes;

    internal class TraktEpisodeRatingsRequest : TraktGetByIdEpisodeRequest<TraktEpisodeRating, TraktEpisodeRating>
    {
        internal TraktEpisodeRatingsRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/ratings";
    }
}
