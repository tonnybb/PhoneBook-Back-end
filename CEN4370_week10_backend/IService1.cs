using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CEN4370_week10_backend
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet(UriTemplate = "/{lastName}")]
        string[] GetEntries(string lastName);

        [OperationContract]
        [WebGet(UriTemplate = "/{lastName}/{firstName}/{phoneNumber}")]
        string AddEntries(string lastName, string firstName, string phoneNumber);
    }
}
