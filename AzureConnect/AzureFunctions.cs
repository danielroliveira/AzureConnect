using System;
using System.Web.Script.Serialization;

namespace AzureConnect
{
	public static class AzureFunctions
	{
		// INSERT NEW IP IN AZURE FIREWALL
		public static string runCmdAzure(string strArgs)
		{
			try
			{
				System.Diagnostics.Process process = new System.Diagnostics.Process();
				process.StartInfo = new System.Diagnostics.ProcessStartInfo()
				{
					UseShellExecute = false,
					CreateNoWindow = true,
					WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
					FileName = "cmd.exe",
					Arguments = "/C " + strArgs,
					RedirectStandardError = true,
					RedirectStandardOutput = true
				};
				process.Start();

				// Now read the value
				string myError = process.StandardError.ReadToEnd();
				if (!string.IsNullOrEmpty(myError))
				{
					throw new Exception(myError);
				}

				string jsonResult = process.StandardOutput.ReadToEnd();
				process.WaitForExit();

				if (string.IsNullOrEmpty(jsonResult))
				{
					throw new Exception("erro inesperado...");
				}

				return jsonResult;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// GET AZURE ACCOUNT DATA
		public static AzureAccount GetAzureAccountData()
		{
			try
			{
				System.Diagnostics.Process process = new System.Diagnostics.Process();
				process.StartInfo = new System.Diagnostics.ProcessStartInfo()
				{
					UseShellExecute = false,
					CreateNoWindow = true,
					WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
					FileName = "cmd.exe",
					Arguments = "/C az account show",
					RedirectStandardError = true,
					RedirectStandardOutput = true
				};
				process.Start();

				/*
				// Now read the value
				string myError = process.StandardError.ReadToEnd();
				if (!string.IsNullOrEmpty(myError))
				{
					throw new Exception(myError);
				}
				*/

				string jsonResult = process.StandardOutput.ReadToEnd();
				process.WaitForExit();

				if (string.IsNullOrEmpty(jsonResult))
				{
					return null;
				}

				// Deserializing json data to object  
				JavaScriptSerializer js = new JavaScriptSerializer();
				AzureAccount account = js.Deserialize<AzureAccount>(jsonResult);

				string userName = account.user.name;
				string accountName = account.name;

				return account;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// LOGIN IN AZURE
		public static AzureAccount LoginAzureAccount()
		{
			try
			{
				System.Diagnostics.Process process = new System.Diagnostics.Process();
				process.StartInfo = new System.Diagnostics.ProcessStartInfo()
				{
					UseShellExecute = false,
					CreateNoWindow = true,
					WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
					FileName = "cmd.exe",
					Arguments = "/C az login",
					RedirectStandardError = true,
					RedirectStandardOutput = true
				};
				process.Start();

				// Now read the value
				string jsonResult = process.StandardOutput.ReadToEnd();
				process.WaitForExit();

				if (string.IsNullOrEmpty(jsonResult))
				{
					throw new Exception("Uma exceção ocorreu ao realizar o login no Azure...\n" +
						"Favor realizar o login na conta do AZURE");
				}

				return GetAzureAccountData();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// LOGOUT IN AZURE
		public static void LogoutAzureAccount()
		{
			try
			{
				System.Diagnostics.Process process = new System.Diagnostics.Process();
				process.StartInfo = new System.Diagnostics.ProcessStartInfo()
				{
					UseShellExecute = false,
					CreateNoWindow = true,
					WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
					FileName = "cmd.exe",
					Arguments = "/C az logout",
					RedirectStandardError = true,
					RedirectStandardOutput = true
				};
				process.Start();

				// Now read the value
				string jsonResult = process.StandardOutput.ReadToEnd();
				process.WaitForExit();

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
