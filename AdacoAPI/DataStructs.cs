using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;

namespace AdacoAPI
{
    // TODO: REWRITE USING HANDS
    public class DataStructs
    {   
        public struct MethodStruct
        {
            public MethodStruct(string name, string resource, string type)
            {
                this.Name = name;
                this.Resource = resource;
                this.Type = type;
            }

            public string Name { get; }
            public string Resource { get; }
            public string Type { get; }
        }

        public struct MethodListStruct
        {
            private IList<MethodStruct> methodList;
            public MethodListStruct(MethodStruct[] list)
            {
                methodList = new ReadOnlyCollection<MethodStruct>(list);
            }
            public bool NameExists(string name)
            {
                return this.methodList.Any(element => element.Name == name);
            }

            public MethodStruct MethodStructByName(string name)
            {
                return this.methodList.FirstOrDefault(element => element.Name == name);
            }
            public string ResourceByName(string name)
            {
                foreach (MethodStruct element in this.methodList)
                {
                    if (element.Name == name) return element.Resource;
                }
                return string.Empty;
            }
            public List<string> RequestParams(string name)
            {
                List<string> result = this.methodList.First(m => m.Name == name).Resource.Split('{', '}').Where((part, index) => index % 2 != 0).ToList();
                return result;
            }
        }

        public struct RequestData
        {
            public string Method { get; set; }
            public Uri Uri { get; set; }
            public Dictionary<string, string> Headers { get; set; }
            public HttpContent Media { get; set; }
            public RequestData concat(RequestData req1, RequestData req2)
            {
                req1.Method = (req1.Method.Length > req2.Method.Length) ? req1.Method : req2.Method;
                req1.Uri = (req1.Uri.ToString().Length > req2.Uri.ToString().Length) ? req1.Uri : req2.Uri;
                req1.Media = (req1.Media.ToString().Length > req2.Media.ToString().Length) ? req1.Media : req2.Media;
                if (req1.Headers.Keys.Any(key1 => req2.Headers.Keys.Any(key2 => (key1 == key2)&(req1.Headers[key1].Length > 0)&(req2.Headers[key2].Length > 0))))
                {
                    return req1;
                }
                req1.Headers = req1.Headers.Concat(req2.Headers).ToDictionary(x => x.Key, x => x.Value);
                return req1;
            }
        }

        public struct FormData
        {
            public string MethodName { get; set; }
            public string Endpoint { get; set; }
            public Dictionary<string,string> AdacoHeaders { get; set; } 
            public Dictionary<string,string> Parameters { get; set; } 
            public string Request { get; set; }
            public string Response { get; set; }

        }
    }
}