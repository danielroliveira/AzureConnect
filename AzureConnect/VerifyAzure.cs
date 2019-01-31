using Microsoft.Win32;
using System.Linq;

namespace AzureConnect
{
    public class VerifyAzure
    {
        public static bool checkInstalled(string c_name, string c_subname = "")
        {
            string displayName;

            string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey);
            if (key != null)
            {
                foreach (RegistryKey subkey in key.GetSubKeyNames().Select(keyName => key.OpenSubKey(keyName)))
                {
                    displayName = subkey.GetValue("DisplayName") as string;

                    if (displayName != null)
                    {
                        if (displayName.Contains(c_name) && (c_subname == "" ? true : displayName.Contains(c_subname)))
                        {
                            return true;
                        }
                    }
                    //if (displayName != null && displayName.Contains(c_name) && c_subname == "" ? true : displayName.Contains(c_subname))
                    //{
                    //    return true;
                    //}
                }
                key.Close();
            }

            registryKey = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
            key = Registry.LocalMachine.OpenSubKey(registryKey);
            if (key != null)
            {
                foreach (RegistryKey subkey in key.GetSubKeyNames().Select(keyName => key.OpenSubKey(keyName)))
                {
                    displayName = subkey.GetValue("DisplayName") as string;

                    //if (displayName != null && displayName.Contains(c_name) && c_subname == "" ? true : displayName.Contains(c_subname))
                    //{
                    //    return true;
                    //}

                    if (displayName != null)
                    {
                        if(displayName.Contains(c_name) && (c_subname == "" ? true : displayName.Contains(c_subname)))
                        {
                            return true;
                        }
                    }



                }
                key.Close();
            }
            return false;
        }
    }
}
