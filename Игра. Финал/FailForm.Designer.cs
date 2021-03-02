namespace Игра.Финал
{
    partial class FailForm
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
            this.Info_Label = new System.Windows.Forms.Label();
            this.Restart_Button = new System.Windows.Forms.Button();
            this.GoToMainMenu_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Info_Label
            // 
            this.Info_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Info_Label.AutoSize = true;
            this.Info_Label.BackColor = System.Drawing.Color.Transparent;
            this.Info_Label.Location = new System.Drawing.Point(11, 8);
            this.Info_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Info_Label.Name = "Info_Label";
            this.Info_Label.Size = new System.Drawing.Size(56, 23);
            this.Info_Label.TabIndex = 0;
            this.Info_Label.Text = "label1";
            // 
            // Restart_Button
            // 
            this.Restart_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Restart_Button.BackColor = System.Drawing.Color.LightGray;
            this.Restart_Button.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Restart_Button.FlatAppearance.BorderSize = 0;
            this.Restart_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Restart_Button.Location = new System.Drawing.Point(11, 150);
            this.Restart_Button.Margin = new System.Windows.Forms.Padding(2);
            this.Restart_Button.Name = "Restart_Button";
            this.Restart_Button.Size = new System.Drawing.Size(172, 34);
            this.Restart_Button.TabIndex = 1;
            this.Restart_Button.Text = "Да, попробую";
            this.Restart_Button.UseVisualStyleBackColor = false;
            // 
            // GoToMainMenu_Button
            // 
            this.GoToMainMenu_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GoToMainMenu_Button.BackColor = System.Drawing.Color.LightGray;
            this.GoToMainMenu_Button.DialogResult = System.Windows.Forms.DialogResult.No;
            this.GoToMainMenu_Button.FlatAppearance.BorderSize = 0;
            this.GoToMainMenu_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GoToMainMenu_Button.Location = new System.Drawing.Point(196, 150);
            this.GoToMainMenu_Button.Margin = new System.Windows.Forms.Padding(2);
            this.GoToMainMenu_Button.Name = "GoToMainMenu_Button";
            this.GoToMainMenu_Button.Size = new System.Drawing.Size(172, 34);
            this.GoToMainMenu_Button.TabIndex = 2;
            this.GoToMainMenu_Button.Text = "Нет, выйти";
            this.GoToMainMenu_Button.UseVisualStyleBackColor = false;
            // 
            // FailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 195);
            this.Controls.Add(this.GoToMainMenu_Button);
            this.Controls.Add(this.Restart_Button);
            this.Controls.Add(this.Info_Label);
            this.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FailForm";
            this.Text = "Упс!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Restart_Button;
        private System.Windows.Forms.Button GoToMainMenu_Button;
        public System.Windows.Forms.Label Info_Label;
    }
}