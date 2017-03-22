using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdacoAPI
{
    internal class Data : DataStructs
    {
        // TODO: parse adacoapi contract??
        public static readonly MethodListStruct Methods = new MethodListStruct
            (new[] {
                new MethodStruct ("GetCategories", "/Categories/{classification}?PropertyNumber={propertyNumber}", "GET"),
                new MethodStruct ("GetProperties", "/Properties", "GET"),
                new MethodStruct ("GetPropertyNumberById", "/Property/{propertyIdentifier}", "GET"),
                new MethodStruct ("GetAllProducts", "/Product/{classification}?PropertyNumber={propertyNumber}", "GET"),
                new MethodStruct ("GetPropertyProducts", "/Product/{classification}/PropertyNumber/{propertyNumber}", "GET"),
                new MethodStruct ("GetProductByNumber", "/Product/ProductNumber/{productNumber}?PropertyNumber={propertyNumber}", "GET"),
                new MethodStruct ("GetProductById", "/Product?ProductIdentifier={productIdentifier}&PropertyNumber={propertyNumber}", "GET"),
                new MethodStruct ("GetProductByNumberAndDetail", "/Product/ProductNumber/{productNumber}/DetailNumber/{detailNumber}?PropertyNumber={propertyNumber}", "GET"),
                new MethodStruct ("GetProduct", "/Product/ProductNumber/{productNumber}/DetailNumber/{detailNumber}/PropertyNumber/{propertyNumber}", "GET"),
                new MethodStruct ("CreateProduct", "/Product", "POST"),
                new MethodStruct ("UpdatePropertyProduct", "/Product/ProductNumber/{productNumber}/PropertyNumber/{propertyNumber}", "PUT"),
                new MethodStruct ("UpdateRootProduct", "/Product/ProductNumber/{productNumber}", "PUT"),
                new MethodStruct ("MergeProductDetails", "/Product/ProductNumber/{productNumber}/DetailNumber/{detailNumber}", "DELETE"),
                new MethodStruct ("MergeProducts", "/Product/ProductNumber/{productNumber}", "DELETE"),
                new MethodStruct ("ResetDataBase", "/Product/PropertyNumber/{propertyNumber}", "DELETE"),
                new MethodStruct ("UpdateCoreList", "/CoreListProduct?PropertyNumber={propertyNumber}", "PUT"),
                new MethodStruct ("GetCoreList", "/CoreListProduct?PropertyNumber={propertyNumber}", "GET"),
            });

        public static FormData OnFormData;

        public static RequestData CurrentRequest;

        // TODO: dispose after usage
        
    }
}
