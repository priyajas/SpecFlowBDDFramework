using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBDDAutomationFramework.Pages
{
    public class ResultPage
    {
        private IWebDriver driver;
        private IReadOnlyCollection<IWebElement> SearchResults;

        public ResultPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        
        By searchResult = By.XPath("//div[contains(@class, 'Box-sc-g0xbh4-0 iwUbcA')]");
        By filterList = By.XPath("//a[contains(@class, 'Box-sc-g0xbh4-0 cQdyWD prc-Link-Link-85e08')]//div//span[contains(@id,'label')]");

        public ChannelPage verifySearchResult()
        {
            SearchResults = driver.FindElements(searchResult);
            Console.WriteLine("Search Results:");
            foreach (var result in SearchResults)
            {
                Console.WriteLine(result.Text.ToLower().Contains("android"));
            }
            return new ChannelPage(driver);
        }
        public void verifyFilterList(List<string> expectedFilters)
        {
            var actualFilters = driver.FindElements(filterList).Select(element => element.Text.Trim()).ToList();
            Console.WriteLine(actualFilters);
            foreach (var filter in expectedFilters)
            {
                if (!actualFilters.Contains(filter, StringComparer.OrdinalIgnoreCase))
                {
                    throw new Exception($"Filter '{filter}' is not present in the search results.");
                }
            }
        }

       
    }
    
    
}