using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace Clicker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        private static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;

        public void ClickIt(int x, int y)
        {
            SetCursorPos(x, y);
            this.Refresh();
            Application.DoEvents();
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Point current = Cursor.Position;
            label2.Text = "X - " + current.X.ToString() + " Y - " + current.Y.ToString();
            posX.Text = current.X.ToString();
            posY.Text = current.Y.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Clicker.Properties.Settings.Default["Interval1"] = textBox1.Text;
            int result;
            if (int.TryParse(textBox1.Text, out result))
            {
                timer1.Interval = result;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            int x;
            int y;

            x = Int32.Parse(posX.Text);
            y = Int32.Parse(posY.Text);

            ClickIt(x, y);
            if (checkBox2.Checked)
            {
                ClickIt(x, y);
            }
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            int x;
            int y;

            x = Int32.Parse(posX.Text);
            y = Int32.Parse(posY.Text);
            ClickIt(x, y);

            if (timer2.Interval != 0)
            {
                timer2.Start();
            }

        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            int x;
            int y;

            x = Int32.Parse(posX.Text);
            y = Int32.Parse(posY.Text);
            ClickIt(x, y);
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        string[,] propArr = new string[10, 4];

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default["SaveCollection"] != null)
            {
                //propArr = Properties.Settings.Default["SaveCollection"] as IEnumerable;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Clicker.Properties.Settings.Default["Interval2"] = textBox2.Text;
            int result;
            if (int.TryParse(textBox2.Text, out result))
            {
                timer2.Interval = result;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void posX_TextChanged(object sender, EventArgs e)
        {
            Clicker.Properties.Settings.Default["PositionX"] = posX.Text;
        }

        private void posY_TextChanged(object sender, EventArgs e)
        {
            Clicker.Properties.Settings.Default["PositionY"] = posY.Text;
        }
        
        private void button3_Click(object sender, EventArgs e)
        {

            int dexer = Decimal.ToInt32(numericUpDown1.Value);

            propArr[dexer, 0] = Properties.Settings.Default["Interval1"].ToString();
            propArr[dexer, 1] = Properties.Settings.Default["Interval2"].ToString();
            propArr[dexer, 2] = Properties.Settings.Default["PositionX"].ToString();
            propArr[dexer, 3] = Properties.Settings.Default["PositionY"].ToString();

            //Properties.Settings.Default["SaveCollection"] = propArr;

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int dexer = Decimal.ToInt32(numericUpDown1.Value);
            
            if (propArr[dexer, 0] != null)
            {
                textBox1.Text = propArr[dexer, 0];
                textBox2.Text = propArr[dexer, 1];
                posX.Text = propArr[dexer, 2];
                posY.Text = propArr[dexer, 3];
            }
            
        }
    }
}
