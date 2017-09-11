using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Net;
using BarcodeLib;
using System.Threading;

namespace Test_Word
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

        public string BarAct;
        public string WP1;
        public string WP2;
        public string StartupWay = Application.StartupPath.ToString();
        public string WorkerLatStr;
        public Form1()
        {
            InitializeComponent();
            TBOrder1.Text = "контракта № 34/3.ЭА.У-ИТ17 от 14.06.2017г.";
            TBYear1.Text = DateTime.Now.Year.ToString();
            TBDay1.Text = DateTime.Now.Day.ToString();
            string[] data = System.IO.File.ReadAllLines(Application.StartupPath + "\\SKZI.csv", Encoding.Default);
            foreach (var line in data) { CBSKZI1.Items.Add(line); }
            try
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
                foreach (var line in Write) { CBInstaller1.Items.Add(line); }
                foreach (var line in Write) { CBInstaller2.Items.Add(line); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось соединиться с сервером.");
                string[] WorkersKir = System.IO.File.ReadAllLines(Application.StartupPath + "\\WorkersKir.csv", Encoding.Default);
                foreach (var fio in WorkersKir) { CBInstaller1.Items.Add(fio); }
                foreach (var fio in WorkersKir) { CBInstaller2.Items.Add(fio); }
            }

            switch (DateTime.Now.Month)
            {
                case 1:
                    CBMonth1.SelectedIndex = 0;
                    break;
                case 2:
                    CBMonth1.SelectedIndex = 1;
                    break;
                case 3:
                    CBMonth1.SelectedIndex = 2;
                    break;
                case 4:
                    CBMonth1.SelectedIndex = 3;
                    break;
                case 5:
                    CBMonth1.SelectedIndex = 4;
                    break;
                case 6:
                    CBMonth1.SelectedIndex = 5;
                    break;
                case 7:
                    CBMonth1.SelectedIndex = 6;
                    break;
                case 8:
                    CBMonth1.SelectedIndex = 7;
                    break;
                case 9:
                    CBMonth1.SelectedIndex = 8;
                    break;
                case 10:
                    CBMonth1.SelectedIndex = 9;
                    break;
                case 11:
                    CBMonth1.SelectedIndex = 10;
                    break;
                case 12:
                    CBMonth1.SelectedIndex = 11;
                    break;
            }
        }

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

        public void Change(object sender, EventArgs e)
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
                    for (int j = a-1; j > 0; j--)
                    {
                        WP2 += ch1[j];
                    }
                    TBWorkerPost1.Text = WP2;
                    break;
                }
                a += 1;
                ch1[b - i] = ch[i]; 
            }
            BTNSearchINN.Text = ToInit(WP1);
            TBFoundationVP1.Text = WP2;
        }

        private void ReplaceWordStub(string Find, string Replace, Word.Document docFind)
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

        public string ToInit(string FIO)
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

        private void button1_Click(object sender, EventArgs e)
        {
            Word.Application app = new Word.Application
            {
                Visible = false
            };
            var doc = app.Documents.Open(Application.StartupPath + @"\ActSetup.dot");
            try
            { 
                ReplaceWordStub("$DirectorPost", TBDirectorPost1.Text, doc);
                ReplaceWordStub("$DirectorName", TBDirectorName1.Text, doc);
                ReplaceWordStub("$Foundation", TBFoundation1.Text, doc);
                ReplaceWordStub("$Foundation", TBFoundation1.Text, doc);
                ReplaceWordStub("$FoundVP", TBFoundationVP1.Text, doc);
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
                ReplaceWordStub("$WorkerName", TBWorker1.Text, doc);
                ReplaceWordStub("$AdminPost", TBPostRes1.Text.ToLower(), doc);
                ReplaceWordStub("$AdminPost", TBPostRes1.Text, doc);
                ReplaceWordStub("$AdminName", TBResponsible1.Text, doc);
                ReplaceWordStub("$AdminName", TBResponsible1.Text, doc);
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
                    case 0:
                        ReplaceWordStub("$ActSKZI", "0", doc);
                        m = "0";
                        break;
                    case 1:
                        ReplaceWordStub("$ActSKZI", "1-1", doc);
                        m = "1-1";
                        break;
                    case 2:
                        ReplaceWordStub("$ActSKZI", "1-2", doc);
                        m = "1-2";
                        break;
                    case 3:
                        ReplaceWordStub("$ActSKZI", "1-3", doc);
                        m = "1-3";
                        break;
                    case 4:
                        ReplaceWordStub("$ActSKZI", "1-20", doc);
                        m = "1-20";
                        break;
                    case 5:
                        ReplaceWordStub("$ActSKZI", "2", doc);
                        m = "2";
                        break;
                    case 6:
                        ReplaceWordStub("$ActSKZI", "3", doc);
                        m = "3";
                        break;
                    case 7:
                        ReplaceWordStub("$ActSKZI", "4", doc);
                        m = "4";
                        break;
                    case 8:
                        ReplaceWordStub("$ActSKZI", "5", doc);
                        m = "5";
                        break;
                    case 9:
                        ReplaceWordStub("$ActSKZI", "20", doc);
                        m = "20";
                        break;
                }
                ReplaceWordStub("$ActDst", Act, doc);
                ReplaceWordStub("$UserName", TBRegCard1.Text, doc);
                ReplaceWordStub("$DSTNum", TBKey1.Text, doc);
                ReplaceWordStub("$RegisterCardNum", TBRegCard1.Text, doc);
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
                    BarAct = TBYear1.Text.ToString() + @"/" + m + @"/" + BarAct;
                    BarcodeLib.Barcode bar = new BarcodeLib.Barcode()
                    {
                        IncludeLabel = false,
                        Alignment = AlignmentPositions.CENTER,
                        Width = 340,
                        Height = 10,
                        RotateFlipType = RotateFlipType.RotateNoneFlipNone,
                        BackColor = Color.White,
                        ForeColor = Color.Black,
                    };
                    BTNSearchINN.Text = BarAct;
                    Image img = bar.Encode(TYPE.CODE39Extended, BarAct);
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
                doc.Close();
                app.Quit();
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
                                BarAct = label2.Text;
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

        private void RegCardTextChanged(object sender, EventArgs e)
        {
            
            if (TABAll.SelectedIndex == 0)
            {
                char[] af = TBRegCard1.Text.ToCharArray();
                int aa = af.Count() - 1;
                Act = "";
                BarAct = "";
                for (int i = 0; i <= aa; i++)
                {
                    if (af[i].ToString() == "(")
                    { break; }
                    Act += af[i];
                    BarAct += af[i];
                }
            }
            if (TABAll.SelectedIndex == 1)
            {
                char[] af = TBRegCard2.Text.ToCharArray();
                int aa = af.Count() - 1;
                Act = "";
                BarAct = "";
                for (int i = 0; i <= aa; i++)
                {
                    if (af[i].ToString() == "(")
                    { break; }
                    Act += af[i];
                    BarAct += af[i];
                }
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            
        }

        /*private void button2_Click(object sender, EventArgs e)
        {
          //  ПРИНТЕР
          //  System.Drawing.Printing.PrintDocument.Print(PrinterDialog.Document.);
          //  PrinterDialog.UseEXDialog = true;
          //  PrinterDialog.Document.
          //  PrinterDialog.ShowDialog();
            
        }*/

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
                    case 0:
                        ReplaceWordStub("$ActSKZI", "0", doc);
                        m = "0";
                        break;
                    case 1:
                        ReplaceWordStub("$ActSKZI", "1-1", doc);
                        m = "1-1";
                        break;
                    case 2:
                        ReplaceWordStub("$ActSKZI", "1-2", doc);
                        m = "1-2";
                        break;
                    case 3:
                        ReplaceWordStub("$ActSKZI", "1-3", doc);
                        m = "1-3";
                        break;
                    case 4:
                        ReplaceWordStub("$ActSKZI", "1-20", doc);
                        m = "1-20";
                        break;
                    case 5:
                        ReplaceWordStub("$ActSKZI", "2", doc);
                        m = "2";
                        break;
                    case 6:
                        ReplaceWordStub("$ActSKZI", "3", doc);
                        m = "3";
                        break;
                    case 7:
                        ReplaceWordStub("$ActSKZI", "4", doc);
                        m = "4";
                        break;
                    case 8:
                        ReplaceWordStub("$ActSKZI", "5", doc);
                        m = "5";
                        break;
                    case 9:
                        ReplaceWordStub("$ActSKZI", "20", doc);
                        m = "20";
                        break;
                }
                ReplaceWordStub("$DirectorPost", TBDirectorPost2.Text, doc);
                ReplaceWordStub("$DirectorName", TBDirectorName2.Text, doc);
                ReplaceWordStub("$Day", TBDay2.Text, doc);
                ReplaceWordStub("$Month", CBMonth2.SelectedItem.ToString(), doc);
                ReplaceWordStub("$Year", TBYear2.Text, doc);
                ReplaceWordStub("$Year", TBYear2.Text, doc);
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
                ReplaceWordStub("$DirectorName", TBDirectorName2.Text, doc);
                ReplaceWordStub("$Day", TBDay2.Text, doc);
                ReplaceWordStub("$Month", CBMonth2.SelectedItem.ToString(), doc);
                ReplaceWordStub("$Year", TBYear2.Text, doc);
                ReplaceWordStub("$Day", TBDay2.Text, doc);
                ReplaceWordStub("$Month", CBMonth2.SelectedItem.ToString(), doc);
                ReplaceWordStub("$Year", TBYear2.Text, doc);
                ReplaceWordStub("$WorkerNameIni", ToInit(TBWorker2.Text), doc);
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
                    BarAct = TBYear2.Text.ToString() + @"/" + m + @"/" + BarAct;
                    BarcodeLib.Barcode bar = new BarcodeLib.Barcode()
                    {
                        IncludeLabel = false,
                        Alignment = AlignmentPositions.CENTER,
                        Width = 340,
                        Height = 10,
                        RotateFlipType = RotateFlipType.RotateNoneFlipNone,
                        BackColor = Color.White,
                        ForeColor = Color.Black,
                    };
                    BTNSearchINN.Text = BarAct;
                    Image img = bar.Encode(TYPE.CODE39Extended, BarAct);
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

            }
        }

        private void TABAll_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
