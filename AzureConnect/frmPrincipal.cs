using System;
using System.Data;
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
		private string myGroup = "";
		private string myServer = "";
		private string myRule = "";
		private string startIP = "--start-ip-address";
		private string endIP = "--end-ip-address";
		private bool notOpen = false;
		private bool isShow = false;

		#region SUB NEW

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
			txtGrupo.Validated += txt_Validated;
			txtServer.MouseDoubleClick += txt_MouseDoubleClick;
			txtServer.Validated += txt_Validated;

			//--- GET Account Data
			try
			{
				AzureFunctions.GetAzureAccountData();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Uma exceção ocorreu ao Obter Azure Account..." + "\n" +
					 ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		// FORM SHOW
		private void frmPrincipal_Shown(object sender, EventArgs e)
		{
			if (notOpen) Close();
			isShow = true;
		}

		// PREENCHER COMBO
		private void Preencher_cmbFilial()
		{
			//--- Create DataTable
			DataTable dt = new DataTable();
			dt.Columns.Add("Chave");
			dt.Columns.Add("Valor");

			var dic = ObterRegras();

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
			myRule = "--name " + str;

			//fill StringArgs
			Create_StringArgs();
		}

		#endregion // SUB NEW --- END

		#region BUTTON FUNCTIONS

		// BUTTON CLOSE
		private void btnClose_Click(object sender, EventArgs e)
		{
			Dispose();
			Application.Exit();
		}

		#endregion // BUTTON FUNCTIONS --- END

		#region OTHER FUNCTIONS

		// FILL STRING ARGS
		private void Create_StringArgs()
		{
			// define command string
			strArgs = $"{myCommand} --output json {myGroup} {myServer} {myRule} {startIP} {myIP} {endIP} {myIP}";
			lblCommand.Text = strArgs;
		}

		// GET XML CONFIG VALUES
		private bool GetConfigValues()
		{
			try
			{
				// Ampulheta ON
				Cursor.Current = Cursors.WaitCursor;

				//--- define config values
				if (!VerificaConfigXML())
				{
					CriarConfigXML();
				}

				bool myreturn = true;

				//--- verifica o GRUPO
				string tmpGrupo = ObterConfigValorNode("Grupo");

				if (string.IsNullOrEmpty(tmpGrupo))
				{
					txtGrupo.ReadOnly = false;
					//if (isShow && myreturn) MessageBox.Show("Há Necessidade de Configuração do nome do GRUPO...");
					myreturn = false;
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
					//if (isShow && myreturn) MessageBox.Show("Há Necessidade de Configuração do nome do SERVIDOR...");
					myreturn = false;
				}
				else
				{
					txtServer.Text = tmpServer;
					myServer = "-s " + tmpServer;
				}

				return myreturn;
			}
			catch
			{
				return false;
			}
			finally
			{
				// Ampulheta OFF
				Cursor.Current = Cursors.Default;
			}
		}

		// GET GLOBAL IP ADRESS
		private string GetComputer_InternetIP()
		{
			// Ampulheta ON
			Cursor.Current = Cursors.WaitCursor;

			// check IP using DynDNS's service
			WebRequest request = WebRequest.Create("http://checkip.dyndns.org");
			request.Proxy = null;
			WebResponse response = request.GetResponse();
			StreamReader stream = new StreamReader(response.GetResponseStream());

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

		#endregion // OTHER FUNCTIONS --- END

		#region LIBERAR PORTA FUNCTION

		// BTN LIBERAR PORTA AZURE
		private void btnLiberar_Click(object sender, EventArgs e)
		{
			// --- Ampulheta ON
			Cursor.Current = Cursors.WaitCursor;

			if (!VerifyFields()) return;
			Create_StringArgs();

			// save IP number in list
			try
			{
				SaveIPNumber();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Uma exceção ocorreu ao salvar o IPNumber no arquivo de IPs:" +
					Environment.NewLine +
					ex.Message,
					"Azure Connect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

			// execute command
			try
			{
				AzureFunctions.runCmdAzure(strArgs);

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
				"Azure Connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			// --- Ampulheta OFF
			Cursor.Current = Cursors.Default;
		}

		// VERIFY FIELDS
		private bool VerifyFields()
		{
			// verify cmbFilial value
			if (cmbFilial.SelectedItem == null)
			{
				// Ampulheta OFF
				Cursor.Current = Cursors.Default;

				MessageBox.Show("Escolha uma filial...",
					"Filial",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				cmbFilial.Focus();
				cmbFilial.DroppedDown = true;
				return false;
			}

			// verify Grupo
			if (string.IsNullOrEmpty(txtGrupo.Text))
			{
				// Ampulheta OFF
				Cursor.Current = Cursors.Default;

				MessageBox.Show("Favor definir o Grupo", "Definir Grupo",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				txtGrupo.Focus();
				return false;
			}

			// verify Server
			if (string.IsNullOrEmpty(txtServer.Text))
			{
				// Ampulheta OFF
				Cursor.Current = Cursors.Default;

				MessageBox.Show("Favor definir o Servidor", "Definir Servidor",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				txtServer.Focus();
				return false;
			}

			return true;

		}

		// SAVE IP NUMBER IN TEXT
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

		#endregion // LIBERAR PORTA FUNCTION --- END

		#region CONTROL FUNCTIONS

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

		private void txt_Validated(object sender, EventArgs e)
		{
			if (!isShow) return;

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

		#endregion // CONTROL FUNCTIONS --- END
	}
}
