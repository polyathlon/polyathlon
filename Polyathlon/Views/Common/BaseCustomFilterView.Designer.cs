namespace Polyathlon.Views
{
    partial class BaseCustomFilterView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.tileBar = new DevExpress.XtraBars.Navigation.TileBar();
            this.tileBarGroup2 = new DevExpress.XtraBars.Navigation.TileBarGroup();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            this.SuspendLayout();
            
            
            
            this.mvvmContext.ContainerControl = this;
            
            
            
            this.tileBar.AllowDrag = false;
            this.tileBar.AllowSelectedItem = true;
            this.tileBar.AppearanceGroupText.ForeColor = System.Drawing.Color.White;
            this.tileBar.AppearanceGroupText.Options.UseForeColor = true;
            this.tileBar.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(209)))), ((int)(((byte)(255)))));
            this.tileBar.AppearanceItem.Hovered.ForeColor = System.Drawing.Color.Black;
            this.tileBar.AppearanceItem.Hovered.Options.UseBackColor = true;
            this.tileBar.AppearanceItem.Hovered.Options.UseForeColor = true;
            this.tileBar.AppearanceItem.Normal.BackColor = System.Drawing.Color.White;
            this.tileBar.AppearanceItem.Normal.ForeColor = System.Drawing.Color.Black;
            this.tileBar.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileBar.AppearanceItem.Normal.Options.UseForeColor = true;
            this.tileBar.AppearanceItem.Pressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(149)))), ((int)(((byte)(201)))));
            this.tileBar.AppearanceItem.Pressed.Options.UseBackColor = true;
            this.tileBar.AppearanceItem.Selected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(163)))), ((int)(((byte)(217)))));
            this.tileBar.AppearanceItem.Selected.ForeColor = System.Drawing.Color.White;
            this.tileBar.AppearanceItem.Selected.Options.UseBackColor = true;
            this.tileBar.AppearanceItem.Selected.Options.UseForeColor = true;
            this.tileBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileBar.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileBar.Groups.Add(this.tileBarGroup2);
            this.tileBar.IndentBetweenGroups = 0;
            this.tileBar.ItemSize = 40;
            this.tileBar.Location = new System.Drawing.Point(0, 0);
            this.tileBar.MaxId = 2;
            this.tileBar.Name = "tileBar";
            this.tileBar.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            this.tileBar.Size = new System.Drawing.Size(533, 349);
            this.tileBar.TabIndex = 0;
            this.tileBar.Text = "tileBar1";
            
            
            
            this.tileBarGroup2.Name = "tileBarGroup2";
            
            
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tileBar);
            this.Name = "BaseCustomFilterView";
            this.Size = new System.Drawing.Size(533, 349);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.XtraBars.Navigation.TileBar tileBar;
        private DevExpress.XtraBars.Navigation.TileBarGroup tileBarGroup2;
    }
}
