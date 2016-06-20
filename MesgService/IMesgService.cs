using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MesgService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMesgService" in both code and config file together.
    [ServiceContract]
    public interface IMesgService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "messages")]
        List<Product> GetMessages();

        [OperationContract]
        [WebInvoke(Method="POST", ResponseFormat=WebMessageFormat.Json, UriTemplate="messages/{message}", BodyStyle=WebMessageBodyStyle.Bare)]
        int AddMessage(String message);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "messages/delete/{id}", ResponseFormat=WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        int DeleteMessage(string id);

    }
}
