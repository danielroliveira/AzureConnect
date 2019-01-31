using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Linq;

namespace AzureConnect
{
    public partial class frmPrincipal : Form
    {
        private string myIP;
        private string strArgs = "";
        private string myCommand = "az sql server firewall-rule create";
        private string myGroup = "-g ProgramaLoja";
        private string myServer = "-s novasiaoserver";
        private string myRule = "";
        private string startIP = "--start-ip-address";
        private string endIP = "--end-ip-address";
        private bool notOpen = false;

        // NEW FORM
        public frmPrincipal()
        {

            if (!VerifyAzure.checkInstalled("CLI", "Azure"))
            {
                notOpen = true;
                MessageBox.Show("Azure CLI não está instalado...");
            }

            InitializeComponent();
            myIP = GetComputer_InternetIP();
            lblIP.Text = myIP;
            lblCommand.Text = myCommand + "...";
            Preencher_cmbFilial();
        }

        // FORM SHOW
        private void frmPrincipal_Shown(object sender, EventArgs e)
        {
            if (notOpen) Close();
        }

        // ON CLOSE
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // GET GLOBAL IP ADRESS
        private string GetComputer_InternetIP()
        {
            // check IP using DynDNS's service
            WebRequest request = WebRequest.Create("http://checkip.dyndns.org");
            request.Proxy = null;
            WebResponse response = request.GetResponse();
            StreamReader stream = new StreamReader(response.GetResponseStream());

            // IMPORTANT: set Proxy to null, to drastically INCREASE the speed of request

            // read complete response
            string ipAddress = stream.ReadToEnd();

            // close the stream
            stream.Close();

            // replace everything and keep only IP
            ipAddress = ipAddress.
                        Replace("<html><head><title>Current IP Check</title></head><body>Current IP Address: ", string.Empty).
                        Replace("</body></html>", string.Empty).
                        Replace("\r\n", string.Empty);

            return ipAddress;
        }

        // BTN LIBERAR PORTA AZURE
        private void btnLiberar_Click(object sender, EventArgs e)
        {

            Get_StringArgs();

            // verify cmbFilial value
            if (cmbFilial.SelectedItem == null)
            {
                MessageBox.Show("Escolha uma filial...", "Filial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbFilial.Focus();
                return;
            }

            // save IP numer in list
            SaveIPNumber();

            // execute command
            System.Diagnostics.Process.Start("CMD.exe", "/C " + strArgs);

        }

        // FILL STRING ARGS
        private void Get_StringArgs()
        {
            // define command string
            strArgs = $"{myCommand} {myGroup} {myServer} {myRule} {startIP} {myIP} {endIP} {myIP}";
            lblCommand.Text = strArgs;
        }

        // PREENCHER COMBO
        private void Preencher_cmbFilial()
        {
            //fill the combobox
            cmbFilial.Items.Add("Nova Sião");
            cmbFilial.Items.Add("Vinde");
            cmbFilial.SelectedItem = null;
        }

        // CHANGE INDEX COMBO
        private void cmbFilial_SelectedIndexChanged(object sender, EventArgs e)
        {
            // verify SelectedItem value
            if (cmbFilial.SelectedItem == null) return;
            // get selected Item
            string str = (string)cmbFilial.SelectedItem;
            //change the rule
            myRule = ConfigurationManager.AppSettings[str];
            //fill StringArgs
            Get_StringArgs();
        }

        private void SaveIPNumber()
        {
            // define o arquivo
            string path = Environment.CurrentDirectory + @"/ConfigIPs.txt";
            string readText = "";

            // Open the file to read from.
            if (File.Exists(path))
            {
                // verifica se o IP atual ja foi incluido na ultima linha 

                string t = File.ReadLines(path).Last();
                if (t == lblIP.Text) { return; }

                readText = File.ReadAllText(path);

            }

            // Create a file to write to.
            string createText = readText + lblIP.Text + Environment.NewLine;
            File.WriteAllText(path, createText);
        }
    }
}
