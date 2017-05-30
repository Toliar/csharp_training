using System;
using System.Collections.Generic;
using System.IO;
using WebAddressbookTests;
using System.Xml.Serialization;
using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using System.Linq;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string datatype = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];

            if (datatype == "groups")
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });

                }
                if (format == "excel")
                {
                    writeGroupsToExcelFile(groups, filename);
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter(filename))
                    {
                        if (format == "csv")
                        {
                            writeGroupsToCsvFile(groups, writer);
                        }
                        else if (format == "xml")
                        {
                            writeToXmlFile(groups, writer);
                        }
                        else if (format == "json")
                        {
                            writeToJsonFile(groups, writer);
                        }
                        else
                        {
                            Console.Out.Write("Unrecognized format " + format);
                        }
                    }
                    //  writer.Close();

                }
            }
            else if (datatype == "contacts")
            {
                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData()
                    {
                        Firstname = TestBase.GenerateRandomString(10),
                        Lastname = TestBase.GenerateRandomString(10)
                    });

                }
                
                    using (StreamWriter writer = new StreamWriter(filename))
                    {
                      
                        if (format == "xml")
                        {
                            writeToXmlFile(contacts, writer);
                        }
                        else if (format == "json")
                        {
                            writeToJsonFile(contacts, writer);
                        }
                        else
                        {
                            Console.Out.Write("Unrecognized format " + format);
                        }
                    }
                    //  writer.Close();

                

            }
         
        }

        static void writeGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;
            // sheet.Cells[1, 1] = "test";
            int row = 1;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++; 
            }
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);
            wb.Close();
            app.Visible = false;
            app.Quit();
            //12.46

        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
            
        }
        static void writeToXmlFile(IEnumerable<object> items, StreamWriter writer)
        {
            new XmlSerializer(items.GetType()).Serialize(writer, items);
        }
        static void writeToJsonFile(IEnumerable<object> items, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(items, Newtonsoft.Json.Formatting.Indented));    
        }
    }
}
