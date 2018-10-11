using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Web.Script.Serialization;


namespace ScribeDTSMigrator
{
    public partial class Form1 : Form
    {
        XmlDocument xDoc;
        string path;
        string jsonPath;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void commitChange_Click(object sender, EventArgs e)
        {
            replaceString("be2f213c-6a71-4b86-b1c7-a24056cb6182", "369f54e8-86ef-4a84-a94e-a253cd70ea8e");
            replaceString("5b54c81e-3de5-449c-93a8-08bee8c720f8", "1e9abb7c-de5e-4563-bf43-68c1f1521d6a");
            replaceString("fdc60b0b-1b58-4a59-8f9b-01ec536a416d", "18d5df4a-448b-44bc-8edb-d98014f6f279");
            xDoc.Save(@"C:\GitHub\Text Files\test.dts");
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".dts";
            

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                path = dlg.FileName;
                xDoc = new XmlDocument();
                xDoc.Load(path);
                textBox1.Text = dlg.FileName;
                
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        public void replaceString(string guid, string guid2)
        {
            
            foreach (XmlNode node in xDoc.SelectNodes("DTS/DataProviders/DataProvider"))
            {
                if (node.SelectSingleNode("GUID").InnerText == guid && guid2 == "369f54e8-86ef-4a84-a94e-a253cd70ea8e")                    
                {
                    node.SelectSingleNode("GUID").InnerText = guid2;
                    
                    break;
                }
                else if (node.SelectSingleNode("GUID").InnerText == guid && guid2 == "1e9abb7c-de5e-4563-bf43-68c1f1521d6a")
                {
                    node.SelectSingleNode("GUID").InnerText = guid2;
                    
                    break;
                }
                else if (node.SelectSingleNode("GUID").InnerText == guid && guid2 == "18d5df4a-448b-44bc-8edb-d98014f6f279")
                {
                    node.SelectSingleNode("GUID").InnerText = guid2;
                    
                    break;  
                }
                else
                {

                }
            }
            

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void loadConnectionFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadJson();            
            
        }
        public void loadJson()
        {
            OpenFileDialog jsonFile = new OpenFileDialog();
            jsonFile.DefaultExt = ".json";
            //dlg.Filter = "Text documents (.txt)|*.txt";

            //Nullable<bool> result = dlg.ShowDialog();

            if (jsonFile.ShowDialog() == DialogResult.OK)
            {
                jsonPath = jsonFile.FileName;

            }
            string jsonFilePath = jsonPath;
            string scribeConnections = File.ReadAllText(jsonFilePath);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var deserializedResults = serializer.Deserialize<List<ScribeAdapaters>>(scribeConnections);
        }
    }
    public class ScribeAdapaters
    {
        public string Label { get; set; }
        public string ID { get; set; }
    }
   
}
