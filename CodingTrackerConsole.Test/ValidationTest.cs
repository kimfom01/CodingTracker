namespace CodingTrackerConsole.Test
{
    [TestFixture]
    public class ValidationTest
    {
        private Validation validation = new();

        [Test]
        public void IsValidDate_Returns_True()
        {
            var date = "11-16-2022";

            var result = validation.IsValidDate(date);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidDate_Returns_False()
        {
            var date = "16-11-2022";

            var result = validation.IsValidDate(date);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidTime_Returns_True()
        {
            var time = "18:30";

            var result = validation.IsValidTime(time);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidTime_Returns_False()
        {
            var time = "6:30";

            var result = validation.IsValidTime(time);

            Assert.IsFalse(result);
        }
    }
}
