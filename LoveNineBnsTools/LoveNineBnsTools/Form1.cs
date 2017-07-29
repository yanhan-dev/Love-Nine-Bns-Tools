using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.ComponentModel;
using System.Threading;

namespace LoveNineBnsTools
{

    public partial class Form1 : Form
    {
        public static Form1 CurrentForm;
        string xmlFilePath;   //xml文件路径（文件夹）
        string usedfilepath;
        string usedfilepathonly;
        bool BNSis64 = false;
        public Process process = null;
        public BackgroundWorker bnsdat;
        public BackgroundWorker bnsdatc;
        private AutoResetEvent waitbw = new AutoResetEvent(false);

        //BNSdat操作事件枚举
        enum BNSdatEvent
        {
            Extract = 0, //解包 
            Compress = 1 //打包
        }
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        #region 窗口载入事件
        private void Form1_Load(object sender, EventArgs e)
        {
            init(); //初始化控件

            //初始化运行环境
            if (!releaseIonic())
            {
                MessageBox.Show("无法初始化运行环境，请右键点击本程序 以管理员身份运行");
            }
        }
        #endregion

        #region 启用禁用相关按钮
        /// <summary>
        /// 启用所有按钮
        /// </summary>
        private void initEnable()
        {
            button_Open.Enabled = true;
            button_Unpack.Enabled = true;
            button_loadProfile.Enabled = true;
            button_resetProfile.Enabled = true;
            button_save.Enabled = true;
            button_Pack.Enabled = true;
            groupBox3.Enabled = true;
            groupBox6.Enabled = true;
            groupBox1.Enabled = true;
        }

        /// <summary>
        /// 禁用相关按钮
        /// </summary>
        private void initDisable()
        {
            button_loadProfile.Enabled = false; //禁用“加载当前配置”按钮
            button_resetProfile.Enabled = false;//禁用“恢复默认配置”按钮
            button_save.Enabled = false;
            button_Pack.Enabled = false;        //禁用“打包”按钮
            groupBox3.Enabled = false;
            groupBox6.Enabled = false;
            groupBox1.Enabled = false;

        }

        /// <summary>
        /// 窗口载入初始化
        /// </summary>
        private void init()
        {
            button_Unpack.Enabled = false;      //禁用“解包”按钮
            button_loadProfile.Enabled = false; //禁用“加载当前配置”按钮
            button_resetProfile.Enabled = false;//禁用“恢复默认配置”按钮
            button_save.Enabled = false;
            button_Pack.Enabled = false;        //禁用“打包”按钮
            groupBox3.Enabled = false;
            groupBox6.Enabled = false;
            groupBox1.Enabled = false;

        }
        #endregion

        #region 恢复剑灵默认配置按钮事件
        /// <summary>
        /// 恢复剑灵默认配置
        /// </summary>
        private void button_resetProfile_Click(object sender, EventArgs e)
        {
            label_Now.Text = "正在恢复...";
            checkBox_Six.Checked = false;
            checkBox_Breast.Checked = false;
            checkBox_autoBUFF.Checked = false;
            checkBox_backrun.Checked = false;
            checkBox_fight.Checked = false;
            checkBox_JLG.Checked = false;
            checkBox_ZuiJiaXingNeng.Checked = false;
            label_Now.Text = "恢复成功!";

        }
        #endregion

        #region "打开"按钮事件
        /// <summary>
        /// "打开"按钮事件
        /// </summary>
        private void button_Open_Click(object sender, EventArgs e)
        {

            try
            {
                OpenFileDialog ofd = new OpenFileDialog(); //打开xml.dat文件
                ofd.Title = "请选中xml.dat文件";
                ofd.Filter = "xml.dat|xml.dat";
                ofd.ShowDialog();

                if (ofd.FileName == "") //如果没有打开文件(点了取消)则返回
                {
                    button_Unpack.Enabled = false;      //禁用“解包”按钮
                    initDisable();
                    return;
                }

                xmlFilePath = RemoveRight(ofd.FileName, 7);//末尾去掉“xml.dat”
                textBox_Path.Text = ofd.FileName;

                button_Unpack.Enabled = true; //启用解包按钮

                if (File.Exists(xmlFilePath + "xml.dat.files\\client.config2.xml")) //未解包，已存在配置文件
                {
                    FileInfo fileInfo = new FileInfo(xmlFilePath + "xml.dat.files\\client.config2.xml");
                    if (fileInfo.Length != 0)
                    {
                        initEnable();                      // 先 启用所有按钮
                        button_loadProfile.PerformClick(); // 后 载入当前配置

                        return;
                    }
                }
                //解包失败
                initDisable();

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString(), "解包");
            }


        }

        #endregion

        #region "解包"按钮事件
        /// <summary>
        /// "解包"按钮事件
        /// </summary>
        private void button_Unpack_Click(object sender, EventArgs e)
        {
            try
            {
                initDisable();
                if (!File.Exists(xmlFilePath + "xml.dat"))
                {
                    MessageBox.Show("我的天，发生了什么？ xml.dat 怎么没了？");
                    return;
                }

                label_Now.Text = "正在解包...";

                //解包xml.dat
                usedfilepath = xmlFilePath + "xml.dat";
                Extractor(usedfilepath);

                if (File.Exists(xmlFilePath + "xml.dat.files\\client.config2.xml"))
                {
                    FileInfo xmldat = new FileInfo(xmlFilePath + "xml.dat.files\\client.config2.xml");
                    if (xmldat.Length != 0)
                    {
                        label_Now.Text = "解包完成。";
                        initEnable();
                        button_loadProfile.PerformClick(); //解包完成自动点击载入按钮,
                        return;
                    }
                }
                label_Now.Text = "解包失败。";
                MessageBox.Show("解包失败，请重新解包，有问题请联系作者QQ:852932673。", "解包失败");
                return;

            }//总try结束
            catch (Exception e_bt_unpack)
            {
                MessageBox.Show("请将以下内容截图反馈给作者QQ852932673\r\n" + e_bt_unpack.ToString(), "解包错误");
            }
        }

        #endregion

        #region "保存"按钮事件
        private void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                label_Now.Text = "正在保存...";

                xmlRW xml = new xmlRW();
                bool breast = false, damage = false, autobuff = true, backRun = false, fight = false, JLG = false, ZJXN = false;
                if (checkBox_Breast.Checked)
                {
                    breast = true;
                }
                if (checkBox_Six.Checked)
                {
                    damage = true;
                }
                if (checkBox_autoBUFF.Checked == true)
                {
                    autobuff = false;
                }
                if (checkBox_backrun.Checked == true)
                {
                    backRun = true;
                }
                if (checkBox_fight.Checked == true)
                {
                    fight = true;
                }
                if (checkBox_JLG.Checked == true)
                {
                    JLG = true;
                }
                if (checkBox_ZuiJiaXingNeng.Checked == true)
                {
                    ZJXN = true;
                }
                xml.xmlWrite(xmlFilePath, breast, damage, autobuff, backRun, fight, JLG, ZJXN);
                label_Now.Text = "保存完毕";
            }
            catch (Exception e_bt_save)
            {
                MessageBox.Show(e_bt_save.ToString(), "保存按钮");
            }
        }
        #endregion

        #region 载入当前配置按钮事件
        private void button_loadProfile_Click(object sender, EventArgs e)
        {
            try
            {
                xmlRW xml = new xmlRW();
                bool breast, damage, autobuff, backRun, fight, JLG, ZJXN;
                xml.xmlRead(xmlFilePath, out breast, out damage, out autobuff, out backRun, out fight, out JLG, out ZJXN);

                if (breast == true) //摇乳选择框
                {
                    checkBox_Breast.Checked = true;
                }
                else
                {
                    checkBox_Breast.Checked = false;
                }

                if (damage == true) //6人伤害选择框
                {
                    checkBox_Six.Checked = true;
                }
                else
                {
                    checkBox_Six.Checked = false;
                }
                if (autobuff == true) //BUFF自动排序选择框
                {
                    checkBox_autoBUFF.Checked = false;
                }
                else
                {
                    checkBox_autoBUFF.Checked = true;
                }
                if (backRun == true) //后退加速
                {
                    checkBox_backrun.Checked = true;
                }
                else
                {
                    checkBox_backrun.Checked = false;
                }
                if (fight == true) //战斗加速
                {
                    checkBox_fight.Checked = true;
                }
                else
                {
                    checkBox_fight.Checked = false;
                }
                if (JLG == true) //聚灵阁加速
                {
                    checkBox_JLG.Checked = true;
                }
                else
                {
                    checkBox_JLG.Checked = false;
                }
                if (ZJXN == true) //最佳性能模式
                {
                    checkBox_ZuiJiaXingNeng.Checked = true;
                }
                else
                {
                    checkBox_ZuiJiaXingNeng.Checked = false;
                }


                label_Now.Text = "载入成功！";
            }
            catch (Exception e_load)
            {
                MessageBox.Show(e_load.ToString(), "载入按钮");
                label_Now.Text = "载入失败！";
            }

        }
        #endregion

        #region 从字符串后面删除指定字符个数
        /// <summary>
        /// 从字符串后面删除指定字符个数
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="len">个数</param>
        /// <returns>返回删除后的字符串</returns>
        public static string RemoveRight(string s, int len)
        {
            s = s.PadRight(len);
            return s.Remove(s.Length - len, len);
        }
        #endregion

        #region 打包按钮事件
        private void button_Pack_Click(object sender, EventArgs e)
        {
            try
            {
                //保存修改
                button_save.PerformClick();

                if (Backup_xml())//打包之前先备份xml
                {
                    initDisable();
                    label_Now.Text = "正在打包...";

                    if (Directory.Exists(xmlFilePath + "xml.dat.files"))
                    {
                        usedfilepathonly = xmlFilePath + "xml.dat.files";
                        label_Now.Text = "正在打包xml.dat...";
                        Compiler(usedfilepathonly);

                        label_Now.Text = "打包完成。";
                    }
                    else
                    {
                        label_Now.Text = "打包失败。";
                        MessageBox.Show("找不到相关文件，请重新解包后再试。", "打包失败");
                    }
                    initEnable();
                }
                else
                {
                    MessageBox.Show("备份失败,请检查是否以管理员身份运行。");
                }



            }
            catch (Exception e_Pack)
            {
                MessageBox.Show(e_Pack.ToString(), "打包出错");
            }

        }
        #endregion

        #region 备份xml.dat
        private bool Backup_xml()
        {
            if (File.Exists(xmlFilePath + "xml.dat"))
            {
                try
                {
                    if (!Directory.Exists(xmlFilePath + "备份"))
                    {
                        Directory.CreateDirectory(xmlFilePath + "备份");
                    }
                    File.Copy(xmlFilePath + "xml.dat", xmlFilePath + "备份\\xml.dat", true); //开始拷贝
                    return true;
                }
                catch (Exception e) //拷贝出错
                {
                    MessageBox.Show(e.ToString());
                }
            }
            return false;
        }
        #endregion

        #region 释放 Ionic.Zlib.dll
        private bool releaseIonic()
        {
            try
            {
                if (!File.Exists("Ionic.Zlib.dll"))
                {
                    File.WriteAllBytes(Directory.GetCurrentDirectory() + "\\Ionic.Zlib.dll", Resource1.Ionic_Zlib);
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

                return false;
            }



        }
        #endregion

        #region BNSDat 解包操作

        public void Extractor(string qwerty)
        {
            // Check if 64bit or 32bit
            if (qwerty.Contains("64"))
            {
                BNSis64 = true;
            }
            else { BNSis64 = false; }

            // Go to task
            bnsdat = new BackgroundWorker();
            bnsdat.WorkerSupportsCancellation = true;
            bnsdat.WorkerReportsProgress = true;
            bnsdat.DoWork += new DoWorkEventHandler(bnsdat_DoWork);
            bnsdat.RunWorkerAsync();
            // Wait until task is complete
            waitbw.WaitOne();
            waitbw.Reset();
        }

        private void bnsdat_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            BNSDat BnsDat = new BNSDat();
            BnsDat.Extract(usedfilepath, BNSis64, Dispaly);
            // set task as completed
            waitbw.Set();
        }

        #endregion

        #region BNSDat 打包操作
        public void Compiler(string qwerty)
        {
            // Check if 64bit or 32bit
            if (qwerty.Contains("64"))
            {
                BNSis64 = true;
            }
            else { BNSis64 = false; }
            // Go to task
            bnsdatc = new BackgroundWorker();
            bnsdatc.WorkerSupportsCancellation = true;
            bnsdatc.WorkerReportsProgress = true;
            bnsdatc.DoWork += new DoWorkEventHandler(bnsdatc_DoWork);
            bnsdatc.RunWorkerAsync();
            // Wait until task is complete
            waitbw.WaitOne();
            waitbw.Reset();
        }

        private void bnsdatc_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            BNSDat BnsDat = new BNSDat();
            //ProgressBar progressBar = new ProgressBar();
            BnsDat.Compress(usedfilepathonly, BNSis64, Dispaly);
            // set task as completed
            waitbw.Set();
        }
        #endregion

        #region 进度更新
        public string Dispaly(string value)
        {
            return Dispaly(value, null);
        }
        public string Dispaly(string value, string msg)
        {
            label_Now.Text = value;
            return null;
        }
        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/laoluan/Love-Nine-Bns-Tools/releases");
        }
    }

}
