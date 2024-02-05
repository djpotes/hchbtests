using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using static System.Net.Mime.MediaTypeNames;

namespace hchbtests.utils
{
	public class ElementActions
	{
        private WebDriver driver;

        public ElementActions(WebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void switchToFrame(By selector)
        {
            IWebElement iframe = this.driver.FindElement(selector);
            this.driver.SwitchTo().Frame(iframe);
        }

        public void clickElement(By selector)
        {
            IWebElement element = this.driver.FindElement(selector);
            element.Click();
        }

        public void typeElementText(By selector, String value)
        {
            IWebElement element = this.driver.FindElement(selector);
            element.SendKeys(value);
        }

        public void selectListOptionByText(By selector, String option)
        {
            IWebElement element = this.driver.FindElement(selector);
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByText(option);
        }

        public void clearAndTypeElementText(By selector, String value)
        {
            IWebElement element = this.driver.FindElement(selector);
            element.Clear();
            element.SendKeys(value);
        }

        public String getElementText(By selector)
        {
            IWebElement element = this.driver.FindElement(selector);
            return element.Text;
        }
    }
}

