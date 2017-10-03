using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Net;
using BarcodeLib;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using System.Resources;

namespace Mongoose
{
    public partial class Form1 : Form
    {
        
        public void ChangeCBCityCheck1(object sender, EventArgs e)
        {
            if (CBCity1.Checked)
            { CBCity2.Checked = false; }
        }
        public void ChangeCBCityCheck2(object sender, EventArgs e)
        {
            if (CBCity2.Checked)
            { CBCity1.Checked = false; }
        }
        public void ChangeCBCityCheck21(object sender, EventArgs e)
        {
            if (CBCity21.Checked)
            { CBCity22.Checked = false; }
        }
        public void ChangeCBCityCheck22(object sender, EventArgs e)
        {
            if (CBCity22.Checked)
            { CBCity21.Checked = false; }
        }
        public void ChangeCBFoundationContracter(object sender, EventArgs e)
        {
            if (CBFoundationContracter.Checked)
            {
                TBFoundationContracter1.Visible = true;
                ActiveForm.Size = new Size(1053,648);
                GBInstaller1.Size = new Size(653, 499);
                TABAll.Size = new Size(1018, 597);
                CBAct1.Enabled = false;
                BTNKey1.Enabled = false;
                TBKey1.Enabled = false;
                TBRegCard1.Enabled = false;
                CBUnit1.Enabled = false;
                CBInstaller1.Enabled = false;
                
            }
            else
            {
                TBFoundationContracter1.Visible = false;
                ActiveForm.Size = new Size(711, 648);
                GBInstaller1.Size = new Size(327, 499);
                TABAll.Size = new Size(691, 597);
            }
        }
        public string BarActReader;
        public string BarActWriter;
        public string WP1;
        public string WP2;
        public string StartupWay = Application.StartupPath.ToString();
        public string WorkerLatStr;
        public string WayToFolder;
        public string Act;
        public List<string> SKZIList = new List<string> { };
        public List<string> Workers = new List<string> { };

        public Form1()
        {
            InitializeComponent();
            
            GBInstaller1.Size = new Size(327, 499);
            TABAll.Size = new Size(691, 597);
            TBOrder1.Text = "контракта № 34/3.ЭА.У-ИТ17 от 14.06.2017г.";
            TBYear1.Text = DateTime.Now.Year.ToString();
            TBDay1.Text = DateTime.Now.Day.ToString();
            string[] data = System.IO.File.ReadAllLines(Application.StartupPath + "\\SKZI.csv", Encoding.Default);
            foreach (var line in data) { SKZIList.Add(line); }
            CBSKZI1.DataSource = SKZIList;
            CBUnit1.SelectedIndex = 6;
            CBBarAct1.Checked = true;
            CBBarAct2.Checked = true;
            string[] WorkersKir = System.IO.File.ReadAllLines(Application.StartupPath + "\\WorkersKir.csv", Encoding.Default);
            foreach (var fio in WorkersKir) { Workers.Add(fio); }
            CBInstaller1.DataSource = Workers;
            CBInstaller2.DataSource = Workers;
           
            /* try
            {
                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://help.khv.nppgamma.ru/files/WorkersKir.csv");
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.UserAgent = @"Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.11 (KHTML, like Gecko) Chrome/17.0.963.83 Safari/535.11";
                request.KeepAlive = true;
                string data1 = "";
                byte[] byteData = Encoding.Unicode.GetBytes(data1);
                request.ContentLength = byteData.Length;
                Stream stream = request.GetRequestStream();
                stream.Write(byteData, 0, byteData.Length);
                string response = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.Default).ReadToEnd();
                string[] Write = response.Split((char)0x0A);
                foreach (var line in Write) { Workers.Add(line); }
                CBInstaller1.DataSource = Workers;
                CBInstaller2.DataSource = Workers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось соединиться с сервером.");
                string[] WorkersKir = System.IO.File.ReadAllLines(Application.StartupPath + "\\WorkersKir.csv", Encoding.Default);
                foreach (var fio in WorkersKir) { Workers.Add(fio); }
                foreach (var fio in WorkersKir) { Workers.Add(fio); }
            }

            /* byte[] ResourceRef;
             ResourceRef = Properties.Resources.DocX;
             System.IO.File.WriteAllBytes(Application.StartupPath + "\\Test Word.exe", ResourceRef);
             ResourceRef = Properties.Resources.BarcodeLib;
             System.IO.File.WriteAllBytes(Application.StartupPath + "\\Test Word.exe", ResourceRef);*/


            // AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            // AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;


            switch (DateTime.Now.Month)
            {
                case 1: CBMonth1.SelectedIndex = 0; break;
                case 2: CBMonth1.SelectedIndex = 1; break;
                case 3: CBMonth1.SelectedIndex = 2; break;
                case 4: CBMonth1.SelectedIndex = 3; break;
                case 5: CBMonth1.SelectedIndex = 4; break;
                case 6: CBMonth1.SelectedIndex = 5; break;
                case 7: CBMonth1.SelectedIndex = 6; break;
                case 8: CBMonth1.SelectedIndex = 7; break;
                case 9: CBMonth1.SelectedIndex = 8; break;
                case 10: CBMonth1.SelectedIndex = 9; break;
                case 11: CBMonth1.SelectedIndex = 10; break;
                case 12: CBMonth1.SelectedIndex = 11; break;
            }
        }

        public static void AddElementCB(string s, ref ComboBox cb)
        {
            cb.SelectedItem = s;
        }

        public static void AddElementTB(string s, ref TextBox tb)
        {
            tb.Text = s;
        }

        /*private static Assembly CurrentDomain_AssemblyResolve1(object sender, ResolveEventArgs args)
        {
            var assemblyName = new AssemblyName(args.Name).Name;
            switch (assemblyName)
             {
                case "BarcodeLib":
                    using (var stream = typeof(Program).Assembly.GetManifestResourceStream("TestWord." + assemblyName + ".dll"))
                    {
                        byte[] assemblyData = new byte[stream.Length];
                        stream.Read(assemblyData, 0, assemblyData.Length);
                        return Assembly.Load(assemblyData);
                    }
                case "DocX":
                    using (var stream = typeof(Program).Assembly.GetManifestResourceStream("TestWord." + assemblyName + ".dll")) 
                    {
                        byte[] assemblyData = new byte[stream.Length];
                        stream.Read(assemblyData, 0, assemblyData.Length);
                        return Assembly.Load(assemblyData);
                    }
                default:
                    return null;
             }
        }*/

        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        /*public void Authentication(object sender, EventArgs e)
        {
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://help.khv.nppgamma.ru/files/WorkersKir.csv");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = @"Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.11 (KHTML, like Gecko) Chrome/17.0.963.83 Safari/535.11";
            request.KeepAlive = true;
            string data = "";            
            byte[] byteData = Encoding.Unicode.GetBytes(data);
            request.ContentLength = byteData.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(byteData, 0, byteData.Length);
            string response = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.Default).ReadToEnd();
            textBox1.Text = response;
            textBox1.ScrollBars = ScrollBars.Vertical;
        }*/

        public void ReplaceWordStub(string Find, string Replace, Word.Document docFind)
        {
            var Range = docFind.Content;
            Range.Find.ClearFormatting();
            Range.Find.Execute(FindText: Find, ReplaceWith: Replace);
        }

        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var newImage = new Bitmap(maxWidth, maxHeight);
            using (var graphics = Graphics.FromImage(newImage))
            graphics.DrawImage(image, 0, 0, maxWidth, maxHeight);
            return newImage;
        }

        public string ToIni(string FIO)
        {
            string NewFIO = "";
            int a = 0;
            char[] ch = FIO.ToCharArray();
            for (int i = 0; i < ch.Count(); i++)
            {
                if (ch[i] == ' ')
                {
                    char ch1 = ch[i + 1];
                    ch1 = char.ToUpper(ch1);
                    NewFIO += " ";
                    NewFIO += ch1 + ".";
                    break;
                }
                NewFIO += ch[i];
            }
            for (int i = 0; i < ch.Count(); i++)
            {
                if (ch[i] == ' ')
                {
                    a++;
                }
                if (a == 2)
                {
                    NewFIO += ch[i];
                    char ch1 = ch[i + 1];
                    ch1 = char.ToUpper(ch1);
                    NewFIO += ch1 + ".";
                    break;
                }
            }
            return NewFIO;
        }

        public string ToIniRollover(string FIO)
        {
            string NewFIO = "";
            int a = 0;
            char[] ch = FIO.ToCharArray();
            for (int i = 0; i < ch.Count(); i++)
            {
                if (ch[i] == ' ')
                {
                    char ch1 = ch[i + 1];
                    ch1 = char.ToUpper(ch1);
                    NewFIO += " ";
                    NewFIO += ch1 + ".";
                    break;
                }
                NewFIO += ch[i];
            }
            for (int i = 0; i < ch.Count(); i++)
            {
                if (ch[i] == ' ')
                {
                    a++;
                }
                if (a == 2)
                {
                    NewFIO += ch[i];
                    char ch1 = ch[i + 1];
                    ch1 = char.ToUpper(ch1);
                    NewFIO += ch1 + ".";
                    break;
                }
            }
            ch = NewFIO.ToCharArray();
            NewFIO = "";
            a = ch.Count();
            int b = 5;
            for (int i = 0; i < a; i++)
            {
                NewFIO += ch[a-b];
                b--;
                if (b == 0)
                {
                    NewFIO += ' ';
                    for (int k = 0; k < a; k++)
                    {
                        NewFIO += ch[k];
                        if (ch[k] == ' ')
                        {
                            break;
                        }
                    }
                    break;
                }
            }
            return NewFIO;
        }

        private void BTNCreateWord1_Click(object sender, EventArgs e)
        {
            Word.Application app = new Word.Application
            {
                Visible = false
            };
            var doc = app.Documents.Open(Application.StartupPath + @"\ActSetup.dot");
            try
            { 
                ReplaceWordStub("$DirectorPost", TBDirectorPost1.Text, doc);
                ReplaceWordStub("$DirectorIni", ToIniRollover(TBDirectorName1.Text), doc);
                ReplaceWordStub("$FoundationClient", TBFoundation1.Text, doc);
                ReplaceWordStub("$FoundationClient", TBFoundation1.Text, doc);
                ReplaceWordStub("$Unit", CBUnit1.SelectedItem.ToString(), doc);
                ReplaceWordStub("$Unit", CBUnit1.SelectedItem.ToString(), doc);
                if(CBFoundationContracter.Checked)
                {
                    ReplaceWordStub("$FoundationContracter", TBFoundationContracter1.Text, doc);
                    ReplaceWordStub("$FoundationContracter", TBFoundationContracter1.Text, doc);
                    ReplaceWordStub("$FoundationContracter", TBFoundationContracter1.Text, doc);
                }
                else
                {
                    ReplaceWordStub("$FoundationContracter", "Хабаровского НТЦ «ФГУП НПП «Гамма»", doc);
                    ReplaceWordStub("$FoundationContracter", "Хабаровского НТЦ «ФГУП НПП «Гамма»", doc);
                    ReplaceWordStub("$FoundationContracter", "Хабаровского НТЦ «ФГУП НПП «Гамма»", doc);
                }
                ReplaceWordStub("$Day", TBDay1.Text, doc);
                ReplaceWordStub("$Month", CBMonth1.SelectedItem.ToString(), doc);
                ReplaceWordStub("$Year", TBYear1.Text, doc);
                ReplaceWordStub("$Year", TBYear1.Text, doc);
                ReplaceWordStub("$Year", TBYear1.Text, doc);
                ReplaceWordStub("$UserIni", TBUser1.Text, doc);
                ReplaceWordStub("$UserIni", TBUser1.Text, doc);
                ReplaceWordStub("$UserIni", TBUser1.Text, doc);
                ReplaceWordStub("$WorkerPost", TBWorkerPost1.Text, doc);
                ReplaceWordStub("$WorkerPost", TBWorkerPost1.Text, doc);
                ReplaceWordStub("$WorkerName", TBWorker1.Text, doc);
                ReplaceWordStub("$WorkerIni", ToIni(TBWorker1.Text), doc);
                ReplaceWordStub("$AdminPost", TBPostRes1.Text.ToLower(), doc);
                ReplaceWordStub("$AdminPost", TBPostRes1.Text, doc);
                ReplaceWordStub("$AdminName", TBResponsible1.Text, doc);
                ReplaceWordStub("$AdminIni", ToIni(TBResponsible1.Text), doc);
                ReplaceWordStub("$CabinetNum", TBCabinet1.Text, doc);
                ReplaceWordStub("$PCNumber", TBPC1.Text, doc);
                ReplaceWordStub("$Order", TBOrder1.Text, doc);
                ReplaceWordStub("$Print", TBOrder11.Text, doc);
                ReplaceWordStub("$Print", TBOrder12.Text, doc);
                ReplaceWordStub("$VersionSKZI", CBSKZI1.SelectedItem.ToString(), doc);
                ReplaceWordStub("$VersionSKZI", CBSKZI1.SelectedItem.ToString(), doc);
                string m = "";
                switch (CBAct1.SelectedIndex)
                {
                    default: ReplaceWordStub("$ActSKZI", "1-1", doc); m = "1-1"; break;
                    case 0:ReplaceWordStub("$ActSKZI", "0", doc);m = "0";break;
                    case 1:ReplaceWordStub("$ActSKZI", "1-1", doc);m = "1-1";break;
                    case 2:ReplaceWordStub("$ActSKZI", "1-2", doc);m = "1-2";break;
                    case 3:ReplaceWordStub("$ActSKZI", "1-3", doc);m = "1-3"; break;
                    case 4:ReplaceWordStub("$ActSKZI", "1-4", doc);m = "1-4";break;
                    case 5:ReplaceWordStub("$ActSKZI", "1-20", doc); m = "1-20";break;
                    case 6:ReplaceWordStub("$ActSKZI", "2", doc);m = "2"; break;
                    case 7:ReplaceWordStub("$ActSKZI", "3", doc);m = "3";break;
                    case 8:ReplaceWordStub("$ActSKZI", "4", doc);m = "4";break;
                    case 9:ReplaceWordStub("$ActSKZI", "5", doc);m = "5";break;
                    case 10:ReplaceWordStub("$ActSKZI", "20", doc);m = "20";break;
                }
                if (m == "2")
                {
                    ReplaceWordStub("$DSTNum", "-", doc);
                    ReplaceWordStub("$RegisterCardNum", "-", doc);
                }
                else
                {
                    ReplaceWordStub("$DSTNum", TBKey1.Text, doc);
                    ReplaceWordStub("$RegisterCardNum", TBRegCard1.Text, doc);
                }
                ReplaceWordStub("$ActDst", Act, doc);
                ReplaceWordStub("$UserName", TBRegCard1.Text, doc);
                ReplaceWordStub("$Instruction", "Да", doc);
                ReplaceWordStub("$Contacts", "Да", doc);
                if (CBCity1.Checked)
                { ReplaceWordStub("$CityType", "г.", doc); CBCity2.Enabled = false; }
                if (CBCity2.Checked)
                { ReplaceWordStub("$CityType", "с.п.", doc); CBCity1.Enabled = false; }
                ReplaceWordStub("$CityName", TBCity1.Text, doc);
                for (int i = 0; i < CBInstaller1.Items.Count; i++)
                {
                    if (CBInstaller1.SelectedIndex==i)
                    {
                        string[] WorkersLat = System.IO.File.ReadAllLines(Application.StartupPath + "\\WorkersLat.csv", Encoding.Default);
                        { WorkerLatStr = WorkersLat[i]; }
                        break;
                    }
                }
                if (CBBarAct1.Checked)
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    BarActReader = TBYear1.Text.ToString() + @"/" + m + @"/" + BarActWriter;
                    Barcode bar = new Barcode()
                    {
                        IncludeLabel = false,
                        Alignment = AlignmentPositions.CENTER,
                        Width = 300,
                        Height = 10,
                        RotateFlipType = RotateFlipType.RotateNoneFlipNone,
                        BackColor = Color.White,
                        ForeColor = Color.Black,
                    };
                    Image img = bar.Encode(TYPE.CODE128B, BarActReader);
                    Clipboard.SetImage(img);
                    app.ActiveDocument.Sections[1].Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Paste();
                }
                Saving.ShowDialog();
                doc.SaveAs(FileName: Saving.FileName, FileFormat: Word.WdSaveFormat.wdFormatDocument);
                doc.Close();
                app.Quit();
                Clipboard.Clear();
                MessageBox.Show("Success!");
            }
            catch (Exception ex)
            {   
                MessageBox.Show(ex.Message);
                doc.SaveAs(FileName: Application.StartupPath + "\\Delete", FileFormat: Word.WdSaveFormat.wdFormatDocument);
                FileInfo file = new FileInfo(Application.StartupPath + "\\Delete.doc");
                doc.Close();
                app.Quit();
                file.Delete();
            }
        }

        private void BTNCreateWord2_Click(object sender, EventArgs e)
        {
            Word.Application app = new Word.Application
            {
                Visible = false
            };
            var doc = app.Documents.Open(Application.StartupPath + @"\ActOrder.dot");
            try
            {
                string m = "";
                switch (CBAct2.SelectedIndex)
                {
                    case 0: ReplaceWordStub("$ActSKZI", "0", doc); m = "0"; break;
                    case 1: ReplaceWordStub("$ActSKZI", "1-1", doc); m = "1-1"; break;
                    case 2: ReplaceWordStub("$ActSKZI", "1-2", doc); m = "1-2"; break;
                    case 3: ReplaceWordStub("$ActSKZI", "1-3", doc); m = "1-3"; break;
                    case 4: ReplaceWordStub("$ActSKZI", "1-4", doc); m = "1-4"; break;
                    case 5: ReplaceWordStub("$ActSKZI", "1-20", doc); m = "1-20"; break;
                    case 6: ReplaceWordStub("$ActSKZI", "2", doc); m = "2"; break;
                    case 7: ReplaceWordStub("$ActSKZI", "3", doc); m = "3"; break;
                    case 8: ReplaceWordStub("$ActSKZI", "4", doc); m = "4"; break;
                    case 9: ReplaceWordStub("$ActSKZI", "5", doc); m = "5"; break;
                    case 10: ReplaceWordStub("$ActSKZI", "20", doc); m = "20"; break;
                }
                ReplaceWordStub("$DirectorPost", TBDirectorPost2.Text, doc);
                ReplaceWordStub("$DirectorIni", ToIniRollover(TBDirectorName2.Text), doc);
                ReplaceWordStub("$Day", TBDay2.Text, doc);
                ReplaceWordStub("$Month", CBMonth2.SelectedItem.ToString(), doc);
                ReplaceWordStub("$Year", TBYear2.Text, doc);
                ReplaceWordStub("$Year", TBYear2.Text, doc);
                ReplaceWordStub("$Unit", CBUnit2.SelectedItem.ToString(), doc);
                ReplaceWordStub("$Dst", Act, doc);
                if (CBCity21.Checked)
                { ReplaceWordStub("$CityType", "г.", doc); }
                if (CBCity22.Checked)
                { ReplaceWordStub("$CityType", "с.п.", doc); }
                ReplaceWordStub("$CityName", TBCity2.Text, doc);
                ReplaceWordStub("$Day", TBDay2.Text, doc);
                ReplaceWordStub("$Month", CBMonth2.SelectedItem.ToString(), doc);
                ReplaceWordStub("$Year", TBYear2.Text, doc);
                ReplaceWordStub("$WorkerPost", TBWorkerPost2.Text, doc);
                ReplaceWordStub("$WorkerName", TBWorker2.Text, doc);
                ReplaceWordStub("$Foundation", TBFoundation2.Text, doc);
                ReplaceWordStub("$Client", TBDirectorName2.Text, doc);
                ReplaceWordStub("$Contract", TBOrder2.Text, doc);
                ReplaceWordStub("$Contract", TBOrder2.Text, doc);
                ReplaceWordStub("$SKZIWork", CBSKZIWork.SelectedItem.ToString(), doc);
                ReplaceWordStub("$SKZIReg", CBSKZIReg.SelectedItem.ToString(), doc);
                ReplaceWordStub("$SKZICheck", CBSKZICheck.SelectedItem.ToString(), doc);
                ReplaceWordStub("$SKZIKnowlenge", CBSKZIKnowlenge.SelectedItem.ToString(), doc);
                ReplaceWordStub("$SKZIAccept", CBSKZIAccept.SelectedItem.ToString(), doc);
                ReplaceWordStub("$Foundation", TBFoundation2.Text, doc);
                ReplaceWordStub("$Foundation", TBFoundation2.Text, doc);
                ReplaceWordStub("$DirectorIni", ToIniRollover(TBDirectorName2.Text), doc);
                ReplaceWordStub("$Day", TBDay2.Text, doc);
                ReplaceWordStub("$Month", CBMonth2.SelectedItem.ToString(), doc);
                ReplaceWordStub("$Year", TBYear2.Text, doc);
                ReplaceWordStub("$Day", TBDay2.Text, doc);
                ReplaceWordStub("$Month", CBMonth2.SelectedItem.ToString(), doc);
                ReplaceWordStub("$Year", TBYear2.Text, doc);
                ReplaceWordStub("$WorkerIni", ToIniRollover(TBWorker2.Text), doc);
                for (int i = 0; i < CBInstaller1.Items.Count; i++)

                {
                    if (CBInstaller1.SelectedIndex == i)
                    {
                        string[] WorkersLat = System.IO.File.ReadAllLines(Application.StartupPath + "\\WorkersLat.csv", Encoding.Default);
                        { WorkerLatStr = WorkersLat[i]; }
                        break;
                    }
                }
                if (CBBarAct2.Checked)
                {
                    BarActReader = TBYear2.Text.ToString() + @"/" + m + @"/" + BarActWriter;
                    BarcodeLib.Barcode bar = new BarcodeLib.Barcode()
                    {
                        IncludeLabel = false,
                        Alignment = AlignmentPositions.CENTER,
                        Width = 300,
                        Height = 10,
                        RotateFlipType = RotateFlipType.RotateNoneFlipNone,
                        BackColor = Color.White,
                        ForeColor = Color.Black,
                    };
                    Image img = bar.Encode(TYPE.CODE128B, BarActReader);
                    Clipboard.SetImage(img);
                    app.ActiveDocument.Sections[1].Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Paste();
                }
                Saving.ShowDialog();
                doc.SaveAs(FileName: Saving.FileName, FileFormat: Word.WdSaveFormat.wdFormatDocument);
                FileInfo file = new FileInfo(Application.StartupPath + "\\Delete");
                file.Delete();
                doc.Close();
                app.Quit();
                Clipboard.Clear();
                MessageBox.Show("Success!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                doc.SaveAs(FileName: Application.StartupPath + "\\Delete", FileFormat: Word.WdSaveFormat.wdFormatDocument);
                FileInfo file = new FileInfo(Application.StartupPath + "\\Delete.doc");
                doc.Close();
                app.Quit();
                file.Delete();
            }
        }

        private void BTNCreateTemplate1_Click(object sender, EventArgs e)
        {
            if (!CBFoundationContracter.Checked)
            {
                try
                {
                    Saving.ShowDialog();
                    Directory.CreateDirectory(Saving.FileName);
                    Thread.Sleep(10);
                    FileStream file1 = new FileStream(Saving.FileName + @"\Install.csv", FileMode.OpenOrCreate);
                    StreamWriter writer = new StreamWriter(file1, Encoding.Default);
                    writer.WriteLine("0;" + "Хабаровского НТЦ «ФГУП НПП «Гамма»");
                    if (TBDirectorName1.Text != "") { writer.WriteLine("1;" + TBDirectorName1.Text); }
                    if (TBDirectorPost1.Text != "") { writer.WriteLine("2;" + TBDirectorPost1.Text); }
                    if (TBFoundation1.Text != "") { writer.WriteLine("3;" + TBFoundation1.Text); }
                    if (TBUser1.Text != "") { writer.WriteLine("4;" + TBUser1.Text); }
                    if (TBResponsible1.Text != "") { writer.WriteLine("5;" + TBResponsible1.Text); }
                    if (TBPostRes1.Text != "") { writer.WriteLine("6;" + TBPostRes1.Text); }
                    if (TBCabinet1.Text != "") { writer.WriteLine("7;" + TBCabinet1.Text); }
                    if (TBPC1.Text != "") { writer.WriteLine("8;" + TBPC1.Text); }
                    if (TBOrder1.Text != "") { writer.WriteLine("9;" + TBOrder1.Text); }
                    writer.WriteLine("10;" + CBAct1.SelectedItem.ToString());
                    if (CBSKZI1.SelectedItem.ToString() != "") { writer.WriteLine("11;" + CBSKZI1.SelectedItem.ToString()); }
                    if (CBUnit1.SelectedItem.ToString() != "") { writer.WriteLine("12;" + CBUnit1.SelectedItem.ToString()); }
                    if (CBInstaller1.SelectedItem.ToString() != "") { writer.WriteLine("13;" + CBInstaller1.SelectedItem); }
                    if (TBWorker1.Text != "") { writer.WriteLine("14;" + TBWorker1.Text); }
                    if (TBWorkerPost1.Text != "") { writer.WriteLine("15;" + TBWorkerPost1.Text); }
                    if (TBOrder11.Text != "") { writer.WriteLine("16;" + TBOrder11.Text); }
                    if (TBOrder12.Text != "") { writer.WriteLine("17;" + TBOrder12.Text); }
                    if (TBCity1.Text != "") { writer.WriteLine("18;" + TBCity1.Text); }
                    if (CBCity1.Checked)
                    { CBCity2.Enabled = false; writer.WriteLine("19;" + "г."); }
                    if (CBCity2.Checked)
                    { CBCity1.Enabled = false; writer.WriteLine("19;" + "с.п."); }
                    writer.Close();
                    
                    MessageBox.Show("Success!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    FileInfo file = new FileInfo(Application.StartupPath + "\\Delete.doc");
                    file.Delete();
                }
            }
            else
            {
                
            }
        }

        private void BTNLoadTemplate1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenTemplate.ShowDialog();
                FileStream file = new FileStream(path: OpenTemplate.FileName, mode: FileMode.Open);
                StreamReader sr = new StreamReader(file, Encoding.Default);
                char ch1;
                char ch2;
                string s = "";
                string ss = "";
                while (sr.EndOfStream == false)
                {
                    ch1 = Convert.ToChar(sr.Read()); s += ch1;
                    ch2 = Convert.ToChar(sr.Read()); if (ch2 != ';') { s += ch2; }
                    switch (s)
                    {
                        case "0": { sr.ReadLine(); break; }
                        case "1": { AddElementTB(sr.ReadLine(), ref TBDirectorName1); break; }
                        case "2": { AddElementTB(sr.ReadLine(), ref TBDirectorPost1); break; }
                        case "3": { AddElementTB(sr.ReadLine(), ref TBFoundation1); break; }
                        case "4": { AddElementTB(sr.ReadLine(), ref TBUser1); break; }
                        case "5": { AddElementTB(sr.ReadLine(), ref TBResponsible1); break; }
                        case "6": { AddElementTB(sr.ReadLine(), ref TBPostRes1); break; }
                        case "7": { AddElementTB(sr.ReadLine(), ref TBCabinet1); break; }
                        case "8": { AddElementTB(sr.ReadLine(), ref TBPC1); break; }
                        case "9": { AddElementTB(sr.ReadLine(), ref TBOrder1); break; }
                        case "10": { sr.Read(); AddElementCB(sr.ReadLine(), ref CBAct1); break; }
                        case "11": { sr.Read(); AddElementCB(sr.ReadLine(), ref CBSKZI1); break; }
                        case "12": { sr.Read(); AddElementCB(sr.ReadLine(), ref CBUnit1); break; }
                        case "13": { sr.Read(); AddElementCB(sr.ReadLine(), ref CBInstaller1); break; }
                        case "14": { sr.Read(); AddElementTB(sr.ReadLine(), ref TBWorker1); break; }
                        case "15": { sr.Read(); AddElementTB(sr.ReadLine(), ref TBWorkerPost1); break; }
                        case "16": { sr.Read(); AddElementTB(sr.ReadLine(), ref TBOrder11); break; }
                        case "17": { sr.Read(); AddElementTB(sr.ReadLine(), ref TBOrder12); break; }
                        case "18": { sr.Read(); ss = sr.ReadLine(); if (ss == "г.") { CBCity1.Checked = true; } else { CBCity2.Checked = true; } break; }
                        case "19": { sr.Read(); AddElementTB(sr.ReadLine(), ref TBCity1); break; }
                        default: { break; }
                    }
                    s = "";
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void BTNCreateTemplate2_Click(object sender, EventArgs e)
        {
            try
            {
                Saving.ShowDialog();
                Directory.CreateDirectory(Saving.FileName);
                Thread.Sleep(10);
                FileStream file1 = new FileStream(Saving.FileName + @"\Order.csv", FileMode.OpenOrCreate);
                StreamWriter writer = new StreamWriter(file1, Encoding.Default);
                writer.WriteLine("0;" + "Хабаровского НТЦ «ФГУП НПП «Гамма»");
                if (TBDirectorName2.Text != "") { writer.WriteLine("1;" + TBDirectorName2.Text); }
                if (TBDirectorPost2.Text != "") { writer.WriteLine("2;" + TBDirectorPost2.Text); }
                if (TBFoundation2.Text != "") { writer.WriteLine("3;" + TBFoundation2.Text); }
                if (TBOrder2.Text != "") { writer.WriteLine("4;" + TBOrder2.Text); }
                writer.WriteLine("5;" + CBAct2.SelectedItem.ToString());
                if (CBUnit2.SelectedItem.ToString() != "") { writer.WriteLine("6;" + CBUnit2.SelectedItem.ToString()); }
                if (CBInstaller2.SelectedItem.ToString() != "") { writer.WriteLine("7;" + CBInstaller2.SelectedItem); }
                if (TBWorker2.Text != "") { writer.WriteLine("8;" + TBWorker2.Text); }
                if (TBWorkerPost2.Text != "") { writer.WriteLine("9;" + TBWorkerPost2.Text); }
                if (TBCity2.Text != "") { writer.WriteLine("10;" + TBCity2.Text); }
                if (CBCity21.Checked)
                { writer.WriteLine("11;" + "г."); }
                if (CBCity22.Checked)
                { writer.WriteLine("11;" + "с.п."); }
                if (CBSKZIAccept.SelectedItem.ToString() != "") { writer.WriteLine("12;" + CBSKZIAccept.SelectedItem.ToString()); }
                if (CBSKZICheck.SelectedItem.ToString() != "") { writer.WriteLine("13;" + CBSKZICheck.SelectedItem.ToString()); }
                if (CBSKZIReg.SelectedItem.ToString() != "") { writer.WriteLine("14;" + CBSKZIReg.SelectedItem.ToString()); }
                if (CBSKZIWork.SelectedItem.ToString() != "") { writer.WriteLine("15;" + CBSKZIWork.SelectedItem.ToString()); }
                if (CBSKZIKnowlenge.SelectedItem.ToString() != "") { writer.WriteLine("16;" + CBSKZIKnowlenge.SelectedItem.ToString()); }
                writer.Close();
                MessageBox.Show("Success!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                FileInfo file = new FileInfo(Application.StartupPath + "\\Delete.doc");
                file.Delete();
            }
        }

        private void BTNLoadTemplate2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenTemplate.ShowDialog();
                FileStream file = new FileStream(path: OpenTemplate.FileName, mode: FileMode.OpenOrCreate);
                StreamReader sr = new StreamReader(file, Encoding.Default);
                char ch1;
                char ch2;
                string s = "";
                string ss = "";
                while (sr.EndOfStream == false)
                {
                    ch1 = Convert.ToChar(sr.Read()); s += ch1;
                    ch2 = Convert.ToChar(sr.Read()); if (ch2 != ';') { s += ch2; }
                    switch (s)
                    {
                        case "0": { sr.ReadLine(); break; }
                        case "1": { AddElementTB(sr.ReadLine(), ref TBDirectorName2); break; }
                        case "2": { AddElementTB(sr.ReadLine(), ref TBDirectorPost2); break; }
                        case "3": { AddElementTB(sr.ReadLine(), ref TBFoundation2); break; }
                        case "4": { AddElementTB(sr.ReadLine(), ref TBOrder2); break; }
                        case "5": { AddElementCB(sr.ReadLine(), ref CBAct2); break; }
                        case "6": { AddElementCB(sr.ReadLine(), ref CBUnit2); break; }
                        case "7": { AddElementCB(sr.ReadLine(), ref CBInstaller2); break; }
                        case "8": { AddElementTB(sr.ReadLine(), ref TBWorker2); break; }
                        case "9": { AddElementTB(sr.ReadLine(), ref TBWorkerPost2); break; }
                        case "10": { sr.Read(); AddElementTB(sr.ReadLine(), ref TBCity2); break; }
                        case "11": { sr.Read(); ss = sr.ReadLine(); if (ss == "г.") { CBCity22.Checked = true; } else { CBCity21.Checked = true; } break; }
                        case "12": { sr.Read(); AddElementCB(sr.ReadLine(), ref CBSKZIAccept); break; }
                        case "13": { sr.Read(); AddElementCB(sr.ReadLine(), ref CBSKZICheck); break; }
                        case "14": { sr.Read(); AddElementCB(sr.ReadLine(), ref CBSKZIReg); break; }
                        case "15": { sr.Read(); AddElementCB(sr.ReadLine(), ref CBSKZIWork); break; }
                        case "16": { sr.Read(); AddElementCB(sr.ReadLine(), ref CBSKZIKnowlenge); break; }
                        default: { break; }
                    }
                    s = "";
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BTNKey_Click(object sender, EventArgs e)
        {
            
            try
            {
                Act = "";
                int a = 0;
                TBKey1.Text = "";
                TBRegCard1.Text = "";
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
                            TBKey1.Text += sss[j];
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
                                BarActWriter = label2.Text;
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
                                TBRegCard1.Text += sss[j];
                            }
                            break;
                        }
                    }
                    aaa += 1;
                    sss[aa - i] = ss[i];
                }
            } 
            catch(Exception ex)
            {
                MessageBox.Show("Убедитесь, что указали корректный путь и файл!");
            }  
        }

        private void BTNTransfer_Click(object sender, EventArgs e)
        {
            TBDirectorName2.Text = TBDirectorName1.Text;
            TBDirectorPost2.Text = TBDirectorPost1.Text;
            TBFoundation2.Text = TBFoundation1.Text;
            TBDay2.Text = TBDay1.Text;
            CBMonth2.SelectedIndex = CBMonth1.SelectedIndex;
            TBYear2.Text = TBYear1.Text;
            TBWorker2.Text = TBWorker1.Text;
            TBWorkerPost2.Text = TBWorkerPost1.Text;
            if (CBCity1.Checked)
                { CBCity21.Checked = true; }
            if (CBCity2.Checked)
                { CBCity22.Checked = true; }
            TBKey2.Text = TBKey1.Text;
            TBRegCard2.Text = TBRegCard1.Text;
            TBOrder2.Text = TBOrder1.Text;
            TBCity2.Text = TBCity1.Text;
            CBAct2.SelectedIndex = CBAct1.SelectedIndex;
            CBUnit2.SelectedIndex = CBUnit1.SelectedIndex;
        }

        public void Change(object sender, EventArgs e)
        {
            if (TABAll.SelectedIndex == 0)
            {
                TBWorker1.Text = "";
                TBWorkerPost1.Text = "";
                WP1 = "";
                WP2 = "";
                string s = CBInstaller1.Text;
                string ss;
                char[] ch = new char[s.Length];
                char[] ch1 = new char[s.Length];
                ch = s.ToCharArray();
                for (int i = 0; i < s.Length; i++)
                {
                    ss = WP1;
                    if (ch[i].ToString() == ";")
                    {
                        TBWorker1.Text = ss;
                        break;
                    }
                    WP1 += ch[i];
                }
                int a = 0;
                int b = s.Length - 1;
                ch = s.ToCharArray();
                for (int i = b; i >= 0; i--)
                {
                    if (ch[i].ToString() == ";")
                    {
                        for (int j = a - 1; j >= 0; j--)
                        {
                            WP2 += ch1[j];
                        }
                        TBWorkerPost1.Text = WP2;
                        break;
                    }
                    a += 1;
                    ch1[b - i] = ch[i];
                }
            }
            if (TABAll.SelectedIndex == 1)
            {
                TBWorker2.Text = "";
                TBWorkerPost2.Text = "";
                WP1 = "";
                WP2 = "";
                string s = CBInstaller2.Text.ToString();
                string ss;
                char[] ch = new char[s.Length];
                char[] ch1 = new char[s.Length];
                ch = s.ToCharArray();
                for (int i = 0; i < s.Length; i++)
                {
                    ss = WP1;
                    if (ch[i].ToString() == ";")
                    {
                        TBWorker2.Text = ss;
                        break;
                    }
                    WP1 += ch[i];
                }
                int a = 0;
                int b = s.Length - 1;
                ch = s.ToCharArray();
                for (int i = b; i >= 0; i--)
                {
                    if (ch[i].ToString() == ";")
                    {
                        for (int j = a - 1; j >= 0; j--)
                        {
                            WP2 += ch1[j];
                        }
                        TBWorkerPost2.Text = WP2;
                        break;
                    }
                    a += 1;
                    ch1[b - i] = ch[i];
                }
            }
        }

        private void RegCardTextChanged(object sender, EventArgs e)
        {

            if (TABAll.SelectedIndex == 0)
            {
                char[] af = TBRegCard1.Text.ToCharArray();
                int aa = af.Count() - 1;
                Act = "";
                BarActWriter = "";
                for (int i = 0; i <= aa; i++)
                {
                    if (af[i].ToString() == "(")
                    { break; }
                    Act += af[i];
                    BarActWriter += af[i];
                }
            }
            if (TABAll.SelectedIndex == 1)
            {
                char[] af = TBRegCard2.Text.ToCharArray();
                int aa = af.Count() - 1;
                Act = "";
                BarActWriter = "";
                for (int i = 0; i <= aa; i++)
                {
                    if (af[i].ToString() == "(")
                    { break; }
                    Act += af[i];
                    BarActWriter += af[i];
                }
            }
        }

    }
}
