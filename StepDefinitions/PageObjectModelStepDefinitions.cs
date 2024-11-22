using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowBDDAutomationFramework.Pages;

namespace SpecFlowBDDAutomationFramework.StepDefinitions
{
    [Binding]
    public sealed class PageObjectModelStepDefinitions
    {
        private IWebDriver driver;
        SearchPage searchPage;
        ResultPage resultPage;
        ChannelPage channelPage;

        public PageObjectModelStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"Enter the Github Search URL")]
        public void GivenEnterTheGitHubURL()
        {
            driver.Url = "https://github.com/search";
            Thread.Sleep(4000);
        }

        [When(@"Search for the Android Repository in Github")]
        public void WhenSearchForTheAndroidRepoInGithub()
        {
            searchPage = new SearchPage(driver);

            resultPage = searchPage.searchText("android");
            Thread.Sleep(4000);
        }

        [When(@"Navigate to Repository")]
        public void WhenNavigateToRepository()
        {
            channelPage.navigateToRepo();
            Thread.Sleep(4000);
        }

        [Then(@"Verify title of the page")]
        public void ThenVerifyTitleOfThePage()
        {
            Assert.IsTrue(channelPage.getTitle().ToLower().Contains("android"));
            //Assert.AreEqual("Repository search results · GitHub", channelPage.getTitle());
        }


        [When(@"Verify Search Results contains Android")]
        public void WhenVerifySearchResultsContainsAndroid()
        {
            channelPage = resultPage.verifySearchResult();
            Thread.Sleep(4000);
        }
        
        [Then(@"Verify Search Results Filter Contains Options")]
        public void ThenVerifySearchResultsFilterContainsOptions(Table table)
        {
            var expectedFilters = table.Rows.Select(row => row[0]).ToList();
            resultPage.verifyFilterList(expectedFilters);
            
        }
        
    }
}