using System;
using System.Runtime.ConstrainedExecution;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium;
using hchbtests.utils;
using hchbtests.pages;

namespace hchbtests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            DriverInstance.init();
        }

        [Test]
        public void Test1()
        {
            WebDriverWait wait = new WebDriverWait(DriverInstance.driver, TimeSpan.FromSeconds(5));
            GoogleSearchPage googleSearchPage = new GoogleSearchPage(DriverInstance.driver);
            HomePage homePage = new HomePage(DriverInstance.driver);
            RequestDemoPage requestDemoPage = new RequestDemoPage(DriverInstance.driver);

            //Navigate to Google page
            DriverInstance.driver.Navigate();

            //1. Wait until the search box and search button are visible.
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(googleSearchPage.TXT_SEARCH));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(googleSearchPage.BTN_SEARCH));

            //2. Clear the search box, input the term "HCHB", and click the search button.
            googleSearchPage.clearAndTypeSearch("HCHB");
            googleSearchPage.clickSarch();

            //3. Make sure that hchb.com is displayed
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(googleSearchPage.LINK_PAGE));

            //4.Navigate to the web site.
            googleSearchPage.clickLinkPage();

            //5. Assert that number and email address in the top left corner of the website equals 866-535-4242 and info@hchb.com respectively.
            String number = homePage.getNumber();
            String email = homePage.getEmail();
            Assert.That(number, Is.EqualTo("866-535-4242"));
            Assert.That(email, Is.EqualTo("info@hchb.com"));

            //6. Click on the ‘Request Demo’ button – top right corner of the screen.
            homePage.clickRequestDemo();

            //7. Verify that app navigates to https://hchb.com/request-demo/ page.
            Assert.That(DriverInstance.driver.Url, Is.EqualTo("https://hchb.com/request-demo/"));

            //8. Fill in all the mandatory fields but two (First and Last name, Email etc). Leave Service offered and Captcha validator unchecked.
            requestDemoPage.switchToDemoFrame();
            requestDemoPage.typeFirstName("Darwin");
            requestDemoPage.typeLastName("Potes");
            requestDemoPage.typeEmail("darwinpotes2102@live.com");
            requestDemoPage.typePhone("+573128378798");
            requestDemoPage.selectRole("Technology/IT");
            requestDemoPage.typeCompany("HCHB");
            requestDemoPage.typeCity("Medellin");
            requestDemoPage.selectState("CA");

            //9.Click Submit button.
            requestDemoPage.clickSubmit();
            
            //10. Verify that following validation errors are displayed on the page:
            //a.Please correct the errors below: header is displayed on top.
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(requestDemoPage.FORM_ERROR_MESSAGE));
            //b.This field is required error displayed next to Services offered field.
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(requestDemoPage.FIELD_SERVICES_OFFERED_ERROR_MESSAGE));
            //c.Invalid CAPTCHA error displayed next to Captcha element.
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(requestDemoPage.CAPTCHA_ERROR_MESSAGE));
            

            //11.Close the Browser.
            DriverInstance.driver.Close();
        }

        [TearDown]
        public void tearDown()
        {
            DriverInstance.quit();
        }
    }
}
