namespace Polyathlon
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.tileNavPane = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.tileBar = new DevExpress.XtraBars.Navigation.TileBar();
            this.tileBarGroup2 = new DevExpress.XtraBars.Navigation.TileBarGroup();
            this.tileBarItem1 = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.tileBarItem2 = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.tileBarItem3 = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.navigationFrame = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.button1 = new System.Windows.Forms.Button();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.couchServer1 = new Polyathlon.MyCouchDB.CouchServer(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tileNavPane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "The Bezier";
            // 
            // tileNavPane
            // 
            this.tileNavPane.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.tileNavPane.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tileNavPane.Appearance.Options.UseBackColor = true;
            this.tileNavPane.Appearance.Options.UseFont = true;
            this.tileNavPane.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(212)))), ((int)(((byte)(219)))));
            this.tileNavPane.AppearanceHovered.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tileNavPane.AppearanceHovered.Options.UseBackColor = true;
            this.tileNavPane.AppearanceHovered.Options.UseFont = true;
            this.tileNavPane.AppearanceSelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(212)))), ((int)(((byte)(219)))));
            this.tileNavPane.AppearanceSelected.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tileNavPane.AppearanceSelected.Options.UseBackColor = true;
            this.tileNavPane.AppearanceSelected.Options.UseFont = true;
            this.tileNavPane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            // 
            // tileNavCategory1
            // 
            this.tileNavPane.DefaultCategory.Name = "tileNavCategory1";
            // 
            // 
            // 
            this.tileNavPane.DefaultCategory.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileNavPane.Dock = System.Windows.Forms.DockStyle.Top;
            this.tileNavPane.Location = new System.Drawing.Point(0, 0);
            this.tileNavPane.Name = "tileNavPane";
            this.tileNavPane.Size = new System.Drawing.Size(2752, 128);
            this.tileNavPane.TabIndex = 0;
            this.tileNavPane.Text = "tileNavPane1";
            // 
            // tileBar
            // 
            this.tileBar.AppearanceGroupText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tileBar.AppearanceGroupText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.tileBar.AppearanceGroupText.Options.UseFont = true;
            this.tileBar.AppearanceGroupText.Options.UseForeColor = true;
            this.tileBar.AppearanceItem.Normal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tileBar.AppearanceItem.Normal.Options.UseFont = true;
            this.tileBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.tileBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.tileBar.DropDownButtonWidth = 30;
            this.tileBar.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileBar.Groups.Add(this.tileBarGroup2);
            this.tileBar.IndentBetweenGroups = 28;
            this.tileBar.IndentBetweenItems = 28;
            this.tileBar.ItemImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Squeeze;
            this.tileBar.ItemPadding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.tileBar.ItemSize = 100;
            this.tileBar.Location = new System.Drawing.Point(0, 128);
            this.tileBar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tileBar.MaxId = 4;
            this.tileBar.Name = "tileBar";
            this.tileBar.Padding = new System.Windows.Forms.Padding(45, 14, 45, 40);
            this.tileBar.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            this.tileBar.SelectionBorderWidth = 2;
            this.tileBar.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.tileBar.SelectionColorMode = DevExpress.XtraBars.Navigation.SelectionColorMode.UseItemBackColor;
            this.tileBar.ShowGroupText = false;
            this.tileBar.Size = new System.Drawing.Size(2752, 240);
            this.tileBar.TabIndex = 0;
            this.tileBar.Text = "tileBar";
            this.tileBar.VerticalContentAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.tileBar.WideTileWidth = 200;
            this.tileBar.Click += new System.EventHandler(this.tileBar_Click);
            // 
            // tileBarGroup2
            // 
            this.tileBarGroup2.Items.Add(this.tileBarItem1);
            this.tileBarGroup2.Items.Add(this.tileBarItem2);
            this.tileBarGroup2.Items.Add(this.tileBarItem3);
            this.tileBarGroup2.Name = "tileBarGroup2";
            this.tileBarGroup2.Text = "Регионы";
            // 
            // tileBarItem1
            // 
            this.tileBarItem1.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.tileBarItem1.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement1.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tileItemElement1.Appearance.Normal.Options.UseFont = true;
            tileItemElement1.ImageOptions.ImageUri.Uri = "hybriddemo_dashboard;Svg";
            tileItemElement1.Text = "Регион";
            this.tileBarItem1.Elements.Add(tileItemElement1);
            this.tileBarItem1.Id = 0;
            this.tileBarItem1.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tileBarItem1.Name = "tileBarItem1";
            this.tileBarItem1.ShowDropDownButton = DevExpress.Utils.DefaultBoolean.False;
            this.tileBarItem1.ShowItemShadow = DevExpress.Utils.DefaultBoolean.False;
            // 
            // tileBarItem2
            // 
            this.tileBarItem2.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.tileBarItem2.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement2.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tileItemElement2.Appearance.Normal.Options.UseFont = true;
            tileItemElement2.ImageOptions.ImageUri.Uri = "arrows/next;Svg";
            tileItemElement2.Text = "Регион";
            this.tileBarItem2.Elements.Add(tileItemElement2);
            this.tileBarItem2.Id = 2;
            this.tileBarItem2.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tileBarItem2.Name = "tileBarItem2";
            // 
            // tileBarItem3
            // 
            this.tileBarItem3.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.tileBarItem3.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.tileBarItem3.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement3.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tileItemElement3.Appearance.Normal.Options.UseFont = true;
            tileItemElement3.ImageOptions.ImageSize = new System.Drawing.Size(40, 40);
            tileItemElement3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("resource.SvgImage")));
            tileItemElement3.Text = "Регион";
            this.tileBarItem3.Elements.Add(tileItemElement3);
            this.tileBarItem3.Id = 3;
            this.tileBarItem3.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tileBarItem3.Name = "tileBarItem3";
            // 
            // navigationFrame
            // 
            this.navigationFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationFrame.Location = new System.Drawing.Point(0, 368);
            this.navigationFrame.Margin = new System.Windows.Forms.Padding(19, 32, 19, 32);
            this.navigationFrame.Name = "navigationFrame";
            this.navigationFrame.SelectedPage = null;
            this.navigationFrame.Size = new System.Drawing.Size(2752, 702);
            this.navigationFrame.TabIndex = 2;
            this.navigationFrame.Text = "navigationFrame1";
            this.navigationFrame.TransitionAnimationProperties.FrameInterval = 5000;
            this.navigationFrame.Click += new System.EventHandler(this.navigationFrame1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(296, 24);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 61);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(558, 29);
            this.button2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 61);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // couchServer1
            // 
            this.couchServer1.Password = "";
            this.couchServer1.Uri = new System.Uri("https://localhost:5984/", System.UriKind.Absolute);
            this.couchServer1.UserName = "";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(829, 29);
            this.button3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 61);
            this.button3.TabIndex = 4;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1128, 29);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(196, 47);
            this.textBox1.TabIndex = 5;
            // 
            // MainForm
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 40F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2752, 1070);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.navigationFrame);
            this.Controls.Add(this.tileBar);
            this.Controls.Add(this.tileNavPane);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Полиатлон 2022";
            ((System.ComponentModel.ISupportInitialize)(this.tileNavPane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Navigation.TileNavPane tileNavPane;
        private DevExpress.XtraBars.Navigation.TileBar tileBar;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private Button button1;
        private Button button2;
        private MyCouchDB.CouchServer couchServer1;
        private Button button3;
        private TextBox textBox1;
        private DevExpress.XtraBars.Navigation.TileBarGroup tileBarGroup2;
        private DevExpress.XtraBars.Navigation.TileBarItem tileBarItem1;
        public DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.Navigation.TileBarItem tileBarItem2;
        private DevExpress.XtraBars.Navigation.TileBarItem tileBarItem3;
    }
}