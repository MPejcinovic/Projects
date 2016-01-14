namespace DiplomskiProjekt
{
    partial class Certificate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbPgGenCertificate = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.cmbBoxValidTillYear = new System.Windows.Forms.ComboBox();
            this.cmbBoxValidTillMonth = new System.Windows.Forms.ComboBox();
            this.cmbBoxValidTillDay = new System.Windows.Forms.ComboBox();
            this.cmbBoxValidFromYear = new System.Windows.Forms.ComboBox();
            this.cmbBoxValidFromMonth = new System.Windows.Forms.ComboBox();
            this.cmbBoxValidFromDay = new System.Windows.Forms.ComboBox();
            this.cmbBoxSignatureAlgorithm = new System.Windows.Forms.ComboBox();
            this.txtBoxSubjectName = new System.Windows.Forms.TextBox();
            this.btnGenerateCertificate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPgGetCertificate = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.rtxtBoxListCollection = new System.Windows.Forms.RichTextBox();
            this.txtBoxSiteUrl = new System.Windows.Forms.TextBox();
            this.cmbBoxCertificates = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnGetLists = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tbPgGenCertificate.SuspendLayout();
            this.tbPgGetCertificate.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tbPgGenCertificate);
            this.tabControl1.Controls.Add(this.tbPgGetCertificate);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1192, 551);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexchanged);
            // 
            // tbPgGenCertificate
            // 
            this.tbPgGenCertificate.BackColor = System.Drawing.Color.LightGray;
            this.tbPgGenCertificate.Controls.Add(this.btnView);
            this.tbPgGenCertificate.Controls.Add(this.label11);
            this.tbPgGenCertificate.Controls.Add(this.btnCloseForm);
            this.tbPgGenCertificate.Controls.Add(this.lblMessage);
            this.tbPgGenCertificate.Controls.Add(this.cmbBoxValidTillYear);
            this.tbPgGenCertificate.Controls.Add(this.cmbBoxValidTillMonth);
            this.tbPgGenCertificate.Controls.Add(this.cmbBoxValidTillDay);
            this.tbPgGenCertificate.Controls.Add(this.cmbBoxValidFromYear);
            this.tbPgGenCertificate.Controls.Add(this.cmbBoxValidFromMonth);
            this.tbPgGenCertificate.Controls.Add(this.cmbBoxValidFromDay);
            this.tbPgGenCertificate.Controls.Add(this.cmbBoxSignatureAlgorithm);
            this.tbPgGenCertificate.Controls.Add(this.txtBoxSubjectName);
            this.tbPgGenCertificate.Controls.Add(this.btnGenerateCertificate);
            this.tbPgGenCertificate.Controls.Add(this.label5);
            this.tbPgGenCertificate.Controls.Add(this.label4);
            this.tbPgGenCertificate.Controls.Add(this.label2);
            this.tbPgGenCertificate.Controls.Add(this.label3);
            this.tbPgGenCertificate.Controls.Add(this.label1);
            this.tbPgGenCertificate.Location = new System.Drawing.Point(4, 25);
            this.tbPgGenCertificate.Name = "tbPgGenCertificate";
            this.tbPgGenCertificate.Padding = new System.Windows.Forms.Padding(3);
            this.tbPgGenCertificate.Size = new System.Drawing.Size(1184, 522);
            this.tbPgGenCertificate.TabIndex = 0;
            this.tbPgGenCertificate.Text = "Generate Certificate";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(784, 487);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(363, 17);
            this.label11.TabIndex = 18;
            this.label11.Text = "Matea Pejčinović, 0036462850, Diplomski projekt";
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCloseForm.Location = new System.Drawing.Point(1008, 431);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(139, 42);
            this.btnCloseForm.TabIndex = 17;
            this.btnCloseForm.Text = "CLOSE FORM";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMessage.Location = new System.Drawing.Point(24, 380);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(496, 85);
            this.lblMessage.TabIndex = 16;
            this.lblMessage.Visible = false;
            // 
            // cmbBoxValidTillYear
            // 
            this.cmbBoxValidTillYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBoxValidTillYear.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbBoxValidTillYear.FormattingEnabled = true;
            this.cmbBoxValidTillYear.Items.AddRange(new object[] {
            "1990",
            "1991",
            "1992",
            "1993",
            "1994",
            "1995",
            "1996",
            "1997",
            "1998",
            "1999",
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030",
            "2031",
            "2032",
            "2033",
            "2034",
            "2035",
            "2036",
            "2037",
            "2038",
            "2039",
            "2040",
            "2041",
            "2042",
            "2043",
            "2044",
            "2045",
            "2046",
            "2047",
            "2048",
            "2049",
            "2050",
            "2051",
            "2052",
            "2053",
            "2054",
            "2055",
            "2056",
            "2057",
            "2058",
            "2059",
            "2060",
            "2061",
            "2062",
            "2063"});
            this.cmbBoxValidTillYear.Location = new System.Drawing.Point(919, 309);
            this.cmbBoxValidTillYear.Name = "cmbBoxValidTillYear";
            this.cmbBoxValidTillYear.Size = new System.Drawing.Size(228, 28);
            this.cmbBoxValidTillYear.TabIndex = 15;
            this.cmbBoxValidTillYear.SelectedIndexChanged += new System.EventHandler(this.cmbBoxValidTillYear_SelectedIndexChanged);
            // 
            // cmbBoxValidTillMonth
            // 
            this.cmbBoxValidTillMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBoxValidTillMonth.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbBoxValidTillMonth.FormattingEnabled = true;
            this.cmbBoxValidTillMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbBoxValidTillMonth.Location = new System.Drawing.Point(539, 309);
            this.cmbBoxValidTillMonth.Name = "cmbBoxValidTillMonth";
            this.cmbBoxValidTillMonth.Size = new System.Drawing.Size(355, 28);
            this.cmbBoxValidTillMonth.TabIndex = 14;
            this.cmbBoxValidTillMonth.SelectedIndexChanged += new System.EventHandler(this.cmbBoxValidTillMonth_SelectedIndexChanged);
            // 
            // cmbBoxValidTillDay
            // 
            this.cmbBoxValidTillDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBoxValidTillDay.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbBoxValidTillDay.FormattingEnabled = true;
            this.cmbBoxValidTillDay.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cmbBoxValidTillDay.Location = new System.Drawing.Point(239, 309);
            this.cmbBoxValidTillDay.Name = "cmbBoxValidTillDay";
            this.cmbBoxValidTillDay.Size = new System.Drawing.Size(281, 28);
            this.cmbBoxValidTillDay.TabIndex = 13;
            this.cmbBoxValidTillDay.SelectedIndexChanged += new System.EventHandler(this.cmbBoxValidTillDay_SelectedIndexChanged);
            // 
            // cmbBoxValidFromYear
            // 
            this.cmbBoxValidFromYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBoxValidFromYear.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbBoxValidFromYear.FormattingEnabled = true;
            this.cmbBoxValidFromYear.Items.AddRange(new object[] {
            "1990",
            "1991",
            "1992",
            "1993",
            "1994",
            "1995",
            "1996",
            "1997",
            "1998",
            "1999",
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030",
            "2031",
            "2032",
            "2033",
            "2034",
            "2035",
            "2036",
            "2037",
            "2038",
            "2039",
            "2040",
            "2041",
            "2042",
            "2043",
            "2044",
            "2045",
            "2046",
            "2047",
            "2048",
            "2049",
            "2050",
            "2051",
            "2052",
            "2053",
            "2054",
            "2055",
            "2056",
            "2057",
            "2058",
            "2059",
            "2060",
            "2061",
            "2062",
            "2063"});
            this.cmbBoxValidFromYear.Location = new System.Drawing.Point(919, 244);
            this.cmbBoxValidFromYear.Name = "cmbBoxValidFromYear";
            this.cmbBoxValidFromYear.Size = new System.Drawing.Size(228, 28);
            this.cmbBoxValidFromYear.TabIndex = 12;
            this.cmbBoxValidFromYear.SelectedIndexChanged += new System.EventHandler(this.cmbBoxValidFromYear_SelectedIndexChanged);
            // 
            // cmbBoxValidFromMonth
            // 
            this.cmbBoxValidFromMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBoxValidFromMonth.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbBoxValidFromMonth.FormattingEnabled = true;
            this.cmbBoxValidFromMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbBoxValidFromMonth.Location = new System.Drawing.Point(539, 244);
            this.cmbBoxValidFromMonth.Name = "cmbBoxValidFromMonth";
            this.cmbBoxValidFromMonth.Size = new System.Drawing.Size(355, 28);
            this.cmbBoxValidFromMonth.TabIndex = 11;
            this.cmbBoxValidFromMonth.SelectedIndexChanged += new System.EventHandler(this.cmbBoxValidFromMonth_SelectedIndexChanged);
            // 
            // cmbBoxValidFromDay
            // 
            this.cmbBoxValidFromDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBoxValidFromDay.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbBoxValidFromDay.FormattingEnabled = true;
            this.cmbBoxValidFromDay.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cmbBoxValidFromDay.Location = new System.Drawing.Point(239, 244);
            this.cmbBoxValidFromDay.Name = "cmbBoxValidFromDay";
            this.cmbBoxValidFromDay.Size = new System.Drawing.Size(281, 28);
            this.cmbBoxValidFromDay.TabIndex = 10;
            this.cmbBoxValidFromDay.SelectedIndexChanged += new System.EventHandler(this.cmbBoxValidFromDay_SelectedIndexChanged);
            // 
            // cmbBoxSignatureAlgorithm
            // 
            this.cmbBoxSignatureAlgorithm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBoxSignatureAlgorithm.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbBoxSignatureAlgorithm.FormattingEnabled = true;
            this.cmbBoxSignatureAlgorithm.Items.AddRange(new object[] {
            "MD2withRSA",
            "MD5withRSA",
            "SHA1withRSA",
            "SHA224withRSA",
            "SHA256withRSA",
            "SHA384withRSA",
            "SHA512withRSA",
            "RIPEMD128withRSA",
            "RIPEMD160withRSA",
            "RIPEMD256withRSA",
            "SHA1withECDSA",
            "SHA224withECDSA",
            "SHA256withECDSA",
            "SHA384withECDSA",
            "SHA512withECDSA",
            "GOST3411withGOST3410",
            "GOST3411withECGOST3410"});
            this.cmbBoxSignatureAlgorithm.Location = new System.Drawing.Point(239, 185);
            this.cmbBoxSignatureAlgorithm.Name = "cmbBoxSignatureAlgorithm";
            this.cmbBoxSignatureAlgorithm.Size = new System.Drawing.Size(908, 28);
            this.cmbBoxSignatureAlgorithm.TabIndex = 9;
            this.cmbBoxSignatureAlgorithm.SelectedIndexChanged += new System.EventHandler(this.cmbBoxSignatureAlgorithm_SelectedIndexChanged);
            // 
            // txtBoxSubjectName
            // 
            this.txtBoxSubjectName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxSubjectName.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtBoxSubjectName.Location = new System.Drawing.Point(239, 124);
            this.txtBoxSubjectName.Name = "txtBoxSubjectName";
            this.txtBoxSubjectName.Size = new System.Drawing.Size(908, 28);
            this.txtBoxSubjectName.TabIndex = 8;
            this.txtBoxSubjectName.Text = "Name";
            this.txtBoxSubjectName.TextChanged += new System.EventHandler(this.txtBoxSubjectName_TextChanged);
            // 
            // btnGenerateCertificate
            // 
            this.btnGenerateCertificate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateCertificate.Enabled = false;
            this.btnGenerateCertificate.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnGenerateCertificate.Location = new System.Drawing.Point(559, 380);
            this.btnGenerateCertificate.Name = "btnGenerateCertificate";
            this.btnGenerateCertificate.Size = new System.Drawing.Size(244, 57);
            this.btnGenerateCertificate.TabIndex = 7;
            this.btnGenerateCertificate.Text = "GENERATE CERTIFICATE";
            this.btnGenerateCertificate.UseVisualStyleBackColor = true;
            this.btnGenerateCertificate.Click += new System.EventHandler(this.btnGenerateCertificate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(24, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Valid Until:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(24, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Valid from:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(24, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Signature Algorithm:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(24, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Subject Name:";
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(23, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(888, 66);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please provide essential information for generating certificate!";
            // 
            // tbPgGetCertificate
            // 
            this.tbPgGetCertificate.AutoScroll = true;
            this.tbPgGetCertificate.BackColor = System.Drawing.Color.LightGray;
            this.tbPgGetCertificate.Controls.Add(this.label10);
            this.tbPgGetCertificate.Controls.Add(this.btnClose);
            this.tbPgGetCertificate.Controls.Add(this.rtxtBoxListCollection);
            this.tbPgGetCertificate.Controls.Add(this.txtBoxSiteUrl);
            this.tbPgGetCertificate.Controls.Add(this.cmbBoxCertificates);
            this.tbPgGetCertificate.Controls.Add(this.label9);
            this.tbPgGetCertificate.Controls.Add(this.btnGetLists);
            this.tbPgGetCertificate.Controls.Add(this.label8);
            this.tbPgGetCertificate.Controls.Add(this.label7);
            this.tbPgGetCertificate.Controls.Add(this.label6);
            this.tbPgGetCertificate.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbPgGetCertificate.Location = new System.Drawing.Point(4, 25);
            this.tbPgGetCertificate.Name = "tbPgGetCertificate";
            this.tbPgGetCertificate.Padding = new System.Windows.Forms.Padding(3);
            this.tbPgGetCertificate.Size = new System.Drawing.Size(1184, 522);
            this.tbPgGetCertificate.TabIndex = 1;
            this.tbPgGetCertificate.Text = "Get Info from Service";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(764, 491);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(363, 17);
            this.label10.TabIndex = 9;
            this.label10.Text = "Matea Pejčinović, 0036462850, Diplomski projekt";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(983, 437);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(144, 37);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "CLOSE FORM";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // rtxtBoxListCollection
            // 
            this.rtxtBoxListCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtBoxListCollection.Location = new System.Drawing.Point(189, 321);
            this.rtxtBoxListCollection.Name = "rtxtBoxListCollection";
            this.rtxtBoxListCollection.Size = new System.Drawing.Size(938, 96);
            this.rtxtBoxListCollection.TabIndex = 7;
            this.rtxtBoxListCollection.Text = "";
            // 
            // txtBoxSiteUrl
            // 
            this.txtBoxSiteUrl.Location = new System.Drawing.Point(189, 158);
            this.txtBoxSiteUrl.Name = "txtBoxSiteUrl";
            this.txtBoxSiteUrl.Size = new System.Drawing.Size(938, 28);
            this.txtBoxSiteUrl.TabIndex = 6;
            this.txtBoxSiteUrl.TextChanged += new System.EventHandler(this.txtBoxSiteUrl_TextChanged);
            // 
            // cmbBoxCertificates
            // 
            this.cmbBoxCertificates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBoxCertificates.FormattingEnabled = true;
            this.cmbBoxCertificates.Location = new System.Drawing.Point(189, 99);
            this.cmbBoxCertificates.Name = "cmbBoxCertificates";
            this.cmbBoxCertificates.Size = new System.Drawing.Size(938, 28);
            this.cmbBoxCertificates.TabIndex = 5;
            this.cmbBoxCertificates.SelectedIndexChanged += new System.EventHandler(this.cmbBoxCertificates_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 321);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "List collection:";
            // 
            // btnGetLists
            // 
            this.btnGetLists.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetLists.Enabled = false;
            this.btnGetLists.Location = new System.Drawing.Point(510, 220);
            this.btnGetLists.Name = "btnGetLists";
            this.btnGetLists.Size = new System.Drawing.Size(229, 55);
            this.btnGetLists.TabIndex = 3;
            this.btnGetLists.Text = "GET LISTS";
            this.btnGetLists.UseVisualStyleBackColor = true;
            this.btnGetLists.Click += new System.EventHandler(this.btnGetLists_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 166);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "Site Url:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Certificates:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoEllipsis = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(32, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1006, 54);
            this.label6.TabIndex = 0;
            this.label6.Text = "Choose appropriate certificate in order to get list collection from SharePoint!";
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnView.Location = new System.Drawing.Point(559, 443);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(244, 35);
            this.btnView.TabIndex = 19;
            this.btnView.Text = "VIEW CERTIFICATE";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Visible = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // Certificate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 575);
            this.Controls.Add(this.tabControl1);
            this.Name = "Certificate";
            this.Text = "Certificate";
            this.tabControl1.ResumeLayout(false);
            this.tbPgGenCertificate.ResumeLayout(false);
            this.tbPgGenCertificate.PerformLayout();
            this.tbPgGetCertificate.ResumeLayout(false);
            this.tbPgGetCertificate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbPgGenCertificate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tbPgGetCertificate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBoxSignatureAlgorithm;
        private System.Windows.Forms.TextBox txtBoxSubjectName;
        private System.Windows.Forms.Button btnGenerateCertificate;
        private System.Windows.Forms.ComboBox cmbBoxValidTillYear;
        private System.Windows.Forms.ComboBox cmbBoxValidTillMonth;
        private System.Windows.Forms.ComboBox cmbBoxValidTillDay;
        private System.Windows.Forms.ComboBox cmbBoxValidFromYear;
        private System.Windows.Forms.ComboBox cmbBoxValidFromMonth;
        private System.Windows.Forms.ComboBox cmbBoxValidFromDay;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RichTextBox rtxtBoxListCollection;
        private System.Windows.Forms.TextBox txtBoxSiteUrl;
        private System.Windows.Forms.ComboBox cmbBoxCertificates;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnGetLists;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Button btnView;
    }
}