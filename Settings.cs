using System;
using System.Xml;
using System.Xml.Serialization;


namespace Gruyere
{
    public static class Settings
    {
        public static string file = "/Users/faritshamardanov/Documents/Gruyere/Settings.xml";
        private static string _baseUrl;
        private static string _login;
        private static string _invalidLogin;
        private static string _password;
        private static XmlDocument document;

        static Settings()
        {
            if (!System.IO.File.Exists(file)) { throw new Exception("Problem: settings file not found: " + file); }
            document = new XmlDocument();
            document.Load(file);
        }

        public static string BaseURL
        {
            get
            {
                if (_baseUrl == null)
                {
                    XmlNode node = document.DocumentElement.SelectSingleNode("BaseURL");
                    _baseUrl = node.InnerText;
                }
                return _baseUrl;
            }
        }
        
        public static string Login
        {
            get
            {
                if (_login == null)
                {
                    XmlNode node = document.DocumentElement.SelectSingleNode("Login");
                    _login = node.InnerText;
                }
                return _login;
            }
        }
        
        public static string InvalidLogin
        {
            get
            {
                if (_invalidLogin == null)
                {
                    XmlNode node = document.DocumentElement.SelectSingleNode("InvalidLogin");
                    _invalidLogin = node.InnerText;
                }
                return _invalidLogin;
            }
        }
        
        public static string Password
        {
            get
            {
                if (_password == null)
                {
                    XmlNode node = document.DocumentElement.SelectSingleNode("Password");
                    _password = node.InnerText;
                }
                return _password;
            }
        }
    }
}