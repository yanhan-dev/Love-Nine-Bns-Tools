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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button_loadProfile = new System.Windows.Forms.Button();
            this.button_resetProfile = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox_Ping = new System.Windows.Forms.TextBox();
            this.radioButton_Input = new System.Windows.Forms.RadioButton();
            this.radioButton_Ping200 = new System.Windows.Forms.RadioButton();
            this.radioButton_Ping180 = new System.Windows.Forms.RadioButton();
            this.radioButton_Ping150 = new System.Windows.Forms.RadioButton();
            this.radioButton_Ping100 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox_autoBUFF = new System.Windows.Forms.CheckBox();
            this.checkBox_Breast = new System.Windows.Forms.CheckBox();
            this.checkBox_Six = new System.Windows.Forms.CheckBox();
            this.groupBox_Step3 = new System.Windows.Forms.GroupBox();
            this.button_save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_Now = new System.Windows.Forms.Label();
            this.groupBox_Step1.SuspendLayout();
            this.groupBox_Step2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
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
            this.groupBox_Step2.Controls.Add(this.groupBox6);
            this.groupBox_Step2.Controls.Add(this.groupBox5);
            this.groupBox_Step2.Controls.Add(this.groupBox3);
            this.groupBox_Step2.Location = new System.Drawing.Point(12, 73);
            this.groupBox_Step2.Name = "groupBox_Step2";
            this.groupBox_Step2.Size = new System.Drawing.Size(474, 163);
            this.groupBox_Step2.TabIndex = 3;
            this.groupBox_Step2.TabStop = false;
            this.groupBox_Step2.Text = "Step2";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button_loadProfile);
            this.groupBox6.Controls.Add(this.button_resetProfile);
            this.groupBox6.Location = new System.Drawing.Point(19, 16);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(116, 137);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "加载/恢复";
            // 
            // button_loadProfile
            // 
            this.button_loadProfile.Location = new System.Drawing.Point(15, 28);
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
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox_Ping);
            this.groupBox5.Controls.Add(this.radioButton_Input);
            this.groupBox5.Controls.Add(this.radioButton_Ping200);
            this.groupBox5.Controls.Add(this.radioButton_Ping180);
            this.groupBox5.Controls.Add(this.radioButton_Ping150);
            this.groupBox5.Controls.Add(this.radioButton_Ping100);
            this.groupBox5.Location = new System.Drawing.Point(305, 18);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(154, 137);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "GCD 修改区";
            // 
            // textBox_Ping
            // 
            this.textBox_Ping.AccessibleDescription = "";
            this.textBox_Ping.Font = new System.Drawing.Font("宋体", 8F);
            this.textBox_Ping.Location = new System.Drawing.Point(50, 105);
            this.textBox_Ping.MaxLength = 3;
            this.textBox_Ping.Multiline = true;
            this.textBox_Ping.Name = "textBox_Ping";
            this.textBox_Ping.Size = new System.Drawing.Size(58, 15);
            this.textBox_Ping.TabIndex = 16;
            this.textBox_Ping.Text = "自定义";
            this.textBox_Ping.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Ping.Click += new System.EventHandler(this.textBox_Ping_Click);
            // 
            // radioButton_Input
            // 
            this.radioButton_Input.AutoSize = true;
            this.radioButton_Input.Location = new System.Drawing.Point(30, 104);
            this.radioButton_Input.Name = "radioButton_Input";
            this.radioButton_Input.Size = new System.Drawing.Size(14, 13);
            this.radioButton_Input.TabIndex = 15;
            this.radioButton_Input.UseVisualStyleBackColor = true;
            this.radioButton_Input.Click += new System.EventHandler(this.radioButton_Input_Click);
            // 
            // radioButton_Ping200
            // 
            this.radioButton_Ping200.AutoSize = true;
            this.radioButton_Ping200.Location = new System.Drawing.Point(30, 83);
            this.radioButton_Ping200.Name = "radioButton_Ping200";
            this.radioButton_Ping200.Size = new System.Drawing.Size(83, 16);
            this.radioButton_Ping200.TabIndex = 14;
            this.radioButton_Ping200.Text = " 极速(200)";
            this.radioButton_Ping200.UseVisualStyleBackColor = true;
            this.radioButton_Ping200.CheckedChanged += new System.EventHandler(this.radioButton_Ping200_CheckedChanged);
            // 
            // radioButton_Ping180
            // 
            this.radioButton_Ping180.AutoSize = true;
            this.radioButton_Ping180.Location = new System.Drawing.Point(30, 62);
            this.radioButton_Ping180.Name = "radioButton_Ping180";
            this.radioButton_Ping180.Size = new System.Drawing.Size(83, 16);
            this.radioButton_Ping180.TabIndex = 13;
            this.radioButton_Ping180.Text = " 高速(180)";
            this.radioButton_Ping180.UseVisualStyleBackColor = true;
            this.radioButton_Ping180.CheckedChanged += new System.EventHandler(this.radioButton_Ping180_CheckedChanged);
            // 
            // radioButton_Ping150
            // 
            this.radioButton_Ping150.AutoSize = true;
            this.radioButton_Ping150.Location = new System.Drawing.Point(30, 41);
            this.radioButton_Ping150.Name = "radioButton_Ping150";
            this.radioButton_Ping150.Size = new System.Drawing.Size(83, 16);
            this.radioButton_Ping150.TabIndex = 12;
            this.radioButton_Ping150.Text = " 稳定(150)";
            this.radioButton_Ping150.UseVisualStyleBackColor = true;
            this.radioButton_Ping150.Click += new System.EventHandler(this.radioButton_Ping150_Click);
            // 
            // radioButton_Ping100
            // 
            this.radioButton_Ping100.AutoSize = true;
            this.radioButton_Ping100.Location = new System.Drawing.Point(30, 20);
            this.radioButton_Ping100.Name = "radioButton_Ping100";
            this.radioButton_Ping100.Size = new System.Drawing.Size(83, 16);
            this.radioButton_Ping100.TabIndex = 11;
            this.radioButton_Ping100.Text = " 默认(100)";
            this.radioButton_Ping100.UseVisualStyleBackColor = true;
            this.radioButton_Ping100.Click += new System.EventHandler(this.radioButton_Ping100_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox_autoBUFF);
            this.groupBox3.Controls.Add(this.checkBox_Breast);
            this.groupBox3.Controls.Add(this.checkBox_Six);
            this.groupBox3.Location = new System.Drawing.Point(151, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(138, 137);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "个性化修改区";
            // 
            // checkBox_autoBUFF
            // 
            this.checkBox_autoBUFF.AutoSize = true;
            this.checkBox_autoBUFF.Location = new System.Drawing.Point(12, 93);
            this.checkBox_autoBUFF.Name = "checkBox_autoBUFF";
            this.checkBox_autoBUFF.Size = new System.Drawing.Size(120, 16);
            this.checkBox_autoBUFF.TabIndex = 6;
            this.checkBox_autoBUFF.Text = "开启BUFF自动排序";
            this.checkBox_autoBUFF.UseVisualStyleBackColor = true;
            // 
            // checkBox_Breast
            // 
            this.checkBox_Breast.AutoSize = true;
            this.checkBox_Breast.Location = new System.Drawing.Point(12, 62);
            this.checkBox_Breast.Name = "checkBox_Breast";
            this.checkBox_Breast.Size = new System.Drawing.Size(72, 16);
            this.checkBox_Breast.TabIndex = 5;
            this.checkBox_Breast.Text = "开启摇乳";
            this.checkBox_Breast.UseVisualStyleBackColor = true;
            // 
            // checkBox_Six
            // 
            this.checkBox_Six.AutoSize = true;
            this.checkBox_Six.Location = new System.Drawing.Point(12, 32);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(432, 303);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "By:烟寒";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(500, 332);
            this.Controls.Add(this.label_Now);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox_Step3);
            this.Controls.Add(this.groupBox_Step2);
            this.Controls.Add(this.groupBox_Step1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "爱玖剑灵助手  2.0.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_Step1.ResumeLayout(false);
            this.groupBox_Step1.PerformLayout();
            this.groupBox_Step2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkBox_Breast;
        private System.Windows.Forms.CheckBox checkBox_Six;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button_resetProfile;
        private System.Windows.Forms.GroupBox groupBox_Step3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Now;
        private System.Windows.Forms.TextBox textBox_Ping;
        private System.Windows.Forms.RadioButton radioButton_Input;
        private System.Windows.Forms.RadioButton radioButton_Ping200;
        private System.Windows.Forms.RadioButton radioButton_Ping180;
        private System.Windows.Forms.RadioButton radioButton_Ping150;
        private System.Windows.Forms.RadioButton radioButton_Ping100;
        private System.Windows.Forms.Button button_loadProfile;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.CheckBox checkBox_autoBUFF;
    }
}

