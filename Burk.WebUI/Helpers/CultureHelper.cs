using Burk.Model.Misc;
using System;
using System.Globalization;
using System.Threading;
using System.Web.SessionState;

namespace Burk.WebUI.Helpers
{
    public class CultureHelper
    {
        protected HttpSessionState session;

        //constructor   
        public CultureHelper(HttpSessionState httpSessionState)
        {
            session = httpSessionState;
        }
        // Properties  
        public static int CurrentCulture
        {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-GB")
                    return (int)Language.en;
                else if (Thread.CurrentThread.CurrentUICulture.Name == "uk-UA")
                    return (int)Language.ua;
                else if (Thread.CurrentThread.CurrentUICulture.Name == "ru-RU")
                    return (int)Language.ru;
                return 0;
            }
            set
            {
                switch (value)
                {
                    case ((int)Language.en):
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
                        break;
                    case ((int)Language.ru):
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
                        break;
                    case ((int)Language.ua):
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("uk-UA");
                        break;
                    default:
                        break;
                }
                Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;
            }
        }
    }
}