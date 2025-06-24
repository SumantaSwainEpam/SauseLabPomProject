using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration;


namespace SauseLabPomProject.Credentials
{
     public class CredentialProvider
    {
        private static  readonly IConfiguration _configuration;

        static CredentialProvider()
        {
            try
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Path.Combine("Credentials", "AppConfig.json"), optional: false, reloadOnChange: true);
                _configuration = builder.Build();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }

        }

        public (string Username,string Password) GetCredential(string userType)
        {
            var credentials = _configuration.GetSection($"Credentials:{userType}");
            if(credentials==null || !credentials.Exists())
            {
                throw new ArgumentException($"Usertype {userType} not found in configuration.");
            }
            return (credentials["Username"],credentials["Password"]);
        }

        public string GetBaseUrl() 
        {   
            var BaseUrl=_configuration.GetSection("Credentials:AppSettings:BaseUrl").Value;
            if (string.IsNullOrEmpty(BaseUrl))
            {
                throw new InvalidOperationException("BaseUrl is not Configured");
            }
            return BaseUrl; 
            
        }
    }
}
