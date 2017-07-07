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
                bool breast = false, damage = false, autobuff = true, backRun = false, fight = false, JLG = false;
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

                xml.xmlWrite(xmlFilePath, breast, damage, autobuff, backRun, fight, JLG);
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
                bool breast, damage, autobuff, backRun, fight, JLG;
                xml.xmlRead(xmlFilePath, out breast, out damage, out autobuff, out backRun, out fight, out JLG);

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

        #region xml读写
        public class xmlRW
        {
            public void xmlRw()
            {

            }
            #region xmlWrite
            /// <summary>
            /// 读取 摇乳是否开启 6人伤害统计是否开启
            /// </summary>
            /// <param name="path">xmlFilePath路径</param>
            /// <param name="breast">摇乳是否开启，是为true(bool)</param>
            /// <param name="damage">6人伤害统计是否开启，是为true(bool)</param>
            public void xmlWrite(string path, bool breast, bool damage, bool autoBUFF, bool backRun, bool fight, bool JLG)
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;//忽略文档里面的注释
                if (!File.Exists(path + "xml.dat.files\\client.config2.xml"))
                {
                    MessageBox.Show("找不到 client.config2.xml 请重新解包");
                    return;
                }

                #region client.config2.xml 修改区
                /*  client.config2.xml  修改区 开始 */
                XmlReader reader = XmlReader.Create(path + "xml.dat.files\\client.config2.xml", settings);
                xmlDoc.Load(reader);

                XmlNodeList nodeList = xmlDoc.SelectSingleNode("config").ChildNodes;//获取config节点的所有子节点

                foreach (XmlNode xn in nodeList)//遍历所有子节点 
                {

                    XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型 

                    #region 摇乳
                    if (xe.GetAttribute("name") == "uncategorized")//如果name属性值为“skill” 
                    {
                        XmlNodeList nls = xe.ChildNodes;//继续获取xe子节点的所有子节点 
                        foreach (XmlNode xn1 in nls)//遍历 
                        {
                            XmlElement xe2 = (XmlElement)xn1;//转换类型 
                            if (xe2.GetAttribute("name") == "no-use-breast-physics")//如果找到 
                            {
                                try
                                {
                                    if (breast == true) { xe2.SetAttribute("value", "false"); }  //Set当前节点值
                                    else { xe2.SetAttribute("value", "true"); }
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show(e.ToString());
                                }
                            }
                        }

                    }
                    #endregion

                    #region 六人伤害统计
                    if (xe.GetAttribute("name") == "damage-meter")//如果name属性值为“skill” 
                    {
                        XmlNodeList nls = xe.ChildNodes;//继续获取xe子节点的所有子节点 
                        foreach (XmlNode xn1 in nls)//遍历 
                        {
                            XmlElement xe2 = (XmlElement)xn1;//转换类型 
                            if (xe2.GetAttribute("name") == "show-party-6-dungeon-and-cave")//如果找到 
                            {
                                try
                                {
                                    if (damage == true) { xe2.SetAttribute("value", "y"); }  //Set当前节点值
                                    else { xe2.SetAttribute("value", "n"); }
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show(e.ToString());
                                }
                            }
                        }

                    }
                    #endregion

                    #region BUFF自动排序
                    if (xe.GetAttribute("name") == "hud")//如果name属性值为“skill” 
                    {
                        XmlNodeList nls = xe.ChildNodes;//继续获取xe子节点的所有子节点 
                        foreach (XmlNode xn1 in nls)//遍历 
                        {
                            XmlElement xe2 = (XmlElement)xn1;//转换类型 
                            if (xe2.GetAttribute("name") == "effect")//如果找到 
                            {
                                XmlNodeList nls2 = xe2.ChildNodes;
                                foreach (XmlNode xn2 in nls2)
                                {
                                    XmlElement xe3 = (XmlElement)xn2;
                                    if (xe3.GetAttribute("name") == "use-passive-effect-auto-sort")
                                    {
                                        try
                                        {
                                            if (autoBUFF == true) { xe3.SetAttribute("value", "y"); }  //Set当前节点值
                                            else { xe3.SetAttribute("value", "n"); }
                                        }
                                        catch (Exception e)
                                        {
                                            MessageBox.Show(e.ToString());
                                        }
                                    }
                                }


                            }
                        }

                    }
                    #endregion

                    #region 移动加速
                    if (xe.GetAttribute("name") == "move")//如果name属性值为“move” 
                    {
                        XmlNodeList nls = xe.ChildNodes;//继续获取xe子节点的所有子节点 
                        foreach (XmlNode xn1 in nls)//遍历 
                        {
                            XmlElement xe2 = (XmlElement)xn1;//转换类型 

                            #region 后退加速
                            if (xe2.GetAttribute("name") == "backrun-velocity-pct")//如果找到 
                            {
                                try
                                {
                                    if (backRun == true) { xe2.SetAttribute("value", "1.400000"); }
                                    else { xe2.SetAttribute("value", "0.400000"); }
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show(e.ToString());
                                }
                            }

                            if (xe2.GetAttribute("name") == "walking-velocity-pct")//如果找到 
                            {
                                try
                                {
                                    if (backRun == true) { xe2.SetAttribute("value", "1.400000"); }
                                    else { xe2.SetAttribute("value", "0.300000"); }
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show(e.ToString());
                                }
                            }

                            if (xe2.GetAttribute("name") == "backwalking-velocity-pct")//如果找到 
                            {
                                try
                                {
                                    if (backRun == true) { xe2.SetAttribute("value", "1.300000"); }
                                    else { xe2.SetAttribute("value", "0.150000"); }
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show(e.ToString());
                                }
                            }
                            #endregion

                            #region 战斗状态加速
                            if (xe2.GetAttribute("name") == "combat-velocity-pct")//如果找到 
                            {
                                try
                                {
                                    if (fight == true) { xe2.SetAttribute("value", "1.200000"); }
                                    else { xe2.SetAttribute("value", "0.800000"); }
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show(e.ToString());
                                }
                            }
                            #endregion

                        }

                    }
                    #endregion

                    #region 聚灵阁加速
                    if (xe.GetAttribute("name") == "random-store")//如果name属性值为 
                    {
                        XmlNodeList nls = xe.ChildNodes;//继续获取xe子节点的所有子节点 
                        foreach (XmlNode xn1 in nls)//遍历 
                        {
                            XmlElement xe2 = (XmlElement)xn1;//转换类型 
                            if (xe2.GetAttribute("name") == "progress-duration")//如果找到 
                            {
                                try
                                {
                                    if (JLG == true) { xe2.SetAttribute("value", "0.01"); }  //Set当前节点值
                                    else { xe2.SetAttribute("value", "2.0"); }
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show(e.ToString());
                                }
                            }
                            if (xe2.GetAttribute("name") == "slot-update-delay")//如果找到 
                            {
                                try
                                {
                                    if (JLG == true) { xe2.SetAttribute("value", "0.01"); }  //Set当前节点值
                                    else { xe2.SetAttribute("value", "0.2"); }
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show(e.ToString());
                                }
                            }
                        }

                    }
                    #endregion


                }//foreach 遍历所有子节点 结束

                reader.Close();
                xmlDoc.Save(path + "xml.dat.files\\client.config2.xml");
                /*  client.config2.xml  修改区 结束  */
                #endregion

            }//xmlWrite结束
            #endregion

            #region xmlRead
            /// <summary>
            /// 读取 摇乳是否开启 6人伤害统计是否开启
            /// </summary>
            /// <param name="path">xmlFilePath路径</param>
            /// <param name="breast">摇乳是否开启，是为true(bool)</param>
            /// <param name="damage">6人伤害统计是否开启，是为true(bool)</param>
            public void xmlRead(string path, out bool breast, out bool damage, out bool autoBUFF, out bool backRun, out bool fight, out bool JLG)
            {
                breast = false;
                damage = false;
                autoBUFF = true;
                backRun = false;
                fight = false;
                JLG = false;

                string[] returnValues = new string[3];
                string[] returnMoves = new string[4];
                string[] returnJLG = new string[2];
                XmlDocument xmlDoc = new XmlDocument();
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;//忽略文档里面的注释
                if (!File.Exists(path + "xml.dat.files\\client.config2.xml"))
                {
                    MessageBox.Show("找不到 client.config2.xml 请重新解包");
                    return;
                }

                /*  client.config2.xml  修改区 开始 */
                XmlReader reader = XmlReader.Create(path + "xml.dat.files\\client.config2.xml", settings);
                xmlDoc.Load(reader);

                XmlNodeList nodeList = xmlDoc.SelectSingleNode("config").ChildNodes;//获取config节点的所有子节点

                foreach (XmlNode xn in nodeList)//遍历所有子节点 
                {

                    XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型 

                    #region 摇乳
                    if (xe.GetAttribute("name") == "uncategorized")//如果name属性值为
                    {
                        XmlNodeList nls = xe.ChildNodes;//继续获取xe子节点的所有子节点 
                        foreach (XmlNode xn1 in nls)//遍历 
                        {
                            XmlElement xe2 = (XmlElement)xn1;//转换类型 
                            if (xe2.GetAttribute("name") == "no-use-breast-physics")//如果找到 
                            {
                                try
                                {
                                    returnValues[1] = xe2.GetAttribute("value"); //获取当前节点值
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show("摇乳" + e.ToString());
                                }
                            }
                        }

                    }
                    #endregion

                    #region 六人伤害统计
                    if (xe.GetAttribute("name") == "damage-meter")//如果name属性值为“skill” 
                    {


                        XmlNodeList nls = xe.ChildNodes;//继续获取xe子节点的所有子节点 
                        foreach (XmlNode xn1 in nls)//遍历 
                        {
                            XmlElement xe2 = (XmlElement)xn1;//转换类型 
                            if (xe2.GetAttribute("name") == "show-party-6-dungeon-and-cave")//如果找到 
                            {
                                try
                                {
                                    returnValues[2] = xe2.GetAttribute("value"); //获取当前节点值
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show("六人伤害统计" + e.ToString());
                                }
                            }
                        }

                    }
                    #endregion

                    #region BUFF自动排序
                    if (xe.GetAttribute("name") == "hud")//如果name属性值为
                    {
                        XmlNodeList nls = xe.ChildNodes;//继续获取xe子节点的所有子节点 
                        foreach (XmlNode xn1 in nls)//遍历 
                        {
                            XmlElement xe2 = (XmlElement)xn1;//转换类型 
                            if (xe2.GetAttribute("name") == "effect")//如果找到 
                            {
                                XmlNodeList nls2 = xe2.ChildNodes;

                                foreach (XmlNode xn2 in nls2)
                                {
                                    XmlElement xe3 = (XmlElement)xn2;
                                    if (xe3.GetAttribute("name") == "use-passive-effect-auto-sort")
                                    {
                                        try
                                        {
                                            returnValues[0] = xe3.GetAttribute("value"); //获取当前节点值
                                        }
                                        catch (Exception e)
                                        {
                                            MessageBox.Show("BUFF自动排序" + e.ToString());
                                        }
                                    }

                                }


                            }
                        }

                    }
                    #endregion

                    #region 移动速度
                    if (xe.GetAttribute("name") == "move")//如果name属性值为
                    {
                        XmlNodeList nls = xe.ChildNodes;//继续获取xe子节点的所有子节点 
                        foreach (XmlNode xn1 in nls)//遍历 
                        {
                            XmlElement xe2 = (XmlElement)xn1;//转换类型 
                            if (xe2.GetAttribute("name") == "backrun-velocity-pct")//如果找到 
                            {
                                try
                                {
                                    returnMoves[0] = xe2.GetAttribute("value"); //获取当前节点值
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show("后退加速0" + e.ToString());
                                }
                            }

                            if (xe2.GetAttribute("name") == "walking-velocity-pct")//如果找到 
                            {
                                try
                                {
                                    returnMoves[1] = xe2.GetAttribute("value"); //获取当前节点值
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show("后退加速1" + e.ToString());
                                }
                            }

                            if (xe2.GetAttribute("name") == "backwalking-velocity-pct")//如果找到 
                            {
                                try
                                {
                                    returnMoves[2] = xe2.GetAttribute("value"); //获取当前节点值
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show("后退加速2" + e.ToString());
                                }
                            }

                            if (xe2.GetAttribute("name") == "combat-velocity-pct")//如果找到 
                            {
                                try
                                {
                                    returnMoves[3] = xe2.GetAttribute("value"); //获取当前节点值
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show("后退加速3" + e.ToString());
                                }
                            }

                        }

                    }
                    #endregion

                    #region 聚灵阁加速
                    if (xe.GetAttribute("name") == "random-store")//如果name属性值为“skill” 
                    {


                        XmlNodeList nls = xe.ChildNodes;//继续获取xe子节点的所有子节点 
                        foreach (XmlNode xn1 in nls)//遍历 
                        {
                            XmlElement xe2 = (XmlElement)xn1;//转换类型 
                            if (xe2.GetAttribute("name") == "progress-duration")//如果找到 
                            {
                                try
                                {
                                    returnJLG[0] = xe2.GetAttribute("value"); //获取当前节点值
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show("聚灵阁" + e.ToString());
                                }
                            }
                            if (xe2.GetAttribute("name") == "slot-update-delay")//如果找到 
                            {
                                try
                                {
                                    returnJLG[1] = xe2.GetAttribute("value"); //获取当前节点值
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show("聚灵阁" + e.ToString());
                                }
                            }
                        }

                    }
                    #endregion
                }//foreach 遍历所有子节点 结束

                /*  client.config2.xml  修改区 结束 */



                /*  返回摇乳是否开启，开启返回true，未开启返回false  */
                if (returnValues[1] == "true") { breast = false; }
                else { breast = true; }

                /*  返回6人伤害统计是否开启，开启返回true，未开启返回false */
                if (returnValues[2] == "y") { damage = true; }
                else { damage = false; }

                /*  返回技能自动排序是否开启，开启返回true，未开启返回false */
                if (returnValues[0] == "n") { autoBUFF = false; }
                else { autoBUFF = true; }

                /* 返回后退加速是否开启 */
                if (Convert.ToDouble(returnMoves[0]) > 0.4 || Convert.ToDouble(returnMoves[1]) > 0.3 || Convert.ToDouble(returnMoves[2]) > 0.15)
                { backRun = true; }
                else { backRun = false; }

                /* 返回战斗加速是否开启 */
                if (Convert.ToDouble(returnMoves[3]) > 0.8) { fight = true; }
                else { fight = false; }

                /* 返回聚灵阁加速是否开启 */
                if (Convert.ToDouble(returnJLG[0]) < 2.0 || Convert.ToDouble(returnJLG[1]) < 0.2) { JLG = true; }
                else { JLG = false; }


                reader.Close();
            }
            #endregion
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
