using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography;

namespace NetworkService.Services
{
    public class CryptographyService
    {
        private readonly string Key = "ntwService";
        

        public async Task<string> Encrypt(string cleanText)
        {
            try
            {

            }
            catch(Exception ex)
            {

            }
        }
    }
}
