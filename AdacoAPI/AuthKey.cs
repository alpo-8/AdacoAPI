using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using static AdacoAPI.DataStructs;

namespace AdacoAPI
{
    static class AuthKey
    {
        private static readonly HMACMD5 hmac = new HMACMD5(Encoding.ASCII.GetBytes("016FC98C-22B9-40AC-80A2-C47D916F5548"));

        public static string GenerateAuthHeader(Uri uri, string time)
        {
            return Convert.ToBase64String(hmac.ComputeHash(Encoding.ASCII.GetBytes(uri.ToString() + time)));

            //request.Headers["Adaco-Timestamp"] = DateTime.Now.ToString();
            //request.Headers["Adaco-Authorization"] = Convert.ToBase64String(hmac.ComputeHash(Encoding.ASCII.GetBytes(request.Uri.ToString() + time)));
            //return result;
        }
    }
}
