namespace CursachV2
{
    partial class Password
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
            this.PsTextBox1 = new System.Windows.Forms.TextBox();
            this.PsTextBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Init = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.ShowChackBox = new System.Windows.Forms.CheckBox();
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
            // PsTextBox1
            // 
            this.PsTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PsTextBox1.Location = new System.Drawing.Point(109, 6);
            this.PsTextBox1.Name = "PsTextBox1";
            this.PsTextBox1.Size = new System.Drawing.Size(100, 22);
            this.PsTextBox1.TabIndex = 1;
            // 
            // PsTextBox2
            // 
            this.PsTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PsTextBox2.Location = new System.Drawing.Point(109, 34);
            this.PsTextBox2.Name = "PsTextBox2";
            this.PsTextBox2.Size = new System.Drawing.Size(100, 22);
            this.PsTextBox2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Потвердите:";
            // 
            // Init
            // 
            this.Init.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Init.Location = new System.Drawing.Point(134, 85);
            this.Init.Name = "Init";
            this.Init.Size = new System.Drawing.Size(75, 23);
            this.Init.TabIndex = 4;
            this.Init.Text = "Ввод";
            this.Init.UseVisualStyleBackColor = true;
            this.Init.Click += new System.EventHandler(this.Init_Click);
            // 
            // Cancel
            // 
            this.Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Cancel.Location = new System.Drawing.Point(15, 85);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 5;
            this.Cancel.Text = "Отмена";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // ShowChackBox
            // 
            this.ShowChackBox.AutoSize = true;
            this.ShowChackBox.Location = new System.Drawing.Point(95, 62);
            this.ShowChackBox.Name = "ShowChackBox";
            this.ShowChackBox.Size = new System.Drawing.Size(114, 17);
            this.ShowChackBox.TabIndex = 6;
            this.ShowChackBox.Text = "Показать пароль";
            this.ShowChackBox.UseVisualStyleBackColor = true;
            this.ShowChackBox.CheckedChanged += new System.EventHandler(this.ShowChackBox_CheckedChanged);
            // 
            // Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 115);
            this.Controls.Add(this.ShowChackBox);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Init);
            this.Controls.Add(this.PsTextBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PsTextBox1);
            this.Controls.Add(this.label1);
            this.Name = "Password";
            this.Text = "Password";
            this.Load += new System.EventHandler(this.Password_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PsTextBox1;
        private System.Windows.Forms.TextBox PsTextBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Init;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.CheckBox ShowChackBox;
    }
}