using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)

        {
            string dataType = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];

            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                    Header = TestBase.GenerateRandomString(100),
                    Footer = TestBase.GenerateRandomString(100),
                });
             
            }
            List<ContactsData> contacts = new List<ContactsData>();
            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactsData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                {
                    Middlename = TestBase.GenerateRandomString(10),
                    Address = TestBase.GenerateRandomString(15),
                    MobilePhone = TestBase.GenerateRandomString(11),
                    HomePhone = TestBase.GenerateRandomString(11),
                    Email = TestBase.GenerateRandomString(10),
                    Title = TestBase.GenerateRandomString(5)

                });
            }
             StreamWriter writer = new StreamWriter(filename);

            if (dataType == "groups")
            {
                if (format == "xml")
                {
                    writeGroupsToXmlFile(groups, writer);
                }

                
                 else
                 {
                    if (format == "json")
                    {
                        writeGroupsToJsonFile(groups, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Unrecognized format" + format);
                    }

                    writer.Close();
                }
            }
            else if (dataType == "contacts")
            {
                if (format == "xml")
                {
                    WriteContactsToXmlFile(contacts, writer);
                }
                else
                {
                    if (format == "json")
                    {
                        WriteContactsToJsonile(contacts, writer);
                    }

                    else
                    {
                        System.Console.Out.Write("Unrecognized format: " + format);
                    }
                    writer.Close();
                }
            }
            else System.Console.Out.Write("Unrecognized data type: " + dataType);

            }

        public static void writeGroupsToExcelFileLiast(List<GroupData> groups, string filename)
        {
           Excel.Application app = new Excel.Application();
           app.Visible = true;
           Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;
            //sheet.Cells[1, 1] = "test";
            int row = 1;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row, 1] =group.Name;
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
        }

        static void writeGroupsToCsvFileLiast(List<GroupData> groups, StreamWriter writer )
        {
            foreach (GroupData group in groups)
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
        }
      static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
    {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);

    }
        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));  

        }
        static void WriteContactsToXmlFile(List<ContactsData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactsData>)).Serialize(writer, contacts);
        }
        static void WriteContactsToJsonile(List<ContactsData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }



    }
}
