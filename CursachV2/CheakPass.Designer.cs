namespace CursachV2
{
    partial class CheakPass
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
            this.label1 = new System.Windows.Forms.Label();
            this.InitPassTextBox = new System.Windows.Forms.TextBox();
            this.ShowChackBox = new System.Windows.Forms.CheckBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.Init = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Пароль:";
            // 
            // InitPassTextBox
            // 
            this.InitPassTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InitPassTextBox.Location = new System.Drawing.Point(78, 6);
            this.InitPassTextBox.Name = "InitPassTextBox";
            this.InitPassTextBox.Size = new System.Drawing.Size(100, 22);
            this.InitPassTextBox.TabIndex = 1;
            // 
            // ShowChackBox
            // 
            this.ShowChackBox.AutoSize = true;
            this.ShowChackBox.Location = new System.Drawing.Point(64, 34);
            this.ShowChackBox.Name = "ShowChackBox";
            this.ShowChackBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowChackBox.Size = new System.Drawing.Size(114, 17);
            this.ShowChackBox.TabIndex = 7;
            this.ShowChackBox.Text = "Показать пароль";
            this.ShowChackBox.UseVisualStyleBackColor = true;
            this.ShowChackBox.CheckedChanged += new System.EventHandler(this.ShowChackBox_CheckedChanged_1);
            // 
            // Cancel
            // 
            this.Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Cancel.Location = new System.Drawing.Point(12, 52);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 9;
            this.Cancel.Text = "Отмена";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Init
            // 
            this.Init.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Init.Location = new System.Drawing.Point(103, 52);
            this.Init.Name = "Init";
            this.Init.Size = new System.Drawing.Size(75, 23);
            this.Init.TabIndex = 8;
            this.Init.Text = "Ввод";
            this.Init.UseVisualStyleBackColor = true;
            this.Init.Click += new System.EventHandler(this.Init_Click);
            // 
            // CheakPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(191, 83);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Init);
            this.Controls.Add(this.ShowChackBox);
            this.Controls.Add(this.InitPassTextBox);
            this.Controls.Add(this.label1);
            this.Name = "CheakPass";
            this.Text = "CheakPass";
            this.Load += new System.EventHandler(this.CheakPass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InitPassTextBox;
        private System.Windows.Forms.CheckBox ShowChackBox;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Init;
    }
}