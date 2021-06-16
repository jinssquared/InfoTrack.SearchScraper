using AutoFixture.NUnit3;
using InfoTrack.SearchScraper.API.Entities;
using InfoTrack.SearchScraper.API.Representations;
using Moq;
using NUnit.Framework;
using System;
using System.Net;

namespace InfoTrack.SearchScraper.Tests.Services.GoogleSearchServiceTests
{
    [TestFixture]
    public class GoogleSearchServiceTest : GoogleSearchServiceTestBase
    {
        [Test]
        [AutoData]
        public void Search_CallsConverter(string fakesearchRequest)
        {
            Service.Search(fakesearchRequest, It.IsAny<string>());

            GoogleSearchConverterMock.Verify(c => c.Convert(fakesearchRequest), Times.Once);
        }
    }
}
