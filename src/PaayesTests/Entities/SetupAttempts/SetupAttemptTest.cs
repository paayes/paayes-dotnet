namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class SetupAttemptTest : BasePaayesTest
    {
        public SetupAttemptTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            // Using a fixture as there's no GET API for now on SetupAttempt
            var json = GetResourceAsString("api_fixtures.setup_attempt.json");
            var attempt = JsonConvert.DeserializeObject<SetupAttempt>(json);
            Assert.NotNull(attempt);
            Assert.IsType<SetupAttempt>(attempt);
            Assert.NotNull(attempt.Id);
            Assert.Equal("setup_attempt", attempt.Object);
        }
    }
}
