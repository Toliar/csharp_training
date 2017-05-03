using System;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
      //  private string name;
      //  private string header=""; поле
      // private string footer = "";
        public GroupData(string name)
        //свойство Name
        {
            this.Name = name;
        }
        public bool Equals(GroupData other)
        {
           if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
           if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }
        public override int  GetHashCode()
        {
            //  return 0;
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + Name;
        }
        public int CompareTo(GroupData other)
        {
            if(Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
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
