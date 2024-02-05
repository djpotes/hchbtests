using System;
using hchbtests.utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using static System.Net.Mime.MediaTypeNames;

namespace hchbtests.pages
{
	public class RequestDemoPage
	{
        private WebDriver driver;
        private ElementActions elementActions;

        private By IFRAME_DEMO = By.XPath("//iframe[@class='pardotform']");
        private By TXT_FIRSTNAME = By.XPath("//p[contains(@class,'first_name')]/input");
        private By TXT_LASTNAME = By.XPath("//p[contains(@class,'last_name')]/input");
        private By TXT_EMAIL = By.XPath("//p[contains(@class,'email')]/input");
        private By TXT_PHONE = By.XPath("//p[contains(@class,'phone')]/input");
        private By LIST_ROLE = By.XPath("//p[contains(@class,'Role')]/select");
        private By TXT_COMPANY = By.XPath("//p[contains(@class,'company')]/input");
        private By TXT_CITY = By.XPath("//p[contains(@class,'city')]/input");
        private By LIST_STATE = By.XPath("//p[contains(@class,'state')]/select");
        private By BTN_SUBMIT = By.XPath("//input[@value='Submit']");

        public By FORM_ERROR_MESSAGE = By.XPath("//p[text()='Please correct the errors below:']");
        public By FIELD_SERVICES_OFFERED_ERROR_MESSAGE = By.XPath("//p[contains(@class,'Services_Provided_By_Your_Agency')]/following-sibling::p[text()='This field is required']");
        public By CAPTCHA_ERROR_MESSAGE = By.XPath("//p[text()='Invalid CAPTCHA']");

        public RequestDemoPage(WebDriver driver)
		{
            this.driver = driver;
            this.elementActions = new ElementActions(driver);
            PageFactory.InitElements(driver, this);
        }

        public void switchToDemoFrame()
        {
            this.elementActions.switchToFrame(IFRAME_DEMO);
        }

        public void typeFirstName(String value)
        {
            this.elementActions.typeElementText(TXT_FIRSTNAME, value);
        }

        public void typeLastName(String value)
        {
            this.elementActions.typeElementText(TXT_LASTNAME, value);
        }

        public void typeEmail(String value)
        {
            this.elementActions.typeElementText(TXT_EMAIL, value);
        }

        public void typePhone(String value)
        {
            this.elementActions.typeElementText(TXT_PHONE, value);
        }

        public void selectRole(String text)
        {
            this.elementActions.selectListOptionByText(LIST_ROLE, text);
        }

        public void typeCompany(String value)
        {
            this.elementActions.typeElementText(TXT_COMPANY, value);
        }

        public void typeCity(String value)
        {
            this.elementActions.typeElementText(TXT_CITY, value);
        }

        public void selectState(String text)
        {
            this.elementActions.selectListOptionByText(LIST_STATE, text);
        }

        public void clickSubmit()
        {
            IWebElement element = this.driver.FindElement(BTN_SUBMIT);
            element.Click();
        }

    }
}

