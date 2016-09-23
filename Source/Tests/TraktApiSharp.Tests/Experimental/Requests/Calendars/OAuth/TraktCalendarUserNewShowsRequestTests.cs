﻿namespace TraktApiSharp.Tests.Experimental.Requests.Calendars.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Calendars.OAuth;
    using TraktApiSharp.Objects.Get.Calendars;

    [TestClass]
    public class TraktCalendarUserNewShowsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarUserNewShowsRequestIsNotAbstract()
        {
            typeof(TraktCalendarUserNewShowsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarUserNewShowsRequestIsSealed()
        {
            typeof(TraktCalendarUserNewShowsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarUserNewShowsRequestIsSubclassOfATraktCalendarUserRequest()
        {
            typeof(TraktCalendarUserNewShowsRequest).IsSubclassOf(typeof(ATraktCalendarUserRequest<TraktCalendarShow>)).Should().BeTrue();
        }
    }
}
