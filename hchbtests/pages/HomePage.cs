using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using hchbtests.utils;

namespace hchbtests.pages
{
	public class HomePage
	{

        private WebDriver driver;
        private ElementActions elementActions;
        public By LBL_NUMBER = By.XPath("//div[@data-elementor-type='header']//a[contains(@href,'tel:')]/span[contains(@class,'text')]");
        public By LBL_EMAIL = By.XPath("//div[@data-elementor-type='header']//a[contains(@href,'mailto:')]/span[contains(@class,'text')]");
        public By BTN_REQUEST_DEMO = By.XPath("//div[@data-elementor-type='header']/div/div[2]//span[text()='Request a Demo']");
        

        public HomePage(WebDriver driver)
		{
            this.driver = driver;
            this.elementActions = new ElementActions(driver);
            PageFactory.InitElements(driver, this);
        }

        public String getNumber()
        {
            return this.elementActions.getElementText(LBL_NUMBER);
        }

        public String getEmail()
        {
            return this.elementActions.getElementText(LBL_EMAIL);
        }

        public void clickRequestDemo()
        {
            this.elementActions.clickElement(BTN_REQUEST_DEMO);
        }
    }
}

