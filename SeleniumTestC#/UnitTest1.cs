namespace SeleniumTestC_
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine("Setup methoed executed");
        }

        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("Test1 executed");
        }

        [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("Test2 executed");
        }

        [TearDown]
        public void CloseBrowser() 
        {
            TestContext.Progress.WriteLine("Close drowser executed");
        }
    }
}