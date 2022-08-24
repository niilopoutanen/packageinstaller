using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PackageInstaller
{
    public class FileManager
    {
        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string desktopfile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\test.zip";
        float version = 0.6f;
        static string ProductName = "Testi";
        string ProgramFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\NiiloPoutanen\\" + ProductName;

        public void ChooseFolder()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(fbd.SelectedPath);
            }
        }
        public void UnZipResource()
        {

            Stream stream = new MemoryStream(Properties.Resources.Package);
            FileStream fileStream = new FileStream(desktopfile, FileMode.Create);
            for (int i = 0; i < stream.Length; i++)
                fileStream.WriteByte((byte)stream.ReadByte());
            fileStream.Close();

            version = Convert.ToSingle(Properties.Resources.version);
            CompareVersion(version);
            if (true)
            {
                ExtractZip();

            }

        }
        public bool CompareVersion(float newversion)
        {
            var oldversionstring = File.ReadAllLines(ProgramFiles + "\\version.txt");
            float oldversion = Convert.ToSingle(oldversionstring[0]);

            if(oldversion == newversion)
            {
                MessageBox.Show("New version is the same as old version");
            }
            else if (oldversion < newversion)
            {
                return true;
            }
            else if (newversion < oldversion)
            {
                MessageBox.Show("You are trying to install a older version than the version currently installed.");
            }
            return false;
        }
        public void ExtractZip()
        {
            if (Directory.Exists(ProgramFiles))
            {
                if (Directory.EnumerateFileSystemEntries(ProgramFiles).Any())
                {
                    MessageBox.Show("The folder is not empty.");
                }
                else if (!Directory.EnumerateFileSystemEntries(ProgramFiles).Any())
                {
                    ZipFile.ExtractToDirectory(desktopfile, ProgramFiles);
                    using (StreamWriter versionwriter = new StreamWriter(ProgramFiles + "\\version.txt"))
                    {
                        versionwriter.WriteLine(version);
                    }

                }
            }
            else if (!(Directory.Exists(ProgramFiles)))
            {
                ZipFile.ExtractToDirectory(desktopfile, ProgramFiles);
            }


        }
    }
}
