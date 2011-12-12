using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using LR.RDDD;
using LR.Paradata;
namespace LR
{
    public class Settings
    {
        static public string LR_Integration_KeyID()
        {
            return (ConfigurationManager.AppSettings["LR_Integration_KeyID"]);
        }
        static public string LR_Integration_NodeUsername()
        {
            return (ConfigurationManager.AppSettings["LR_Integration_NodeUsername"]);
        }
        static public string LR_Integration_NodePassword()
        {
            return (ConfigurationManager.AppSettings["LR_Integration_NodePassword"]);
        }
        static public string LR_Integration_PublishURL()
        {
            return (ConfigurationManager.AppSettings["LR_Integration_PublishURL"]);
        }
        static public string LR_Integration_KeyPassPhrase()
        {
            return (ConfigurationManager.AppSettings["LR_Integration_KeyPassPhrase"]);
        }
        static public string LR_Integration_GPGLocation()
        {
            return (ConfigurationManager.AppSettings["LR_Integration_GPGLocation"]);
        }
        static public string LR_Integration_PublicKeyURL()
        {
            return (ConfigurationManager.AppSettings["LR_Integration_PublicKeyURL"]);
        }
        static public string LR_Integration_SubmitterName()
        {
            return (ConfigurationManager.AppSettings["LR_Integration_SubmitterName"]);
        }
        static public string LR_Integration_SignerName()
        {
            return (ConfigurationManager.AppSettings["LR_Integration_SignerName"]);
        }
    }
}