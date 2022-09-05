using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordRPC;
using DiscordRPC.Logging;

namespace Jhn_presensce
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Point lastPoint;
        public DiscordRpcClient client;
        bool initalized = false;
        string discord = "https://dc.johnydev.fun/";
        string web = "https://johnydev.fun/";

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(discord);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (initalized == false)
            {
                MessageBox.Show("You need initzialed first", "JHN PRESENCE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox5.Text.Length != 0)
                {
                    if(textBox4.Text.Length != 0)
                    {
                        if (textBox2.Text.Length != 0)
                        {
                            if (textBox3.Text.Length != 0)
                            {
                                if (textBox6.Text.Length != 0)
                                {
                                    client.SetPresence(new DiscordRPC.RichPresence()
                                    {
                                        Details = $"{textBox5.Text}",
                                        State = $"{textBox4.Text}",
                                        Timestamps = Timestamps.Now,
                                        Assets = new Assets()
                                        {
                                            LargeImageKey = $"{textBox2.Text}",
                                            LargeImageText = $"{textBox6.Text}",
                                            SmallImageKey = $"{textBox3.Text}"
                                        }
                                    });
                                }else
                                {
                                    MessageBox.Show("LargeImageText is empty please add LargeImage text", "JHN PRESENCE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("SmallImageKey is empty please add SmallImageKey text", "JHN PRESENCE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }else
                        {
                            MessageBox.Show("LargeImageKey is empty please add LargeImageKey text", "JHN PRESENCE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }else
                    {
                        MessageBox.Show("State is empty please add state text", "JHN PRESENCE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }else
                {
                    MessageBox.Show("Details is empty please add details text", "JHN PRESENCE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Client is Empty. Please Add client id", "JHN PRESENCE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
            {
                    initalized = true;
                    client = new DiscordRpcClient($"{textBox1.Text}");
                    client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };
                    client.Initialize();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(web);
        }

    }
}
