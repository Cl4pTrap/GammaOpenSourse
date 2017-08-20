using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Text.RegularExpressions;

namespace Test_Word
{
    public partial class Form1 : Form
    {
        public string StartupWay = Application.StartupPath.ToString();
        public Form1()
        {
            InitializeComponent();
            TBOrder.Text = "контракта № 34/3.ЭА.У-ИТ17 от 14.06.2017г.";
            TBYear.Text = DateTime.Now.Year.ToString();
            TBDay.Text = DateTime.Now.Day.ToString();

            string[] data = System.IO.File.ReadAllLines(Application.StartupPath + "\\SKZI.csv", Encoding.Default);
            foreach (var line in data) { CBSKZI.Items.Add(line); }

            string[] workers = System.IO.File.ReadAllLines(Application.StartupPath + "\\Workers.csv", Encoding.Default);
            foreach (var fio in workers)
            { CBInstaller.Items.Add(fio); }

            switch (DateTime.Now.Month)
            {
                case 1:
                    CBMonth.SelectedIndex = 0;
                    break;
                case 2:
                    CBMonth.SelectedIndex = 1;
                    break;
                case 3:
                    CBMonth.SelectedIndex = 2;
                    break;
                case 4:
                    CBMonth.SelectedIndex = 3;
                    break;
                case 5:
                    CBMonth.SelectedIndex = 4;
                    break;
                case 6:
                    CBMonth.SelectedIndex = 5;
                    break;
                case 7:
                    CBMonth.SelectedIndex = 6;
                    break;
                case 8:
                    CBMonth.SelectedIndex = 7;
                    break;
                case 9:
                    CBMonth.SelectedIndex = 8;
                    break;
                case 10:
                    CBMonth.SelectedIndex = 9;
                    break;
                case 11:
                    CBMonth.SelectedIndex = 10;
                    break;
                case 12:
                    CBMonth.SelectedIndex = 11;
                    break;
            }
        }

        public void Authentication(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://help.khv.nppgamma.ru/admin/admin_main.php");
            request.Method = "POST";
            string data = "user=mitryaev.v&password=#Sm3BAn1";
            byte[] byteData = Encoding.UTF8.GetBytes(data);
            request.ContentLength = byteData.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(byteData, 0, byteData.Length);
            string response = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
            textBox1.Text = response;
            //send("https://help.khv.nppgamma.ru/admin/index.php",)
        }

        /*public string send(string url, string par)
        {
            String secondStepForm3 = par;
            HttpWebRequest request3 = (HttpWebRequest)WebRequest.Create(url);
            request3.UserAgent = "Opera/9.80";
            request3.Method = "POST";
            request3.ContentType = "application/x-www-form-urlencoded";
            byte[] EncodedPostParams3 = Encoding.Default.GetBytes(secondStepForm3);
            request3.ContentLength = EncodedPostParams3.Length;
            request3.GetRequestStream().Write(EncodedPostParams3, 0, EncodedPostParams3.Length);
            request3.GetRequestStream().Close();
            HttpWebResponse response = (HttpWebResponse)request3.GetResponse();
            string lol = new StreamReader(response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
            return lol;
        }*/

        public void Change(object sender, EventArgs e)
        {
            TBWorker.Text = "";
            TBWorkerPost.Text = "";
            label2.Text = "";
            string s = CBInstaller.Text;
            string ss;
            char[] ch = new char[s.Length];
            char[] ch1 = new char[s.Length];
            ch = s.ToCharArray();
            for (int i = 0; i < s.Length; i++)
            {
                ss = label2.Text;
                if (ch[i].ToString() == ";")
                {
                    TBWorker.Text = ss;
                    break;
                }
                label2.Text += ch[i];
            }
            label2.Text = "";
            int a = 0;
            int b = s.Length - 1;
            ch = s.ToCharArray();
            for (int i = b; i >= 0; i--)
            {
                if (ch[i].ToString() == ";")
                {
                    for (int j = a; j >= 0; j--)
                    {
                        label2.Text += ch1[j];
                    }
                    TBWorkerPost.Text = label2.Text;
                    break;
                }
                a += 1;
                ch1[b - i] = ch[i]; 
            }
        }

        private void ReplaceWordStub(string Find, string Replace, Word.Document docFind)
        {
            var Range = docFind.Content;
            Range.Find.ClearFormatting();
            Range.Find.Execute(FindText: Find, ReplaceWith: Replace);
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            Word.Application app = new Word.Application();
            app.Visible = false;
            var doc = app.Documents.Open(Application.StartupPath + @"\555.dot");
            try
            { 
                ReplaceWordStub("$DirectorPost", TBDirectorPost.Text, doc);
                ReplaceWordStub("$DirectorName", TBDirectorName.Text, doc);
                ReplaceWordStub("$Foundation", TBFoundation.Text, doc);
                ReplaceWordStub("$Foundation", TBFoundation.Text, doc);
                ReplaceWordStub("$Foundation", TBFoundation.Text, doc);
                ReplaceWordStub("$Day", TBDay.Text, doc);
                ReplaceWordStub("$Month", CBMonth.SelectedItem.ToString(), doc);
                ReplaceWordStub("$Year", TBYear.Text, doc);
                ReplaceWordStub("$Year", TBYear.Text, doc);
                ReplaceWordStub("$Year", TBYear.Text, doc);
                ReplaceWordStub("$UserIni", TBUser.Text, doc);
                ReplaceWordStub("$UserIni", TBUser.Text, doc);
                ReplaceWordStub("$UserIni", TBUser.Text, doc);
                ReplaceWordStub("$WorkerPost", TBWorkerPost.Text, doc);
                ReplaceWordStub("$WorkerPost", TBWorkerPost.Text, doc);
                ReplaceWordStub("$WorkerName", TBWorker.Text, doc);
                ReplaceWordStub("$WorkerName", TBWorker.Text, doc);
                ReplaceWordStub("$AdminPost", TBPostRes.Text, doc);
                ReplaceWordStub("$AdminPost", TBPostRes.Text, doc);
                ReplaceWordStub("$AdminName", TBResponsible.Text, doc);
                ReplaceWordStub("$AdminName", TBResponsible.Text, doc);
                ReplaceWordStub("$CabinetNum", TBCabinet.Text, doc);
                ReplaceWordStub("$PCNumber", TBPC.Text, doc);
                ReplaceWordStub("$Order", TBOrder.Text, doc);
                ReplaceWordStub("$Print", TBOrder1.Text, doc);
                ReplaceWordStub("$Print", TBOrder2.Text, doc);
                ReplaceWordStub("$VersionSKZI", CBSKZI.SelectedItem.ToString(), doc);
                ReplaceWordStub("$VersionSKZI", CBSKZI.SelectedItem.ToString(), doc);
                switch (CBAct.SelectedIndex)
                {
                    case 0:
                        ReplaceWordStub("$ActSKZI", "0", doc);
                        break;
                    case 1:
                        ReplaceWordStub("$ActSKZI", "1-1", doc);
                        break;
                    case 2:
                        ReplaceWordStub("$ActSKZI", "1-2", doc);
                        break;
                    case 3:
                        ReplaceWordStub("$ActSKZI", "1-3", doc);
                        break;
                    case 4:
                        ReplaceWordStub("$ActSKZI", "1-20", doc);
                        break;
                    case 5:
                        ReplaceWordStub("$ActSKZI", "2", doc);
                        break;
                    case 6:
                        ReplaceWordStub("$ActSKZI", "3", doc);
                        break;
                    case 7:
                        ReplaceWordStub("$ActSKZI", "4", doc);
                        break;
                    case 8:
                        ReplaceWordStub("$ActSKZI", "5", doc);
                        break;
                    case 9:
                        ReplaceWordStub("$ActSKZI", "20", doc);
                        break;
                }
                ReplaceWordStub("$ActDst", Act, doc);
                ReplaceWordStub("$UserName", TBRegCard.Text, doc);
                ReplaceWordStub("$DSTNum", TBKey.Text, doc);
                ReplaceWordStub("$RegisterCardNum", TBRegCard.Text, doc);
                ReplaceWordStub("$Instruction", "Да", doc);
                ReplaceWordStub("$Contacts", "Да", doc);
                Saving.ShowDialog();
                doc.SaveAs(FileName: Saving.FileName, FileFormat: Word.WdSaveFormat.wdFormatDocument);
                app.Visible = true;
                doc.Close();
                app.Quit();
                MessageBox.Show("Success!");
            }
            catch (Exception ex)
            {   
                MessageBox.Show(ex.Message);
            } 
        }

        public string WayToFolder;
        public string Act;
        private void BTNKey_Click(object sender, EventArgs e)
        {
            try
            {
                Act = "";
                int a = 0;
                TBKey.Text = "";
                TBRegCard.Text = "";
                OpenDistr.ShowDialog();
                int aa;
                int aaa = 0;
                WayToFolder = OpenDistr.FileName;
                string WayToFile = OpenDistr.FileName;
                char[] ss = WayToFile.ToCharArray();
                aa = ss.Count() - 1;
                char[] sss = new char[aa];
                for (int i = aa; i >= 0; i--)
                {
                    if (ss[i].ToString() == "\\")
                    {
                        for (int j = aaa; j >= 0; j--)
                        {
                            TBKey.Text += sss[j];
                        }
                        break;
                    }
                    sss[aa - i] = ss[i];
                    aaa += 1;
                }
                ss = WayToFolder.ToCharArray();
                aa = ss.Count() - 1;
                sss = new char[aa];
                label2.Text = "";
                aaa = 0;
                for (int i = aa; i >= 0; i--)
                {
                    if (ss[i].ToString() == "\\")
                    {
                        a += 1;
                        if (a == 2)
                        {
                            for (int j = aaa; j >= 0; j--)
                            {
                                if (sss[j].ToString() == "(")
                                { break; }
                                label2.Text += sss[j];
                                Act = label2.Text;
                            }
                            break;
                        }
                    }
                    aaa += 1;
                    sss[aa - i] = ss[i];
                }
                a = 0;
                aaa = 0;
                ss = WayToFolder.ToCharArray();
                aa = ss.Count() - 1;
                sss = new char[aa];
                for (int i = aa; i >= 0; i--)
                {
                    if (ss[i].ToString() == "\\")
                    {
                        a += 1;
                        if (a == 2)
                        {
                            for (int j = aaa; j >= 0; j--)
                            {
                                if (sss[j].ToString() == "\\")
                                { break; }
                                TBRegCard.Text += sss[j];
                            }
                            break;
                        }
                    }
                    aaa += 1;
                    sss[aa - i] = ss[i];
                }
                TBDistr.Text = Act;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Убедитесь, что указали корректный путь и файл!");
            }  
        }
    }
}
