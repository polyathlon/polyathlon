namespace Polyathlon.Forms
{
    partial class DatabaseSettingsForm
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
            this.outputUserNameTextBox = new System.Windows.Forms.TextBox();
            this.outputPasswordTextBox = new System.Windows.Forms.TextBox();
            this.outputHostNameTextBox = new System.Windows.Forms.TextBox();
            this.outputPortTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // outputUserNameTextBox
            // 
            this.outputUserNameTextBox.Location = new System.Drawing.Point(40, 30);
            this.outputUserNameTextBox.Name = "outputUserNameTextBox";
            this.outputUserNameTextBox.Size = new System.Drawing.Size(100, 23);
            this.outputUserNameTextBox.TabIndex = 0;
            // 
            // outputPasswordTextBox
            // 
            this.outputPasswordTextBox.Location = new System.Drawing.Point(250, 30);
            this.outputPasswordTextBox.Name = "outputPasswordTextBox";
            this.outputPasswordTextBox.Size = new System.Drawing.Size(100, 23);
            this.outputPasswordTextBox.TabIndex = 1;
            // 
            // outputHostNameTextBox
            // 
            this.outputHostNameTextBox.Location = new System.Drawing.Point(40, 110);
            this.outputHostNameTextBox.Name = "outputHostNameTextBox";
            this.outputHostNameTextBox.Size = new System.Drawing.Size(100, 23);
            this.outputHostNameTextBox.TabIndex = 2;
            // 
            // outputPortTextBox
            // 
            this.outputPortTextBox.Location = new System.Drawing.Point(250, 110);
            this.outputPortTextBox.Name = "outputPortTextBox";
            this.outputPortTextBox.Size = new System.Drawing.Size(100, 23);
            this.outputPortTextBox.TabIndex = 3;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(150, 170);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(90, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "UserName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "HostName";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(250, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Port";
            // 
            // DatabaseSettingsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(402, 220);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.outputPortTextBox);
            this.Controls.Add(this.outputHostNameTextBox);
            this.Controls.Add(this.outputPasswordTextBox);
            this.Controls.Add(this.outputUserNameTextBox);
            this.Name = "DatabaseSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DatabaseSettingsForm";
            this.Load += new System.EventHandler(this.DatabaseSettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox outputUserNameTextBox;
        private TextBox outputPasswordTextBox;
        private TextBox outputHostNameTextBox;
        private TextBox outputPortTextBox;
        private Button saveButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}