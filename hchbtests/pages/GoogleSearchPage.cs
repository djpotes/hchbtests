using System;
using hchbtests.utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;


namespace hchbtests.pages
{
	public class GoogleSearchPage
	{

        private WebDriver driver;
        private ElementActions elementActions;

        public By TXT_SEARCH = By.Id("APjFqb");
        public By BTN_SEARCH = By.XPath("//input[@name='btnK']");
        public By LINK_PAGE = By.XPath("//a[@href='https://hchb.com/']");
               
        public GoogleSearchPage(WebDriver driver)
        {
            this.driver = driver;
            this.elementActions = new ElementActions(driver);
            PageFactory.InitElements(driver, this);
        }

        public void clearAndTypeSearch(String value)
        {
            this.elementActions.clearAndTypeElementText(TXT_SEARCH, value);
        }

        public void clickSarch()
        {
            this.elementActions.clickElement(BTN_SEARCH);
        }

        public void clickLinkPage()
        {
            this.elementActions.clickElement(LINK_PAGE);
        }
    }
}

