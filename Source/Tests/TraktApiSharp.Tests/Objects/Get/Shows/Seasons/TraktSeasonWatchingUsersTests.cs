﻿namespace TraktApiSharp.Tests.Objects.Shows.Seasons
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Shows.Seasons;
    using Utils;

    [TestClass]
    public class TraktSeasonWatchingUsersTests
    {
        [TestMethod]
        public void TestTraktSeasonWatchingUsersReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonWatchingUsers.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var seasonWatchingUsers = JsonConvert.DeserializeObject<IEnumerable<TraktSeasonWatchingUser>>(jsonFile);

            seasonWatchingUsers.Should().NotBeNull();
            seasonWatchingUsers.Should().HaveCount(3);

            var watchingUsers = seasonWatchingUsers.ToArray();

            watchingUsers[0].Username.Should().Be("TheBossWithE");
            watchingUsers[0].Private.Should().BeFalse();
            watchingUsers[0].Name.Should().BeEmpty();
            watchingUsers[0].VIP.Should().BeFalse();
            watchingUsers[0].VIP_EP.Should().BeFalse();

            watchingUsers[1].Username.Should().Be("spazatabc");
            watchingUsers[1].Private.Should().BeFalse();
            watchingUsers[1].Name.Should().Be("Daniel Lake");
            watchingUsers[1].VIP.Should().BeFalse();
            watchingUsers[1].VIP_EP.Should().BeFalse();

            watchingUsers[2].Username.Should().Be("TiMoose");
            watchingUsers[2].Private.Should().BeFalse();
            watchingUsers[2].Name.Should().BeEmpty();
            watchingUsers[2].VIP.Should().BeFalse();
            watchingUsers[2].VIP_EP.Should().BeFalse();
        }
    }
}