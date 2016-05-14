﻿namespace TraktApiSharp.Requests.WithOAuth.Comments
{
    using Base.Post;
    using Objects.Post.Comments.Responses;

    internal class TraktCommentLikeRequest : TraktBodylessPostByIdRequest<TraktCommentPostResponse, TraktCommentPostResponse>
    {
        internal TraktCommentLikeRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "comments/{id}/like";
    }
}
