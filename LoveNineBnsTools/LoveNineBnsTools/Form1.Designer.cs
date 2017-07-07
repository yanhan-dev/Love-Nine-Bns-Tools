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
            this.checkBox_JLG = new System.Windows.Forms.CheckBox();
            this.checkBox_autoBUFF = new System.Windows.Forms.CheckBox();
            this.checkBox_Breast = new System.Windows.Forms.CheckBox();
            this.checkBox_Six = new System.Windows.Forms.CheckBox();
            this.groupBox_Step3 = new System.Windows.Forms.GroupBox();
            this.button_save = new System.Windows.Forms.Button();
            this.label_Now = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
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
            this.button_Unpack.Location = new System.Drawing.Point(511, 21);
            this.button_Unpack.Margin = new System.Windows.Forms.Padding(4);
            this.button_Unpack.Name = "button_Unpack";
            this.button_Unpack.Size = new System.Drawing.Size(72, 31);
            this.button_Unpack.TabIndex = 0;
            this.button_Unpack.Text = "解包";
            this.button_Unpack.UseVisualStyleBackColor = true;
            this.button_Unpack.Click += new System.EventHandler(this.button_Unpack_Click);
            // 
            // button_Pack
            // 
            this.button_Pack.Location = new System.Drawing.Point(312, 14);
            this.button_Pack.Margin = new System.Windows.Forms.Padding(4);
            this.button_Pack.Name = "button_Pack";
            this.button_Pack.Size = new System.Drawing.Size(124, 40);
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
            this.groupBox_Step1.Location = new System.Drawing.Point(15, 21);
            this.groupBox_Step1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_Step1.Name = "groupBox_Step1";
            this.groupBox_Step1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_Step1.Size = new System.Drawing.Size(592, 62);
            this.groupBox_Step1.TabIndex = 2;
            this.groupBox_Step1.TabStop = false;
            this.groupBox_Step1.Text = "Step1 选中剑灵 xml.dat config.dat 目录";
            // 
            // button_Open
            // 
            this.button_Open.Location = new System.Drawing.Point(429, 21);
            this.button_Open.Margin = new System.Windows.Forms.Padding(4);
            this.button_Open.Name = "button_Open";
            this.button_Open.Size = new System.Drawing.Size(72, 31);
            this.button_Open.TabIndex = 2;
            this.button_Open.Text = "打开";
            this.button_Open.UseVisualStyleBackColor = true;
            this.button_Open.Click += new System.EventHandler(this.button_Open_Click);
            // 
            // textBox_Path
            // 
            this.textBox_Path.Location = new System.Drawing.Point(8, 24);
            this.textBox_Path.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Path.Name = "textBox_Path";
            this.textBox_Path.Size = new System.Drawing.Size(410, 25);
            this.textBox_Path.TabIndex = 1;
            // 
            // groupBox_Step2
            // 
            this.groupBox_Step2.Controls.Add(this.groupBox1);
            this.groupBox_Step2.Controls.Add(this.groupBox6);
            this.groupBox_Step2.Controls.Add(this.groupBox3);
            this.groupBox_Step2.Location = new System.Drawing.Point(15, 91);
            this.groupBox_Step2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_Step2.Name = "groupBox_Step2";
            this.groupBox_Step2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_Step2.Size = new System.Drawing.Size(592, 204);
            this.groupBox_Step2.TabIndex = 3;
            this.groupBox_Step2.TabStop = false;
            this.groupBox_Step2.Text = "Step2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_fight);
            this.groupBox1.Controls.Add(this.checkBox_backrun);
            this.groupBox1.Location = new System.Drawing.Point(398, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(165, 171);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "慎重修改区";
            // 
            // checkBox_fight
            // 
            this.checkBox_fight.AutoSize = true;
            this.checkBox_fight.ForeColor = System.Drawing.Color.Red;
            this.checkBox_fight.Location = new System.Drawing.Point(24, 64);
            this.checkBox_fight.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_fight.Name = "checkBox_fight";
            this.checkBox_fight.Size = new System.Drawing.Size(119, 19);
            this.checkBox_fight.TabIndex = 11;
            this.checkBox_fight.Text = "开启战斗加速";
            this.checkBox_fight.UseVisualStyleBackColor = true;
            // 
            // checkBox_backrun
            // 
            this.checkBox_backrun.AutoSize = true;
            this.checkBox_backrun.ForeColor = System.Drawing.Color.Red;
            this.checkBox_backrun.Location = new System.Drawing.Point(24, 33);
            this.checkBox_backrun.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_backrun.Name = "checkBox_backrun";
            this.checkBox_backrun.Size = new System.Drawing.Size(119, 19);
            this.checkBox_backrun.TabIndex = 10;
            this.checkBox_backrun.Text = "开启后退加速";
            this.checkBox_backrun.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button_loadProfile);
            this.groupBox6.Controls.Add(this.button_resetProfile);
            this.groupBox6.Location = new System.Drawing.Point(31, 20);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(145, 171);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "加载/恢复";
            // 
            // button_loadProfile
            // 
            this.button_loadProfile.Location = new System.Drawing.Point(19, 43);
            this.button_loadProfile.Margin = new System.Windows.Forms.Padding(4);
            this.button_loadProfile.Name = "button_loadProfile";
            this.button_loadProfile.Size = new System.Drawing.Size(109, 29);
            this.button_loadProfile.TabIndex = 1;
            this.button_loadProfile.Text = "加载当前配置";
            this.button_loadProfile.UseVisualStyleBackColor = true;
            this.button_loadProfile.Click += new System.EventHandler(this.button_loadProfile_Click);
            // 
            // button_resetProfile
            // 
            this.button_resetProfile.Location = new System.Drawing.Point(19, 104);
            this.button_resetProfile.Margin = new System.Windows.Forms.Padding(4);
            this.button_resetProfile.Name = "button_resetProfile";
            this.button_resetProfile.Size = new System.Drawing.Size(109, 29);
            this.button_resetProfile.TabIndex = 0;
            this.button_resetProfile.Text = "恢复默认配置";
            this.button_resetProfile.UseVisualStyleBackColor = true;
            this.button_resetProfile.Click += new System.EventHandler(this.button_resetProfile_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox_JLG);
            this.groupBox3.Controls.Add(this.checkBox_autoBUFF);
            this.groupBox3.Controls.Add(this.checkBox_Breast);
            this.groupBox3.Controls.Add(this.checkBox_Six);
            this.groupBox3.Location = new System.Drawing.Point(201, 20);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(172, 171);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "随意修改区";
            // 
            // checkBox_JLG
            // 
            this.checkBox_JLG.AutoSize = true;
            this.checkBox_JLG.Location = new System.Drawing.Point(15, 126);
            this.checkBox_JLG.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_JLG.Name = "checkBox_JLG";
            this.checkBox_JLG.Size = new System.Drawing.Size(134, 19);
            this.checkBox_JLG.TabIndex = 7;
            this.checkBox_JLG.Text = "开启聚灵阁加速";
            this.checkBox_JLG.UseVisualStyleBackColor = true;
            // 
            // checkBox_autoBUFF
            // 
            this.checkBox_autoBUFF.AutoSize = true;
            this.checkBox_autoBUFF.Location = new System.Drawing.Point(15, 95);
            this.checkBox_autoBUFF.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_autoBUFF.Name = "checkBox_autoBUFF";
            this.checkBox_autoBUFF.Size = new System.Drawing.Size(151, 19);
            this.checkBox_autoBUFF.TabIndex = 6;
            this.checkBox_autoBUFF.Text = "关闭BUFF自动排序";
            this.checkBox_autoBUFF.UseVisualStyleBackColor = true;
            // 
            // checkBox_Breast
            // 
            this.checkBox_Breast.AutoSize = true;
            this.checkBox_Breast.Location = new System.Drawing.Point(15, 64);
            this.checkBox_Breast.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_Breast.Name = "checkBox_Breast";
            this.checkBox_Breast.Size = new System.Drawing.Size(89, 19);
            this.checkBox_Breast.TabIndex = 5;
            this.checkBox_Breast.Text = "开启摇乳";
            this.checkBox_Breast.UseVisualStyleBackColor = true;
            // 
            // checkBox_Six
            // 
            this.checkBox_Six.AutoSize = true;
            this.checkBox_Six.Location = new System.Drawing.Point(15, 33);
            this.checkBox_Six.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_Six.Name = "checkBox_Six";
            this.checkBox_Six.Size = new System.Drawing.Size(149, 19);
            this.checkBox_Six.TabIndex = 4;
            this.checkBox_Six.Text = "开启六人伤害统计";
            this.checkBox_Six.UseVisualStyleBackColor = true;
            // 
            // groupBox_Step3
            // 
            this.groupBox_Step3.Controls.Add(this.button_save);
            this.groupBox_Step3.Controls.Add(this.button_Pack);
            this.groupBox_Step3.Location = new System.Drawing.Point(15, 300);
            this.groupBox_Step3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_Step3.Name = "groupBox_Step3";
            this.groupBox_Step3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_Step3.Size = new System.Drawing.Size(592, 60);
            this.groupBox_Step3.TabIndex = 5;
            this.groupBox_Step3.TabStop = false;
            this.groupBox_Step3.Text = "Step3 先保存后打包";
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(152, 14);
            this.button_save.Margin = new System.Windows.Forms.Padding(4);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(124, 40);
            this.button_save.TabIndex = 2;
            this.button_save.Text = "保存修改";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // label_Now
            // 
            this.label_Now.AutoSize = true;
            this.label_Now.Location = new System.Drawing.Point(20, 379);
            this.label_Now.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Now.Name = "label_Now";
            this.label_Now.Size = new System.Drawing.Size(67, 15);
            this.label_Now.TabIndex = 7;
            this.label_Now.Text = "等待操作";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.linkLabel1.Location = new System.Drawing.Point(531, 379);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(67, 15);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "检查更新";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(625, 415);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label_Now);
            this.Controls.Add(this.groupBox_Step3);
            this.Controls.Add(this.groupBox_Step2);
            this.Controls.Add(this.groupBox_Step1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "爱玖剑灵助手  2.2.0";
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
        private System.Windows.Forms.CheckBox checkBox_JLG;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

