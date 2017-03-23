using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AdacoAPI.DataStructs;
using static AdacoAPI.DataValidator;

namespace AdacoAPI
{
    public static class MainAuth
    {
        private static readonly HMACMD5 hmac = new HMACMD5(Encoding.ASCII.GetBytes("016FC98C-22B9-40AC-80A2-C47D916F5548"));
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AdacoAPIForm());
        }

        public static List<string> GetAuthKey(Uri uri)
        {
            List<string> result = new List<string>();
            result.Add(DateTime.Now.ToString());
            result.Add(Convert.ToBase64String(hmac.ComputeHash(Encoding.ASCII.GetBytes(uri.ToString() + result[0]))));

            return result;
        }
    }
}
