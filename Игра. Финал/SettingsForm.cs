using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace Игра.Финал
{
    public partial class SettingsForm : Form
    {
        MainForm _parrent;
        public SettingsForm()
        {
            InitializeComponent();
        }
        public SettingsForm(MainForm f)
        {
            InitializeComponent();
            _parrent = f;
        }
        private void Mode_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Mode_ListBox.SelectedItem.ToString() == "Бесконечный")
            {
                Complexity_Panel.Visible = false;
            }
            else
            {
                Complexity_Panel.Visible = true;
                
            }
        }
        private void ClearRegistry_Button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Это действие удалит записи в реестре, созданные игрой, и закроет окно игры. Вы уверены, что хотите продолжить?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (RegistryKey key = Registry.CurrentUser)
                {
                    if (key.OpenSubKey(MainForm.Subkey) != null)
                    {
                        key.DeleteSubKeyTree(MainForm.Subkey);
                    }
                }
                Close();
                _parrent.Dispose();
            }
        }
    }
}
