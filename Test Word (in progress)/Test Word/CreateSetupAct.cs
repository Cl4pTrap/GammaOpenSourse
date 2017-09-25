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
using System.Reflection;
using System.Resources;

namespace Mongoose
{
    class CreateSetupAct : Form1
    {
        
        public void BTNCreateSetupAct()
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
                if (CBFoundationContracter.Checked)
                {
                    ReplaceWordStub("$FoundationContracter", TBFoundationContracter1.Text, doc);
                    ReplaceWordStub("$FoundationContracter", TBFoundationContracter1.Text, doc);
                    ReplaceWordStub("$FoundationContracter", TBFoundationContracter1.Text, doc);
                }
                else
                {
                    ReplaceWordStub("$FoundationContractor", "Хабаровского НТЦ «ФГУП НПП «Гамма»", doc);
                    ReplaceWordStub("$FoundationContractor", "Хабаровского НТЦ «ФГУП НПП «Гамма»", doc);
                    ReplaceWordStub("$FoundationContractor", "Хабаровского НТЦ «ФГУП НПП «Гамма»", doc);
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
                        ReplaceWordStub("$ActSKZI", "1-4", doc);
                        m = "1-4";
                        break;
                    case 5:
                        ReplaceWordStub("$ActSKZI", "1-20", doc);
                        m = "1-20";
                        break;
                    case 6:
                        ReplaceWordStub("$ActSKZI", "2", doc);
                        m = "2";
                        break;
                    case 7:
                        ReplaceWordStub("$ActSKZI", "3", doc);
                        m = "3";
                        break;
                    case 8:
                        ReplaceWordStub("$ActSKZI", "4", doc);
                        m = "4";
                        break;
                    case 9:
                        ReplaceWordStub("$ActSKZI", "5", doc);
                        m = "5";
                        break;
                    case 10:
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
                    if (CBInstaller1.SelectedIndex == i)
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
                    BTNLoadTemplate1.Text = BarActReader;
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
    }
}
