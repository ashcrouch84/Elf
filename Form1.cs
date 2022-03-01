using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace Elf
{
    public partial class Form1 : Form
    {
        int interror;
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdBrowseSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(txtMon.Text)) ReadFolderBrowser.SelectedPath = txtMon.Text;
                if (ReadFolderBrowser.ShowDialog() == DialogResult.OK)
                {
                    txtMon.Text = ReadFolderBrowser.SelectedPath;
                    Properties.Settings.Default.savedLoc = txtMon.Text;
                    Properties.Settings.Default.Save();
                }
            }
            catch
            {
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var list = new List<string>();
            string strread = "";


            try
            {
                strread = Properties.Settings.Default.savedLoc.ToString();
                strread = strread + "\\" + cboMon.SelectedItem.ToString() + ".txt";
                // MessageBox.Show(strread.ToString());
                var fileStream = new FileStream(strread, FileMode.Open, System.IO.FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        list.Add(line);
                    }
                }
                fileStream.Close();
            }
            catch
            {
            }

            try
            {
                if (list.Count < 0)
                { }
                else
                {
                    lblE1.Text = list[0].ToString();
                    lblE2.Text = list[1].ToString();
                    lblE3.Text = list[2].ToString();
                    lblE4.Text = list[3].ToString();
                    lblF1.Text = list[4].ToString();
                    lblF2.Text = list[5].ToString();
                    lblF3.Text = list[6].ToString();
                    lblF4.Text = list[7].ToString();
                }
            }
            catch
            { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtMon.Text = Properties.Settings.Default.savedLoc.ToString();
            cboMon.Items.Add("Red");
            cboMon.Items.Add("Blue");
            cboMon.Text = Properties.Settings.Default.savedID.ToString();
            interror = 0;
            txtInterval.Text = Properties.Settings.Default.savedInterval.ToString();
            timer1.Interval = Properties.Settings.Default.savedInterval;
            timer1.Enabled = true;

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            int i = Properties.Settings.Default.savedInterval;
            timer1.Enabled = false;
            try
            {
                Properties.Settings.Default.savedInterval = Int32.Parse(txtInterval.Text);
                Properties.Settings.Default.Save();
                timer1.Interval = Int32.Parse(txtInterval.Text);
            }
            catch
            {
                MessageBox.Show("Interval needs to be a valid number, please try again", "Interval Error");
                timer1.Interval = Properties.Settings.Default.savedInterval;
            }
            timer1.Enabled = true;
        }

        private void lblE1_Click(object sender, EventArgs e)
        {

        }
    }
}
