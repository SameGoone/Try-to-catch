namespace Игра.Финал
{
    partial class InfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Rules = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.HotKeys = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AboutMe = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.OK_Button = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.Rules.SuspendLayout();
            this.HotKeys.SuspendLayout();
            this.AboutMe.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.Rules);
            this.tabControl1.Controls.Add(this.HotKeys);
            this.tabControl1.Controls.Add(this.AboutMe);
            this.tabControl1.Location = new System.Drawing.Point(-2, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(475, 468);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 0;
            // 
            // Rules
            // 
            this.Rules.BackColor = System.Drawing.Color.Transparent;
            this.Rules.Controls.Add(this.label2);
            this.Rules.Location = new System.Drawing.Point(4, 28);
            this.Rules.Margin = new System.Windows.Forms.Padding(4);
            this.Rules.Name = "Rules";
            this.Rules.Padding = new System.Windows.Forms.Padding(4);
            this.Rules.Size = new System.Drawing.Size(467, 436);
            this.Rules.TabIndex = 0;
            this.Rules.Text = "Правила игры";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(7, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(435, 418);
            this.label2.TabIndex = 0;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // HotKeys
            // 
            this.HotKeys.BackColor = System.Drawing.Color.Transparent;
            this.HotKeys.Controls.Add(this.label4);
            this.HotKeys.Controls.Add(this.label1);
            this.HotKeys.Location = new System.Drawing.Point(4, 28);
            this.HotKeys.Margin = new System.Windows.Forms.Padding(4);
            this.HotKeys.Name = "HotKeys";
            this.HotKeys.Size = new System.Drawing.Size(467, 436);
            this.HotKeys.TabIndex = 2;
            this.HotKeys.Text = "Горячие клавиши";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(16, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 26);
            this.label4.TabIndex = 1;
            this.label4.Text = "Кнопки во время игры:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(17, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Пауза/Возобновить:        Пробел\r\nГлавное меню:                    Escape";
            // 
            // AboutMe
            // 
            this.AboutMe.BackColor = System.Drawing.Color.Transparent;
            this.AboutMe.Controls.Add(this.label3);
            this.AboutMe.Location = new System.Drawing.Point(4, 28);
            this.AboutMe.Margin = new System.Windows.Forms.Padding(4);
            this.AboutMe.Name = "AboutMe";
            this.AboutMe.Padding = new System.Windows.Forms.Padding(4);
            this.AboutMe.Size = new System.Drawing.Size(467, 436);
            this.AboutMe.TabIndex = 1;
            this.AboutMe.Text = "Об авторе";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(23, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 46);
            this.label3.TabIndex = 1;
            this.label3.Text = "Студент ПО-92б\r\nОвеченко Н. Р.";
            // 
            // OK_Button
            // 
            this.OK_Button.BackColor = System.Drawing.Color.LightGray;
            this.OK_Button.FlatAppearance.BorderSize = 0;
            this.OK_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK_Button.Location = new System.Drawing.Point(302, 473);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(163, 34);
            this.OK_Button.TabIndex = 1;
            this.OK_Button.Text = "Понятно";
            this.OK_Button.UseVisualStyleBackColor = false;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 514);
            this.Controls.Add(this.OK_Button);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InfoForm";
            this.Text = "Справка";
            this.tabControl1.ResumeLayout(false);
            this.Rules.ResumeLayout(false);
            this.Rules.PerformLayout();
            this.HotKeys.ResumeLayout(false);
            this.HotKeys.PerformLayout();
            this.AboutMe.ResumeLayout(false);
            this.AboutMe.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage Rules;
        private System.Windows.Forms.TabPage HotKeys;
        private System.Windows.Forms.TabPage AboutMe;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button OK_Button;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
    }
}