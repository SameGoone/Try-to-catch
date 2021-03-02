namespace Игра.Финал
{
    partial class SettingsForm
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
            this.Apply_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Complexity_Panel = new System.Windows.Forms.Panel();
            this.Complexity_ListBox = new System.Windows.Forms.ListBox();
            this.Mode_ListBox = new System.Windows.Forms.ListBox();
            this.Theme_ListBox = new System.Windows.Forms.ListBox();
            this.FullScreen_CheckBox = new System.Windows.Forms.CheckBox();
            this.ClearRegistry_Button = new System.Windows.Forms.Button();
            this.Complexity_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Apply_Button
            // 
            this.Apply_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Apply_Button.BackColor = System.Drawing.Color.LightGray;
            this.Apply_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Apply_Button.FlatAppearance.BorderSize = 0;
            this.Apply_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Apply_Button.Location = new System.Drawing.Point(8, 311);
            this.Apply_Button.Name = "Apply_Button";
            this.Apply_Button.Size = new System.Drawing.Size(158, 36);
            this.Apply_Button.TabIndex = 2;
            this.Apply_Button.Text = "Применить";
            this.Apply_Button.UseVisualStyleBackColor = false;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Button.BackColor = System.Drawing.Color.LightGray;
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.FlatAppearance.BorderSize = 0;
            this.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel_Button.Location = new System.Drawing.Point(195, 311);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(158, 36);
            this.Cancel_Button.TabIndex = 3;
            this.Cancel_Button.Text = "Отмена";
            this.Cancel_Button.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Режим:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Тема оформления:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "Сложность:";
            // 
            // Complexity_Panel
            // 
            this.Complexity_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Complexity_Panel.Controls.Add(this.Complexity_ListBox);
            this.Complexity_Panel.Controls.Add(this.label3);
            this.Complexity_Panel.Location = new System.Drawing.Point(185, 3);
            this.Complexity_Panel.Name = "Complexity_Panel";
            this.Complexity_Panel.Size = new System.Drawing.Size(175, 129);
            this.Complexity_Panel.TabIndex = 10;
            // 
            // Complexity_ListBox
            // 
            this.Complexity_ListBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Complexity_ListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Complexity_ListBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Complexity_ListBox.FormattingEnabled = true;
            this.Complexity_ListBox.ItemHeight = 23;
            this.Complexity_ListBox.Items.AddRange(new object[] {
            "Легко",
            "Нормально",
            "Хардкор"});
            this.Complexity_ListBox.Location = new System.Drawing.Point(10, 41);
            this.Complexity_ListBox.Name = "Complexity_ListBox";
            this.Complexity_ListBox.Size = new System.Drawing.Size(158, 69);
            this.Complexity_ListBox.TabIndex = 12;
            // 
            // Mode_ListBox
            // 
            this.Mode_ListBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Mode_ListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Mode_ListBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Mode_ListBox.FormattingEnabled = true;
            this.Mode_ListBox.ItemHeight = 23;
            this.Mode_ListBox.Items.AddRange(new object[] {
            "Бесконечный",
            "К Победе"});
            this.Mode_ListBox.Location = new System.Drawing.Point(8, 44);
            this.Mode_ListBox.Name = "Mode_ListBox";
            this.Mode_ListBox.Size = new System.Drawing.Size(158, 46);
            this.Mode_ListBox.TabIndex = 11;
            this.Mode_ListBox.SelectedIndexChanged += new System.EventHandler(this.Mode_ListBox_SelectedIndexChanged);
            // 
            // Theme_ListBox
            // 
            this.Theme_ListBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Theme_ListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Theme_ListBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Theme_ListBox.FormattingEnabled = true;
            this.Theme_ListBox.ItemHeight = 23;
            this.Theme_ListBox.Items.AddRange(new object[] {
            "Светлая",
            "Тёмная"});
            this.Theme_ListBox.Location = new System.Drawing.Point(8, 210);
            this.Theme_ListBox.Name = "Theme_ListBox";
            this.Theme_ListBox.Size = new System.Drawing.Size(158, 46);
            this.Theme_ListBox.TabIndex = 12;
            // 
            // FullScreen_CheckBox
            // 
            this.FullScreen_CheckBox.AutoSize = true;
            this.FullScreen_CheckBox.Location = new System.Drawing.Point(8, 262);
            this.FullScreen_CheckBox.Name = "FullScreen_CheckBox";
            this.FullScreen_CheckBox.Size = new System.Drawing.Size(124, 23);
            this.FullScreen_CheckBox.TabIndex = 13;
            this.FullScreen_CheckBox.Text = "На весь экран";
            this.FullScreen_CheckBox.UseVisualStyleBackColor = true;
            // 
            // ClearRegistry_Button
            // 
            this.ClearRegistry_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearRegistry_Button.BackColor = System.Drawing.Color.IndianRed;
            this.ClearRegistry_Button.FlatAppearance.BorderSize = 0;
            this.ClearRegistry_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearRegistry_Button.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearRegistry_Button.Location = new System.Drawing.Point(195, 225);
            this.ClearRegistry_Button.Name = "ClearRegistry_Button";
            this.ClearRegistry_Button.Size = new System.Drawing.Size(158, 30);
            this.ClearRegistry_Button.TabIndex = 14;
            this.ClearRegistry_Button.Tag = "DeleteButton";
            this.ClearRegistry_Button.Text = "Очистить реестр";
            this.ClearRegistry_Button.UseVisualStyleBackColor = false;
            this.ClearRegistry_Button.Click += new System.EventHandler(this.ClearRegistry_Button_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(360, 353);
            this.Controls.Add(this.ClearRegistry_Button);
            this.Controls.Add(this.FullScreen_CheckBox);
            this.Controls.Add(this.Theme_ListBox);
            this.Controls.Add(this.Mode_ListBox);
            this.Controls.Add(this.Complexity_Panel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Apply_Button);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingsForm";
            this.Text = "Настройки";
            this.Complexity_Panel.ResumeLayout(false);
            this.Complexity_Panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ListBox Complexity_ListBox;
        public System.Windows.Forms.ListBox Mode_ListBox;
        public System.Windows.Forms.ListBox Theme_ListBox;
        public System.Windows.Forms.Button Apply_Button;
        public System.Windows.Forms.Button Cancel_Button;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Panel Complexity_Panel;
        public System.Windows.Forms.Button ClearRegistry_Button;
        public System.Windows.Forms.CheckBox FullScreen_CheckBox;
    }
}