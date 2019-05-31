using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace xs8_Cipher {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        public static byte[] Combine(byte[] first, byte[] second) {
            byte[] ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }



        #region [BYTE TO >HEX< TO BYTE]
        // class is sealed and not static in my personal complete version
        public unsafe sealed partial class Fast
        {
        // assigned int values for bytes (0-255)
        static readonly int[] toHexTable = new int[] {
            3145776, 3211312, 3276848, 3342384, 3407920, 3473456, 3538992, 3604528, 3670064, 3735600,
            4259888, 4325424, 4390960, 4456496, 4522032, 4587568, 3145777, 3211313, 3276849, 3342385,
            3407921, 3473457, 3538993, 3604529, 3670065, 3735601, 4259889, 4325425, 4390961, 4456497,
            4522033, 4587569, 3145778, 3211314, 3276850, 3342386, 3407922, 3473458, 3538994, 3604530,
            3670066, 3735602, 4259890, 4325426, 4390962, 4456498, 4522034, 4587570, 3145779, 3211315,
            3276851, 3342387, 3407923, 3473459, 3538995, 3604531, 3670067, 3735603, 4259891, 4325427,
            4390963, 4456499, 4522035, 4587571, 3145780, 3211316, 3276852, 3342388, 3407924, 3473460,
            3538996, 3604532, 3670068, 3735604, 4259892, 4325428, 4390964, 4456500, 4522036, 4587572,
            3145781, 3211317, 3276853, 3342389, 3407925, 3473461, 3538997, 3604533, 3670069, 3735605,
            4259893, 4325429, 4390965, 4456501, 4522037, 4587573, 3145782, 3211318, 3276854, 3342390,
            3407926, 3473462, 3538998, 3604534, 3670070, 3735606, 4259894, 4325430, 4390966, 4456502,
            4522038, 4587574, 3145783, 3211319, 3276855, 3342391, 3407927, 3473463, 3538999, 3604535,
            3670071, 3735607, 4259895, 4325431, 4390967, 4456503, 4522039, 4587575, 3145784, 3211320,
            3276856, 3342392, 3407928, 3473464, 3539000, 3604536, 3670072, 3735608, 4259896, 4325432,
            4390968, 4456504, 4522040, 4587576, 3145785, 3211321, 3276857, 3342393, 3407929, 3473465,
            3539001, 3604537, 3670073, 3735609, 4259897, 4325433, 4390969, 4456505, 4522041, 4587577,
            3145793, 3211329, 3276865, 3342401, 3407937, 3473473, 3539009, 3604545, 3670081, 3735617,
            4259905, 4325441, 4390977, 4456513, 4522049, 4587585, 3145794, 3211330, 3276866, 3342402,
            3407938, 3473474, 3539010, 3604546, 3670082, 3735618, 4259906, 4325442, 4390978, 4456514,
            4522050, 4587586, 3145795, 3211331, 3276867, 3342403, 3407939, 3473475, 3539011, 3604547,
            3670083, 3735619, 4259907, 4325443, 4390979, 4456515, 4522051, 4587587, 3145796, 3211332,
            3276868, 3342404, 3407940, 3473476, 3539012, 3604548, 3670084, 3735620, 4259908, 4325444,
            4390980, 4456516, 4522052, 4587588, 3145797, 3211333, 3276869, 3342405, 3407941, 3473477,
            3539013, 3604549, 3670085, 3735621, 4259909, 4325445, 4390981, 4456517, 4522053, 4587589,
            3145798, 3211334, 3276870, 3342406, 3407942, 3473478, 3539014, 3604550, 3670086, 3735622,
            4259910, 4325446, 4390982, 4456518, 4522054, 4587590
        };

        public static string ToHexString(byte[] source)
        {
            return ToHexString(source, false);
        }
        
        // hexIndicator: use prefix ("0x") or not
        public static string ToHexString(byte[] source, bool hexIndicator)
        {
            // freeze toHexTable position in memory
            fixed (int* hexRef = toHexTable)
            // freeze source position in memory
            fixed (byte* sourceRef = source)
            {
                // take first parsing position of source - allow inline pointer positioning
                byte* s = sourceRef;
                // calculate result length
                int resultLen = (source.Length << 1);
                // use prefix ("Ox")
                if (hexIndicator)
                    // adapt result length
                    resultLen += 2;
                // initialize result string with any character expect '\0'
                string result = new string(' ', resultLen);
                // take the first character address of result
                fixed (char* resultRef = result)
                {
                    // pairs of characters explain the endianess of toHexTable
                    // move on by pairs of characters (2 x 2 bytes) - allow inline pointer positioning
                    int* pair = (int*)resultRef;
                    // use prefix ("Ox") ?
                    if (hexIndicator)
                        // set first pair value
                        *pair++ = 7864368;
                    // more to go
                    while (*pair != 0)
                        // set the value of the current pair and move to next pair and source byte
                        *pair++ = hexRef[*s++];
                    return result;
                }
            }
        }
        
        // values for '\0' to 'f' where 255 indicates invalid input character
        // starting from '\0' and not from '0' costs 48 bytes
        // but results 0 subtructions and less if conditions
        static readonly byte[] fromHexTable = new byte[] {
            255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
            255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
            255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
            255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
            255, 255, 255, 255, 255, 255, 255, 255, 0, 1,
            2, 3, 4, 5, 6, 7, 8, 9, 255, 255,
            255, 255, 255, 255, 255, 10, 11, 12, 13, 14, 
            15, 255, 255, 255, 255, 255, 255, 255, 255, 255,
            255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
            255, 255, 255, 255, 255, 255, 255, 10, 11, 12,
            13, 14, 15
        };

        // same as above but valid values are multiplied by 16
        static readonly byte[] fromHexTable16 = new byte[] {
            255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
            255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
            255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
            255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
            255, 255, 255, 255, 255, 255, 255, 255, 0, 16,
            32, 48, 64, 80, 96, 112, 128, 144, 255, 255,
            255, 255, 255, 255, 255, 160, 176, 192, 208, 224, 
            240, 255, 255, 255, 255, 255, 255, 255, 255, 255,
            255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
            255, 255, 255, 255, 255, 255, 255, 160, 176, 192,
            208, 224, 240
        };

        public static byte[] FromHexString(string source)
        {
            // return an empty array in case of null or empty source
            if (string.IsNullOrEmpty(source))
                return new byte[0]; // you may change it to return null
            if (source.Length % 2 == 1) // source length must be even
                throw new ArgumentException();
            int
                index = 0, // start position for parsing source
                len = source.Length >> 1; // initial length of result
            // take the first character address of source
            fixed (char* sourceRef = source)
            {
                if (*(int*)sourceRef == 7864368) // source starts with "0x"
                {
                    if (source.Length == 2) // source must not be just a "0x")
                        throw new ArgumentException();
                    index += 2; // start position (bypass "0x")
                    len -= 1; // result length (exclude "0x")
                }
                byte add = 0; // keeps a fromHexTable value
                byte[] result = new byte[len]; // initialization of result for known length
                // freeze fromHexTable16 position in memory
                fixed (byte* hiRef = fromHexTable16)
                // freeze fromHexTable position in memory
                fixed (byte* lowRef = fromHexTable)
                // take the first byte address of result
                fixed (byte* resultRef = result)
                {
                    // take first parsing position of source - allow inremental memory position
                    char* s = (char*)&sourceRef[index];
                    // take first byte position of result - allow incremental memory position
                    byte* r = resultRef;
                    // source has more characters to parse
                    while (*s != 0)
                    {
                        // check for non valid characters in pairs
                        // you may split it if you don't like its readbility
                        if (
                            // check for character > 'f'
                            *s > 102 ||
                            // assign source value to current result position and increment source position
                            // and check if is a valid character
                            (*r = hiRef[*s++]) == 255 ||
                            // check for character > 'f'
                            *s > 102 ||
                            // assign source value to "add" parameter and increment source position
                            // and check if is a valid character
                            (add = lowRef[*s++]) == 255
                            )
                            throw new ArgumentException();
                        // set final value of current result byte and move pointer to next byte
                        *r++ += add;
                    }
                    return result;
                }
            }
        }
        }
        #endregion

        #region [GLOBAL VARIABLES]
        string globalFormTitle = "";
        ushort globalTypeOfProcess = 0; //0 = nothing; 1 = encrypt; 2 = decrypt;
        
        bool globalFileType = false;
        bool globalEncodeBase64 = true;
        string globalDataProcessed;
        string globalKey;
        xs8CipherKey globalKeySize;
        string[] globalFileName = new string[3]; //0 = output file name; 1 = folderBrowserDialog path; 2 = inputFile;
        #endregion

        private void Form1_Load(object sender, EventArgs e) {
            globalFormTitle = this.Text;
            this.ActiveControl = label1;
            encryptKSize_cmbox.SelectedIndex = 0;
            decryptKSize_cmbox.SelectedIndex = 0;
        }

        #region [Elements control]

        #region [ENCRYPT]
        private void encryptFile_cbox_CheckedChanged(object sender, EventArgs e) {
            if (encryptFile_cbox.Checked == false) {
                if ((encryptTextClear_txtb.Text.Length > 0 || encryptKey_txtb.Text.Length > 8) && !(encryptTextClear_txtb.Text.Length < 1 || encryptKey_txtb.Text.Length < 8)) { encrypt_btn.Enabled = true; } else { encrypt_btn.Enabled = false; }
            } else {
                if ((encryptFileOutputName_txtb.Text.Length > 0 || encryptSelFile_txtb.Text.Length > 0 || encryptKey_txtb.Text.Length > 8) && !(encryptFileOutputName_txtb.Text.Length < 1 || encryptSelFile_txtb.Text.Length < 1 || encryptKey_txtb.Text.Length < 8)) { encrypt_btn.Enabled = true; } else { encrypt_btn.Enabled = false; }
            }
        }

        private void encryptFileOutputName_txtb_TextChanged(object sender, EventArgs e) {
            if (encryptFile_cbox.Checked == true) {
                if ((encryptFileOutputName_txtb.Text.Length > 0 || encryptSelFile_txtb.Text.Length > 0 || encryptKey_txtb.Text.Length > 8) && !(encryptFileOutputName_txtb.Text.Length < 1 || encryptSelFile_txtb.Text.Length < 1 || encryptKey_txtb.Text.Length < 8)) { encrypt_btn.Enabled = true; } else { encrypt_btn.Enabled = false; }
            }
        }

        private void encryptSelFile_txtb_TextChanged(object sender, EventArgs e) {
            if (encryptFile_cbox.Checked == true) {
                if ((encryptFileOutputName_txtb.Text.Length > 0 || encryptSelFile_txtb.Text.Length > 0 || encryptKey_txtb.Text.Length > 8) && !(encryptFileOutputName_txtb.Text.Length < 1 || encryptSelFile_txtb.Text.Length < 1)) { encrypt_btn.Enabled = true; } else { encrypt_btn.Enabled = false; }
            }
        }

        private void encryptTextClear_txtb_TextChanged(object sender, EventArgs e) {
            if (encryptFile_cbox.Checked == false) {
                if ((encryptTextClear_txtb.Text.Length > 0 || encryptKey_txtb.Text.Length > 8) && !(encryptTextClear_txtb.Text.Length < 1 || encryptKey_txtb.Text.Length < 8)) { encrypt_btn.Enabled = true; } else { encrypt_btn.Enabled = false; }
            }
        }

        private void encryptKey_txtb_TextChanged(object sender, EventArgs e) {
            if (encryptFile_cbox.Checked == false) {
                if ((encryptTextClear_txtb.Text.Length > 0 || encryptKey_txtb.Text.Length > 8) && !(encryptTextClear_txtb.Text.Length < 1 || encryptKey_txtb.Text.Length < 8)) { encrypt_btn.Enabled = true; } else { encrypt_btn.Enabled = false; }
            } else {
                if ((encryptFileOutputName_txtb.Text.Length > 0 || encryptSelFile_txtb.Text.Length > 0 || encryptKey_txtb.Text.Length > 8) && !(encryptFileOutputName_txtb.Text.Length < 1 || encryptSelFile_txtb.Text.Length < 1 || encryptKey_txtb.Text.Length < 8)) { encrypt_btn.Enabled = true; } else { encrypt_btn.Enabled = false; }
            }
        }

        private void encryptSelFile_btn_MouseClick(object sender, MouseEventArgs e) {
            this.ActiveControl = label1;
            openFileDialog1.Title = "Encrypt File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                encryptSelFile_txtb.Text = openFileDialog1.FileName;
            }
        }

        private void encryptKSize_cmbox_SelectedIndexChanged(object sender, EventArgs e) {
            try {
            if (encryptKey_txtb.Text.Length > (Convert.ToInt16(encryptKSize_cmbox.Text.Remove(encryptKSize_cmbox.Text.IndexOf('-'))) / 8))  {
                encryptKey_txtb.Text = encryptKey_txtb.Text.Remove(Convert.ToInt16(encryptKSize_cmbox.Text.Remove(encryptKSize_cmbox.Text.IndexOf('-'))) / 8);
            } else if (encryptKey_txtb.Text.Length != (Convert.ToInt16(encryptKSize_cmbox.Text.Remove(encryptKSize_cmbox.Text.IndexOf('-'))) / 8)) {
                int l = encryptKey_txtb.Text.Length;
                string p = "bQeShVmYq3t6w9z$C&F)J@NcRfUjWnZr4u7x!A%D*G-KaPdSgVkYp2s5v8y/B?E(";
                for (int i = 0; i < ((Convert.ToInt16(encryptKSize_cmbox.Text.Remove(encryptKSize_cmbox.Text.IndexOf('-'))) / 8) - l); i++) {
                    encryptKey_txtb.Text = encryptKey_txtb.Text.Insert(i, p.Substring((i ^ (char)Convert.ToChar(encryptKey_txtb.Text.Substring(i % l, 1))) % 64, 1));
                }
            }

            if (encryptKSize_cmbox.Text != decryptKSize_cmbox.Text) {
                encryptKey_grpb.ForeColor = Color.Red; encryptKey_grpb.Text = "Encryption key | [INFO] En/Decryption key LENGTH aren't equal...";
                decryptKey_grpb.ForeColor = Color.Red; decryptKey_grpb.Text = "Decryption key | [INFO] En/Decryption key LENGTH aren't equal...";
            } else {
                encryptKey_grpb.ForeColor = Color.Black; encryptKey_grpb.Text = "Encryption key"; decryptKey_grpb.ForeColor = Color.Black;
                decryptKey_grpb.Text = "Decryption key";
            }
            } catch { }
        }
        #endregion

        #region [DECRYPT]
        private void decryptFile_cbox_CheckedChanged(object sender, EventArgs e) {
            if (decryptFile_cbox.Checked == false) {
                if ((decryptTextEncrypted_txtb.Text.Length > 0 || decryptKey_txtb.Text.Length > 8) && !(decryptTextEncrypted_txtb.Text.Length < 1 || decryptKey_txtb.Text.Length < 8)) { decrypt_btn.Enabled = true; } else { decrypt_btn.Enabled = false; }
            } else {
                if ((decryptFileOutputName_txtb.Text.Length > 0 || decryptSelFile_txtb.Text.Length > 0 || decryptKey_txtb.Text.Length > 8) && !(decryptFileOutputName_txtb.Text.Length < 1 || decryptSelFile_txtb.Text.Length < 1 || decryptKey_txtb.Text.Length < 8)) { decrypt_btn.Enabled = true; } else { decrypt_btn.Enabled = false; }
            }
        }

        private void decryptFileOutputName_txtb_TextChanged(object sender, EventArgs e) {
            if (decryptFile_cbox.Checked == true) {
                if ((decryptFileOutputName_txtb.Text.Length > 0 || decryptSelFile_txtb.Text.Length > 0 || decryptKey_txtb.Text.Length > 8) && !(decryptFileOutputName_txtb.Text.Length < 1 || decryptSelFile_txtb.Text.Length < 1 || decryptKey_txtb.Text.Length < 8)) { decrypt_btn.Enabled = true; } else { decrypt_btn.Enabled = false; }
            }
        }

        private void decryptSelFile_txtb_TextChanged(object sender, EventArgs e) {
            if (decryptFile_cbox.Checked == true) {
                if ((decryptFileOutputName_txtb.Text.Length > 0 || decryptSelFile_txtb.Text.Length > 0 || decryptKey_txtb.Text.Length > 8) && !(decryptFileOutputName_txtb.Text.Length < 1 || decryptSelFile_txtb.Text.Length < 1 || decryptKey_txtb.Text.Length < 8)) { decrypt_btn.Enabled = true; } else { decrypt_btn.Enabled = false; }
            }
        }

        private void decryptTextEncrypted_txtb_TextChanged_1(object sender, EventArgs e) {
            if (decryptFile_cbox.Checked == false) {
                if ((decryptTextEncrypted_txtb.Text.Length > 0 || decryptKey_txtb.Text.Length > 8) && !(decryptTextEncrypted_txtb.Text.Length < 1 || decryptKey_txtb.Text.Length < 8)) { decrypt_btn.Enabled = true; } else { decrypt_btn.Enabled = false; }
            }
        }

        private void decryptKey_txtb_TextChanged(object sender, EventArgs e) {
            if (decryptFile_cbox.Checked == false) {
                if ((decryptTextEncrypted_txtb.Text.Length > 0 || decryptKey_txtb.Text.Length > 8) && !(decryptTextEncrypted_txtb.Text.Length < 1 || decryptKey_txtb.Text.Length < 8)) { decrypt_btn.Enabled = true; } else { decrypt_btn.Enabled = false; }
            } else {
                if ((decryptFileOutputName_txtb.Text.Length > 0 || decryptSelFile_txtb.Text.Length > 0 || decryptKey_txtb.Text.Length > 8) && !(decryptFileOutputName_txtb.Text.Length < 1 || decryptSelFile_txtb.Text.Length < 1 || decryptKey_txtb.Text.Length < 8)) { decrypt_btn.Enabled = true; } else { decrypt_btn.Enabled = false; }
            }
        }

        private void decryptSelFile_btn_Click(object sender, EventArgs e) {
            this.ActiveControl = label1;
            openFileDialog1.Title = "Decrypt File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                decryptSelFile_txtb.Text = openFileDialog1.FileName;
            }
        }

        private void decryptKSize_cmbox_SelectedIndexChanged(object sender, EventArgs e) {
            try {
            if (decryptKey_txtb.Text.Length > (Convert.ToInt16(decryptKSize_cmbox.Text.Remove(decryptKSize_cmbox.Text.IndexOf('-'))) / 8))  {
                decryptKey_txtb.Text = decryptKey_txtb.Text.Remove(Convert.ToInt16(decryptKSize_cmbox.Text.Remove(decryptKSize_cmbox.Text.IndexOf('-'))) / 8);
            } else if (decryptKey_txtb.Text.Length != (Convert.ToInt16(decryptKSize_cmbox.Text.Remove(decryptKSize_cmbox.Text.IndexOf('-'))) / 8)) {
                int l = decryptKey_txtb.Text.Length;
                string p = "bQeShVmYq3t6w9z$C&F)J@NcRfUjWnZr4u7x!A%D*G-KaPdSgVkYp2s5v8y/B?E(";
                for (int i = 0; i < ((Convert.ToInt16(decryptKSize_cmbox.Text.Remove(decryptKSize_cmbox.Text.IndexOf('-'))) / 8) - l); i++) {
                    decryptKey_txtb.Text = decryptKey_txtb.Text.Insert(i, p.Substring((i ^ (char)Convert.ToChar(decryptKey_txtb.Text.Substring(i % l, 1))) % 64, 1));
                }
            }
            } catch { }

            if (decryptKSize_cmbox.Text != encryptKSize_cmbox.Text) {
                decryptKey_grpb.ForeColor = Color.Red; decryptKey_grpb.Text = "Decryption key | [INFO] En/Decryption key LENGTH aren't equal...";
                encryptKey_grpb.ForeColor = Color.Red; encryptKey_grpb.Text = "Encryption key | [INFO] En/Decryption key LENGTH aren't equal...";
            } else {
                decryptKey_grpb.ForeColor = Color.Black; decryptKey_grpb.Text = "Decryption key";
                encryptKey_grpb.ForeColor = Color.Black; encryptKey_grpb.Text = "Encryption key";
            }
        }
        #endregion

        #endregion

        System.Diagnostics.Stopwatch pTimer = new System.Diagnostics.Stopwatch();

        #region [Encrypt button click]
        private void encrypt_btn_Click(object sender, EventArgs e) {
            globalTypeOfProcess = 1;

            if (encryptKey_txtb.Text.Length == (Convert.ToInt16(encryptKSize_cmbox.Text.Remove(encryptKSize_cmbox.Text.IndexOf('-'))) / 8)) {
                if (encryptFile_cbox.Checked == true) {
                    globalFileType = true;

                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                        globalFileName[0] = encryptFileOutputName_txtb.Text;
                        globalFileName[1] = folderBrowserDialog1.SelectedPath;
                        globalFileName[2] = encryptSelFile_txtb.Text;
                    }
                } else {
                    globalFileType = false;
                    if (encryptedToBase64_radio.Checked == false) { globalEncodeBase64 = false; } else { globalEncodeBase64 = true; }
                    globalDataProcessed = encryptTextClear_txtb.Text;
                }

                globalKey = encryptKey_txtb.Text;
                globalKeySize = (xs8CipherKey)Convert.ToInt16(encryptKSize_cmbox.Text.Remove(encryptKSize_cmbox.Text.IndexOf('-')));

                progress_grpbx.Enabled = true;
                progress_grpbx.Text = "Data started being encrypted...";

                work_progressbar.Style = ProgressBarStyle.Marquee;
                work_progressbar.MarqueeAnimationSpeed = 25;
                process_bkgw.RunWorkerAsync();
            } else { MessageBox.Show("The selected key size isn't equal to the input key size\r\n\r\nSelected key size length: " + (Convert.ToInt16(encryptKSize_cmbox.Text.Remove(encryptKSize_cmbox.Text.IndexOf('-')))).ToString() + "-bit" + "\r\nInput key size length: " + (encryptKey_txtb.Text.Length * 8).ToString() + "-bit", "[#4] - Key size error!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            this.ActiveControl = label1;
        }
        #endregion

        #region [Decrypt button click]
        private void decrypt_btn_Click(object sender, EventArgs e) {
            globalTypeOfProcess = 2;

            if (decryptKey_txtb.Text.Length == (Convert.ToInt16(decryptKSize_cmbox.Text.Remove(decryptKSize_cmbox.Text.IndexOf('-'))) / 8)) {
                if (decryptFile_cbox.Checked == true) {
                    globalFileType = true;

                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                        globalFileName[0] = decryptFileOutputName_txtb.Text;
                        globalFileName[1] = folderBrowserDialog1.SelectedPath;
                        globalFileName[2] = decryptSelFile_txtb.Text;
                    }
                } else {
                    globalFileType = false;
                    if (encryptedFromBase64_radio.Checked == false) { globalEncodeBase64 = false; } else { globalEncodeBase64 = true; }
                    globalDataProcessed = decryptTextEncrypted_txtb.Text;
                }

                globalKey = decryptKey_txtb.Text;
                globalKeySize = (xs8CipherKey)Convert.ToInt16(decryptKSize_cmbox.Text.Remove(decryptKSize_cmbox.Text.IndexOf('-')));

                progress_grpbx.Enabled = true;
                progress_grpbx.Text = "Data started being decrypted...";

                work_progressbar.Style = ProgressBarStyle.Marquee;
                work_progressbar.MarqueeAnimationSpeed = 25;
                process_bkgw.RunWorkerAsync();
            } else { MessageBox.Show("The selected key size isn't equal to the input key size\r\n\r\nSelected key size length: " + (Convert.ToInt16(decryptKSize_cmbox.Text.Remove(decryptKSize_cmbox.Text.IndexOf('-')))).ToString() + "-bit" + "\r\nInput key size length: " + (decryptKey_txtb.Text.Length * 8).ToString() + "-bit", "[#4] - Key size error!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            this.ActiveControl = label1;
        }
        #endregion

        private void process_bkgw_DoWork(object sender, DoWorkEventArgs e) {
            if (globalTypeOfProcess == 1) {
                if (globalFileType == false) {
                    try {
                        pTimer.Start();
                        /*              Encrypt string              */
                        if (globalEncodeBase64 == true) {
                            globalDataProcessed = Convert.ToBase64String(xs8Cipher.Encrypt(Encoding.UTF8.GetBytes(globalDataProcessed), globalKey, globalKeySize));
                        } else {
                            globalDataProcessed = Fast.ToHexString(xs8Cipher.Encrypt(Encoding.UTF8.GetBytes(globalDataProcessed), globalKey, globalKeySize));
                        }
                        pTimer.Stop();
                    } catch { MessageBox.Show("Strange, very strange...", "[#0] - Can't encrypt this string...", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                } else {
                    string fileOut = globalFileName[0];
                    fileOut = fileOut.Insert(0, globalFileName[1] + "\\");
                    fileOut = fileOut.Insert(fileOut.Length, globalFileName[2].Substring(globalFileName[2].LastIndexOf('.')));
                    try {
                        pTimer.Start();
                        /*                Encrypt file              */
                        if (globalFileName[2].Substring(globalFileName[2].LastIndexOf('.') + 1) != "bmp") {
                            File.WriteAllBytes(fileOut, xs8Cipher.Encrypt(File.ReadAllBytes(globalFileName[2]), globalKey, globalKeySize));
                        } else {
                            var fileStream = new FileStream(globalFileName[2], FileMode.Open, FileAccess.Read);
                            MemoryStream ms = new MemoryStream();
                            fileStream.CopyTo(ms);
                            var header = ms.ToArray().Take(54).ToArray();
                            var imageArray = ms.ToArray().Skip(54).ToArray();
                            var encimg = xs8Cipher.Encrypt(imageArray, globalKey, globalKeySize);
                            var image = Combine(header, encimg);
                            File.WriteAllBytes(fileOut, image);
                            fileStream.Close();
                        }
                        
                        pTimer.Stop();
                    } catch {
                        MessageBox.Show("This can happen when you try to encrypt a large file", "[#2] - Can't encrypt this file...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            if (globalTypeOfProcess == 2) {
                if (globalFileType == false) {
                    try {
                        pTimer.Start();
                        /*              Decrypt string              */
                        if (globalEncodeBase64 == true) {
                            globalDataProcessed = Encoding.UTF8.GetString(xs8Cipher.Decrypt(Convert.FromBase64String(globalDataProcessed), globalKey, globalKeySize));
                        } else {
                            byte[] fromHex = Fast.FromHexString(globalDataProcessed);
                            globalDataProcessed = Encoding.UTF8.GetString(xs8Cipher.Decrypt(fromHex, globalKey, globalKeySize));
                        }
                        pTimer.Stop();
                    } catch { MessageBox.Show("Strange, very strange...", "[#0] - Can't encrypt this string...", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                } else {
                    string fileOut = globalFileName[0];
                    fileOut = fileOut.Insert(0, globalFileName[1] + "\\");
                    fileOut = fileOut.Insert(fileOut.Length, globalFileName[2].Substring(globalFileName[2].LastIndexOf('.')));
                    try {
                        pTimer.Start();
                        /*              Decrypt file              */
                        if (globalFileName[2].Substring(globalFileName[2].LastIndexOf('.') + 1) != "bmp") {
                            File.WriteAllBytes(fileOut, xs8Cipher.Decrypt(File.ReadAllBytes(globalFileName[2]), globalKey, globalKeySize));
                        } else {
                            var fileStream = new FileStream(globalFileName[2], FileMode.Open, FileAccess.Read);
                            MemoryStream ms = new MemoryStream();
                            fileStream.CopyTo(ms);
                            var header = ms.ToArray().Take(54).ToArray();
                            var imageArray = ms.ToArray().Skip(54).ToArray();
                            var encimg = xs8Cipher.Decrypt(imageArray, globalKey, globalKeySize);
                            var image = Combine(header, encimg);
                            File.WriteAllBytes(fileOut, image);
                            fileStream.Close();
                        }

                        pTimer.Stop();
                    } catch {
                        MessageBox.Show("This can happen when you try to encrypt a large file", "[#2] - Can't encrypt this file...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void workCancel_btn_Click(object sender, EventArgs e) {
            Application.Restart();
        }

        private void process_bkgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            work_progressbar.Style = ProgressBarStyle.Continuous;
            work_progressbar.MarqueeAnimationSpeed = 0;
            
            this.Text = globalFormTitle + " | Data processed in: [" + pTimer.Elapsed.Milliseconds.ToString() + "] ms and [" + (pTimer.Elapsed.TotalMilliseconds * 1000000).ToString() + "] ns";
            pTimer.Reset();
            if (globalTypeOfProcess == 1) { encryptedPlainText_txtb.Text = globalDataProcessed; }
            if (globalTypeOfProcess == 2) { decryptedEncryptedText_txtb.Text = globalDataProcessed; }

            progress_grpbx.Text = "Data status";
            globalTypeOfProcess = 0;
            progress_grpbx.Enabled = false;
        }

        private void clearAll_btn_Click(object sender, EventArgs e) {
            encryptTextClear_txtb.Text = "";
            encryptedPlainText_txtb.Text = "";
            encryptKey_txtb.Text = "";
            encryptFileOutputName_txtb.Text = "";
            encryptSelFile_txtb.Text = "";
            decryptTextEncrypted_txtb.Text = "";
            decryptedEncryptedText_txtb.Text = "";
            decryptKey_txtb.Text = "";
            decryptFileOutputName_txtb.Text = "";
            decryptSelFile_txtb.Text = "";
            this.ActiveControl = label1;
        }
    }
}
