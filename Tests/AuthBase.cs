using NUnit.Framework;

namespace Gruyere
{
    public class AuthBase : TestBase
    {
        [SetUp]
        public void SetupTest()
        {
            app = ApplicationManager.GetInstance();
            app.Navigation.OpenHomePage();
            AccountData account = new AccountData(Settings.Login, Settings.Password);
            app.Auth.SignIn(account);
        }
    }
}