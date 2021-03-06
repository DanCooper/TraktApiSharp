﻿namespace TraktApiSharp.Tests.Objects.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Get.Shows;
    using Utils;

    [TestClass]
    public class TraktShowSingleAliasTests
    {
        [TestMethod]
        public void TestTraktShowSingleAliasDefaultConstructor()
        {
            var alias = new TraktShowAlias();

            alias.Title.Should().BeNullOrEmpty();
            alias.CountryCode.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktShowSingleAliasReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowSingleAlias.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var alias = JsonConvert.DeserializeObject<TraktShowAlias>(jsonFile);

            alias.Should().NotBeNull();
            alias.Title.Should().Be("Game of Thrones- Das Lied von Eis und Feuer");
            alias.CountryCode.Should().Be("de");
        }
    }
}
