using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace LoveNineBnsTools
{
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
        public void xmlWrite(string path, bool breast, bool damage, bool autoBUFF, bool backRun, bool fight, bool JLG, bool ZJXN)
        {
            if (!File.Exists(path + "xml.dat.files\\client.config2.xml"))
            {
                MessageBox.Show("找不到 client.config2.xml 请重新解包");
                return;
            }

            XmlDocument xmlDoc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;//忽略文档里面的注释                

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

                #region 最佳性能模式
                if (xe.GetAttribute("name") == "option")
                {
                    XmlNodeList nls = xe.ChildNodes;//继续获取xe子节点的所有子节点 
                    foreach (XmlNode xn1 in nls)//遍历 
                    {
                        XmlElement xe2 = (XmlElement)xn1;//转换类型 
                        if (xe2.GetAttribute("name") == "use-optimal-performance-mode-option")//如果找到 
                        {
                            try
                            {
                                if (ZJXN == true) { xe2.SetAttribute("value", "true"); }  //Set当前节点值
                                else { xe2.SetAttribute("value", "false"); }
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
        public void xmlRead(string path, out bool breast, out bool damage, out bool autoBUFF, out bool backRun, out bool fight, out bool JLG, out bool ZJXN)
        {
            breast = false;
            damage = false;
            autoBUFF = true;
            backRun = false;
            fight = false;
            JLG = false;
            ZJXN = false;

            string[] returnValues = new string[4];
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

                #region 最佳性能模式
                if (xe.GetAttribute("name") == "option")
                {


                    XmlNodeList nls = xe.ChildNodes;//继续获取xe子节点的所有子节点 
                    foreach (XmlNode xn1 in nls)//遍历 
                    {
                        XmlElement xe2 = (XmlElement)xn1;//转换类型 
                        if (xe2.GetAttribute("name") == "use-optimal-performance-mode-option")//如果找到 
                        {
                            try
                            {
                                returnValues[3] = xe2.GetAttribute("value"); //获取当前节点值
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show("最佳性能模式" + e.ToString());
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

            /*  返回最佳性能模式是否开启，开启返回true，未开启返回false */
            if (returnValues[3] == "true") { ZJXN = true; }
            else { ZJXN = false; }

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

}
