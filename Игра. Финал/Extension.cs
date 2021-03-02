using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Игра.Финал
{
    public static class Extension
    {
        public static void RecolorWindow(this Form form, Color foreColor, Color backColor)
        {
            foreach (Control control in form.Controls)
            {
                if (control is Button || control is ListBox)
                {
                    if (control.Tag?.ToString() != "DeleteButton")
                        control.BackColor = backColor;
                    control.ForeColor = foreColor;
                }
                else if (control is Label || control is CheckBox)
                {
                    control.ForeColor = foreColor;
                }
                else if (control is Panel)
                {
                    foreach (Control subcontrol in control.Controls)
                    {
                        if (subcontrol is Label)
                        {
                            subcontrol.ForeColor = foreColor;
                        }
                        else if (subcontrol is ListBox)
                        {
                            subcontrol.ForeColor = foreColor;
                            subcontrol.BackColor = backColor;
                        }
                    }
                }
                else if (control is TabControl)
                {
                    TabControl tc = (TabControl)control;
                    foreach (TabPage page in tc.TabPages)
                    {
                        foreach (Control subcontrol in page.Controls)
                        {
                            if (subcontrol is Label)
                            {
                                control.ForeColor = foreColor;
                            }
                            else if (control is Button || control is ListBox)
                            {
                                control.BackColor = backColor;
                                control.ForeColor = foreColor;
                            }
                        }
                        page.BackColor = form.BackColor;
                    }
                }
            }
        }
        public static void ResizeControl(this Control control, Form mainWindow, Size size, Point location, Font font)
        {
            double kSizeWidth = (double)size.Width / 1920;
            double kSizeHeight = (double)size.Height / 1080;
            double kLocationX = (double)location.X / 1920;
            double kLocationY = (double)location.Y / 1080;

            control.Size = new Size((int)(kSizeWidth * mainWindow.Width), (int)(kSizeHeight * mainWindow.Height));
            control.Location = new Point((int)(kLocationX * mainWindow.Width), (int)(kLocationY * mainWindow.Height));
            control.Font = font;
        }
    }
}
