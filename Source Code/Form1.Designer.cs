namespace xs8_Cipher
{
    partial class Form1
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
            this.encrypt_grpb = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.encryptFile_cbox = new System.Windows.Forms.CheckBox();
            this.encryptSelFile_txtb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.encryptSelFile_btn = new System.Windows.Forms.Button();
            this.encryptFileOutputName_txtb = new System.Windows.Forms.TextBox();
            this.encrypt_btn = new System.Windows.Forms.Button();
            this.encryptKey_grpb = new System.Windows.Forms.GroupBox();
            this.encryptKSize_cmbox = new System.Windows.Forms.ComboBox();
            this.encryptKey_txtb = new System.Windows.Forms.TextBox();
            this.encryptText_grpb = new System.Windows.Forms.GroupBox();
            this.encryptTextClear_txtb = new System.Windows.Forms.RichTextBox();
            this.encryptedPlainText_txtb = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.encryptedToHex_radio = new System.Windows.Forms.RadioButton();
            this.encryptedToBase64_radio = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.decrypt_grpb = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.decryptFile_cbox = new System.Windows.Forms.CheckBox();
            this.decryptSelFile_txtb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.decryptSelFile_btn = new System.Windows.Forms.Button();
            this.decryptFileOutputName_txtb = new System.Windows.Forms.TextBox();
            this.decrypt_btn = new System.Windows.Forms.Button();
            this.decryptKey_grpb = new System.Windows.Forms.GroupBox();
            this.decryptKSize_cmbox = new System.Windows.Forms.ComboBox();
            this.decryptKey_txtb = new System.Windows.Forms.TextBox();
            this.decryptText_grpb = new System.Windows.Forms.GroupBox();
            this.decryptTextEncrypted_txtb = new System.Windows.Forms.RichTextBox();
            this.decryptedEncryptedText_txtb = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.encryptedFromHex_radio = new System.Windows.Forms.RadioButton();
            this.encryptedFromBase64_radio = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.clearAll_btn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.progress_grpbx = new System.Windows.Forms.GroupBox();
            this.workCancel_btn = new System.Windows.Forms.Button();
            this.work_progressbar = new System.Windows.Forms.ProgressBar();
            this.process_bkgw = new System.ComponentModel.BackgroundWorker();
            this.encrypt_grpb.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.encryptKey_grpb.SuspendLayout();
            this.encryptText_grpb.SuspendLayout();
            this.panel1.SuspendLayout();
            this.decrypt_grpb.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.decryptKey_grpb.SuspendLayout();
            this.decryptText_grpb.SuspendLayout();
            this.panel2.SuspendLayout();
            this.progress_grpbx.SuspendLayout();
            this.SuspendLayout();
            // 
            // encrypt_grpb
            // 
            this.encrypt_grpb.Controls.Add(this.groupBox1);
            this.encrypt_grpb.Controls.Add(this.encrypt_btn);
            this.encrypt_grpb.Controls.Add(this.encryptKey_grpb);
            this.encrypt_grpb.Controls.Add(this.encryptText_grpb);
            this.encrypt_grpb.Location = new System.Drawing.Point(2, 2);
            this.encrypt_grpb.Name = "encrypt_grpb";
            this.encrypt_grpb.Size = new System.Drawing.Size(453, 435);
            this.encrypt_grpb.TabIndex = 0;
            this.encrypt_grpb.TabStop = false;
            this.encrypt_grpb.Text = "Encrypt";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.encryptFile_cbox);
            this.groupBox1.Controls.Add(this.encryptSelFile_txtb);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.encryptSelFile_btn);
            this.groupBox1.Controls.Add(this.encryptFileOutputName_txtb);
            this.groupBox1.Location = new System.Drawing.Point(6, 315);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 42);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File";
            // 
            // encryptFile_cbox
            // 
            this.encryptFile_cbox.AutoSize = true;
            this.encryptFile_cbox.Location = new System.Drawing.Point(420, 19);
            this.encryptFile_cbox.Name = "encryptFile_cbox";
            this.encryptFile_cbox.Size = new System.Drawing.Size(15, 14);
            this.encryptFile_cbox.TabIndex = 5;
            this.encryptFile_cbox.UseVisualStyleBackColor = true;
            this.encryptFile_cbox.CheckedChanged += new System.EventHandler(this.encryptFile_cbox_CheckedChanged);
            // 
            // encryptSelFile_txtb
            // 
            this.encryptSelFile_txtb.Location = new System.Drawing.Point(184, 16);
            this.encryptSelFile_txtb.Name = "encryptSelFile_txtb";
            this.encryptSelFile_txtb.ReadOnly = true;
            this.encryptSelFile_txtb.Size = new System.Drawing.Size(175, 20);
            this.encryptSelFile_txtb.TabIndex = 4;
            this.encryptSelFile_txtb.TextChanged += new System.EventHandler(this.encryptSelFile_txtb_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(170, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(9, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "|";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Output:";
            // 
            // encryptSelFile_btn
            // 
            this.encryptSelFile_btn.Location = new System.Drawing.Point(365, 14);
            this.encryptSelFile_btn.Name = "encryptSelFile_btn";
            this.encryptSelFile_btn.Size = new System.Drawing.Size(48, 23);
            this.encryptSelFile_btn.TabIndex = 1;
            this.encryptSelFile_btn.Text = "Select";
            this.encryptSelFile_btn.UseVisualStyleBackColor = true;
            this.encryptSelFile_btn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.encryptSelFile_btn_MouseClick);
            // 
            // encryptFileOutputName_txtb
            // 
            this.encryptFileOutputName_txtb.Location = new System.Drawing.Point(48, 16);
            this.encryptFileOutputName_txtb.Name = "encryptFileOutputName_txtb";
            this.encryptFileOutputName_txtb.Size = new System.Drawing.Size(116, 20);
            this.encryptFileOutputName_txtb.TabIndex = 0;
            this.encryptFileOutputName_txtb.TextChanged += new System.EventHandler(this.encryptFileOutputName_txtb_TextChanged);
            // 
            // encrypt_btn
            // 
            this.encrypt_btn.Enabled = false;
            this.encrypt_btn.Location = new System.Drawing.Point(6, 408);
            this.encrypt_btn.Name = "encrypt_btn";
            this.encrypt_btn.Size = new System.Drawing.Size(444, 23);
            this.encrypt_btn.TabIndex = 1;
            this.encrypt_btn.Text = "Encrypt";
            this.encrypt_btn.UseVisualStyleBackColor = true;
            this.encrypt_btn.Click += new System.EventHandler(this.encrypt_btn_Click);
            // 
            // encryptKey_grpb
            // 
            this.encryptKey_grpb.Controls.Add(this.encryptKSize_cmbox);
            this.encryptKey_grpb.Controls.Add(this.encryptKey_txtb);
            this.encryptKey_grpb.Location = new System.Drawing.Point(6, 363);
            this.encryptKey_grpb.Name = "encryptKey_grpb";
            this.encryptKey_grpb.Size = new System.Drawing.Size(440, 46);
            this.encryptKey_grpb.TabIndex = 1;
            this.encryptKey_grpb.TabStop = false;
            this.encryptKey_grpb.Text = "Encryption key";
            // 
            // encryptKSize_cmbox
            // 
            this.encryptKSize_cmbox.DropDownHeight = 100;
            this.encryptKSize_cmbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.encryptKSize_cmbox.IntegralHeight = false;
            this.encryptKSize_cmbox.Items.AddRange(new object[] {
            "128-bit",
            "256-bit",
            "512-bit"});
            this.encryptKSize_cmbox.Location = new System.Drawing.Point(9, 18);
            this.encryptKSize_cmbox.Name = "encryptKSize_cmbox";
            this.encryptKSize_cmbox.Size = new System.Drawing.Size(68, 21);
            this.encryptKSize_cmbox.TabIndex = 2;
            this.encryptKSize_cmbox.SelectedIndexChanged += new System.EventHandler(this.encryptKSize_cmbox_SelectedIndexChanged);
            // 
            // encryptKey_txtb
            // 
            this.encryptKey_txtb.Location = new System.Drawing.Point(83, 19);
            this.encryptKey_txtb.MaxLength = 64;
            this.encryptKey_txtb.Name = "encryptKey_txtb";
            this.encryptKey_txtb.Size = new System.Drawing.Size(352, 20);
            this.encryptKey_txtb.TabIndex = 0;
            this.encryptKey_txtb.Text = "3t6w9z$C&F)J@Nc9";
            this.encryptKey_txtb.TextChanged += new System.EventHandler(this.encryptKey_txtb_TextChanged);
            // 
            // encryptText_grpb
            // 
            this.encryptText_grpb.Controls.Add(this.encryptTextClear_txtb);
            this.encryptText_grpb.Controls.Add(this.encryptedPlainText_txtb);
            this.encryptText_grpb.Controls.Add(this.panel1);
            this.encryptText_grpb.Controls.Add(this.label2);
            this.encryptText_grpb.Controls.Add(this.label1);
            this.encryptText_grpb.Location = new System.Drawing.Point(6, 18);
            this.encryptText_grpb.Name = "encryptText_grpb";
            this.encryptText_grpb.Size = new System.Drawing.Size(440, 291);
            this.encryptText_grpb.TabIndex = 0;
            this.encryptText_grpb.TabStop = false;
            this.encryptText_grpb.Text = "Text";
            // 
            // encryptTextClear_txtb
            // 
            this.encryptTextClear_txtb.Location = new System.Drawing.Point(6, 30);
            this.encryptTextClear_txtb.Name = "encryptTextClear_txtb";
            this.encryptTextClear_txtb.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.encryptTextClear_txtb.Size = new System.Drawing.Size(428, 110);
            this.encryptTextClear_txtb.TabIndex = 11;
            this.encryptTextClear_txtb.Text = "";
            this.encryptTextClear_txtb.TextChanged += new System.EventHandler(this.encryptTextClear_txtb_TextChanged);
            // 
            // encryptedPlainText_txtb
            // 
            this.encryptedPlainText_txtb.Location = new System.Drawing.Point(6, 174);
            this.encryptedPlainText_txtb.Name = "encryptedPlainText_txtb";
            this.encryptedPlainText_txtb.ReadOnly = true;
            this.encryptedPlainText_txtb.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.encryptedPlainText_txtb.Size = new System.Drawing.Size(428, 110);
            this.encryptedPlainText_txtb.TabIndex = 9;
            this.encryptedPlainText_txtb.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.encryptedToHex_radio);
            this.panel1.Controls.Add(this.encryptedToBase64_radio);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(120, 146);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 22);
            this.panel1.TabIndex = 8;
            // 
            // encryptedToHex_radio
            // 
            this.encryptedToHex_radio.AutoSize = true;
            this.encryptedToHex_radio.Location = new System.Drawing.Point(72, 3);
            this.encryptedToHex_radio.Name = "encryptedToHex_radio";
            this.encryptedToHex_radio.Size = new System.Drawing.Size(61, 17);
            this.encryptedToHex_radio.TabIndex = 6;
            this.encryptedToHex_radio.Text = "Base16";
            this.encryptedToHex_radio.UseVisualStyleBackColor = true;
            // 
            // encryptedToBase64_radio
            // 
            this.encryptedToBase64_radio.AutoSize = true;
            this.encryptedToBase64_radio.Checked = true;
            this.encryptedToBase64_radio.Location = new System.Drawing.Point(3, 3);
            this.encryptedToBase64_radio.Name = "encryptedToBase64_radio";
            this.encryptedToBase64_radio.Size = new System.Drawing.Size(61, 17);
            this.encryptedToBase64_radio.TabIndex = 5;
            this.encryptedToBase64_radio.TabStop = true;
            this.encryptedToBase64_radio.Text = "Base64";
            this.encryptedToBase64_radio.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(61, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(9, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "|";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Encrypted (Convert to):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Clear:";
            // 
            // decrypt_grpb
            // 
            this.decrypt_grpb.Controls.Add(this.groupBox2);
            this.decrypt_grpb.Controls.Add(this.decrypt_btn);
            this.decrypt_grpb.Controls.Add(this.decryptKey_grpb);
            this.decrypt_grpb.Controls.Add(this.decryptText_grpb);
            this.decrypt_grpb.Location = new System.Drawing.Point(458, 2);
            this.decrypt_grpb.Name = "decrypt_grpb";
            this.decrypt_grpb.Size = new System.Drawing.Size(450, 435);
            this.decrypt_grpb.TabIndex = 1;
            this.decrypt_grpb.TabStop = false;
            this.decrypt_grpb.Text = "Decrypt";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.decryptFile_cbox);
            this.groupBox2.Controls.Add(this.decryptSelFile_txtb);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.decryptSelFile_btn);
            this.groupBox2.Controls.Add(this.decryptFileOutputName_txtb);
            this.groupBox2.Location = new System.Drawing.Point(6, 315);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(440, 42);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File";
            // 
            // decryptFile_cbox
            // 
            this.decryptFile_cbox.AutoSize = true;
            this.decryptFile_cbox.Location = new System.Drawing.Point(420, 19);
            this.decryptFile_cbox.Name = "decryptFile_cbox";
            this.decryptFile_cbox.Size = new System.Drawing.Size(15, 14);
            this.decryptFile_cbox.TabIndex = 5;
            this.decryptFile_cbox.UseVisualStyleBackColor = true;
            this.decryptFile_cbox.CheckedChanged += new System.EventHandler(this.decryptFile_cbox_CheckedChanged);
            // 
            // decryptSelFile_txtb
            // 
            this.decryptSelFile_txtb.Location = new System.Drawing.Point(184, 16);
            this.decryptSelFile_txtb.Name = "decryptSelFile_txtb";
            this.decryptSelFile_txtb.ReadOnly = true;
            this.decryptSelFile_txtb.Size = new System.Drawing.Size(175, 20);
            this.decryptSelFile_txtb.TabIndex = 4;
            this.decryptSelFile_txtb.TextChanged += new System.EventHandler(this.decryptSelFile_txtb_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(170, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(9, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "|";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Output:";
            // 
            // decryptSelFile_btn
            // 
            this.decryptSelFile_btn.Location = new System.Drawing.Point(365, 14);
            this.decryptSelFile_btn.Name = "decryptSelFile_btn";
            this.decryptSelFile_btn.Size = new System.Drawing.Size(48, 23);
            this.decryptSelFile_btn.TabIndex = 1;
            this.decryptSelFile_btn.Text = "Select";
            this.decryptSelFile_btn.UseVisualStyleBackColor = true;
            this.decryptSelFile_btn.Click += new System.EventHandler(this.decryptSelFile_btn_Click);
            // 
            // decryptFileOutputName_txtb
            // 
            this.decryptFileOutputName_txtb.Location = new System.Drawing.Point(48, 16);
            this.decryptFileOutputName_txtb.Name = "decryptFileOutputName_txtb";
            this.decryptFileOutputName_txtb.Size = new System.Drawing.Size(116, 20);
            this.decryptFileOutputName_txtb.TabIndex = 0;
            this.decryptFileOutputName_txtb.TextChanged += new System.EventHandler(this.decryptFileOutputName_txtb_TextChanged);
            // 
            // decrypt_btn
            // 
            this.decrypt_btn.Enabled = false;
            this.decrypt_btn.Location = new System.Drawing.Point(6, 408);
            this.decrypt_btn.Name = "decrypt_btn";
            this.decrypt_btn.Size = new System.Drawing.Size(440, 23);
            this.decrypt_btn.TabIndex = 1;
            this.decrypt_btn.Text = "Decrypt";
            this.decrypt_btn.UseVisualStyleBackColor = true;
            this.decrypt_btn.Click += new System.EventHandler(this.decrypt_btn_Click);
            // 
            // decryptKey_grpb
            // 
            this.decryptKey_grpb.Controls.Add(this.decryptKSize_cmbox);
            this.decryptKey_grpb.Controls.Add(this.decryptKey_txtb);
            this.decryptKey_grpb.Location = new System.Drawing.Point(6, 363);
            this.decryptKey_grpb.Name = "decryptKey_grpb";
            this.decryptKey_grpb.Size = new System.Drawing.Size(440, 46);
            this.decryptKey_grpb.TabIndex = 1;
            this.decryptKey_grpb.TabStop = false;
            this.decryptKey_grpb.Text = "Decryption key";
            // 
            // decryptKSize_cmbox
            // 
            this.decryptKSize_cmbox.DropDownHeight = 100;
            this.decryptKSize_cmbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.decryptKSize_cmbox.IntegralHeight = false;
            this.decryptKSize_cmbox.Items.AddRange(new object[] {
            "128-bit",
            "256-bit",
            "512-bit"});
            this.decryptKSize_cmbox.Location = new System.Drawing.Point(9, 18);
            this.decryptKSize_cmbox.Name = "decryptKSize_cmbox";
            this.decryptKSize_cmbox.Size = new System.Drawing.Size(67, 21);
            this.decryptKSize_cmbox.TabIndex = 1;
            this.decryptKSize_cmbox.SelectedIndexChanged += new System.EventHandler(this.decryptKSize_cmbox_SelectedIndexChanged);
            // 
            // decryptKey_txtb
            // 
            this.decryptKey_txtb.Location = new System.Drawing.Point(82, 19);
            this.decryptKey_txtb.MaxLength = 64;
            this.decryptKey_txtb.Name = "decryptKey_txtb";
            this.decryptKey_txtb.Size = new System.Drawing.Size(352, 20);
            this.decryptKey_txtb.TabIndex = 0;
            this.decryptKey_txtb.Text = "3t6w9z$C&F)J@Nc9";
            this.decryptKey_txtb.TextChanged += new System.EventHandler(this.decryptKey_txtb_TextChanged);
            // 
            // decryptText_grpb
            // 
            this.decryptText_grpb.Controls.Add(this.decryptTextEncrypted_txtb);
            this.decryptText_grpb.Controls.Add(this.decryptedEncryptedText_txtb);
            this.decryptText_grpb.Controls.Add(this.panel2);
            this.decryptText_grpb.Controls.Add(this.label3);
            this.decryptText_grpb.Controls.Add(this.label4);
            this.decryptText_grpb.Location = new System.Drawing.Point(6, 18);
            this.decryptText_grpb.Name = "decryptText_grpb";
            this.decryptText_grpb.Size = new System.Drawing.Size(440, 291);
            this.decryptText_grpb.TabIndex = 0;
            this.decryptText_grpb.TabStop = false;
            this.decryptText_grpb.Text = "Text";
            // 
            // decryptTextEncrypted_txtb
            // 
            this.decryptTextEncrypted_txtb.Location = new System.Drawing.Point(6, 30);
            this.decryptTextEncrypted_txtb.Name = "decryptTextEncrypted_txtb";
            this.decryptTextEncrypted_txtb.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.decryptTextEncrypted_txtb.Size = new System.Drawing.Size(428, 110);
            this.decryptTextEncrypted_txtb.TabIndex = 11;
            this.decryptTextEncrypted_txtb.Text = "";
            this.decryptTextEncrypted_txtb.TextChanged += new System.EventHandler(this.decryptTextEncrypted_txtb_TextChanged_1);
            // 
            // decryptedEncryptedText_txtb
            // 
            this.decryptedEncryptedText_txtb.Location = new System.Drawing.Point(6, 174);
            this.decryptedEncryptedText_txtb.Name = "decryptedEncryptedText_txtb";
            this.decryptedEncryptedText_txtb.ReadOnly = true;
            this.decryptedEncryptedText_txtb.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.decryptedEncryptedText_txtb.Size = new System.Drawing.Size(428, 110);
            this.decryptedEncryptedText_txtb.TabIndex = 10;
            this.decryptedEncryptedText_txtb.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.encryptedFromHex_radio);
            this.panel2.Controls.Add(this.encryptedFromBase64_radio);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Location = new System.Drawing.Point(132, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(160, 22);
            this.panel2.TabIndex = 9;
            // 
            // encryptedFromHex_radio
            // 
            this.encryptedFromHex_radio.AutoSize = true;
            this.encryptedFromHex_radio.Location = new System.Drawing.Point(72, 3);
            this.encryptedFromHex_radio.Name = "encryptedFromHex_radio";
            this.encryptedFromHex_radio.Size = new System.Drawing.Size(61, 17);
            this.encryptedFromHex_radio.TabIndex = 6;
            this.encryptedFromHex_radio.Text = "Base16";
            this.encryptedFromHex_radio.UseVisualStyleBackColor = true;
            // 
            // encryptedFromBase64_radio
            // 
            this.encryptedFromBase64_radio.AutoSize = true;
            this.encryptedFromBase64_radio.Checked = true;
            this.encryptedFromBase64_radio.Location = new System.Drawing.Point(3, 3);
            this.encryptedFromBase64_radio.Name = "encryptedFromBase64_radio";
            this.encryptedFromBase64_radio.Size = new System.Drawing.Size(61, 17);
            this.encryptedFromBase64_radio.TabIndex = 5;
            this.encryptedFromBase64_radio.TabStop = true;
            this.encryptedFromBase64_radio.Text = "Base64";
            this.encryptedFromBase64_radio.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(61, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(9, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "|";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Clear:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Encrypted (Convert from):";
            // 
            // clearAll_btn
            // 
            this.clearAll_btn.Location = new System.Drawing.Point(2, 443);
            this.clearAll_btn.Name = "clearAll_btn";
            this.clearAll_btn.Size = new System.Drawing.Size(906, 21);
            this.clearAll_btn.TabIndex = 1;
            this.clearAll_btn.Text = "Clear all";
            this.clearAll_btn.UseVisualStyleBackColor = true;
            this.clearAll_btn.Click += new System.EventHandler(this.clearAll_btn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "All Files|*.*|Text Files|*.txt|Executable Files|*.exe|Image Files|*.jpg;*.png;*.g" +
    "if;*.bmp|Music Files|*.mp3;*.wav;*.ogg;*.wma";
            // 
            // progress_grpbx
            // 
            this.progress_grpbx.Controls.Add(this.workCancel_btn);
            this.progress_grpbx.Controls.Add(this.work_progressbar);
            this.progress_grpbx.Enabled = false;
            this.progress_grpbx.Location = new System.Drawing.Point(2, 470);
            this.progress_grpbx.Name = "progress_grpbx";
            this.progress_grpbx.Size = new System.Drawing.Size(906, 65);
            this.progress_grpbx.TabIndex = 2;
            this.progress_grpbx.TabStop = false;
            this.progress_grpbx.Text = "Data status";
            // 
            // workCancel_btn
            // 
            this.workCancel_btn.Location = new System.Drawing.Point(6, 35);
            this.workCancel_btn.Name = "workCancel_btn";
            this.workCancel_btn.Size = new System.Drawing.Size(894, 23);
            this.workCancel_btn.TabIndex = 1;
            this.workCancel_btn.Text = "Cancel";
            this.workCancel_btn.UseVisualStyleBackColor = true;
            this.workCancel_btn.Click += new System.EventHandler(this.workCancel_btn_Click);
            // 
            // work_progressbar
            // 
            this.work_progressbar.Location = new System.Drawing.Point(6, 19);
            this.work_progressbar.Name = "work_progressbar";
            this.work_progressbar.Size = new System.Drawing.Size(894, 10);
            this.work_progressbar.TabIndex = 0;
            // 
            // process_bkgw
            // 
            this.process_bkgw.WorkerReportsProgress = true;
            this.process_bkgw.WorkerSupportsCancellation = true;
            this.process_bkgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.process_bkgw_DoWork);
            this.process_bkgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.process_bkgw_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(910, 541);
            this.Controls.Add(this.progress_grpbx);
            this.Controls.Add(this.clearAll_btn);
            this.Controls.Add(this.decrypt_grpb);
            this.Controls.Add(this.encrypt_grpb);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "xs8 v1.b-b Cipher (Xxshark888xX - Adriano Mutu)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.encrypt_grpb.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.encryptKey_grpb.ResumeLayout(false);
            this.encryptKey_grpb.PerformLayout();
            this.encryptText_grpb.ResumeLayout(false);
            this.encryptText_grpb.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.decrypt_grpb.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.decryptKey_grpb.ResumeLayout(false);
            this.decryptKey_grpb.PerformLayout();
            this.decryptText_grpb.ResumeLayout(false);
            this.decryptText_grpb.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.progress_grpbx.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox encrypt_grpb;
        private System.Windows.Forms.Button encrypt_btn;
        private System.Windows.Forms.GroupBox encryptKey_grpb;
        private System.Windows.Forms.TextBox encryptKey_txtb;
        private System.Windows.Forms.GroupBox encryptText_grpb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox decrypt_grpb;
        private System.Windows.Forms.Button decrypt_btn;
        private System.Windows.Forms.GroupBox decryptKey_grpb;
        private System.Windows.Forms.TextBox decryptKey_txtb;
        private System.Windows.Forms.Button clearAll_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox encryptSelFile_txtb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button encryptSelFile_btn;
        private System.Windows.Forms.TextBox encryptFileOutputName_txtb;
        private System.Windows.Forms.CheckBox encryptFile_cbox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox decryptFile_cbox;
        private System.Windows.Forms.TextBox decryptSelFile_txtb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button decryptSelFile_btn;
        private System.Windows.Forms.TextBox decryptFileOutputName_txtb;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton encryptedToHex_radio;
        private System.Windows.Forms.RadioButton encryptedToBase64_radio;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox decryptKSize_cmbox;
        private System.Windows.Forms.ComboBox encryptKSize_cmbox;
        private System.Windows.Forms.GroupBox progress_grpbx;
        private System.Windows.Forms.Button workCancel_btn;
        private System.Windows.Forms.ProgressBar work_progressbar;
        private System.ComponentModel.BackgroundWorker process_bkgw;
        private System.Windows.Forms.RichTextBox encryptedPlainText_txtb;
        private System.Windows.Forms.RichTextBox encryptTextClear_txtb;
        private System.Windows.Forms.GroupBox decryptText_grpb;
        private System.Windows.Forms.RichTextBox decryptTextEncrypted_txtb;
        private System.Windows.Forms.RichTextBox decryptedEncryptedText_txtb;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton encryptedFromHex_radio;
        private System.Windows.Forms.RadioButton encryptedFromBase64_radio;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

