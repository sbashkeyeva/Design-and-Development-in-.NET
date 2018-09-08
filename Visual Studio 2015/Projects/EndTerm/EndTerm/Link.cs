using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace EndTerm
{
    [Serializable()]
    public class Link : ISerializable
    {
        //System.Diagnostics.Process.Start(link)
        
        public Link()
        {

        }
        string name;
        string address;
        string keyWord;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string KeyWord
        {
            get { return keyWord; }
            set { keyWord = value; }
        }

        public Link(string name, string address, string keyWord)
        {
            this.name = name;
            this.address = address;
            this.keyWord = keyWord;
        }
        public Link(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            //EmpId = (int)info.GetValue("EmployeeId", typeof(int));
            Name = (String)info.GetValue("Name", typeof(string));
            Address = (String)info.GetValue("Address", typeof(string));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //You can use any custom name for your name-value pair. But make sure you
            // read the values with the same name. For ex:- If you write EmpId as "EmployeeId"
            // then you should read the same with "EmployeeId"
            //info.AddValue("EmployeeId", EmpId);
            info.AddValue("EmployeeName", Name);
        }


    }
}
