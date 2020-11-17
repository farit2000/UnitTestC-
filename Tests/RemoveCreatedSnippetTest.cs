using NUnit.Framework;

namespace Gruyere
{
    public class RemoveCreatedSnippetTest : TestBase
    {
        [Test]
        public void test()
        {
            app.Snippets.RemoveSnippet();
        }
    }
}