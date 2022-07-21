namespace Polyathlon.Views
{
    partial class BaseFilterView
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
            this.filterTileControl = new DevExpress.XtraEditors.TileControl();
            this.tileGroup2 = new DevExpress.XtraEditors.TileGroup();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            this.SuspendLayout();
            
            
            
            this.filterTileControl.AllowDrag = false;
            this.filterTileControl.AllowGlyphSkinning = true;
            this.filterTileControl.AllowSelectedItem = true;
            this.filterTileControl.AppearanceItem.Normal.BackColor = System.Drawing.Color.White;
            this.filterTileControl.AppearanceItem.Normal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.filterTileControl.AppearanceItem.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.filterTileControl.AppearanceItem.Normal.Options.UseBackColor = true;
            this.filterTileControl.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.filterTileControl.AppearanceItem.Normal.Options.UseFont = true;
            this.filterTileControl.AppearanceItem.Normal.Options.UseForeColor = true;
            this.filterTileControl.AppearanceItem.Pressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(38)))), ((int)(((byte)(115)))));
            this.filterTileControl.AppearanceItem.Pressed.ForeColor = System.Drawing.Color.Gainsboro;
            this.filterTileControl.AppearanceItem.Pressed.Options.UseBackColor = true;
            this.filterTileControl.AppearanceItem.Pressed.Options.UseFont = true;
            this.filterTileControl.AppearanceItem.Pressed.Options.UseForeColor = true;
            this.filterTileControl.AppearanceItem.Selected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(81)))), ((int)(((byte)(165)))));
            this.filterTileControl.AppearanceItem.Selected.BorderColor = System.Drawing.Color.Transparent;
            this.filterTileControl.AppearanceItem.Selected.ForeColor = System.Drawing.Color.White;
            this.filterTileControl.AppearanceItem.Selected.Options.UseBackColor = true;
            this.filterTileControl.AppearanceItem.Selected.Options.UseBorderColor = true;
            this.filterTileControl.AppearanceItem.Selected.Options.UseFont = true;
            this.filterTileControl.AppearanceItem.Selected.Options.UseForeColor = true;
            this.filterTileControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterTileControl.DragSize = new System.Drawing.Size(0, 0);
            this.filterTileControl.Groups.Add(this.tileGroup2);
            this.filterTileControl.HorizontalContentAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.filterTileControl.IndentBetweenItems = 10;
            this.filterTileControl.ItemPadding = new System.Windows.Forms.Padding(7, 7, 7, 4);
            this.filterTileControl.ItemSize = 90;
            this.filterTileControl.Location = new System.Drawing.Point(0, 0);
            this.filterTileControl.Margin = new System.Windows.Forms.Padding(0);
            this.filterTileControl.Name = "filterTileControl";
            this.filterTileControl.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.filterTileControl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.filterTileControl.Size = new System.Drawing.Size(331, 266);
            this.filterTileControl.TabIndex = 2;
            this.filterTileControl.Text = "tileControl1";
            
            
            
            this.tileGroup2.Name = "tileGroup2";
            
            
            
            this.mvvmContext.ContainerControl = this;
            
            
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.filterTileControl);
            this.Name = "BaseFilterView";
            this.Size = new System.Drawing.Size(331, 266);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraEditors.TileGroup tileGroup2;
        protected DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        protected DevExpress.XtraEditors.TileControl filterTileControl;
    }
}
