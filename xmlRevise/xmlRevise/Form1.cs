using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Resources;
using System.Reflection;
using System.Xml;
using System.Linq;

namespace xmlRevise
{
    public partial class Form1 : Form
    {
        bool firstRun = true; //第一次运行标志位，如果是第一次运行，则释放bnsdat.exe
        string xmlFilePath;   //xml文件路径（文件夹）
        public bool isNantian = false;
        public Process process = null;
        public Form1()
        {
            InitializeComponent();
        }

        #region 窗口载入事件
        private void Form1_Load(object sender, EventArgs e)
        {
            init(); //初始化控件
        }
        #endregion

        #region 启用禁用相关按钮
        /// <summary>
        /// Enable 所有 button
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
            groupBox5.Enabled = true;
            groupBox6.Enabled = true;
        }

        /// <summary>
        /// Disable some button
        /// </summary>
        private void initDisable()
        {
            button_loadProfile.Enabled = false; //禁用“加载当前配置”按钮
            button_resetProfile.Enabled = false;//禁用“恢复默认配置”按钮
            button_save.Enabled = false;
            button_Pack.Enabled = false;        //禁用“打包”按钮
            groupBox3.Enabled = false;
            groupBox5.Enabled = false;
            groupBox6.Enabled = false;

        }

        /// <summary>
        /// 窗口载入初始化
        /// </summary>
        private void init()
        {
            radioButton_X.Select();
            button_Unpack.Enabled = false;      //禁用“解包”按钮
            button_loadProfile.Enabled = false; //禁用“加载当前配置”按钮
            button_resetProfile.Enabled = false;//禁用“恢复默认配置”按钮
            button_save.Enabled = false;
            button_Pack.Enabled = false;        //禁用“打包”按钮
            groupBox3.Enabled = false;
            groupBox5.Enabled = false;
            groupBox6.Enabled = false;
            radioButton_ZSF.Select();
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
            checkBox_autoBUFF.Checked = true;
            radioButton_Ping100.Select();
            label_Now.Text = "恢复成功!";

        }
        #endregion

        #region bnsdat.exe操作事件
        /// <summary>
        /// bnsdat.exe操作事件
        /// </summary>
        private bool OutPutForm_Shown(string path, string arg)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "bnsdat.exe";

                p.StartInfo.WorkingDirectory = path;

                p.StartInfo.Arguments = arg;

                p.Start();

                //p.StandardInput.WriteLine("bnsdat.exe");

                //p.StandardInput.WriteLine("exit");

                while (!p.HasExited)
                {

                    p.WaitForExit();

                }

                //int returnValue = p.ExitCode;
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(),"bnsdat操作事件");
                return false;
            }
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

                if (firstRun)
                {
                    if (releaseBnsdatExe())
                    {
                        firstRun = false;
                    }

                }

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

                if (!File.Exists(xmlFilePath + "bnsdat.exe"))
                {
                    MessageBox.Show("你是不是把bnsdat.exe删了?快还原回来,如果还原不回来了那就重启本软件,我自己搞定 ^0~ ");
                    return;
                }
                label_Now.Text = "正在解包...";
                //解包结束并且 client.config2.xml 不是0字节
                if (OutPutForm_Shown(xmlFilePath, String.Format("{0}{1}", radioButton_E.Checked ? "-e " : "-x ", "xml.dat")) && OutPutForm_Shown(xmlFilePath, String.Format("{0}{1}", radioButton_E.Checked ? "-e " : "-x ", "config.dat")))
                {
                    if (File.Exists(xmlFilePath + "xml.dat.files\\client.config2.xml") && File.Exists(xmlFilePath + "config.dat.files\\system.config2.xml"))
                    {
                        FileInfo xmldat = new FileInfo(xmlFilePath + "xml.dat.files\\client.config2.xml");
                        FileInfo configdat = new FileInfo(xmlFilePath + "xml.dat.files\\client.config2.xml");
                        if (xmldat.Length != 0 && configdat.Length != 0)
                        {
                            label_Now.Text = "解包完成。";
                            initEnable();
                            button_loadProfile.PerformClick(); //解包完成自动点击载入按钮,
                            return;
                        }
                        else
                        {
                            MessageBox.Show("您的xml.dat和config.dat是被修改过的,编码方式已被改变,无法解包,请从QQ群493171881下载原版文件.", "解包失败");
                            return;
                        }
                    }


                }

                label_Now.Text = "解包失败。";
                MessageBox.Show("解包失败");
            }//总try结束
            catch(Exception e_bt_unpack)
            {
                MessageBox.Show(e_bt_unpack.ToString(), "解包按钮错误");
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
                int GCD = 100;
                bool breast = false, damage = false, autobuff = true;
                if (checkBox_Breast.Checked)
                {
                    breast = true;
                }
                if (checkBox_Six.Checked)
                {
                    damage = true;
                }
                if (checkBox_autoBUFF.Checked == false)
                {
                    autobuff = false;
                }
                if (radioButton_Ping100.Checked)
                {
                    GCD = 100;
                }
                else if (radioButton_Ping150.Checked)
                {
                    GCD = 150;
                }
                else if (radioButton_Ping180.Checked)
                {
                    GCD = 180;
                }
                else if (radioButton_Ping200.Checked)
                {
                    GCD = 200;
                }
                else if (radioButton_Input.Checked)
                {
                    try
                    {
                        GCD = Convert.ToInt32(textBox_Ping.Text);
                    }
                    catch
                    {
                        MessageBox.Show("GCD输入错误，请输入（100-255）之间的整数");
                        return;
                    }

                }

                if (radioButton_NT.Checked) //如果选中南天国模式
                {
                    isNantian = true;
                }
                else if (radioButton_ZSF.Checked)
                {
                    isNantian = false;
                }
                xml.xmlWrite(xmlFilePath, GCD, breast, damage, autobuff, isNantian);
                label_Now.Text = "保存完毕";
            }
            catch(Exception e_bt_save)
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
                int GCD;
                bool breast, damage, autobuff;
                xml.xmlRead(xmlFilePath, out GCD, out breast, out damage, out autobuff);

                if (breast == true) //摇乳选择框
                {
                    checkBox_Six.Checked = true;
                }
                else
                {
                    checkBox_Six.Checked = false;
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
                    checkBox_autoBUFF.Checked = true;
                }
                else
                {
                    checkBox_autoBUFF.Checked = false;
                }
                switch (GCD)
                {
                    case 100:
                        radioButton_Ping100.Checked = true;
                        break;
                    case 150:
                        radioButton_Ping150.Checked = true;
                        break;
                    case 180:
                        radioButton_Ping180.Checked = true;
                        break;
                    case 200:
                        radioButton_Ping200.Checked = true;
                        break;
                    default:
                        radioButton_Input.Checked = true;
                        textBox_Ping.Enabled = true;
                        textBox_Ping.Text = GCD.ToString();
                        break;
                }
                label_Now.Text = "载入成功！";
            }
            catch (Exception e_load)
            {
                MessageBox.Show(e_load.ToString(),"载入按钮");
                label_Now.Text = "载入失败！";
            }

        }
        #endregion

        #region GCD 选择编辑框 点击事件
        private void textBox_Ping_Click(object sender, EventArgs e)
        {
            if (textBox_Ping.Text == "自定义")
                textBox_Ping.Text = "";
        }

        private void radioButton_Input_Click(object sender, EventArgs e)
        {
            textBox_Ping.Enabled = true;
            textBox_Ping.Text = "自定义";
        }

        private void radioButton_Ping100_Click(object sender, EventArgs e)
        {
            textBox_Ping.Enabled = false;
            textBox_Ping.Text = "自定义";
        }

        private void radioButton_Ping150_Click(object sender, EventArgs e)
        {
            textBox_Ping.Enabled = false;
            textBox_Ping.Text = "自定义";
        }

        private void radioButton_Ping180_CheckedChanged(object sender, EventArgs e)
        {
            textBox_Ping.Enabled = false;
            textBox_Ping.Text = "自定义";
        }

        private void radioButton_Ping200_CheckedChanged(object sender, EventArgs e)
        {
            textBox_Ping.Enabled = false;
            textBox_Ping.Text = "自定义";
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
                Backup_xml_config(); //打包之前先备份xml

                initDisable();
                label_Now.Text = "正在打包...";

                if (OutPutForm_Shown(xmlFilePath, "-c xml.dat.files") && OutPutForm_Shown(xmlFilePath, "-c config.dat.files"))
                {
                    label_Now.Text = "打包完成。";
                }
                else
                {
                    label_Now.Text = "打包失败。";
                    MessageBox.Show("打包失败");
                }
                initEnable();
            }
            catch (Exception e_Pack)
            {
                MessageBox.Show(e_Pack.ToString());
            }

        }
        #endregion

        #region 备份xml.dat config.dat
        private void Backup_xml_config()
        {
            if (File.Exists(xmlFilePath + "xml.dat") && File.Exists(xmlFilePath + "config.dat"))
            {
                try
                {
                    DateTime nowTime = DateTime.Now; //获取当前系统时间
                    File.Copy(xmlFilePath + "xml.dat", xmlFilePath + "Backup\\xml.dat." + nowTime.ToString("HH_mm_ss")); //开始拷贝
                    File.Copy(xmlFilePath + "config.dat", xmlFilePath + "Backup\\config.dat." + nowTime.ToString("HH_mm_ss")); //开始拷贝
                }
                catch (Exception e) //拷贝出错
                {
                    MessageBox.Show(e.ToString(),"备份出错");
                }
            }
        }
        #endregion

        #region 释放 bnsdat.exe
        private bool releaseBnsdatExe()
        {
            try
            {
                //写出bnsdat.exe
                File.WriteAllBytes(xmlFilePath + "bnsdat.exe", Resource1.bnsdat);

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
            /// 读取GCD数值 摇乳是否开启 6人伤害统计是否开启
            /// </summary>
            /// <param name="path">xmlFilePath路径</param>
            /// <param name="GCD">GCD数值(int)</param>
            /// <param name="breast">摇乳是否开启，是为true(bool)</param>
            /// <param name="damage">6人伤害统计是否开启，是为true(bool)</param>
            public void xmlWrite(string path, int GCD, bool breast, bool damage, bool autoBUFF, bool isNantian)
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;//忽略文档里面的注释
                if (!File.Exists(path + "xml.dat.files\\client.config2.xml"))
                {
                    MessageBox.Show("找不到 client.config2.xml 请重新解压");
                    return;
                }
                if (!File.Exists(path + "config.dat.files\\system.config2.xml"))
                {
                    MessageBox.Show("找不到 system.config2.xml 请重新解压");
                    return;
                }


                #region system.config2.xml 修改区
                /*  system.config2.xml  修改区 开始 */
                if (isNantian)
                {
                    XmlReader reader_NT = XmlReader.Create(path + "config.dat.files\\system.config2.xml", settings);
                    xmlDoc.Load(reader_NT);
                    XmlNodeList nodeList_NT = xmlDoc.SelectSingleNode("config").ChildNodes;//获取config节点的所有子节点

                    foreach (XmlNode xn_NT in nodeList_NT)//遍历所有子节点 
                    {

                        XmlElement xe_NT = (XmlElement)xn_NT;//将子节点类型转换为XmlElement类型
                        if (xe_NT.GetAttribute("name") == "use-auto-bias-global-cool-time")//如果找到 
                        {
                            try
                            {
                                xe_NT.SetAttribute("value", "false"); //设置当前节点值
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show("EnableGCD" + e.ToString());
                            }
                        }
                    }
                    reader_NT.Close();
                    xmlDoc.Save(path + "config.dat.files\\system.config2.xml");
                }

                /*  system.config2.xml  修改区 结束 */
                #endregion

                #region client.config 修改区
                /*  client.config2.xml  修改区 开始 */
                XmlReader reader = XmlReader.Create(path + "xml.dat.files\\client.config2.xml", settings);
                xmlDoc.Load(reader);

                XmlNodeList nodeList = xmlDoc.SelectSingleNode("config").ChildNodes;//获取config节点的所有子节点

                foreach (XmlNode xn in nodeList)//遍历所有子节点 
                {

                    XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型 

                    #region GCD
                    if (xe.GetAttribute("name") == "skill")//如果name属性值为 
                    {

                        XmlNodeList nls = xe.ChildNodes;//继续获取xe子节点的所有子节点 
                        foreach (XmlNode xn1 in nls)//遍历 
                        {
                            XmlElement xe2 = (XmlElement)xn1;//转换类型 
                            if (xe2.GetAttribute("name") == "skill-global-cool-latency-time")//如果找到 
                            {
                                try
                                {
                                    xe2.SetAttribute("value", GCD.ToString()); //Set当前节点值
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show(e.ToString());
                                }
                            }
                        }

                    }
                    #endregion

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


                }//foreach 遍历所有子节点 结束

                reader.Close();
                xmlDoc.Save(path + "xml.dat.files\\client.config2.xml");
                /*  client.config2.xml  修改区 结束  */
                #endregion

            }//xmlWrite结束
            #endregion

            #region xmlRead
            /// <summary>
            /// 读取GCD数值 摇乳是否开启 6人伤害统计是否开启
            /// </summary>
            /// <param name="path">xmlFilePath路径</param>
            /// <param name="GCD">GCD数值(int)</param>
            /// <param name="breast">摇乳是否开启，是为true(bool)</param>
            /// <param name="damage">6人伤害统计是否开启，是为true(bool)</param>
            public void xmlRead(string path, out int GCD, out bool breast, out bool damage, out bool autoBUFF)
            {
                GCD = 100;
                breast = false;
                damage = false;
                autoBUFF = true;

                string[] returnValues = new string[4];
                XmlDocument xmlDoc = new XmlDocument();
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;//忽略文档里面的注释
                if (!File.Exists(path + "xml.dat.files\\client.config2.xml"))
                {
                    MessageBox.Show("找不到 client.config2.xml 请重新解压");
                    return;
                }
                if (!File.Exists(path + "config.dat.files\\system.config2.xml"))
                {
                    MessageBox.Show("找不到 system.config2.xml 请重新解压");
                    return;
                }



                /*  client.config2.xml  修改区 开始 */
                XmlReader reader = XmlReader.Create(path + "xml.dat.files\\client.config2.xml", settings);
                xmlDoc.Load(reader);

                XmlNodeList nodeList = xmlDoc.SelectSingleNode("config").ChildNodes;//获取config节点的所有子节点

                foreach (XmlNode xn in nodeList)//遍历所有子节点 
                {

                    XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型 

                    #region GCD延时
                    if (xe.GetAttribute("name") == "skill")//如果name属性值为“skill” 
                    {


                        XmlNodeList nls = xe.ChildNodes;//继续获取xe子节点的所有子节点 
                        foreach (XmlNode xn1 in nls)//遍历 
                        {
                            XmlElement xe2 = (XmlElement)xn1;//转换类型 
                            if (xe2.GetAttribute("name") == "skill-global-cool-latency-time")//如果找到 
                            {
                                try
                                {
                                    returnValues[0] = xe2.GetAttribute("value"); //获取当前节点值
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show("GCD" + e.ToString());
                                }
                            }
                        }

                    }
                    #endregion

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
                                            returnValues[3] = xe3.GetAttribute("value"); //获取当前节点值
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
                }//foreach 遍历所有子节点 结束

                /*  client.config2.xml  修改区 结束 */



                /*   返回GCD值为int32型   */
                try
                {
                    GCD = Convert.ToInt32(returnValues[0]); //out GCD值
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    reader.Close();
                    return;
                }

                /*  返回摇乳是否开启，开启返回true，未开启返回false，数据损坏返回false  */
                try
                {
                    if (returnValues[1] == "true")
                    {
                        breast = false;
                    }
                    else if (returnValues[1] == "false")
                    {
                        breast = true;
                    }
                    else
                    {
                        MessageBox.Show("数据损坏，请重新解包后再进行修改", "摇乳");
                        reader.Close();
                        return;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    reader.Close();
                    return;
                }

                /*  返回6人伤害统计是否开启，开启返回true，未开启返回false，数据损坏返回false  */
                try
                {
                    if (returnValues[2] == "n")
                    {
                        damage = false;
                    }
                    else if (returnValues[2] == "y")
                    {
                        damage = true;
                    }
                    else
                    {
                        MessageBox.Show("数据损坏，请重新解包后再进行修改", "6人伤害");
                        reader.Close();
                        return;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    reader.Close();
                    return;
                }

                /*  返回技能自动排序是否开启，开启返回true，未开启返回false，数据损坏返回false*/
                try
                {
                    if (returnValues[3] == "n")
                    {
                        autoBUFF = false;
                    }
                    else if (returnValues[3] == "y")
                    {
                        autoBUFF = true;
                    }
                    else
                    {
                        MessageBox.Show("数据损坏，请重新解包后再进行修改", "技能排序");
                        reader.Close();
                        return;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    reader.Close();
                    return;
                }

                reader.Close();
            }
            #endregion
        }
        #endregion

    }
}
