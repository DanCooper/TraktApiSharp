﻿namespace TraktApiSharp.Tests.Objects.Users
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Users;
    using Utils;

    [TestClass]
    public class TraktSharingTextTests
    {
        [TestMethod]
        public void TestTraktSharingTextDefaultConstructor()
        {
            var sharingText = new TraktSharingText();

            sharingText.Watching.Should().BeNullOrEmpty();
            sharingText.Watched.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktSharingTextReadFromJson()
        {
            var jsonFile = TestUtility.ReadJsonData(@"Users\SharingText.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var sharingText = JsonConvert.DeserializeObject<TraktSharingText>(jsonFile);

            sharingText.Should().NotBeNull();
            sharingText.Watching.Should().Be("I'm watching [item]");
            sharingText.Watched.Should().Be("I just watched [item]");
        }
    }
}