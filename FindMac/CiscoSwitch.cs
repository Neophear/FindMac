using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using MinimalisticTelnet;

namespace FindMac
{
    public delegate void MacFoundHandler(string newIP);

    class CiscoSwitch
    {
        private string macAddress = string.Empty;
        private string outgoingPort = string.Empty;
        private string ipAddress = string.Empty;
        private TelnetConnection tc;
        //private Thread telnetThread;

        public event MacFoundHandler MacFound;
        private void NotifyMacFound(string newIP)
        {
            MacFoundHandler handler = MacFound;

            if (handler != null)
            {
                handler(newIP);
            }
        }
        public string MacAddress
        {
            get { return macAddress; }
            set { macAddress = value; }
        }

        public string OutgoingPort
        {
            get { return outgoingPort; }
            set { outgoingPort = value; }
        }

        public string IPAddress
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }

        public CiscoSwitch(string ipAddress)
        {
            this.ipAddress = ipAddress;
        }

        public void FindMac(string macAddress)
        {
            this.macAddress = macAddress;

            //telnetThread = new Thread(new ThreadStart(HandleComm));
            //telnetThread.Start();

            //login with user "root",password "rootpassword", using a timeout of 100ms, and show server output
            tc = new TelnetConnection(IPAddress, 23);
            string s = tc.Login("clrscr", 1000);

            // server output should end with "$" or ">", otherwise the connection failed
            string prompt = s.TrimEnd();
            prompt = s.Substring(prompt.Length - 1, 1);
            if (prompt != "$" && prompt != ">")
                throw new ConnectionFailedException();

            tc.WriteLine("en");
            tc.WriteLine("clrscr");
            tc.WriteLine(string.Format("show mac address-table address {0} | incl Gi|Fa", macAddress));
            prompt = "";

            Match macFoundOnInterface = Regex.Match(tc.Read(), "(fa|gi)(\\d/|\\d)+", RegexOptions.IgnoreCase);

            if (!macFoundOnInterface.Success)
            {
                throw new MacNotFoundException();
            }
            outgoingPort = macFoundOnInterface.Value;

            SendCommand(string.Format("sho cdp neigh {0} deta | incl IP", outgoingPort));

            string lastLine = tc.Read();

            if (Regex.IsMatch(lastLine, "IP address: ", RegexOptions.IgnoreCase))
            {
                Match IPResult = Regex.Match(lastLine, "\\d+.\\d+.\\d+.\\d+");
                NotifyMacFound(IPResult.Value);
            }
            else
            {
                NotifyMacFound("localhost");
            }
        }

        //private void HandleComm()
        //{
            
        //}

        private void SendCommand(string Command)
        {
            tc.WriteLine(Command);
        }

        public void Close()
        {
            //telnetThread.Abort();
        }
    }
}