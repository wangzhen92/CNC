namespace CncProcess
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quiteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maxMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.streamMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.navBarItem3 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem4 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem5 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem6 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem9 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem8 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup3 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem7 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem10 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem12 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem11 = new DevExpress.XtraNavBar.NavBarItem();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.MaxItemId = 0;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1280, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 800);
            this.barDockControlBottom.Size = new System.Drawing.Size(1280, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 800);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1280, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 800);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.Peru;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quiteMenuItem,
            this.maxMenuItem,
            this.minMenuItem,
            this.streamMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1280, 36);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseDown);
            // 
            // quiteMenuItem
            // 
            this.quiteMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.quiteMenuItem.AutoSize = false;
            this.quiteMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.quiteMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.quiteMenuItem.ForeColor = System.Drawing.Color.Transparent;
            this.quiteMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("quiteMenuItem.Image")));
            this.quiteMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.quiteMenuItem.Margin = new System.Windows.Forms.Padding(5);
            this.quiteMenuItem.Name = "quiteMenuItem";
            this.quiteMenuItem.Size = new System.Drawing.Size(25, 25);
            this.quiteMenuItem.Text = " ";
            this.quiteMenuItem.Click += new System.EventHandler(this.quiteMenuItem_Click);
            // 
            // maxMenuItem
            // 
            this.maxMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.maxMenuItem.AutoSize = false;
            this.maxMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.maxMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.maxMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("maxMenuItem.Image")));
            this.maxMenuItem.Margin = new System.Windows.Forms.Padding(5);
            this.maxMenuItem.Name = "maxMenuItem";
            this.maxMenuItem.Size = new System.Drawing.Size(25, 25);
            this.maxMenuItem.Text = " ";
            this.maxMenuItem.Click += new System.EventHandler(this.maxMenuItem_Click);
            // 
            // minMenuItem
            // 
            this.minMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.minMenuItem.AutoSize = false;
            this.minMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.minMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.minMenuItem.ForeColor = System.Drawing.Color.Transparent;
            this.minMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("minMenuItem.Image")));
            this.minMenuItem.Margin = new System.Windows.Forms.Padding(5);
            this.minMenuItem.Name = "minMenuItem";
            this.minMenuItem.Size = new System.Drawing.Size(25, 25);
            this.minMenuItem.Text = " ";
            this.minMenuItem.Click += new System.EventHandler(this.minMenuItem_Click);
            // 
            // streamMenuItem
            // 
            this.streamMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.streamMenuItem.AutoSize = false;
            this.streamMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.streamMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.streamMenuItem.ForeColor = System.Drawing.Color.Transparent;
            this.streamMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("streamMenuItem.Image")));
            this.streamMenuItem.Margin = new System.Windows.Forms.Padding(5);
            this.streamMenuItem.Name = "streamMenuItem";
            this.streamMenuItem.Size = new System.Drawing.Size(25, 25);
            this.streamMenuItem.Text = " ";
            // 
            // navBarItem3
            // 
            this.navBarItem3.Caption = "CNC3";
            this.navBarItem3.Name = "navBarItem3";
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "CNC2";
            this.navBarItem2.Name = "navBarItem2";
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "CNC1";
            this.navBarItem1.Name = "navBarItem1";
            // 
            // navBarItem4
            // 
            this.navBarItem4.Caption = "CNC1";
            this.navBarItem4.Name = "navBarItem4";
            this.navBarItem4.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem4.SmallImage")));
            this.navBarItem4.Tag = "cnc1";
            // 
            // navBarItem5
            // 
            this.navBarItem5.Caption = "CNC2";
            this.navBarItem5.Name = "navBarItem5";
            this.navBarItem5.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem5.SmallImage")));
            this.navBarItem5.Tag = "cnc2";
            // 
            // navBarItem6
            // 
            this.navBarItem6.Caption = "CNC3";
            this.navBarItem6.Name = "navBarItem6";
            this.navBarItem6.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem6.SmallImage")));
            this.navBarItem6.Tag = "cnc3";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "设备管理";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem4),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem5),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem6)});
            this.navBarGroup1.Name = "navBarGroup1";
            this.navBarGroup1.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup1.SmallImage")));
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "系统设置";
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem9),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem8)});
            this.navBarGroup2.Name = "navBarGroup2";
            this.navBarGroup2.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup2.SmallImage")));
            // 
            // navBarItem9
            // 
            this.navBarItem9.Caption = "基本设置";
            this.navBarItem9.Name = "navBarItem9";
            this.navBarItem9.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem9.SmallImage")));
            // 
            // navBarItem8
            // 
            this.navBarItem8.Caption = "检查设置";
            this.navBarItem8.Name = "navBarItem8";
            this.navBarItem8.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem8.SmallImage")));
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Appearance.Item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(62)))));
            this.navBarControl1.Appearance.Item.Options.UseBackColor = true;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup3,
            this.navBarGroup2});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItem4,
            this.navBarItem5,
            this.navBarItem6,
            this.navBarItem7,
            this.navBarItem8,
            this.navBarItem9,
            this.navBarItem10,
            this.navBarItem11,
            this.navBarItem12});
            this.navBarControl1.Location = new System.Drawing.Point(0, 36);
            this.navBarControl1.Margin = new System.Windows.Forms.Padding(0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.NavigationPaneMaxVisibleGroups = 0;
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 167;
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl1.Size = new System.Drawing.Size(167, 728);
            this.navBarControl1.TabIndex = 9;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinNavigationPaneViewInfoRegistrator("DevExpress Dark Style");
            this.navBarControl1.LinkPressed += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarControl1_LinkPressed);
            // 
            // navBarGroup3
            // 
            this.navBarGroup3.Caption = "数据管理";
            this.navBarGroup3.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem7),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem10),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem12)});
            this.navBarGroup3.Name = "navBarGroup3";
            this.navBarGroup3.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup3.SmallImage")));
            // 
            // navBarItem7
            // 
            this.navBarItem7.Caption = "CNC1控制台";
            this.navBarItem7.Name = "navBarItem7";
            this.navBarItem7.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem7.SmallImage")));
            this.navBarItem7.Tag = "cnc1_control";
            // 
            // navBarItem10
            // 
            this.navBarItem10.Caption = "CNC2控制台";
            this.navBarItem10.Name = "navBarItem10";
            this.navBarItem10.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem10.SmallImage")));
            this.navBarItem10.Tag = "cnc2_control";
            // 
            // navBarItem12
            // 
            this.navBarItem12.Caption = "CNC3控制台";
            this.navBarItem12.Name = "navBarItem12";
            this.navBarItem12.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem12.SmallImage")));
            this.navBarItem12.Tag = "cnc3_control";
            // 
            // navBarItem11
            // 
            this.navBarItem11.Caption = "navBarItem11";
            this.navBarItem11.Name = "navBarItem11";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Peru;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 764);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 36);
            this.panel1.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(772, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.navBarControl1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quiteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maxMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minMenuItem;
        private System.Windows.Forms.ToolStripMenuItem streamMenuItem;
        private DevExpress.XtraNavBar.NavBarItem navBarItem3;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem4;
        private DevExpress.XtraNavBar.NavBarItem navBarItem5;
        private DevExpress.XtraNavBar.NavBarItem navBarItem6;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup3;
        private DevExpress.XtraNavBar.NavBarItem navBarItem7;
        private DevExpress.XtraNavBar.NavBarItem navBarItem10;
        private DevExpress.XtraNavBar.NavBarItem navBarItem12;
        private DevExpress.XtraNavBar.NavBarItem navBarItem9;
        private DevExpress.XtraNavBar.NavBarItem navBarItem8;
        private DevExpress.XtraNavBar.NavBarItem navBarItem11;
    }
}

