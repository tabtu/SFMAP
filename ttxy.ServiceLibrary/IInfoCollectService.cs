using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.IO;

using ttxy.Model;

namespace ttxy.Host
{
    //JSON传输
    [ServiceContract]
    public interface IttxyServiceJson
    {
        [OperationContract(Name = "echoJson")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "echo/{Message}", BodyStyle = WebMessageBodyStyle.Bare)]
        string echo (string Message);
    }

    //XML传输
    [ServiceContract]
    public interface IttxyServiceXml
    {
        [OperationContract(Name = "echoXml")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "echo/{Message}", BodyStyle = WebMessageBodyStyle.Bare)]
        string echo (string Message);
    }
}
