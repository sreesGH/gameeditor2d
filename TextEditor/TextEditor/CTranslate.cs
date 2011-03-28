using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Net;

namespace TextEditor
{
    public class CTranslate
    {
        public string[] m_languageCode = { "af", "sq", "am", "ar", "hy", "az", "eu", "be", "bn", "bh",
                                    "br", "bg", "my", "ca", "chr", "zh", "zh-CN", "zh-TW", "co", "hr",
                                    "cs", "da", "dv", "nl", "en", "eo", "et", "fo", "tl", "fi",
                                    "fr", "fy", "gl", "ka", "de", "el", "gu", "ht", "iw", "hi",
                                    "hu", "is", "id", "iu", "ga", "it", "ja", "jw", "kn", "kk",
                                    "km", "ko", "ku", "ky", "lo", "la", "lv", "lt", "lb", "mk",
                                    "ms", "ml", "mt", "mi", "mr", "mn", "ne", "no", "oc", "or",
                                    "ps", "fa", "pl", "pt", "pt-PT", "pa", "qu", "ro", "ru", "sa",
                                    "gd", "sr", "sd", "si", "sk", "sl", "es", "su", "sw", "sv",
                                    "sy", "tg", "ta", "tt", "te", "th", "bo", "to", "tr", "uk",
                                    "ur", "uz", "ug", "vi", "cy", "yi", "yo"
                                  };

        string site = "https://www.googleapis.com/language/translate/v2?key=";
        string key = "AIzaSyC7ucoWylTqp9AY65yCf3b9aFQ8M7cbZLs";
        string source = "&source=";
        string m_sourceLanguage = "en";
        string target = "&target=";
        string m_targetLanguage = "fr";
        string fnc = "&callback=translationResponseHandler&q=";
        string m_text = "hotdogs and hamburgers";

        public void InitTranslation(string sourceL, string targetL)
        {
            m_sourceLanguage = sourceL;
            m_targetLanguage = targetL;
        }

        public void SetData(string txt)
        {
            m_text = txt;
        }

        public string Translate()
        {
            // Create URL. 
            string url = site + key + source + m_sourceLanguage + target + m_targetLanguage + fnc + m_text;

            // Create a request for the URL. 
            WebRequest request = WebRequest.Create(url);

            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;

            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Check status.
            if (response.StatusDescription != "OK")
            {
                Console.WriteLine(response.StatusDescription);
                Console.WriteLine("Request failed");
            }

            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();

            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);

            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            string start = "translatedText";
            string translatedText = responseFromServer.Substring(responseFromServer.IndexOf(start) + start.Length + 4, responseFromServer.Length - (responseFromServer.IndexOf(start) + start.Length + 4 + 18));

            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();

            return translatedText;
        }
    }
}
