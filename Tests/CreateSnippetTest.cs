using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using NUnit.Framework;

namespace Gruyere
{
    [TestFixture]
    public class CreateSnippetTest : AuthBase
    {
        public static IEnumerable<SnippetData> SnippetDataFromXmlFile()
        {
            return (List<SnippetData>) new XmlSerializer(typeof(List<SnippetData>))
                .Deserialize(new StreamReader(@"/Users/faritshamardanov/Documents/DataGenerator/data.xml"));
        }


        [Test, TestCaseSource("SnippetDataFromXmlFile")]
        public void test(SnippetData snippetData)
        {
            SnippetData snippet = new SnippetData(snippetData.SnippetText);
            app.Snippets.CreateNewSnippet(snippet);
            SnippetData newSnippet = app.Snippets.GetSnippetCreatedData();
            Assert.AreEqual(snippet.SnippetText, newSnippet.SnippetText);
        }
    }
}