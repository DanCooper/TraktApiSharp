﻿namespace TraktApiSharp.Tests.Objects.Post.Syncs.History
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.Episodes;
    using TraktApiSharp.Objects.Post.Syncs.History;

    [TestClass]
    public class TraktSyncHistoryRemovePostTests
    {
        [TestMethod]
        public void TestTraktSyncHistoryRemovePostDefaultConstructor()
        {
            var historyRemovePost = new TraktSyncHistoryRemovePost();

            historyRemovePost.Movies.Should().BeNull();
            historyRemovePost.Shows.Should().BeNull();
            historyRemovePost.Episodes.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSyncHistoryRemovePostWriteJson()
        {
            var historyRemovePost = new TraktSyncHistoryRemovePost
            {
                Movies = new List<TraktSyncHistoryPostMovie>()
                {
                    new TraktSyncHistoryPostMovie
                    {
                        Title = "Batman Begins",
                        Year = 2005,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1,
                            Slug = "batman-begins-2005",
                            Imdb = "tt0372784",
                            Tmdb = 272
                        }
                    },
                    new TraktSyncHistoryPostMovie
                    {
                        Ids = new TraktMovieIds
                        {
                            Imdb = "tt0000111"
                        }
                    }
                },
                Shows = new List<TraktSyncHistoryPostShow>()
                {
                    new TraktSyncHistoryPostShow
                    {
                        Title = "Breaking Bad",
                        Year = 2008,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1,
                            Slug = "breaking-bad",
                            Tvdb = 81189,
                            Imdb = "tt0903747",
                            Tmdb = 1396,
                            TvRage = 18164
                        }
                    },
                    new TraktSyncHistoryPostShow
                    {
                        Title = "The Walking Dead",
                        Year = 2010,
                        Ids = new TraktShowIds
                        {
                            Trakt = 2,
                            Slug = "the-walking-dead",
                            Tvdb = 153021,
                            Imdb = "tt1520211",
                            Tmdb = 1402,
                            TvRage = 25056
                        },
                        Seasons = new List<TraktSyncHistoryPostShowSeason>()
                        {
                            new TraktSyncHistoryPostShowSeason
                            {
                                Number = 3
                            }
                        }
                    },
                    new TraktSyncHistoryPostShow
                    {
                        Title = "Mad Men",
                        Year = 2007,
                        Ids = new TraktShowIds
                        {
                            Trakt = 4,
                            Slug = "mad-men",
                            Tvdb = 80337,
                            Imdb = "tt0804503",
                            Tmdb = 1104,
                            TvRage = 16356
                        },
                        Seasons = new List<TraktSyncHistoryPostShowSeason>()
                        {
                            new TraktSyncHistoryPostShowSeason
                            {
                                Number = 1,
                                Episodes = new List<TraktSyncHistoryPostShowEpisode>()
                                {
                                    new TraktSyncHistoryPostShowEpisode
                                    {
                                        Number = 1
                                    },
                                    new TraktSyncHistoryPostShowEpisode
                                    {
                                        Number = 2
                                    }
                                }
                            }
                        }
                    }
                },
                Episodes = new List<TraktSyncHistoryPostEpisode>()
                {
                    new TraktSyncHistoryPostEpisode
                    {
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 1061,
                            Tvdb = 1555111,
                            Imdb = "tt007404",
                            Tmdb = 422183,
                            TvRage = 12345
                        }
                    }
                }
            };

            var strJson = JsonConvert.SerializeObject(historyRemovePost);

            strJson.Should().NotBeNullOrEmpty();

            var historyPostFromJson = JsonConvert.DeserializeObject<TraktSyncHistoryPost>(strJson);

            historyPostFromJson.Should().NotBeNull();

            historyPostFromJson.Movies.Should().NotBeNull().And.HaveCount(2);
            historyPostFromJson.Shows.Should().NotBeNull().And.HaveCount(3);
            historyPostFromJson.Episodes.Should().NotBeNull().And.HaveCount(1);

            var movies = historyPostFromJson.Movies.ToArray();

            movies[0].WatchedAt.Should().NotHaveValue();
            movies[0].Title.Should().Be("Batman Begins");
            movies[0].Year.Should().Be(2005);
            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(1);
            movies[0].Ids.Slug.Should().Be("batman-begins-2005");
            movies[0].Ids.Imdb.Should().Be("tt0372784");
            movies[0].Ids.Tmdb.Should().Be(272);

            movies[1].WatchedAt.Should().NotHaveValue();
            movies[1].Title.Should().BeNullOrEmpty();
            movies[1].Year.Should().NotHaveValue();
            movies[1].Ids.Should().NotBeNull();
            movies[1].Ids.Trakt.Should().Be(0);
            movies[1].Ids.Slug.Should().BeNullOrEmpty();
            movies[1].Ids.Imdb.Should().Be("tt0000111");
            movies[1].Ids.Tmdb.Should().NotHaveValue();

            var shows = historyPostFromJson.Shows.ToArray();

            shows[0].WatchedAt.Should().NotHaveValue();
            shows[0].Title.Should().Be("Breaking Bad");
            shows[0].Year.Should().Be(2008);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1);
            shows[0].Ids.Slug.Should().Be("breaking-bad");
            shows[0].Ids.Tvdb.Should().Be(81189);
            shows[0].Ids.Imdb.Should().Be("tt0903747");
            shows[0].Ids.Tmdb.Should().Be(1396);
            shows[0].Ids.TvRage.Should().Be(18164);
            shows[0].Seasons.Should().BeNull();

            shows[1].WatchedAt.Should().NotHaveValue();
            shows[1].Title.Should().Be("The Walking Dead");
            shows[1].Year.Should().Be(2010);
            shows[1].Ids.Should().NotBeNull();
            shows[1].Ids.Trakt.Should().Be(2);
            shows[1].Ids.Slug.Should().Be("the-walking-dead");
            shows[1].Ids.Tvdb.Should().Be(153021);
            shows[1].Ids.Imdb.Should().Be("tt1520211");
            shows[1].Ids.Tmdb.Should().Be(1402);
            shows[1].Ids.TvRage.Should().Be(25056);
            shows[1].Seasons.Should().NotBeNull().And.HaveCount(1);

            var show2Seasons = shows[1].Seasons.ToArray();

            show2Seasons[0].WatchedAt.Should().NotHaveValue();
            show2Seasons[0].Number.Should().Be(3);
            show2Seasons[0].Episodes.Should().BeNull();

            shows[2].WatchedAt.Should().NotHaveValue();
            shows[2].Title.Should().Be("Mad Men");
            shows[2].Year.Should().Be(2007);
            shows[2].Ids.Should().NotBeNull();
            shows[2].Ids.Trakt.Should().Be(4);
            shows[2].Ids.Slug.Should().Be("mad-men");
            shows[2].Ids.Tvdb.Should().Be(80337);
            shows[2].Ids.Imdb.Should().Be("tt0804503");
            shows[2].Ids.Tmdb.Should().Be(1104);
            shows[2].Ids.TvRage.Should().Be(16356);
            shows[2].Seasons.Should().NotBeNull().And.HaveCount(1);

            var show3Seasons = shows[2].Seasons.ToArray();

            show3Seasons[0].WatchedAt.Should().NotHaveValue();
            show3Seasons[0].Number.Should().Be(1);
            show3Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var show3Season1Episodes = show3Seasons[0].Episodes.ToArray();

            show3Season1Episodes[0].WatchedAt.Should().NotHaveValue();
            show3Season1Episodes[0].Number.Should().Be(1);

            show3Season1Episodes[1].WatchedAt.Should().NotHaveValue();
            show3Season1Episodes[1].Number.Should().Be(2);

            var episodes = historyPostFromJson.Episodes.ToArray();

            episodes[0].WatchedAt.Should().NotHaveValue();
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(1061);
            episodes[0].Ids.Tvdb.Should().Be(1555111);
            episodes[0].Ids.Imdb.Should().Be("tt007404");
            episodes[0].Ids.Tmdb.Should().Be(422183);
            episodes[0].Ids.TvRage.Should().Be(12345);
        }
    }
}
