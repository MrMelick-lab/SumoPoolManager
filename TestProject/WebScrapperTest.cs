namespace TestProject
{
    public class WebScrapperTest
    {
        private string htmlPageOf202301;


        public WebScrapperTest()
        {
            htmlPageOf202301 = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "202301.html"));
        }
    }
}