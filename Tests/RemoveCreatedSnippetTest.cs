using NUnit.Framework;

namespace Gruyere
{
    public class RemoveCreatedSnippetTest : AuthBase
    {
        [Test]
        public void test()
        {
            app.Navigation.GoToMySnippets();
            app.Snippets.RemoveSnippet();
        }
    }
}