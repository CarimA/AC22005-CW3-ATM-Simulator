namespace ATM_Simulator.Forms
{
    partial class Control
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
            this.btnInstance = new System.Windows.Forms.Button();
            this.btnNewAccount = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInstance
            // 
            this.btnInstance.Location = new System.Drawing.Point(13, 13);
            this.btnInstance.Name = "btnInstance";
            this.btnInstance.Size = new System.Drawing.Size(178, 36);
            this.btnInstance.TabIndex = 0;
            this.btnInstance.Text = "Open new ATM instance";
            this.btnInstance.UseVisualStyleBackColor = true;
            this.btnInstance.Click += new System.EventHandler(this.btnInstance_Click);
            // 
            // btnNewAccount
            // 
            this.btnNewAccount.Location = new System.Drawing.Point(13, 55);
            this.btnNewAccount.Name = "btnNewAccount";
            this.btnNewAccount.Size = new System.Drawing.Size(178, 36);
            this.btnNewAccount.TabIndex = 2;
            this.btnNewAccount.Text = "Add new account";
            this.btnNewAccount.UseVisualStyleBackColor = true;
            this.btnNewAccount.Click += new System.EventHandler(this.btnNewAccount_Click);
            // 
            // Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 101);
            this.ControlBox = false;
            this.Controls.Add(this.btnNewAccount);
            this.Controls.Add(this.btnInstance);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Control";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Control";
            this.Load += new System.EventHandler(this.Control_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnInstance;
        public System.Windows.Forms.Button btnNewAccount;
    }
}