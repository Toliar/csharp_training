using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class GroupData
    {
      //  private string name;
      //  private string header=""; поле
      // private string footer = "";
        public GroupData(string name)
        //свойство Name
        {
            this.Name = name;
        }
    //    public GroupData(string name,string header, string footer)
    //    {
   //         this.Name = name;
    //        this.Header = header;
   //         this.Footer = footer;
   //     }
        public string Name { get; set; }
        public string Header { get; set; } = "";
        public string Footer { get; set; } = "";
    }
}
