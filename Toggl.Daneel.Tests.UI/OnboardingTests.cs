﻿using NUnit.Framework;
using Xamarin.UITest.iOS;
using static Toggl.Daneel.Tests.UI.Extensions.OnboardingExtensions;

namespace Toggl.Daneel.Tests.UI
{
    [TestFixture]
    public class OnboardingTests
    {
        private iOSApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            app = Configuration.GetApp();

            app.WaitForOnboardingScreen();
        }

        [Test]
        public void FirstScreenIsTheOnboardingScreen()
        {
            app.Screenshot("Onboarding screen.");
        }

        [Test]
        public void TheNextButtonShowsTheSecondPage()
        {
            app.GoForwardToSecondOnboardingPage();

            app.Screenshot("Onboarding second page.");
        }

        [Test]
        public void SwipingRightOnTheFirstLabelShowsTheSecondPage()
        {
            app.SwipeForwardToSecondOnboardingPage();

            app.Screenshot("Onboarding second page.");
        }

        [Test]
        public void TheBackButtonShowsTheFirstPageAgain()
        {
            app.GoForwardToSecondOnboardingPage();
            app.GoBackToFirstOnboardingPage();

            app.Screenshot("Onboarding first page.");
        }

        [Test]
        public void SwipingLeftOnTheSecondLabelShowsTheFirstPage()
        {
            app.SwipeForwardToSecondOnboardingPage();
            app.SwipeBackToFirstOnboardingPage();

            app.Screenshot("Onboarding first page.");
        }

        [Test]
        public void ClickingNextThriceShowsTheLoginSignupScreen()
        {
            app.GoForwardToSecondOnboardingPage();
            app.GoForwardToThirdOnboardingPage();
            app.GoForwardToFourthOnboardingPage();

            app.Screenshot("Login or Sign up page.");
        }

        [Test]
        public void SwipingRightThriceShowsTheLoginSignupScreen()
        {
            app.SwipeForwardToSecondOnboardingPage();
            app.SwipeForwardToThirdOnboardingPage();
            app.SwipeForwardToFourthOnboardingPage();

            app.Screenshot("Login or Sign up page.");
        }

        [Test]
        public void TheSkipButtonShowsTheLoginSignUpScreen()
        {
            app.SkipToLastOnboardingPage();

            app.Screenshot("Login or Sign up page.");
        }

        [Test]
        public void TheLoginButtonOpensTheLoginScreen()
        {
            app.SkipToLastOnboardingPage();
            app.OpenLoginFromOnboardingLastPage();

            app.Screenshot("Login screen.");
        }
    }
}
