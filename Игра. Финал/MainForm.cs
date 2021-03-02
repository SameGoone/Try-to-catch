using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Игра.Финал.Properties;

namespace Игра.Финал
{
    public partial class MainForm : Form
    {
        private Bitmap _myTexture = myRes.PlayerRight,
            _angryTexture = angryRes.AngryRight_Stage1,
            _cloudTexture = anotherRes.Cloud300,
            _fruitTexture = anotherRes.fruit2;
        private InfoForm _inForm;
        private SettingsForm _setForm;
        private FailForm _fForm;

        private Label InfoPause_Label = new Label(),
            СЧЕТ_Label = new Label(),
            Score_Label = new Label(),
            Victory_Label = new Label(),
            РекИлиЦель_Label = new Label(),
            MaxScore_Label = new Label();

        private string _oldRecordParameter = "Maximum score",
            _newRecordParameter = "Max score",
            _oldLastSettings = "Last Settings",
            _newLastSettings = "Last setts",
            _intervalParameter = "Interval";
        public static string
            Subkey = @"Software\Try To Catch";

        private struct MyDouble
        {
            public double X;
            public double Y;
        }
        private struct MyTextureStruct
        {
            public Bitmap Right;
            public Bitmap Left;
            public MyTextureStruct(Bitmap right, Bitmap left)
            {
                Right = right;
                Left = left;
            }
        }
        private MyTextureStruct _myTextureStruct = new MyTextureStruct(myRes.PlayerLeft, myRes.PlayerRight);
        private MyDouble _angryPosition,
            _angryDirection,
            _cloudPosition,
            _cloudDirection,
            _fruitPosition;

        Font _bigFont,
            _smallFont,
            _hugeFont;

        Point _mousePosition,
            _cursorSave,
            _recordLocation,
            _targetLocation;

        private double
            _kSpeed_Angry,
            _kSpeed_Cloud,
            _kResolution,
             _mySize_K,
            _deltaSpeedAngry,
            _deltaSpeedCloud;
        private byte _complexityType,
            _targetScore;
        private Size _cloudSize;
        private const int _myStartSize = 35;
        private int _mySize,
            _formWidth,
            _formHeight,
            _score = 0,
            _pauseFixCnt,
            _cntPause = 4,
            _fruitSize,
            _angrySize;
        bool _isGaming,
            _isHidden,
            _victory,
           _darkMode,
            _endlessMode,
            _startedJustNow,
            _itIsTheRecord;

        int _countFPS = 0,
            _fixFPS,
            _countFramesAnimation;
        int[] _directions = new int[] { -1, 1 };

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isGaming)
                PauseStart(null, e);
            if (MessageBox.Show("Вы хотите выйти из игры?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                File.Delete("cursor.cur");
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(Subkey, true))
                {
                    if (key.GetValue(_newLastSettings) == null)
                    {
                        string lastsetts = "towin 0 light full";
                        key?.SetValue(_newLastSettings, lastsetts);
                    }
                }
            }
            else
            {
                e.Cancel = true;
                if (_isGaming)
                    PauseStart(null, e);
            }
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_isGaming)
            {
                if (e.KeyChar == (char)Keys.Escape)
                {
                    PauseStart(sender, e);
                    var result = MessageBox.Show("Вы уверены, что хотите выйти в меню?", "Выход", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        GameOver();

                        Controls.Remove(InfoPause_Label);
                        Controls.Remove(Victory_Label);
                    }
                    else
                    {
                        PauseStart(sender, e);
                    }
                }
                else if (e.KeyChar == (char)Keys.Space)
                {
                    PauseStart(sender, e);
                }
            }
            else
                e.Handled = true;
        }
        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            if (this.Width == Screen.PrimaryScreen.Bounds.Width && this.Height == Screen.PrimaryScreen.Bounds.Height)
                Location = new Point(0, 0);
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            ResizeComponents();
        }
        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            if (_isGaming && Refresher.Enabled)
            {
                PauseStart(null, e);
            }
        }

        public MainForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            Initialization();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;


            if (Refresher.Enabled)
            {
                if (!FruitGenerator.Enabled && !_victory)
                {
                    g.DrawImage(_fruitTexture, new Rectangle((int)_fruitPosition.X - _fruitSize / 2, (int)_fruitPosition.Y - _fruitSize / 2, _fruitSize, _fruitSize));
                }

                g.DrawImage(_myTexture, new Rectangle(_mousePosition.X - _mySize / 2, _mousePosition.Y - _mySize / 2, _mySize, _mySize));
                g.DrawImage(_cloudTexture, new Rectangle((int)_cloudPosition.X - _cloudSize.Width / 2, (int)_cloudPosition.Y - _cloudSize.Height / 2, _cloudSize.Width, _cloudSize.Height));
                g.DrawImage(_angryTexture, new Rectangle((int)_angryPosition.X - _angrySize / 2, (int)_angryPosition.Y - _angrySize / 2, _angrySize, _angrySize));
            }
        }
        private void Refresher_Tick(object sender, EventArgs e)
        {
            _mousePosition = PointToClient(Cursor.Position);

            Refresh();
            CloudMove();
            AngryMove();

            if (Distance(_angryPosition.X, _angryPosition.Y, _mousePosition.X, _mousePosition.Y) < _angrySize / 2 + _mySize / 2
                && Refresher.Enabled && _pauseFixCnt == 10 && !_isHidden)
            {
                if (!_victory)
                {
                    FailEvent();
                }
                else
                {
                    Controls.Remove(Victory_Label);
                    GameOver();
                }
            }

            if (!_victory)
            {
                CheckFruit();

                if (_isHidden)
                {
                    if (_mousePosition.X - _angryPosition.X > 0)
                        _myTexture = myRes.PlayerIsHiddenLeft;
                    else
                        _myTexture = myRes.PlayerIsHiddenRight;
                }
                else
                {
                    if (_mousePosition.X - _angryPosition.X > 0)
                        _myTexture = myRes.PlayerLeft;
                    else
                        _myTexture = myRes.PlayerRight;
                }
            }
            else
            {
                if (_mousePosition.X - _angryPosition.X > 0)
                    _myTexture = myRes.PlayerVicrotyLeft;
                else
                    _myTexture = myRes.PlayerVicrotyRight;
            }

            _countFPS++;
        }
        private void CheckFruit()
        {
            if (!FruitGenerator.Enabled)
            {
                if (Distance(_fruitPosition.X, _fruitPosition.Y, _mousePosition.X, _mousePosition.Y) < _fruitSize + _mySize / 2
                 && _pauseFixCnt == 10)
                {
                    _score++;
                    Score_Label.Text = _score.ToString();
                    ComplexityIncrease();
                    if (!_endlessMode)
                    {
                        MySizeIncrease();

                        if (_score == _targetScore)
                        {
                            _victory = true;
                            _kSpeed_Angry = 1;
                            _kSpeed_Cloud = 1;
                            VictoryEvent();
                        }
                        else
                        {
                            FruitGenerator.Enabled = true;
                        }
                    }
                    else
                    {
                        FruitGenerator.Enabled = true;
                    }
                }
            }
        }
        private void Settings_Button_Click(object sender, EventArgs e)
        {
            _setForm = new SettingsForm(this);
            FillStartingWindow(_setForm);
            if (FormBorderStyle == FormBorderStyle.None)
            {
                _setForm.FullScreen_CheckBox.Checked = true;
            }
            else
            {
                _setForm.FullScreen_CheckBox.Checked = false;
            }
            _setForm.Theme_ListBox.SelectedIndex = _darkMode ? 1 : 0;
            _setForm.Mode_ListBox.SelectedIndex = _endlessMode ? 0 : 1;
            switch (_complexityType)
            {
                case 0: _setForm.Complexity_ListBox.SelectedIndex = 0; break;
                case 1: _setForm.Complexity_ListBox.SelectedIndex = 1; break;
                case 2: _setForm.Complexity_ListBox.SelectedIndex = 2; break;
            }

            if (_setForm.ShowDialog() == DialogResult.OK)
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(Subkey, true))
                {
                    string lastsetts;
                    if (_setForm.Mode_ListBox.SelectedIndex == 0)
                    {
                        lastsetts = "endless " + _setForm.Complexity_ListBox.SelectedIndex.ToString();
                    }
                    else
                    {
                        lastsetts = "towin " + _setForm.Complexity_ListBox.SelectedIndex.ToString();
                    }

                    if (_setForm.Theme_ListBox.SelectedIndex == 1)
                    {
                        lastsetts += " dark";
                    }
                    else
                    {
                        lastsetts += " light";
                    }

                    if (_setForm.FullScreen_CheckBox.Checked == true)
                    {
                        lastsetts += " full";
                    }
                    else
                    {
                        lastsetts += " windowed";
                    }
                    key.SetValue(_newLastSettings, lastsetts);
                }
                CheckSettingsInTheRegistry();
            }
        }
        private void Info_Button_Click(object sender, EventArgs e)
        {
            _inForm = new InfoForm();
            FillStartingWindow(_inForm);
            _inForm.ShowDialog();
        }
        private void FPSUpdater_Tick(object sender, EventArgs e)
        {
            FPS_Label.Text = $"FPS: {_countFPS} Интервал: {Refresher.Interval} {_fixFPS} {_startedJustNow}";
            if (Refresher.Enabled)
            {
                if (_countFPS > 35 && !_startedJustNow)
                {
                    Refresher.Interval++;
                }
                else if (_countFPS < 30 && !_startedJustNow && Refresher.Interval > 10)
                {
                    Refresher.Interval -= 5;
                }
                if (_startedJustNow)
                {
                    _fixFPS++;
                    if (_fixFPS >= 3)
                        _startedJustNow = false;
                }

                _countFPS = 0;
            }
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void NewGame_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void Initialization()
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(Subkey, true))
            {
                if (key.GetValue(_newRecordParameter) == null)
                {
                    if (key.GetValue(_oldRecordParameter) != null)
                    {
                        key.DeleteValue(_oldRecordParameter);
                    }
                }
                if (key.GetValue(_newLastSettings) == null)
                {
                    if (key.GetValue(_oldLastSettings) != null)
                    {
                        key.DeleteValue(_oldLastSettings);
                    }
                }
                if (key.GetValue(_intervalParameter) != null)
                {
                    Refresher.Interval = Convert.ToInt32(key.GetValue(_intervalParameter));
                }
            }
            CheckSettingsInTheRegistry();
            _isGaming = false;
            _formWidth = Screen.PrimaryScreen.Bounds.Width;
            _formHeight = Screen.PrimaryScreen.Bounds.Height;
            Width = _formWidth;
            Height = _formHeight;

            ResizeComponents();
            File.WriteAllBytes($"cursor.cur", Resources.myCursor);
        }
        private void CheckSettingsInTheRegistry()
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(Subkey))
            {
                if (key.GetValue(_newLastSettings) != null)
                {
                    string lastsetts = key.GetValue(_newLastSettings).ToString();
                    string[] settings = lastsetts.Split(' ');

                    _complexityType = Convert.ToByte(settings[1]);
                    switch (_complexityType)
                    {
                        case 0: _targetScore = 30; break;
                        case 1: _targetScore = 70; break;
                        case 2: _targetScore = 100; break;
                    }
                    if (settings[0] == "endless")
                    {
                        _endlessMode = true;
                        РекИлиЦель_Label.Text = "РЕКОРД:";
                        РекИлиЦель_Label.Location = _recordLocation;
                        MaxScore_Label.Text = GetRegistryRecord();
                    }
                    else
                    {
                        _endlessMode = false;
                        РекИлиЦель_Label.Text = "ЦЕЛЬ:";
                        РекИлиЦель_Label.Location = _targetLocation;
                        MaxScore_Label.Text = _targetScore.ToString();
                    }
                    if (settings[2] == "dark")
                    {
                        _darkMode = true;
                    }
                    else
                    {
                        _darkMode = false;
                    }
                    Recolor();
                    if (settings[3] == "full")
                    {
                        WindowState = FormWindowState.Normal;
                        FormBorderStyle = FormBorderStyle.None;
                        Location = new Point(0, 0);
                        Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                    }
                    else
                    {
                        FormBorderStyle = FormBorderStyle.Sizable;
                    }
                }
                else
                {
                    _endlessMode = false;
                    РекИлиЦель_Label.Text = "ЦЕЛЬ:";
                    РекИлиЦель_Label.Location = _targetLocation;
                    MaxScore_Label.Text = _targetScore.ToString();
                }
            }
        }
        private void VictoryEvent()
        {
            Victory_Label.ResizeControl(this, new Size(575, 162), new Point(670, 135), _hugeFont);
            Victory_Label.BackColor = Color.Transparent;
            Victory_Label.ForeColor = СЧЕТ_Label.ForeColor;
            Victory_Label.Text = "ПОБЕДА! \n FINISH HIM";
            Controls.Add(Victory_Label);
        }
        private void FailEvent()
        {
            Refresher.Enabled = false;
            _fForm = new FailForm();
            FillStartingWindow(_fForm);

            if (_endlessMode)
            {
                RememberMaxScores();
                _fForm.Info_Label.Text = $"Ваш счет: {_score}\n";
                _fForm.Info_Label.Text += _itIsTheRecord ? "Это новый рекорд, поздравляем!\n\n" :
                    $"Ваш рекорд: {MaxScore_Label.Text}\n\n";
                _fForm.Info_Label.Text += "Хотите попробовать еще раз?";
            }
            else
            {
                _fForm.Info_Label.Text = "Вы проиграли :(\n";
                _fForm.Info_Label.Text += $"Ваш счёт: {_score}\nДо победы оставалось: {_targetScore - _score}\n\nХотите попробовать еще раз?";
            }

            if (_fForm.ShowDialog() == DialogResult.Yes)
            {
                StartGame();
            }
            else
            {
                GameOver();
            }
        }
        private void PauseTimer_Tick(object sender, EventArgs e)
        {
            _cntPause--;
            InfoPause_Label.Text = "Старт  через:   " + _cntPause.ToString();
            if (_cntPause == 0)
            {
                _mousePosition = _cursorSave;
                _pauseFixCnt = 0;
                _cntPause = 4;
                Controls.Remove(InfoPause_Label);
                PauseTimer.Enabled = false;
                Refresher.Enabled = true;
                FixPauseTimer.Enabled = true;
                _pauseFixCnt = 0;
            }
        }
        private void PauseStart(object sender, EventArgs e)
        {
            if (!Refresher.Enabled)
            {
                PauseTimer.Enabled = true;
                PauseTimer_Tick(sender, e);
                _startedJustNow = true;
                _fixFPS = 0;
            }
            else
            {
                Refresher.Enabled = false;
                _pauseFixCnt = 0;
                _cursorSave = _mousePosition;
                Controls.Add(InfoPause_Label);
                InfoPause_Label.Text = "Игра  приостановлена";
            }
        }
        private void FixPauseTimer_Tick(object sender, EventArgs e)
        {
            if (_pauseFixCnt < 10)
            {
                _pauseFixCnt++;
            }
            else
            {
                FixPauseTimer.Enabled = false;
            }
        }

        private void CloudDirection_Controller_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            CloudDirection_Controller.Interval = 1000 * r.Next(2, 5);
            _cloudDirection.X = _directions[r.Next(0, 2)];
            _cloudDirection.Y = _directions[r.Next(0, 2)];
        }
        private void AngryDirection_Controller_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            _angryDirection.X = _directions[r.Next(0, 2)];
            _angryDirection.Y = _directions[r.Next(0, 2)];
            AngryDirection_Controller.Interval = 1000 * r.Next(2, 5);
        }
        private void FruitGenerator_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int fruit = r.Next(1, 7);

            switch (fruit)
            {
                case 1: _fruitTexture = anotherRes.fruit1; break;
                case 2: _fruitTexture = anotherRes.fruit2; break;
                case 3: _fruitTexture = anotherRes.fruit3; break;
                case 4: _fruitTexture = anotherRes.fruit4; break;
                case 5: _fruitTexture = anotherRes.fruit5; break;
                case 6: _fruitTexture = anotherRes.fruit6; break;
            }

            _fruitPosition.Y = r.Next((int)(Height * 0.093), Height - (int)(Height * 0.046));
            _fruitPosition.X = r.Next((int)(Width * 0.026), Width - (int)(Width * 0.026));
            FruitGenerator.Interval = 500 * (r.Next(1, 4));
            FruitGenerator.Enabled = false;
        }

        private double Distance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
        private double ElemVector_X(double x1, double y1, double x2, double y2)
        {
            double VectorPosition_X = x2 - x1,
            VectorPosition_Y = y2 - y1;
            double lnVector = Math.Sqrt(Math.Pow(VectorPosition_X, 2) + Math.Pow(VectorPosition_Y, 2));
            return (VectorPosition_X / lnVector);
        }
        private double ElemVector_Y(double x1, double y1, double x2, double y2)
        {
            double VectorPosition_X = x2 - x1,
            VectorPosition_Y = y2 - y1;
            double lnVector = Math.Sqrt(Math.Pow(VectorPosition_X, 2) + Math.Pow(VectorPosition_Y, 2));
            return (VectorPosition_Y / lnVector);
        }
        private void StartGame()
        {
            _mySize_K = (double)_myStartSize / 1920;
            _isGaming = true;
            _victory = false;
            Controls.Add(Score_Label);
            Controls.Add(СЧЕТ_Label);
            Controls.Add(РекИлиЦель_Label);
            Controls.Add(MaxScore_Label);
            MaxScore_Label.BringToFront();

            Controls.Remove(NewGame_Button);
            Controls.Remove(Info_Button);
            Controls.Remove(Exit_Button);
            Controls.Remove(Settings_Button);

            Random r = new Random();
            _cloudPosition.X = r.Next(_cloudSize.Width / 2 + 3, Width - _cloudSize.Width / 2 - 3);
            _cloudPosition.Y = r.Next(_cloudSize.Height / 2 + 3, Height - _cloudSize.Height / 2 - 3);
            _angryPosition.X = _mousePosition.X + 500;
            _angryPosition.Y = _mousePosition.Y + 500;
            if (!_endlessMode)
            {
                switch (_complexityType)
                {
                    case 0:
                        _kSpeed_Angry = 4;
                        _deltaSpeedAngry = 0.1;
                        _deltaSpeedCloud = 0;
                        _targetScore = 30; break;
                    case 1:
                        _kSpeed_Angry = 7;
                        _deltaSpeedAngry = 0.2;
                        _deltaSpeedCloud = 0.01;
                        _targetScore = 70; break;
                    case 2:
                        _kSpeed_Angry = 10;
                        _deltaSpeedAngry = 0.3;
                        _deltaSpeedCloud = 0.01;
                        _targetScore = 100; break;
                }
            }
            else
            {
                _kSpeed_Angry = 5;
                _deltaSpeedAngry = 0.1;
                _deltaSpeedCloud = 0.01;
            }

            _kSpeed_Cloud = 5;
            _pauseFixCnt = 0;
            _mySize = (int)(Width * _mySize_K);
            _pauseFixCnt = 0;
            FixPauseTimer.Enabled = true;

            if (File.Exists("cursor.cur"))
            {
                Cursor = new Cursor("cursor.cur");
            }
            else
            {
                File.WriteAllBytes($"cursor.cur", Resources.myCursor);
                Cursor = new Cursor("cursor.cur");
            }

            Refresher.Enabled = true;
            CloudDirection_Controller.Enabled = true;
            FruitGenerator.Enabled = true;
            timer1.Enabled = true;

            _score = 0;
            if (_score != 0)
            {
                for (int i = 1; i <= _score; i++)
                {
                    if (!_endlessMode)
                    {
                        MySizeIncrease();
                    }
                    ComplexityIncrease();
                }
            }
            Score_Label.Text = _score.ToString();

            _startedJustNow = true;
            _fixFPS = 0;
            ResizeComponents();
        }
        private void GameOver()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(Subkey, true))
            {
                key.SetValue("interval", Refresher.Interval);
            }

            Refresher.Enabled = false;
            CloudDirection_Controller.Enabled = false;
            AngryDirection_Controller.Enabled = false;
            FruitGenerator.Enabled = false;
            PauseTimer.Enabled = false;
            timer1.Enabled = false;

            _isGaming = false;

            Controls.Remove(Score_Label);
            Controls.Remove(СЧЕТ_Label);
            Controls.Remove(РекИлиЦель_Label);
            Controls.Remove(MaxScore_Label);

            Controls.Add(NewGame_Button);
            Controls.Add(Info_Button);
            Controls.Add(Exit_Button);
            Controls.Add(Settings_Button);

            Cursor = DefaultCursor;

            Refresh();
        }
        private void RememberMaxScores()
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(Subkey))
            {
                if (key.GetValue(_newRecordParameter) != null)
                {
                    if (Convert.ToInt32(key.GetValue(_newRecordParameter)) < _score)
                    {
                        _itIsTheRecord = true;
                        key.SetValue(_newRecordParameter, _score);
                        MaxScore_Label.Text = _score.ToString();
                    }
                    else
                    {
                        _itIsTheRecord = false;
                    }
                }
                else
                {
                    key.SetValue(_newRecordParameter, _score);
                    _itIsTheRecord = true;
                }
            }
        }
        private string GetRegistryRecord()
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(Subkey))
            {
                if (key.GetValue(_newRecordParameter) != null)
                    return key.GetValue(_newRecordParameter).ToString();
                else
                    return "нет";
            }
        }
        private void CloudMove()
        {
            _cloudPosition.X += _cloudDirection.X * _kSpeed_Cloud * _kResolution;
            _cloudPosition.Y += _cloudDirection.Y * _kSpeed_Cloud * _kResolution;

            if (_cloudPosition.X <= _cloudSize.Width / 2)
            {
                _cloudDirection.X = 1;
            }
            if (_cloudPosition.X >= Width - _cloudSize.Width / 2)
            {
                _cloudDirection.X = -1;
            }
            if (_cloudPosition.Y <= _cloudSize.Height / 2)
            {
                _cloudDirection.Y = 1;
            }
            if (_cloudPosition.Y >= Height - _cloudSize.Height / 2)
            {
                _cloudDirection.Y = -1;
            }
        }
        private void AngryMove()
        {
            if (!_victory)
            {
                if (Math.Abs(_cloudPosition.X - _mousePosition.X) > _cloudSize.Width / 2 + _mySize / 2 ||
                Math.Abs(_cloudPosition.Y - _mousePosition.Y) > _cloudSize.Height / 2 + _mySize / 2) // Игрок вне облака?
                {
                    _isHidden = false;
                    AngryAnimation();

                    AngryDirection_Controller.Enabled = false;
                    _angryDirection.X = ElemVector_X(_angryPosition.X, _angryPosition.Y, _mousePosition.X, _mousePosition.Y);
                    _angryDirection.Y = ElemVector_Y(_angryPosition.X, _angryPosition.Y, _mousePosition.X, _mousePosition.Y);

                    _angryPosition.X += _angryDirection.X * _kSpeed_Angry * _kResolution;
                    _angryPosition.Y += _angryDirection.Y * _kSpeed_Angry * _kResolution;
                }

                else
                {
                    _isHidden = true;
                    _angryTexture = _angryDirection.X > 0 ? angryRes.CalmRight : angryRes.CalmLeft; //текстура спокойной птицы (учитывая направление движения)

                    AngryDirection_Controller.Enabled = true;


                    if (_angryPosition.X <= _angrySize / 2 || _angryPosition.X >= Width - _angrySize / 2)
                    {
                        _angryDirection.X *= -1;
                    }
                    if (_angryPosition.Y <= _angrySize / 2 || _angryPosition.Y >= Height - _angrySize / 2)
                    {
                        _angryDirection.Y *= -1;
                    }

                    _angryPosition.X += _angryDirection.X * _kSpeed_Angry * _kResolution;
                    _angryPosition.Y += _angryDirection.Y * _kSpeed_Angry * _kResolution;
                }
            }
            else
            {
                if (_angryPosition.X > _angrySize / 2 &&
                    _angryPosition.X < Width - _angrySize / 2 &&
                    _angryPosition.Y > _angrySize / 2 &&
                    _angryPosition.Y < Height - _angrySize / 2)
                {

                    AngryDirection_Controller.Enabled = false;
                    _angryDirection.X = ElemVector_X(_angryPosition.X, _angryPosition.Y, _mousePosition.X, _mousePosition.Y);
                    _angryDirection.Y = ElemVector_Y(_angryPosition.X, _angryPosition.Y, _mousePosition.X, _mousePosition.Y);

                    _angryTexture = _angryPosition.X - _mousePosition.X > 0 ? angryRes.AngryVictoryLeft : angryRes.AngryVictoryRight;

                    _angryPosition.X -= _angryDirection.X * _kSpeed_Angry * _kResolution;
                    _angryPosition.Y -= _angryDirection.Y * _kSpeed_Angry * _kResolution;
                }
            }
        }
        private void AngryAnimation()
        {
            if (_countFramesAnimation < 10)
            {
                _angryTexture = _mousePosition.X - _angryPosition.X > 0 ? angryRes.AngryRight_Stage1 : angryRes.AngryLeft_Stage1; //анимация агрессивной птицы (учитывая направление движения)
                _countFramesAnimation++;
            }
            else
            {
                _angryTexture = _mousePosition.X - _angryPosition.X > 0 ? angryRes.AngryRight_Stage2 : angryRes.AngryLeft_Stage2;
                _countFramesAnimation++;
                if (_countFramesAnimation > 20)
                {
                    _countFramesAnimation = 0;
                }
            }
        }
        private void ResizeComponents()
        {
            int bigSize = 25;
            int smallSize = 18;
            int hugeSize = 40;
            if (Width > 1200 && Width < 1400)
            {
                bigSize = 18;
                smallSize = 12;
                hugeSize = 30;
                _kResolution = 0.70;
            }
            else if (Width >= 1400 && Width < 1600)
            {
                bigSize = 20;
                smallSize = 13;
                hugeSize = 32;
                _kResolution = 0.78;
            }
            else if (Width >= 1600 && Width < 1700)
            {
                bigSize = 23;
                smallSize = 14;
                hugeSize = 35;
                _kResolution = 0.85;
            }
            else if (Width > 1900 && Width < 2000)
            {
                bigSize = 27;
                smallSize = 18;
                hugeSize = 40;
                _kResolution = 1;
            }
            else if (Width <= 1200)
            {
                bigSize = 15;
                smallSize = 9;
                hugeSize = 28;
                _kResolution = 0.57;
            }
            _hugeFont = new Font("Calibri", hugeSize, FontStyle.Bold);
            _bigFont = new Font("Calibri", bigSize, FontStyle.Bold);
            _smallFont = new Font("Calibri", smallSize, FontStyle.Bold);

            _cloudSize = ResizeTexture(new Size(400, 220));
            _angrySize = ResizeTexture(130);
            _fruitSize = ResizeTexture(40);
            _mySize = (int)(Width * _mySize_K);

            InfoPause_Label.ResizeControl(this, new Size(400, 50), new Point(760, 515), _bigFont);
            Score_Label.ResizeControl(this, new Size(60, 60), new Point(1843, 15), _smallFont);
            СЧЕТ_Label.ResizeControl(this, new Size(85, 35), new Point(1775, 15), _smallFont);
            MaxScore_Label.ResizeControl(this, new Size(85, 35), new Point(1843, 50), _smallFont);
            Victory_Label.ResizeControl(this, new Size(575, 162), new Point(670, 135), _hugeFont);

            _recordLocation = new Point(1745, 50);
            _targetLocation = new Point(1770, 50);
            if (_endlessMode)
            {
                РекИлиЦель_Label.ResizeControl(this, new Size(150, 35), _recordLocation, _smallFont);
            }
            else
            {
                РекИлиЦель_Label.ResizeControl(this, new Size(150, 35), _targetLocation, _smallFont);
            }

            NewGame_Button.ResizeControl(this, new Size(575, 100), new Point(575, 150), _bigFont);
            Info_Button.ResizeControl(this, new Size(575, 100), new Point(575, 300), _bigFont);
            Settings_Button.ResizeControl(this, new Size(575, 100), new Point(575, 450), _bigFont);
            Exit_Button.ResizeControl(this, new Size(575, 100), new Point(575, 600), _bigFont);


            InfoPause_Label.BackColor = Color.Transparent;
            Score_Label.BackColor = Color.Transparent;
            СЧЕТ_Label.BackColor = Color.Transparent;
            РекИлиЦель_Label.BackColor = Color.Transparent;
            MaxScore_Label.BackColor = Color.Transparent;
            СЧЕТ_Label.Text = "СЧЕТ:";
        }
        private int ResizeTexture(int size)
        {
            double kSize = (double)size / 1920;
            return (int)(Width * kSize);
        }
        private Size ResizeTexture(Size size)
        {
            double kSizeX = (double)size.Width / 1920;
            double kSizeY = (double)size.Height / 1080;
            return new Size((int)(Width * kSizeX), (int)(Height * kSizeY));
        }
        private void Recolor()
        {
            if (_darkMode)
            {
                BackColor = Color.FromArgb(64, 64, 64);
                СЧЕТ_Label.ForeColor = Color.White;
                Score_Label.ForeColor = Color.White;
                InfoPause_Label.ForeColor = Color.White;
                MaxScore_Label.ForeColor = Color.White;
                РекИлиЦель_Label.ForeColor = Color.White;
                this.RecolorWindow(Color.White, Color.DimGray);
            }
            else
            {
                BackColor = Color.WhiteSmoke;
                СЧЕТ_Label.ForeColor = Color.Black;
                Score_Label.ForeColor = Color.Black;
                InfoPause_Label.ForeColor = Color.Black;
                MaxScore_Label.ForeColor = Color.Black;
                РекИлиЦель_Label.ForeColor = Color.Black;
                this.RecolorWindow(Color.Black, Color.LightGray);
            }
        }
        private void FillStartingWindow(Form form)
        {
            form.BackColor = BackColor;
            if (_darkMode)
            {
                form.RecolorWindow(Color.White, Color.DimGray);
            }
            else
            {
                form.RecolorWindow(Color.Black, Color.LightGray);
            }
        }

        private void ComplexityIncrease()
        {
            _kSpeed_Angry += _deltaSpeedAngry;
            _kSpeed_Cloud += _deltaSpeedCloud;
        }
        private void MySizeIncrease()
        {
            _mySize_K += ((double)(_angrySize - _myStartSize) / _targetScore) / 1920;
            _mySize = (int)(this.Width * _mySize_K);
        }
    }
}
