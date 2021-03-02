namespace Игра.Финал
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CloudDirection_Controller = new System.Windows.Forms.Timer(this.components);
            this.AngryDirection_Controller = new System.Windows.Forms.Timer(this.components);
            this.FruitGenerator = new System.Windows.Forms.Timer(this.components);
            this.PauseTimer = new System.Windows.Forms.Timer(this.components);
            this.FixPauseTimer = new System.Windows.Forms.Timer(this.components);
            this.Refresher = new System.Windows.Forms.Timer(this.components);
            this.NewGame_Button = new System.Windows.Forms.Button();
            this.Exit_Button = new System.Windows.Forms.Button();
            this.Settings_Button = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.FPS_Label = new System.Windows.Forms.Label();
            this.Info_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CloudDirection_Controller
            // 
            this.CloudDirection_Controller.Tick += new System.EventHandler(this.CloudDirection_Controller_Tick);
            // 
            // AngryDirection_Controller
            // 
            this.AngryDirection_Controller.Tick += new System.EventHandler(this.AngryDirection_Controller_Tick);
            // 
            // FruitGenerator
            // 
            this.FruitGenerator.Interval = 5000;
            this.FruitGenerator.Tick += new System.EventHandler(this.FruitGenerator_Tick);
            // 
            // PauseTimer
            // 
            this.PauseTimer.Interval = 1000;
            this.PauseTimer.Tick += new System.EventHandler(this.PauseTimer_Tick);
            // 
            // FixPauseTimer
            // 
            this.FixPauseTimer.Tick += new System.EventHandler(this.FixPauseTimer_Tick);
            // 
            // Refresher
            // 
            this.Refresher.Interval = 25;
            this.Refresher.Tick += new System.EventHandler(this.Refresher_Tick);
            // 
            // NewGame_Button
            // 
            this.NewGame_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NewGame_Button.BackColor = System.Drawing.Color.LightGray;
            this.NewGame_Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.NewGame_Button.FlatAppearance.BorderSize = 0;
            this.NewGame_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewGame_Button.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewGame_Button.Location = new System.Drawing.Point(422, 110);
            this.NewGame_Button.Name = "NewGame_Button";
            this.NewGame_Button.Size = new System.Drawing.Size(557, 102);
            this.NewGame_Button.TabIndex = 2;
            this.NewGame_Button.Text = "Новая игра";
            this.NewGame_Button.UseVisualStyleBackColor = false;
            this.NewGame_Button.Click += new System.EventHandler(this.NewGame_Click);
            // 
            // Exit_Button
            // 
            this.Exit_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Exit_Button.BackColor = System.Drawing.Color.LightGray;
            this.Exit_Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Exit_Button.FlatAppearance.BorderSize = 0;
            this.Exit_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold);
            this.Exit_Button.Location = new System.Drawing.Point(422, 591);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.Size = new System.Drawing.Size(557, 102);
            this.Exit_Button.TabIndex = 6;
            this.Exit_Button.Text = "Выйти";
            this.Exit_Button.UseVisualStyleBackColor = false;
            this.Exit_Button.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // Settings_Button
            // 
            this.Settings_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Settings_Button.BackColor = System.Drawing.Color.LightGray;
            this.Settings_Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Settings_Button.FlatAppearance.BorderSize = 0;
            this.Settings_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Settings_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold);
            this.Settings_Button.Location = new System.Drawing.Point(422, 429);
            this.Settings_Button.Name = "Settings_Button";
            this.Settings_Button.Size = new System.Drawing.Size(557, 102);
            this.Settings_Button.TabIndex = 10;
            this.Settings_Button.Text = "Настройки";
            this.Settings_Button.UseVisualStyleBackColor = false;
            this.Settings_Button.Click += new System.EventHandler(this.Settings_Button_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.FPSUpdater_Tick);
            // 
            // FPS_Label
            // 
            this.FPS_Label.AutoSize = true;
            this.FPS_Label.Location = new System.Drawing.Point(12, 9);
            this.FPS_Label.Name = "FPS_Label";
            this.FPS_Label.Size = new System.Drawing.Size(43, 20);
            this.FPS_Label.TabIndex = 8;
            this.FPS_Label.Text = "FPS";
            this.FPS_Label.Visible = false;
            // 
            // Info_Button
            // 
            this.Info_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Info_Button.BackColor = System.Drawing.Color.LightGray;
            this.Info_Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Info_Button.FlatAppearance.BorderSize = 0;
            this.Info_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Info_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold);
            this.Info_Button.Location = new System.Drawing.Point(422, 271);
            this.Info_Button.Name = "Info_Button";
            this.Info_Button.Size = new System.Drawing.Size(557, 102);
            this.Info_Button.TabIndex = 11;
            this.Info_Button.Text = "Справка";
            this.Info_Button.UseVisualStyleBackColor = false;
            this.Info_Button.Click += new System.EventHandler(this.Info_Button_Click);
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1540, 845);
            this.Controls.Add(this.Info_Button);
            this.Controls.Add(this.Settings_Button);
            this.Controls.Add(this.FPS_Label);
            this.Controls.Add(this.Exit_Button);
            this.Controls.Add(this.NewGame_Button);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Try to Catch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResizeBegin += new System.EventHandler(this.Form1_ResizeBegin);
            this.LocationChanged += new System.EventHandler(this.Form1_LocationChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer CloudDirection_Controller;
        private System.Windows.Forms.Timer AngryDirection_Controller;
        private System.Windows.Forms.Timer FruitGenerator;
        private System.Windows.Forms.Timer PauseTimer;
        private System.Windows.Forms.Timer FixPauseTimer;
        private System.Windows.Forms.Timer Refresher;
        private System.Windows.Forms.Button NewGame_Button;
        private System.Windows.Forms.Button Exit_Button;
        private System.Windows.Forms.Button Settings_Button;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label FPS_Label;
        private System.Windows.Forms.Button Info_Button;
    }
}

