using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

namespace HostService
{
    class Program
    {
        static void Main(string[] args)
        {

            using (ServiceHost host = new ServiceHost(typeof(MesgService.MesgService)))
            {
                host.Open();
                Console.WriteLine("Hosting started @ " + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}
