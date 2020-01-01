﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionMobile.UnitTests.Presenters
{
    using Common;
    using Moq;
    using Pages;
    using Shouldly;
    using TransactionMobile.Presenters;
    using ViewModels;
    using Xunit;

    public class LoginPresenterTests
    {
        [Fact]
        public void LoginPresenter_CanBeCreated_IsCreated()
        {
            Mock<ILoginPage> loginPage = new Mock<ILoginPage>();
            LoginViewModel loginViewModel = new LoginViewModel();
            Mock<IDevice> device = new Mock<IDevice>();

            LoginPresenter loginPresenter = new LoginPresenter(loginPage.Object,loginViewModel, device.Object);

            loginPresenter.ShouldNotBeNull();
        }
    }
}
