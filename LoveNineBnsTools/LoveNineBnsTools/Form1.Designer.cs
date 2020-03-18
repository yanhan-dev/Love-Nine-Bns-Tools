namespace LoveNineBnsTools
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_Unpack = new System.Windows.Forms.Button();
            this.button_Pack = new System.Windows.Forms.Button();
            this.groupBox_Step1 = new System.Windows.Forms.GroupBox();
            this.button_Open = new System.Windows.Forms.Button();
            this.textBox_Path = new System.Windows.Forms.TextBox();
            this.groupBox_Step2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_fight = new System.Windows.Forms.CheckBox();
            this.checkBox_backrun = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button_loadProfile = new System.Windows.Forms.Button();
            this.button_resetProfile = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox_autoBUFF = new System.Windows.Forms.CheckBox();
            this.checkBox_Breast = new System.Windows.Forms.CheckBox();
            this.checkBox_Six = new System.Windows.Forms.CheckBox();
            this.groupBox_Step3 = new System.Windows.Forms.GroupBox();
            this.button_save = new System.Windows.Forms.Button();
            this.label_Now = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.cbGCD = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_Step1.SuspendLayout();
            this.groupBox_Step2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox_Step3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Unpack
            // 
            this.button_Unpack.Location = new System.Drawing.Point(409, 17);
            this.button_Unpack.Name = "button_Unpack";
            this.button_Unpack.Size = new System.Drawing.Size(58, 25);
            this.button_Unpack.TabIndex = 0;
            this.button_Unpack.Text = "解包";
            this.button_Unpack.UseVisualStyleBackColor = true;
            this.button_Unpack.Click += new System.EventHandler(this.button_Unpack_Click);
            // 
            // button_Pack
            // 
            this.button_Pack.Location = new System.Drawing.Point(250, 11);
            this.button_Pack.Name = "button_Pack";
            this.button_Pack.Size = new System.Drawing.Size(99, 32);
            this.button_Pack.TabIndex = 1;
            this.button_Pack.Text = "打包文件";
            this.button_Pack.UseVisualStyleBackColor = true;
            this.button_Pack.Click += new System.EventHandler(this.button_Pack_Click);
            // 
            // groupBox_Step1
            // 
            this.groupBox_Step1.Controls.Add(this.button_Unpack);
            this.groupBox_Step1.Controls.Add(this.button_Open);
            this.groupBox_Step1.Controls.Add(this.textBox_Path);
            this.groupBox_Step1.Location = new System.Drawing.Point(12, 17);
            this.groupBox_Step1.Name = "groupBox_Step1";
            this.groupBox_Step1.Size = new System.Drawing.Size(474, 50);
            this.groupBox_Step1.TabIndex = 2;
            this.groupBox_Step1.TabStop = false;
            this.groupBox_Step1.Text = "Step1 选中剑灵 xml.dat config.dat 目录";
            // 
            // button_Open
            // 
            this.button_Open.Location = new System.Drawing.Point(343, 17);
            this.button_Open.Name = "button_Open";
            this.button_Open.Size = new System.Drawing.Size(58, 25);
            this.button_Open.TabIndex = 2;
            this.button_Open.Text = "打开";
            this.button_Open.UseVisualStyleBackColor = true;
            this.button_Open.Click += new System.EventHandler(this.button_Open_Click);
            // 
            // textBox_Path
            // 
            this.textBox_Path.Location = new System.Drawing.Point(6, 19);
            this.textBox_Path.Name = "textBox_Path";
            this.textBox_Path.Size = new System.Drawing.Size(329, 21);
            this.textBox_Path.TabIndex = 1;
            // 
            // groupBox_Step2
            // 
            this.groupBox_Step2.Controls.Add(this.groupBox1);
            this.groupBox_Step2.Controls.Add(this.groupBox6);
            this.groupBox_Step2.Controls.Add(this.groupBox3);
            this.groupBox_Step2.Location = new System.Drawing.Point(12, 73);
            this.groupBox_Step2.Name = "groupBox_Step2";
            this.groupBox_Step2.Size = new System.Drawing.Size(474, 163);
            this.groupBox_Step2.TabIndex = 3;
            this.groupBox_Step2.TabStop = false;
            this.groupBox_Step2.Text = "Step2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbGCD);
            this.groupBox1.Controls.Add(this.checkBox_fight);
            this.groupBox1.Controls.Add(this.checkBox_backrun);
            this.groupBox1.Location = new System.Drawing.Point(318, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 137);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "慎重修改区";
            // 
            // checkBox_fight
            // 
            this.checkBox_fight.AutoSize = true;
            this.checkBox_fight.ForeColor = System.Drawing.Color.Red;
            this.checkBox_fight.Location = new System.Drawing.Point(19, 51);
            this.checkBox_fight.Name = "checkBox_fight";
            this.checkBox_fight.Size = new System.Drawing.Size(96, 16);
            this.checkBox_fight.TabIndex = 11;
            this.checkBox_fight.Text = "开启战斗加速";
            this.checkBox_fight.UseVisualStyleBackColor = true;
            // 
            // checkBox_backrun
            // 
            this.checkBox_backrun.AutoSize = true;
            this.checkBox_backrun.ForeColor = System.Drawing.Color.Red;
            this.checkBox_backrun.Location = new System.Drawing.Point(19, 26);
            this.checkBox_backrun.Name = "checkBox_backrun";
            this.checkBox_backrun.Size = new System.Drawing.Size(96, 16);
            this.checkBox_backrun.TabIndex = 10;
            this.checkBox_backrun.Text = "开启后退加速";
            this.checkBox_backrun.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button_loadProfile);
            this.groupBox6.Controls.Add(this.button_resetProfile);
            this.groupBox6.Location = new System.Drawing.Point(25, 16);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(116, 137);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "加载/恢复";
            // 
            // button_loadProfile
            // 
            this.button_loadProfile.Location = new System.Drawing.Point(15, 34);
            this.button_loadProfile.Name = "button_loadProfile";
            this.button_loadProfile.Size = new System.Drawing.Size(87, 23);
            this.button_loadProfile.TabIndex = 1;
            this.button_loadProfile.Text = "加载当前配置";
            this.button_loadProfile.UseVisualStyleBackColor = true;
            this.button_loadProfile.Click += new System.EventHandler(this.button_loadProfile_Click);
            // 
            // button_resetProfile
            // 
            this.button_resetProfile.Location = new System.Drawing.Point(15, 83);
            this.button_resetProfile.Name = "button_resetProfile";
            this.button_resetProfile.Size = new System.Drawing.Size(87, 23);
            this.button_resetProfile.TabIndex = 0;
            this.button_resetProfile.Text = "恢复默认配置";
            this.button_resetProfile.UseVisualStyleBackColor = true;
            this.button_resetProfile.Click += new System.EventHandler(this.button_resetProfile_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox_autoBUFF);
            this.groupBox3.Controls.Add(this.checkBox_Breast);
            this.groupBox3.Controls.Add(this.checkBox_Six);
            this.groupBox3.Location = new System.Drawing.Point(161, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(138, 137);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "随意修改区";
            // 
            // checkBox_autoBUFF
            // 
            this.checkBox_autoBUFF.AutoSize = true;
            this.checkBox_autoBUFF.Location = new System.Drawing.Point(12, 66);
            this.checkBox_autoBUFF.Name = "checkBox_autoBUFF";
            this.checkBox_autoBUFF.Size = new System.Drawing.Size(120, 16);
            this.checkBox_autoBUFF.TabIndex = 6;
            this.checkBox_autoBUFF.Text = "关闭BUFF自动排序";
            this.checkBox_autoBUFF.UseVisualStyleBackColor = true;
            // 
            // checkBox_Breast
            // 
            this.checkBox_Breast.AutoSize = true;
            this.checkBox_Breast.Location = new System.Drawing.Point(12, 43);
            this.checkBox_Breast.Name = "checkBox_Breast";
            this.checkBox_Breast.Size = new System.Drawing.Size(96, 16);
            this.checkBox_Breast.TabIndex = 5;
            this.checkBox_Breast.Text = "开启乳摇功能";
            this.checkBox_Breast.UseVisualStyleBackColor = true;
            // 
            // checkBox_Six
            // 
            this.checkBox_Six.AutoSize = true;
            this.checkBox_Six.Location = new System.Drawing.Point(12, 20);
            this.checkBox_Six.Name = "checkBox_Six";
            this.checkBox_Six.Size = new System.Drawing.Size(120, 16);
            this.checkBox_Six.TabIndex = 4;
            this.checkBox_Six.Text = "开启六人伤害统计";
            this.checkBox_Six.UseVisualStyleBackColor = true;
            // 
            // groupBox_Step3
            // 
            this.groupBox_Step3.Controls.Add(this.button_save);
            this.groupBox_Step3.Controls.Add(this.button_Pack);
            this.groupBox_Step3.Location = new System.Drawing.Point(12, 240);
            this.groupBox_Step3.Name = "groupBox_Step3";
            this.groupBox_Step3.Size = new System.Drawing.Size(474, 48);
            this.groupBox_Step3.TabIndex = 5;
            this.groupBox_Step3.TabStop = false;
            this.groupBox_Step3.Text = "Step3 先保存后打包";
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(122, 11);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(99, 32);
            this.button_save.TabIndex = 2;
            this.button_save.Text = "保存修改";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // label_Now
            // 
            this.label_Now.AutoSize = true;
            this.label_Now.Location = new System.Drawing.Point(16, 303);
            this.label_Now.Name = "label_Now";
            this.label_Now.Size = new System.Drawing.Size(53, 12);
            this.label_Now.TabIndex = 7;
            this.label_Now.Text = "等待操作";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.linkLabel1.Location = new System.Drawing.Point(425, 303);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(53, 12);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "检查更新";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // cbGCD
            // 
            this.cbGCD.FormattingEnabled = true;
            this.cbGCD.Items.AddRange(new object[] {
            "100",
            "130",
            "150",
            "170",
            "190",
            "200",
            "210",
            "220",
            "230",
            "240",
            "250"});
            this.cbGCD.Location = new System.Drawing.Point(19, 74);
            this.cbGCD.Name = "cbGCD";
            this.cbGCD.Size = new System.Drawing.Size(64, 20);
            this.cbGCD.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(89, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "GCD";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(500, 332);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label_Now);
            this.Controls.Add(this.groupBox_Step3);
            this.Controls.Add(this.groupBox_Step2);
            this.Controls.Add(this.groupBox_Step1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "爱玖剑灵助手 175剑灵专用";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_Step1.ResumeLayout(false);
            this.groupBox_Step1.PerformLayout();
            this.groupBox_Step2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox_Step3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Unpack;
        private System.Windows.Forms.Button button_Pack;
        private System.Windows.Forms.GroupBox groupBox_Step1;
        private System.Windows.Forms.Button button_Open;
        private System.Windows.Forms.TextBox textBox_Path;
        private System.Windows.Forms.GroupBox groupBox_Step2;
        private System.Windows.Forms.CheckBox checkBox_Breast;
        private System.Windows.Forms.CheckBox checkBox_Six;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button_resetProfile;
        private System.Windows.Forms.GroupBox groupBox_Step3;
        private System.Windows.Forms.Label label_Now;
        private System.Windows.Forms.Button button_loadProfile;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.CheckBox checkBox_autoBUFF;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_fight;
        private System.Windows.Forms.CheckBox checkBox_backrun;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbGCD;
    }
}

