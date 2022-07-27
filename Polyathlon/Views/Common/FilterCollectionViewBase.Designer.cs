namespace Polyathlon.Views
{
    partial class FilterCollectionViewBase
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
            this.labelControl = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl.Panel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl.Panel2)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // windowsUIButtonPanel
            // 
            this.windowsUIButtonPanel.AppearanceButton.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.windowsUIButtonPanel.AppearanceButton.Hovered.FontSizeDelta = -1;
            this.windowsUIButtonPanel.AppearanceButton.Hovered.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.windowsUIButtonPanel.AppearanceButton.Hovered.Options.UseBackColor = true;
            this.windowsUIButtonPanel.AppearanceButton.Hovered.Options.UseFont = true;
            this.windowsUIButtonPanel.AppearanceButton.Hovered.Options.UseForeColor = true;
            this.windowsUIButtonPanel.AppearanceButton.Normal.FontSizeDelta = -1;
            this.windowsUIButtonPanel.AppearanceButton.Normal.Options.UseFont = true;
            this.windowsUIButtonPanel.AppearanceButton.Pressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.windowsUIButtonPanel.AppearanceButton.Pressed.FontSizeDelta = -1;
            this.windowsUIButtonPanel.AppearanceButton.Pressed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.windowsUIButtonPanel.AppearanceButton.Pressed.Options.UseBackColor = true;
            this.windowsUIButtonPanel.AppearanceButton.Pressed.Options.UseFont = true;
            this.windowsUIButtonPanel.AppearanceButton.Pressed.Options.UseForeColor = true;
            this.windowsUIButtonPanel.Location = new System.Drawing.Point(0, 991);
            this.windowsUIButtonPanel.Margin = new System.Windows.Forms.Padding(8);
            this.windowsUIButtonPanel.PeekFormOptions.Size = new System.Drawing.Size(312, 406);
            this.windowsUIButtonPanel.Size = new System.Drawing.Size(1625, 171);
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            // 
            // labelControl
            // 
            this.labelControl.AllowHtmlString = true;
            this.labelControl.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelControl.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.labelControl.Appearance.Options.UseFont = true;
            this.labelControl.Appearance.Options.UseForeColor = true;
            this.labelControl.Appearance.Options.UseTextOptions = true;
            this.labelControl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl.Location = new System.Drawing.Point(0, 0);
            this.labelControl.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl.Name = "labelControl";
            this.labelControl.Size = new System.Drawing.Size(1625, 32);
            this.labelControl.TabIndex = 6;
            this.labelControl.Text = "CAPTION";
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel1;
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.IsSplitterFixed = true;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 32);
            this.splitContainerControl.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.splitContainerControl.Name = "splitContainerControl";
            // 
            // splitContainerControl.Panel1
            // 
            this.splitContainerControl.Panel1.MinSize = 246;
            this.splitContainerControl.Panel1.Text = "Panel1";
            // 
            // splitContainerControl.Panel2
            // 
            this.splitContainerControl.Panel2.Text = "Panel2";
            this.splitContainerControl.Size = new System.Drawing.Size(1625, 959);
            this.splitContainerControl.SplitterPosition = 125;
            this.splitContainerControl.TabIndex = 7;
            this.splitContainerControl.Text = "splitContainerControl1";
            // 
            // FilterCollectionViewBase
            // 
            this.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl);
            this.Controls.Add(this.labelControl);
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "FilterCollectionViewBase";
            this.Size = new System.Drawing.Size(1625, 1162);
            this.Controls.SetChildIndex(this.windowsUIButtonPanel, 0);
            this.Controls.SetChildIndex(this.labelControl, 0);
            this.Controls.SetChildIndex(this.splitContainerControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl.Panel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        protected DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        protected DevExpress.XtraEditors.LabelControl labelControl;
    }
}
