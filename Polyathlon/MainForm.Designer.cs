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
            this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.tileNavSubItem1 = new DevExpress.XtraBars.Navigation.TileNavSubItem();
            this.tileBar = new DevExpress.XtraBars.Navigation.TileBar();
            this.navigationFrame = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel
            // 
            this.defaultLookAndFeel.LookAndFeel.SkinName = "The Bezier";
            // 
            // tileNavSubItem1
            // 
            this.tileNavSubItem1.Caption = "tileNavSubItem1";
            this.tileNavSubItem1.Name = "tileNavSubItem1";
            // 
            // 
            // 
            this.tileNavSubItem1.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement1.Text = "tileNavSubItem1";
            this.tileNavSubItem1.Tile.Elements.Add(tileItemElement1);
            this.tileNavSubItem1.Tile.Name = "tileBarItem5";
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
            this.tileBar.IndentBetweenGroups = 28;
            this.tileBar.IndentBetweenItems = 28;
            this.tileBar.ItemImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Squeeze;
            this.tileBar.ItemPadding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.tileBar.ItemSize = 100;
            this.tileBar.Location = new System.Drawing.Point(0, 0);
            this.tileBar.MaxId = 4;
            this.tileBar.Name = "tileBar";
            this.tileBar.Padding = new System.Windows.Forms.Padding(22, 7, 22, 20);
            this.tileBar.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            this.tileBar.SelectionBorderWidth = 2;
            this.tileBar.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.tileBar.SelectionColorMode = DevExpress.XtraBars.Navigation.SelectionColorMode.UseItemBackColor;
            this.tileBar.ShowGroupText = false;
            this.tileBar.Size = new System.Drawing.Size(971, 120);
            this.tileBar.TabIndex = 0;
            this.tileBar.Text = "tileBar";
            this.tileBar.VerticalContentAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.tileBar.WideTileWidth = 200;
            // 
            // navigationFrame
            // 
            this.navigationFrame.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.navigationFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationFrame.Location = new System.Drawing.Point(0, 120);
            this.navigationFrame.Margin = new System.Windows.Forms.Padding(10, 16, 10, 16);
            this.navigationFrame.Name = "navigationFrame";
            this.navigationFrame.SelectedPage = null;
            this.navigationFrame.Size = new System.Drawing.Size(971, 413);
            this.navigationFrame.TabIndex = 2;
            this.navigationFrame.Text = "navigationFrame1";
            this.navigationFrame.TransitionAnimationProperties.FrameInterval = 5000;
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(Polyathlon.ViewModels.PolyathlonViewModel);
            // 
            // MainForm
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 533);
            this.Controls.Add(this.navigationFrame);
            this.Controls.Add(this.tileBar);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Полиатлон 2022";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Navigation.TileBar tileBar;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        public DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel;
        private DevExpress.XtraBars.Navigation.TileNavSubItem tileNavSubItem1;
    }
}