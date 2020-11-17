using NUnit.Framework;

namespace Gruyere
{
    public class CreateSnippetTest : TestBase
    {
        [Test]
        public void test()
        {
            SnippetData snippet = new SnippetData("Hello world!");
            app.Snippets.CreateNewSnippet(snippet);
            SnippetData newSnippet = app.Snippets.GetSnippetCreatedData();
            Assert.AreEqual(snippet.SnippetText, newSnippet.SnippetText);
        }
    }
}