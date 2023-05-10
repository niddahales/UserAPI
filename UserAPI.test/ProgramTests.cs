
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;

namespace UserAPI.test
{
    public class ProgramTests
    {
        [Fact]
        public async void GetMethod()
        {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();
            var response = await client.GetAsync("/users");
            var data = await response.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task PostMethod()
        {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();
            var result = await client.PostAsJsonAsync("/users", new User
            {
                Name = "Test",
                Email = "test@gmail.com",
                Password = 1234,
                ConfirmPassword = 1234,
                Birthday = "01/01/2000",
                Age = 23,
            });
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
    }
}