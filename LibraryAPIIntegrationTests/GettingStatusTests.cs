﻿using LibraryApiIntegrationTests;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LibraryAPIIntegrationTests
{
    public class GettingStatusTests : IClassFixture<WebTestFixture>
    {
        private readonly HttpClient Client;

        public GettingStatusTests(WebTestFixture factory)
        {
            this.Client = factory.CreateClient();
        }

        [Fact]
        public async Task WeGetAnOkStatusCode()
        {
            var response = await Client.GetAsync("/status"); // use await, NOT .result. See article in notes.
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task WeGetSomeJsonDataBack()
        {
            var response = await Client.GetAsync("/status");
            var contentType = response.Content.Headers.ContentType.MediaType;
            Assert.Equal("application/json", contentType);
        }

        [Fact]
        public async Task ReturnsProperResponse()
        {
            var response = await Client.GetAsync("/status");
            var content = await response.Content.ReadAsAsync<StatusResponse>();
            Assert.Equal("Everything is golden!", content.message);
            Assert.Equal("The H I V E", content.checkedBy);
            Assert.Equal(new DateTime(1969,4,20,23,59,59), content.whenLastChecked);
        }
    }


    public class StatusResponse
    {
        public string message { get; set; }
        public string checkedBy { get; set; }
        public DateTime whenLastChecked { get; set; }
    }

}
