using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MesgService
{
    [DataContract]
    public class Product
    {

        private int Id;
        private string Name;

        [DataMember]
        public int id
        {
            get { return Id; }
            set { Id = value; }
        }

        [DataMember]
        public string name
        {
            get { return Name; }
            set { Name = value; }
        }


    }
}
