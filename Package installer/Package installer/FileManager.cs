using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Package_installer
{
    internal class FileManager
    {
        //0 = same version exists = false
        //1 = older version exists but installed is newer = true
        //2 = older version is newer than installed = false

        public readonly static string productName = "Template";
        public readonly static float appVersion = 0.1f;
        readonly string exeName = "Template.exe";


        readonly string tempfile = Path.GetTempPath() + "\\temp.zip";
        readonly string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        readonly string programFiles = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "NiiloPoutanen", productName);

        public async Task<bool> StartInstall()
        {
            byte[] result;
            Stream stream = new MemoryStream(Package_installer.Properties.Resources.package);
            await using (FileStream fileStream = new FileStream(tempfile, FileMode.Create))
            {
                result = new byte[stream.Length];
                await stream.ReadAsync(result, 0, (int)stream.Length);

                await fileStream.WriteAsync(result, 0, result.Length);
            }
            return true;
            
        }
        public bool IsAppInstalled()
        {
            if (Directory.Exists(programFiles))
            {
                int versioncompare = CompareVersion(appVersion);

                if (versioncompare == 0)
                {
                    return true;
                }
                else if (versioncompare == 1 || versioncompare == 2)
                {
                    return false;
                }
            }
            return false;
        }
        public void StartUninstall()
        {

        }
        private int CompareVersion(float newVersion)
        {
            float oldVersion = GetVersion(false);

            if (oldVersion == newVersion)
            {
                return 0;
            }
            else if (oldVersion > newVersion)
            {
                return 1;
            }
            else if (oldVersion < newVersion)
            {
                return 2;
            }
            return 0;
        }

        public float GetVersion(bool IsLocal)
        {
            if (IsLocal == false)
            {
                string[] oldversionstring;
                try
                {
                    oldversionstring = System.IO.File.ReadAllLines(programFiles + "\\version.txt");
                    float oldversion = Convert.ToSingle(oldversionstring[0]);

                    return oldversion;
                }
                catch (Exception)
                {
                    return 0.0f;
                }
            }
            return appVersion;
        }
    }
}
