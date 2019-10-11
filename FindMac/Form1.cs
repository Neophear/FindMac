using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using MinimalisticTelnet;

namespace FindMac
{
    public partial class Form1 : Form
    {
        CiscoSwitch cs;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            txtIP.Text = "10.0.0.1";
            txtMac.Text = "XXX.XXXX.XXX";
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            EnableInput(false);

            cs = new CiscoSwitch(txtIP.Text);
            cs.MacFound += cs_MacFound;

            try
            {
                cs.FindMac(txtMac.Text);
            }
            catch (MacNotFoundException)
            {
                WriteOutput("Mac wasn't found");
            }
            catch (ConnectionFailedException)
            {
                WriteOutput("Couldn't connect");
            }

            EnableInput(true);
        }

        private void EnableInput(bool status)
        {
            txtIP.Enabled = status;
            txtMac.Enabled = status;
            btnFind.Enabled = status;
        }

        void cs_MacFound(string newIP)
        {
            if (newIP != "localhost")
            {
                WriteOutput("Found on IP: {0}", newIP);
                txtIP.Text = newIP;                
            }
            else
            {
                WriteOutput("MAC is on this device");
            }
        }

        private void WriteOutput(string text)
        {
            txtOutput.Text += text + Environment.NewLine;
        }
        private void WriteOutput(string format, params object[] args)
        {
            txtOutput.Text += String.Format(format, args) + Environment.NewLine;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            cs.Close();
        }
    }
}