namespace TestSabre
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
    [TestFixture]
    public class DateConsolidationTests
    {
        [Test]
        public void TestDateConsolidation()
        {
            List<DateRange> inputRanges = new List<DateRange>
            {
                new(new DateTime(2024, 1, 1), new DateTime(2024, 1, 10)),
                new(new DateTime(2024, 1, 5), new DateTime(2024, 1, 15)),
                new(new DateTime(2024, 1, 19), new DateTime(2024, 1, 20)),
                new(new DateTime(2024, 1, 2), new DateTime(2024, 1, 5)),
                new(new DateTime(2024, 1, 22), new DateTime(2024, 1, 22)),
                new(new DateTime(2024, 1, 17), new DateTime(2024, 1, 18))
            };

            List<DateRange> consolidatedRanges = Utility.ConsolidateDateRanges(inputRanges);

            List<DateRange> expectedRanges = new List<DateRange>
            {
                new(new DateTime(2024, 1, 1), new DateTime(2024, 1, 15)),
                new(new DateTime(2024, 1, 17), new DateTime(2024, 1, 20)),
                new(new DateTime(2024, 1, 22), new DateTime(2024, 1, 22))
            };

            CollectionAssert.AreEqual(expectedRanges, consolidatedRanges);
        }

        // Add more test cases as needed
    }
}