namespace Test_Word
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TBFoundation = new System.Windows.Forms.TextBox();
            this.BTNSave = new System.Windows.Forms.Button();
            this.LBFoundation = new System.Windows.Forms.Label();
            this.LBDay = new System.Windows.Forms.Label();
            this.LBMonth = new System.Windows.Forms.Label();
            this.TBDay = new System.Windows.Forms.TextBox();
            this.TBYear = new System.Windows.Forms.TextBox();
            this.CBMonth = new System.Windows.Forms.ComboBox();
            this.LBYear = new System.Windows.Forms.Label();
            this.LBUser = new System.Windows.Forms.Label();
            this.TBUser = new System.Windows.Forms.TextBox();
            this.LBCabinet = new System.Windows.Forms.Label();
            this.TBCabinet = new System.Windows.Forms.TextBox();
            this.TBPC = new System.Windows.Forms.TextBox();
            this.LBPC = new System.Windows.Forms.Label();
            this.LBInstaller = new System.Windows.Forms.Label();
            this.LBResponsible = new System.Windows.Forms.Label();
            this.TBResponsible = new System.Windows.Forms.TextBox();
            this.LBPostRes = new System.Windows.Forms.Label();
            this.TBPostRes = new System.Windows.Forms.TextBox();
            this.Saving = new System.Windows.Forms.SaveFileDialog();
            this.LBDirectorName = new System.Windows.Forms.Label();
            this.TBDirectorName = new System.Windows.Forms.TextBox();
            this.LBDirectorPost = new System.Windows.Forms.Label();
            this.TBDirectorPost = new System.Windows.Forms.TextBox();
            this.LBSKZI = new System.Windows.Forms.Label();
            this.CBSKZI = new System.Windows.Forms.ComboBox();
            this.LBRegCard = new System.Windows.Forms.Label();
            this.TBRegCard = new System.Windows.Forms.TextBox();
            this.LBKey = new System.Windows.Forms.Label();
            this.TBKey = new System.Windows.Forms.TextBox();
            this.TBDistr = new System.Windows.Forms.TextBox();
            this.LBDistr = new System.Windows.Forms.Label();
            this.OpenDistr = new System.Windows.Forms.OpenFileDialog();
            this.BTNKey = new System.Windows.Forms.Button();
            this.LBWorkerPost = new System.Windows.Forms.Label();
            this.OpenCard = new System.Windows.Forms.FolderBrowserDialog();
            this.LBOrder = new System.Windows.Forms.Label();
            this.TBOrder = new System.Windows.Forms.TextBox();
            this.TBOrder2 = new System.Windows.Forms.TextBox();
            this.TBOrder1 = new System.Windows.Forms.TextBox();
            this.LBOrder1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TBWorker = new System.Windows.Forms.TextBox();
            this.TBWorkerPost = new System.Windows.Forms.TextBox();
            this.CBInstaller = new System.Windows.Forms.ComboBox();
            this.LBInstallerCB = new System.Windows.Forms.Label();
            this.GBBuyer = new System.Windows.Forms.GroupBox();
            this.BTNSearchINN = new System.Windows.Forms.Button();
            this.GBInstaller = new System.Windows.Forms.GroupBox();
            this.CBAct = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.CB123 = new System.Windows.Forms.ComboBox();
            this.LBTest = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.TABAll = new System.Windows.Forms.TabControl();
            this.TABAct = new System.Windows.Forms.TabPage();
            this.TABTest = new System.Windows.Forms.TabPage();
            this.GBBuyer.SuspendLayout();
            this.GBInstaller.SuspendLayout();
            this.TABAll.SuspendLayout();
            this.TABAct.SuspendLayout();
            this.TABTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // TBFoundation
            // 
            this.TBFoundation.Location = new System.Drawing.Point(9, 112);
            this.TBFoundation.Name = "TBFoundation";
            this.TBFoundation.Size = new System.Drawing.Size(310, 20);
            this.TBFoundation.TabIndex = 0;
            // 
            // BTNSave
            // 
            this.BTNSave.AutoSize = true;
            this.BTNSave.Location = new System.Drawing.Point(192, 407);
            this.BTNSave.Name = "BTNSave";
            this.BTNSave.Size = new System.Drawing.Size(333, 36);
            this.BTNSave.TabIndex = 1;
            this.BTNSave.Text = "Создать и сохранить документ";
            this.BTNSave.UseVisualStyleBackColor = true;
            this.BTNSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // LBFoundation
            // 
            this.LBFoundation.AutoSize = true;
            this.LBFoundation.Location = new System.Drawing.Point(6, 96);
            this.LBFoundation.Name = "LBFoundation";
            this.LBFoundation.Size = new System.Drawing.Size(120, 13);
            this.LBFoundation.TabIndex = 2;
            this.LBFoundation.Text = "Название учреждения";
            // 
            // LBDay
            // 
            this.LBDay.AutoSize = true;
            this.LBDay.Location = new System.Drawing.Point(6, 134);
            this.LBDay.Name = "LBDay";
            this.LBDay.Size = new System.Drawing.Size(89, 13);
            this.LBDay.TabIndex = 3;
            this.LBDay.Text = "День установки";
            // 
            // LBMonth
            // 
            this.LBMonth.AutoSize = true;
            this.LBMonth.Location = new System.Drawing.Point(112, 135);
            this.LBMonth.Name = "LBMonth";
            this.LBMonth.Size = new System.Drawing.Size(95, 13);
            this.LBMonth.TabIndex = 4;
            this.LBMonth.Text = "Месяц установки";
            // 
            // TBDay
            // 
            this.TBDay.Location = new System.Drawing.Point(9, 150);
            this.TBDay.Name = "TBDay";
            this.TBDay.Size = new System.Drawing.Size(100, 20);
            this.TBDay.TabIndex = 5;
            // 
            // TBYear
            // 
            this.TBYear.Location = new System.Drawing.Point(242, 151);
            this.TBYear.Name = "TBYear";
            this.TBYear.Size = new System.Drawing.Size(77, 20);
            this.TBYear.TabIndex = 6;
            // 
            // CBMonth
            // 
            this.CBMonth.FormattingEnabled = true;
            this.CBMonth.Items.AddRange(new object[] {
            "января",
            "февраля",
            "марта",
            "апреля",
            "мая",
            "июня",
            "июля",
            "августа",
            "сентября",
            "октября",
            "ноября",
            "декабря"});
            this.CBMonth.Location = new System.Drawing.Point(115, 150);
            this.CBMonth.Name = "CBMonth";
            this.CBMonth.Size = new System.Drawing.Size(121, 21);
            this.CBMonth.TabIndex = 7;
            // 
            // LBYear
            // 
            this.LBYear.AutoSize = true;
            this.LBYear.Location = new System.Drawing.Point(239, 135);
            this.LBYear.Name = "LBYear";
            this.LBYear.Size = new System.Drawing.Size(80, 13);
            this.LBYear.TabIndex = 8;
            this.LBYear.Text = "Год установки";
            // 
            // LBUser
            // 
            this.LBUser.AutoSize = true;
            this.LBUser.Location = new System.Drawing.Point(6, 173);
            this.LBUser.Name = "LBUser";
            this.LBUser.Size = new System.Drawing.Size(192, 13);
            this.LBUser.TabIndex = 9;
            this.LBUser.Text = "Фамилия и инициалы пользователя";
            // 
            // TBUser
            // 
            this.TBUser.Location = new System.Drawing.Point(9, 189);
            this.TBUser.Name = "TBUser";
            this.TBUser.Size = new System.Drawing.Size(310, 20);
            this.TBUser.TabIndex = 10;
            // 
            // LBCabinet
            // 
            this.LBCabinet.AutoSize = true;
            this.LBCabinet.Location = new System.Drawing.Point(8, 290);
            this.LBCabinet.Name = "LBCabinet";
            this.LBCabinet.Size = new System.Drawing.Size(68, 13);
            this.LBCabinet.TabIndex = 13;
            this.LBCabinet.Text = "№ кабинета";
            // 
            // TBCabinet
            // 
            this.TBCabinet.Location = new System.Drawing.Point(9, 306);
            this.TBCabinet.Name = "TBCabinet";
            this.TBCabinet.Size = new System.Drawing.Size(147, 20);
            this.TBCabinet.TabIndex = 14;
            // 
            // TBPC
            // 
            this.TBPC.Location = new System.Drawing.Point(165, 306);
            this.TBPC.Name = "TBPC";
            this.TBPC.Size = new System.Drawing.Size(154, 20);
            this.TBPC.TabIndex = 15;
            // 
            // LBPC
            // 
            this.LBPC.AutoSize = true;
            this.LBPC.Location = new System.Drawing.Point(162, 290);
            this.LBPC.Name = "LBPC";
            this.LBPC.Size = new System.Drawing.Size(36, 13);
            this.LBPC.TabIndex = 18;
            this.LBPC.Text = "№ ПК";
            // 
            // LBInstaller
            // 
            this.LBInstaller.AutoSize = true;
            this.LBInstaller.Location = new System.Drawing.Point(3, 251);
            this.LBInstaller.Name = "LBInstaller";
            this.LBInstaller.Size = new System.Drawing.Size(104, 13);
            this.LBInstaller.TabIndex = 20;
            this.LBInstaller.Text = "ФИО установщика";
            // 
            // LBResponsible
            // 
            this.LBResponsible.AutoSize = true;
            this.LBResponsible.Location = new System.Drawing.Point(6, 211);
            this.LBResponsible.Name = "LBResponsible";
            this.LBResponsible.Size = new System.Drawing.Size(117, 13);
            this.LBResponsible.TabIndex = 21;
            this.LBResponsible.Text = "ФИО ответственного";
            // 
            // TBResponsible
            // 
            this.TBResponsible.Location = new System.Drawing.Point(9, 227);
            this.TBResponsible.Name = "TBResponsible";
            this.TBResponsible.Size = new System.Drawing.Size(310, 20);
            this.TBResponsible.TabIndex = 22;
            // 
            // LBPostRes
            // 
            this.LBPostRes.AutoSize = true;
            this.LBPostRes.Location = new System.Drawing.Point(6, 250);
            this.LBPostRes.Name = "LBPostRes";
            this.LBPostRes.Size = new System.Drawing.Size(148, 13);
            this.LBPostRes.TabIndex = 23;
            this.LBPostRes.Text = "Должность ответственного";
            // 
            // TBPostRes
            // 
            this.TBPostRes.Location = new System.Drawing.Point(9, 266);
            this.TBPostRes.Name = "TBPostRes";
            this.TBPostRes.Size = new System.Drawing.Size(310, 20);
            this.TBPostRes.TabIndex = 24;
            // 
            // LBDirectorName
            // 
            this.LBDirectorName.AutoSize = true;
            this.LBDirectorName.Location = new System.Drawing.Point(6, 18);
            this.LBDirectorName.Name = "LBDirectorName";
            this.LBDirectorName.Size = new System.Drawing.Size(139, 13);
            this.LBDirectorName.TabIndex = 25;
            this.LBDirectorName.Text = "ФИО утверждающего акт";
            // 
            // TBDirectorName
            // 
            this.TBDirectorName.Location = new System.Drawing.Point(9, 34);
            this.TBDirectorName.Name = "TBDirectorName";
            this.TBDirectorName.Size = new System.Drawing.Size(310, 20);
            this.TBDirectorName.TabIndex = 26;
            // 
            // LBDirectorPost
            // 
            this.LBDirectorPost.AutoSize = true;
            this.LBDirectorPost.Location = new System.Drawing.Point(6, 57);
            this.LBDirectorPost.Name = "LBDirectorPost";
            this.LBDirectorPost.Size = new System.Drawing.Size(170, 13);
            this.LBDirectorPost.TabIndex = 27;
            this.LBDirectorPost.Text = "Должность утверждающего акт";
            // 
            // TBDirectorPost
            // 
            this.TBDirectorPost.Location = new System.Drawing.Point(9, 73);
            this.TBDirectorPost.Name = "TBDirectorPost";
            this.TBDirectorPost.Size = new System.Drawing.Size(310, 20);
            this.TBDirectorPost.TabIndex = 28;
            // 
            // LBSKZI
            // 
            this.LBSKZI.AutoSize = true;
            this.LBSKZI.Location = new System.Drawing.Point(3, 97);
            this.LBSKZI.Name = "LBSKZI";
            this.LBSKZI.Size = new System.Drawing.Size(66, 13);
            this.LBSKZI.TabIndex = 30;
            this.LBSKZI.Text = "Что ставим";
            // 
            // CBSKZI
            // 
            this.CBSKZI.FormattingEnabled = true;
            this.CBSKZI.Location = new System.Drawing.Point(6, 114);
            this.CBSKZI.Name = "CBSKZI";
            this.CBSKZI.Size = new System.Drawing.Size(310, 21);
            this.CBSKZI.TabIndex = 31;
            // 
            // LBRegCard
            // 
            this.LBRegCard.AutoSize = true;
            this.LBRegCard.Location = new System.Drawing.Point(102, 175);
            this.LBRegCard.Name = "LBRegCard";
            this.LBRegCard.Size = new System.Drawing.Size(145, 13);
            this.LBRegCard.TabIndex = 32;
            this.LBRegCard.Text = "Регистрационная карточка";
            // 
            // TBRegCard
            // 
            this.TBRegCard.Location = new System.Drawing.Point(105, 192);
            this.TBRegCard.Name = "TBRegCard";
            this.TBRegCard.Size = new System.Drawing.Size(142, 20);
            this.TBRegCard.TabIndex = 33;
            // 
            // LBKey
            // 
            this.LBKey.AutoSize = true;
            this.LBKey.Location = new System.Drawing.Point(3, 176);
            this.LBKey.Name = "LBKey";
            this.LBKey.Size = new System.Drawing.Size(53, 13);
            this.LBKey.TabIndex = 34;
            this.LBKey.Text = "Ключ .dst";
            // 
            // TBKey
            // 
            this.TBKey.Location = new System.Drawing.Point(6, 192);
            this.TBKey.Name = "TBKey";
            this.TBKey.Size = new System.Drawing.Size(93, 20);
            this.TBKey.TabIndex = 35;
            // 
            // TBDistr
            // 
            this.TBDistr.Location = new System.Drawing.Point(6, 153);
            this.TBDistr.Name = "TBDistr";
            this.TBDistr.Size = new System.Drawing.Size(310, 20);
            this.TBDistr.TabIndex = 36;
            // 
            // LBDistr
            // 
            this.LBDistr.AutoSize = true;
            this.LBDistr.Location = new System.Drawing.Point(3, 137);
            this.LBDistr.Name = "LBDistr";
            this.LBDistr.Size = new System.Drawing.Size(194, 13);
            this.LBDistr.TabIndex = 37;
            this.LBDistr.Text = "Дистрибутив КриптоПРО (если есть)";
            // 
            // OpenDistr
            // 
            this.OpenDistr.FileName = "OpenDistr";
            // 
            // BTNKey
            // 
            this.BTNKey.Location = new System.Drawing.Point(253, 190);
            this.BTNKey.Name = "BTNKey";
            this.BTNKey.Size = new System.Drawing.Size(63, 23);
            this.BTNKey.TabIndex = 38;
            this.BTNKey.Text = "Открыть";
            this.BTNKey.UseVisualStyleBackColor = true;
            this.BTNKey.Click += new System.EventHandler(this.BTNKey_Click);
            // 
            // LBWorkerPost
            // 
            this.LBWorkerPost.AutoSize = true;
            this.LBWorkerPost.Location = new System.Drawing.Point(3, 290);
            this.LBWorkerPost.Name = "LBWorkerPost";
            this.LBWorkerPost.Size = new System.Drawing.Size(135, 13);
            this.LBWorkerPost.TabIndex = 39;
            this.LBWorkerPost.Text = "Должность установщика";
            // 
            // LBOrder
            // 
            this.LBOrder.AutoSize = true;
            this.LBOrder.Location = new System.Drawing.Point(6, 18);
            this.LBOrder.Name = "LBOrder";
            this.LBOrder.Size = new System.Drawing.Size(153, 13);
            this.LBOrder.TabIndex = 41;
            this.LBOrder.Text = "Акт составлен на основании";
            // 
            // TBOrder
            // 
            this.TBOrder.Location = new System.Drawing.Point(6, 34);
            this.TBOrder.Name = "TBOrder";
            this.TBOrder.Size = new System.Drawing.Size(310, 20);
            this.TBOrder.TabIndex = 42;
            // 
            // TBOrder2
            // 
            this.TBOrder2.Location = new System.Drawing.Point(157, 346);
            this.TBOrder2.Name = "TBOrder2";
            this.TBOrder2.Size = new System.Drawing.Size(159, 20);
            this.TBOrder2.TabIndex = 43;
            // 
            // TBOrder1
            // 
            this.TBOrder1.Location = new System.Drawing.Point(6, 346);
            this.TBOrder1.Name = "TBOrder1";
            this.TBOrder1.Size = new System.Drawing.Size(145, 20);
            this.TBOrder1.TabIndex = 44;
            // 
            // LBOrder1
            // 
            this.LBOrder1.AutoSize = true;
            this.LBOrder1.Location = new System.Drawing.Point(3, 330);
            this.LBOrder1.Name = "LBOrder1";
            this.LBOrder1.Size = new System.Drawing.Size(117, 13);
            this.LBOrder1.TabIndex = 45;
            this.LBOrder1.Text = "Номер первой печати";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Номер второй печати";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 327);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 48;
            // 
            // TBWorker
            // 
            this.TBWorker.Location = new System.Drawing.Point(6, 267);
            this.TBWorker.Name = "TBWorker";
            this.TBWorker.Size = new System.Drawing.Size(310, 20);
            this.TBWorker.TabIndex = 17;
            // 
            // TBWorkerPost
            // 
            this.TBWorkerPost.Location = new System.Drawing.Point(6, 306);
            this.TBWorkerPost.Name = "TBWorkerPost";
            this.TBWorkerPost.Size = new System.Drawing.Size(310, 20);
            this.TBWorkerPost.TabIndex = 40;
            // 
            // CBInstaller
            // 
            this.CBInstaller.FormattingEnabled = true;
            this.CBInstaller.Location = new System.Drawing.Point(6, 228);
            this.CBInstaller.Name = "CBInstaller";
            this.CBInstaller.Size = new System.Drawing.Size(310, 21);
            this.CBInstaller.TabIndex = 49;
            this.CBInstaller.TextChanged += new System.EventHandler(this.Change);
            // 
            // LBInstallerCB
            // 
            this.LBInstallerCB.AutoSize = true;
            this.LBInstallerCB.Location = new System.Drawing.Point(3, 213);
            this.LBInstallerCB.Name = "LBInstallerCB";
            this.LBInstallerCB.Size = new System.Drawing.Size(98, 13);
            this.LBInstallerCB.TabIndex = 50;
            this.LBInstallerCB.Text = "Кто устанавливал";
            // 
            // GBBuyer
            // 
            this.GBBuyer.Controls.Add(this.BTNSearchINN);
            this.GBBuyer.Controls.Add(this.LBDirectorName);
            this.GBBuyer.Controls.Add(this.TBFoundation);
            this.GBBuyer.Controls.Add(this.LBFoundation);
            this.GBBuyer.Controls.Add(this.LBDay);
            this.GBBuyer.Controls.Add(this.LBMonth);
            this.GBBuyer.Controls.Add(this.TBDay);
            this.GBBuyer.Controls.Add(this.TBYear);
            this.GBBuyer.Controls.Add(this.CBMonth);
            this.GBBuyer.Controls.Add(this.LBYear);
            this.GBBuyer.Controls.Add(this.LBUser);
            this.GBBuyer.Controls.Add(this.TBUser);
            this.GBBuyer.Controls.Add(this.TBDirectorName);
            this.GBBuyer.Controls.Add(this.LBDirectorPost);
            this.GBBuyer.Controls.Add(this.TBDirectorPost);
            this.GBBuyer.Controls.Add(this.LBPostRes);
            this.GBBuyer.Controls.Add(this.LBResponsible);
            this.GBBuyer.Controls.Add(this.TBResponsible);
            this.GBBuyer.Controls.Add(this.TBPostRes);
            this.GBBuyer.Controls.Add(this.LBPC);
            this.GBBuyer.Controls.Add(this.LBCabinet);
            this.GBBuyer.Controls.Add(this.TBCabinet);
            this.GBBuyer.Controls.Add(this.TBPC);
            this.GBBuyer.Location = new System.Drawing.Point(8, 6);
            this.GBBuyer.Name = "GBBuyer";
            this.GBBuyer.Size = new System.Drawing.Size(333, 383);
            this.GBBuyer.TabIndex = 51;
            this.GBBuyer.TabStop = false;
            this.GBBuyer.Text = "Организация-заказчик";
            // 
            // BTNSearchINN
            // 
            this.BTNSearchINN.Enabled = false;
            this.BTNSearchINN.Location = new System.Drawing.Point(9, 337);
            this.BTNSearchINN.Name = "BTNSearchINN";
            this.BTNSearchINN.Size = new System.Drawing.Size(310, 36);
            this.BTNSearchINN.TabIndex = 29;
            this.BTNSearchINN.Text = "Поиск организации по ИНН";
            this.BTNSearchINN.UseVisualStyleBackColor = true;
            this.BTNSearchINN.Click += new System.EventHandler(this.Authentication);
            // 
            // GBInstaller
            // 
            this.GBInstaller.Controls.Add(this.CBAct);
            this.GBInstaller.Controls.Add(this.label3);
            this.GBInstaller.Controls.Add(this.LBOrder);
            this.GBInstaller.Controls.Add(this.LBInstallerCB);
            this.GBInstaller.Controls.Add(this.TBWorker);
            this.GBInstaller.Controls.Add(this.CBInstaller);
            this.GBInstaller.Controls.Add(this.LBInstaller);
            this.GBInstaller.Controls.Add(this.CBSKZI);
            this.GBInstaller.Controls.Add(this.label1);
            this.GBInstaller.Controls.Add(this.LBRegCard);
            this.GBInstaller.Controls.Add(this.LBOrder1);
            this.GBInstaller.Controls.Add(this.TBRegCard);
            this.GBInstaller.Controls.Add(this.TBOrder1);
            this.GBInstaller.Controls.Add(this.LBKey);
            this.GBInstaller.Controls.Add(this.TBOrder2);
            this.GBInstaller.Controls.Add(this.TBKey);
            this.GBInstaller.Controls.Add(this.TBOrder);
            this.GBInstaller.Controls.Add(this.TBDistr);
            this.GBInstaller.Controls.Add(this.LBDistr);
            this.GBInstaller.Controls.Add(this.TBWorkerPost);
            this.GBInstaller.Controls.Add(this.LBSKZI);
            this.GBInstaller.Controls.Add(this.LBWorkerPost);
            this.GBInstaller.Controls.Add(this.BTNKey);
            this.GBInstaller.Location = new System.Drawing.Point(347, 6);
            this.GBInstaller.Name = "GBInstaller";
            this.GBInstaller.Size = new System.Drawing.Size(333, 383);
            this.GBInstaller.TabIndex = 52;
            this.GBInstaller.TabStop = false;
            this.GBInstaller.Text = "Организация-исполнитель";
            // 
            // CBAct
            // 
            this.CBAct.FormattingEnabled = true;
            this.CBAct.Items.AddRange(new object[] {
            "Акт о неготовности",
            "СКЗИ VipNet Client (АРМ СЭД)",
            "СКЗИ VipNet Client (ССТУ)",
            "СКЗИ VipNet Client (ПФР)",
            "СКЗИ VipNet Client (Иное)",
            "СКЗИ КриптоПРО",
            "Континент-АП",
            "СКЗИ Континент TLS",
            "СКЗИ JinnClient",
            "Иное"});
            this.CBAct.Location = new System.Drawing.Point(6, 73);
            this.CBAct.Name = "CBAct";
            this.CBAct.Size = new System.Drawing.Size(310, 21);
            this.CBAct.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Выберите категорию акта";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 54;
            this.button1.Text = "BTNTest";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Authentication);
            // 
            // CB123
            // 
            this.CB123.FormattingEnabled = true;
            this.CB123.Location = new System.Drawing.Point(10, 42);
            this.CB123.Name = "CB123";
            this.CB123.Size = new System.Drawing.Size(131, 21);
            this.CB123.TabIndex = 53;
            // 
            // LBTest
            // 
            this.LBTest.AutoSize = true;
            this.LBTest.Location = new System.Drawing.Point(687, 224);
            this.LBTest.Name = "LBTest";
            this.LBTest.Size = new System.Drawing.Size(0, 13);
            this.LBTest.TabIndex = 55;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 78);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(680, 328);
            this.textBox1.TabIndex = 56;
            // 
            // TABAll
            // 
            this.TABAll.Controls.Add(this.TABAct);
            this.TABAll.Controls.Add(this.TABTest);
            this.TABAll.Location = new System.Drawing.Point(3, 1);
            this.TABAll.Name = "TABAll";
            this.TABAll.SelectedIndex = 0;
            this.TABAll.Size = new System.Drawing.Size(705, 489);
            this.TABAll.TabIndex = 57;
            // 
            // TABAct
            // 
            this.TABAct.Controls.Add(this.GBBuyer);
            this.TABAct.Controls.Add(this.BTNSave);
            this.TABAct.Controls.Add(this.GBInstaller);
            this.TABAct.Location = new System.Drawing.Point(4, 22);
            this.TABAct.Name = "TABAct";
            this.TABAct.Padding = new System.Windows.Forms.Padding(3);
            this.TABAct.Size = new System.Drawing.Size(697, 463);
            this.TABAct.TabIndex = 0;
            this.TABAct.Text = "Акт";
            this.TABAct.UseVisualStyleBackColor = true;
            // 
            // TABTest
            // 
            this.TABTest.Controls.Add(this.button1);
            this.TABTest.Controls.Add(this.textBox1);
            this.TABTest.Controls.Add(this.CB123);
            this.TABTest.Location = new System.Drawing.Point(4, 22);
            this.TABTest.Name = "TABTest";
            this.TABTest.Padding = new System.Windows.Forms.Padding(3);
            this.TABTest.Size = new System.Drawing.Size(697, 463);
            this.TABTest.TabIndex = 1;
            this.TABTest.Text = "Тест";
            this.TABTest.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 488);
            this.Controls.Add(this.TABAll);
            this.Controls.Add(this.LBTest);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "Создание акта";
            this.GBBuyer.ResumeLayout(false);
            this.GBBuyer.PerformLayout();
            this.GBInstaller.ResumeLayout(false);
            this.GBInstaller.PerformLayout();
            this.TABAll.ResumeLayout(false);
            this.TABAct.ResumeLayout(false);
            this.TABAct.PerformLayout();
            this.TABTest.ResumeLayout(false);
            this.TABTest.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TBFoundation;
        private System.Windows.Forms.Button BTNSave;
        private System.Windows.Forms.Label LBFoundation;
        private System.Windows.Forms.Label LBDay;
        private System.Windows.Forms.Label LBMonth;
        private System.Windows.Forms.TextBox TBDay;
        private System.Windows.Forms.TextBox TBYear;
        private System.Windows.Forms.ComboBox CBMonth;
        private System.Windows.Forms.Label LBYear;
        private System.Windows.Forms.Label LBUser;
        private System.Windows.Forms.TextBox TBUser;
        private System.Windows.Forms.Label LBCabinet;
        private System.Windows.Forms.TextBox TBCabinet;
        private System.Windows.Forms.TextBox TBPC;
        private System.Windows.Forms.Label LBPC;
        private System.Windows.Forms.Label LBInstaller;
        private System.Windows.Forms.Label LBResponsible;
        private System.Windows.Forms.TextBox TBResponsible;
        private System.Windows.Forms.Label LBPostRes;
        private System.Windows.Forms.TextBox TBPostRes;
        private System.Windows.Forms.SaveFileDialog Saving;
        private System.Windows.Forms.Label LBDirectorName;
        private System.Windows.Forms.TextBox TBDirectorName;
        private System.Windows.Forms.Label LBDirectorPost;
        private System.Windows.Forms.TextBox TBDirectorPost;
        private System.Windows.Forms.Label LBSKZI;
        private System.Windows.Forms.ComboBox CBSKZI;
        private System.Windows.Forms.Label LBRegCard;
        private System.Windows.Forms.TextBox TBRegCard;
        private System.Windows.Forms.Label LBKey;
        private System.Windows.Forms.TextBox TBKey;
        private System.Windows.Forms.TextBox TBDistr;
        private System.Windows.Forms.Label LBDistr;
        private System.Windows.Forms.OpenFileDialog OpenDistr;
        private System.Windows.Forms.Button BTNKey;
        private System.Windows.Forms.Label LBWorkerPost;
        private System.Windows.Forms.FolderBrowserDialog OpenCard;
        private System.Windows.Forms.Label LBOrder;
        private System.Windows.Forms.TextBox TBOrder;
        private System.Windows.Forms.TextBox TBOrder2;
        private System.Windows.Forms.TextBox TBOrder1;
        private System.Windows.Forms.Label LBOrder1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBWorker;
        private System.Windows.Forms.TextBox TBWorkerPost;
        private System.Windows.Forms.ComboBox CBInstaller;
        private System.Windows.Forms.Label LBInstallerCB;
        private System.Windows.Forms.GroupBox GBBuyer;
        private System.Windows.Forms.GroupBox GBInstaller;
        private System.Windows.Forms.Button BTNSearchINN;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CBAct;
        private System.Windows.Forms.ComboBox CB123;
        private System.Windows.Forms.Label LBTest;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabControl TABAll;
        private System.Windows.Forms.TabPage TABAct;
        private System.Windows.Forms.TabPage TABTest;
    }
}

