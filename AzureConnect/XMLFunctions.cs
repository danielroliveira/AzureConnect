using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace AzureConnect
{
	public class XMLFunctions
	{
		#region CONFIG CREATE | LOAD | CHANGE

		// CHECK IF EXIST CONFIG
		//==============================================================================================
		public static bool VerificaConfigXML()
		{
			string FindXML = Application.StartupPath + "\\Config.xml";

			if (File.Exists(FindXML))
				return true;
			else
				return false;
		}

		// CREATE CONFIG XML
		//==============================================================================================
		public static void CriarConfigXML()
		{
			try
			{
				new XDocument(
					new XElement("Configuracao",
						new XElement("DefaultValues",
							new XElement("Grupo", ""),
							new XElement("Server", "")
						),
						new XElement("Rules",
							new XElement("rule1", "regraTexto1"),
							new XElement("rule2", "regraTexto2"),
							new XElement("rule3", "regraTexto3")
						)
					)
				)
				.Save("Config.xml");

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Exceção XML", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		// GET CONFIG XML DEFAULT VALUE
		// =============================================================================
		public static string ObterDefault(string CampoDefault)
		{
			try
			{
				XmlDocument config = MyConfig();
				if (config != null)
				{
					return config.SelectSingleNode("Configuracao").SelectSingleNode("DefaultValues").SelectSingleNode(CampoDefault).InnerText;
				}
				else
				{
					return string.Empty;
				}
			}
			catch
			{
				return string.Empty;
			}
		}

		// GET CONFIG XML DEFAULT VALUE
		// =============================================================================
		public static Dictionary<string, string> ObterRegras()
		{
			try
			{
				XmlDocument config = MyConfig();
				if (config != null)
				{
					Dictionary<string, string> dicRegras = new Dictionary<string, string>();

					var regras = config.SelectSingleNode("Configuracao").SelectSingleNode("Rules").ChildNodes;

					foreach (XmlNode regra in regras)
					{
						dicRegras.Add(regra.Name, regra.InnerText);
					}

					return dicRegras;
				}
				else
				{
					return null;
				}
			}
			catch
			{
				return null;
			}
		}

		// GET CONFIG XML FILE
		// =============================================================================
		public static XmlDocument MyConfig()
		{
			if (VerificaConfigXML())
			{
				XmlDocument myXML = new XmlDocument();
				try
				{
					myXML.Load(Application.StartupPath + "\\Config.xml");
					return myXML;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			else
			{
				return null;
			}
		}

		// OBTER VALOR DO NODE XML DO ARQUIVO CONFIGXML PELO NOME
		// =============================================================================
		public static string ObterConfigValorNode(string NodeName)
		{
			XmlNodeList elemList = MyConfig().GetElementsByTagName(NodeName);
			string myValor = "";

			for (int i = 0; i < elemList.Count; i++)
			{
				myValor = elemList[i].InnerXml;
			}

			return myValor;

		}

		// SAVE CONFIG XML DEFAULT VALUE
		// =============================================================================
		public static bool SaveDefault(string CampoDefault, string NewValorDefault)
		{
			try
			{
				XmlDocument xmlConfig = MyConfig();
				XmlNode myNode = xmlConfig.SelectSingleNode("/Configuracao/DefaultValues/" + CampoDefault);

				if (myNode != null)
				{
					myNode.InnerText = NewValorDefault;
					xmlConfig.Save("Config.xml");
					return true;
				}
				else
				{
					throw new Exception("O XMLNode não foi encontrado...");
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// SAVE CONFIG NODE VALOR CONFIGXML PELO NOME
		// =============================================================================
		public static bool SaveConfigValorNode(string NodeName, string NodeValue)
		{
			try
			{
				XmlDocument xmlConfig = MyConfig();

				if (xmlConfig == null)
				{
					CriarConfigXML();
					xmlConfig = MyConfig();
				}

				XmlNodeList elemList = xmlConfig.GetElementsByTagName(NodeName);

				if (elemList.Count > 0)
				{
					elemList[0].InnerXml = NodeValue;
					xmlConfig.Save("Config.xml");
				}
				else
				{
					throw new Exception("O xmlNode não foi encontrado...");
				}

				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		#endregion

	}
}
