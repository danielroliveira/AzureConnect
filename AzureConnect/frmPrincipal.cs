using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using static AzureConnect.XMLFunctions;

namespace AzureConnect
{
	public partial class frmPrincipal : Form
	{
		private string myIP;
		private string strArgs = "";
		private string myCommand = "az sql server firewall-rule create";
		private string myGroup = "-g GrupoIgreja";
		private string myServer = "-s adrjserver";
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

			//--- try get config values: SERVER NAME AND GRUPO NAME
			GetConfigValues();

			//--- get IP
			myIP = GetComputer_InternetIP();
			lblIP.Text = myIP;
			lblCommand.Text = myCommand + "...";
			Preencher_cmbFilial();

			//--- create HANDLERS
			txtGrupo.MouseDoubleClick += txt_MouseDoubleClick;
			txtGrupo.LostFocus += txt_LostFocus;
			txtServer.MouseDoubleClick += txt_MouseDoubleClick;
			txtServer.LostFocus += txt_LostFocus;
		}

		// FORM SHOW
		private void frmPrincipal_Shown(object sender, EventArgs e)
		{
			if (notOpen) Close();
		}

		// GET XML CONFIG VALUES
		private bool GetConfigValues()
		{
			try
			{
				//--- define config values
				if (!VerificaConfigXML())
				{
					CriarConfigXML();
				}

				//--- verifica o GRUPO
				string tmpGrupo = ObterConfigValorNode("Grupo");

				if (string.IsNullOrEmpty(tmpGrupo))
				{
					txtGrupo.ReadOnly = false;
					txtGrupo.Focus();
					MessageBox.Show("Há Necessidade de Configuração do nome do GRUPO...");
					return false;
				}
				else
				{
					txtGrupo.Text = tmpGrupo;
					myGroup = "-g " + tmpGrupo;
				}

				//--- verifica o SERVER
				string tmpServer = ObterConfigValorNode("Server");

				if (string.IsNullOrEmpty(tmpServer))
				{
					txtServer.ReadOnly = false;
					txtServer.Focus();
					MessageBox.Show("Há Necessidade de Configuração do nome do SERVIDOR...");
					return false;
				}
				else
				{
					txtServer.Text = tmpServer;
					myServer = "-s " + tmpServer;
				}

				return true;
			}
			catch
			{
				return false;
			}
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
			try
			{
				SaveIPNumber();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Uma exceção ocorreu ao salvar o IPNumber no arquivo de IPs:" +
					Environment.NewLine +
					ex.Message,
					"Azure Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			// execute command
			try
			{
				//Process.Start("CMD.exe", "/C " + strArgs);
				runCmdAzure();

				// user message
				MessageBox.Show("Liberação de Porta efetuada com sucesso!",
					"Azure Connect",
					MessageBoxButtons.OK, MessageBoxIcon.Information);

				//quit
				Application.Exit();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Uma exceção ocorreu ao liberar o IP no Azure DB:" +
				Environment.NewLine +
				ex.Message,
				"Azure Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void runCmdAzure()
		{
			String command = @"/C " + strArgs;
			ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
			cmdsi.Arguments = command;
			Process cmd = Process.Start(cmdsi);
			cmd.WaitForExit();
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
			//--- Create DataTable
			DataTable dt = new DataTable();
			dt.Columns.Add("Chave");
			dt.Columns.Add("Valor");

			var dic = ObterContas();

			foreach (var item in dic)
			{
				dt.Rows.Add(new object[] { item.Key, item.Value });
			}

			//--- Set DataTable
			cmbFilial.DataSource = dt;
			cmbFilial.ValueMember = "Chave";
			cmbFilial.DisplayMember = "Valor";
			cmbFilial.SelectedItem = null;
		}

		// CHANGE INDEX COMBO
		private void cmbFilial_SelectedIndexChanged(object sender, EventArgs e)
		{
			// verify SelectedItem value
			if (cmbFilial.SelectedItem == null) return;

			// get selected Item
			string str = (string)((DataRowView)cmbFilial.SelectedItem)["Chave"];

			//change the rule
			myRule = str;

			//fill StringArgs
			Get_StringArgs();
		}

		private void SaveIPNumber()
		{
			// define o arquivo
			string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"/AzureConnect/ConfigIPs.txt";
			string readText = "";
			FileInfo file = new FileInfo(path);

			// Open the file to read from.
			if (file.Exists)
			{
				// verifica se o IP atual ja foi incluido na ultima linha 
				string t = File.ReadLines(path).Last();
				if (t == lblIP.Text) { return; }

				readText = File.ReadAllText(path);
			}

			// Create a file to write to.
			string createdText = readText + lblIP.Text + Environment.NewLine;
			file.Directory.Create(); // If the directory already exists, this method does nothing.
			File.WriteAllText(file.FullName, createdText);

			//message box show
			//MessageBox.Show("Arquivo de registro de IPs salvo com sucesso...", "Azure Connect",
			//                MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void lblCommand_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(lblCommand.Text);
			MessageBox.Show("Comando copiado para a Área de Transferência...", "Comando Copiado");
		}


		private void txt_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			TextBox text = (TextBox)sender;
			text.ReadOnly = false;
		}

		private void txt_LostFocus(object sender, EventArgs e)
		{
			TextBox text = (TextBox)sender;
			text.ReadOnly = true;

			if (text.Name == "txtGrupo")
			{
				SaveDefault("Grupo", txtGrupo.Text);
			}
			else if (text.Name == "txtServer")
			{
				SaveDefault("Server", txtServer.Text);
			}

			GetConfigValues();
		}

	}
}
