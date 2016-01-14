using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DiplomskiProjekt
{
    class SPClass
    {
        private string _username;
        private string _password;
        private string _siteUrl;
        public string Username 
        {
            get 
            {
                return _username;
            }
            set 
            {
                _username = value;
            }
        }

        public string Password 
        {
            get 
            {
                return _password;
            }
            set 
            {
                _password = value;
            }
        }
        public string SiteUrl 
        {
            get 
            {
                return _siteUrl;
            }
            set 
            {
                _siteUrl = value;
            }
        }
        public SPClass(string username, string password, string siteUrl)
        {
            Username = username;
            Password = password;
            SiteUrl = siteUrl;
        }

        public ListCollection GetListFromSharePointOnline()
        {
            ListCollection listCollection = null;
            using (ClientContext context = new ClientContext(SiteUrl))
            {
                var password = new SecureString();

                foreach (var c in Password.ToCharArray())
                {
                    password.AppendChar(c);
                }

                context.Credentials = new SharePointOnlineCredentials(Username, password);
                listCollection = context.Web.Lists;
                context.Load(listCollection);
                context.ExecuteQuery();
            }
            return listCollection;
        }
    }
}
