using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using NUnit.Framework;

namespace Gruyere
{
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidData()
        {
            AccountData account = new AccountData(Settings.Login, Settings.Password);
            app.Auth.SignIn(account);
        }

        [Test]
        public void LoginWithInvalidData()
        {
            AccountData account = new AccountData(Settings.InvalidLogin, Settings.Password);
            app.Auth.SignIn(account);
        }
    }
}