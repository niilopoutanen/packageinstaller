using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using IWshRuntimeLibrary;


namespace PackageInstaller
{
    public class FileManager
    {
        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string tempfile = Path.GetTempPath() + "\\temp.zip";
        float version = 0.3f;
        static string ProductName = "Testi";
        string ProgramFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\NiiloPoutanen\\" + ProductName;
        string Exename = "Tetris.exe";

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
            FileStream fileStream = new FileStream(tempfile, FileMode.Create);
            for (int i = 0; i < stream.Length; i++)
                fileStream.WriteByte((byte)stream.ReadByte());
            fileStream.Close();

            if (CompareVersion(version) == true)
            {
                ExtractZip();

            }

        }
        public bool CompareVersion(float newversion)
        {
            string[] oldversionstring;
            try
            {
                oldversionstring = System.IO.File.ReadAllLines(ProgramFiles + "\\version.txt");
            }
            catch (Exception)
            {
                return true;
            }

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
                DialogResult result = MessageBox.Show("You are trying to install a older version than the version currently installed. Click YES if you wish to continue.","Version issue",MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    return true;
                }
            }
            return false;
        }
        public void ClearDirectory()
        {
            DirectoryInfo drinfo = new DirectoryInfo(ProgramFiles);
            DirectoryInfo[] folders = drinfo.GetDirectories();
            FileInfo[] files = drinfo.GetFiles();
            foreach (FileInfo file in files)
            {
                file.Delete();
            }
            foreach(DirectoryInfo folder in folders)
            {
                folder.Delete(true);
            }
        }
        public void CreateShortcut()
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string desktopShortcut = Path.Combine(desktop, ProductName + ".lnk");
            string StartMenu = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
            string StartMenuShortcut = Path.Combine(StartMenu, ProductName + ".lnk");

            WshShell shell = new WshShell();
            IWshShortcut link = (IWshShortcut)shell.CreateShortcut(desktopShortcut);
            link.TargetPath = ProgramFiles + "\\" +Exename;
            link.Save();

            IWshShortcut menulink = (IWshShortcut)shell.CreateShortcut(StartMenuShortcut);
            menulink.TargetPath = ProgramFiles + "\\" + Exename;
            menulink.Save();
            DeleteTemp();
        }
        public void DeleteTemp()
        {
            System.IO.File.Delete(tempfile);
        }
        public void ExtractZip()
        {
            if (Directory.Exists(ProgramFiles))
            {
                if (Directory.EnumerateFileSystemEntries(ProgramFiles).Any())
                {
                    ClearDirectory();
                    ExtractZip();
                }
                else if (!Directory.EnumerateFileSystemEntries(ProgramFiles).Any())
                {
                    ZipFile.ExtractToDirectory(tempfile, ProgramFiles);
                    using (StreamWriter versionwriter = new StreamWriter(ProgramFiles + "\\version.txt"))
                    {
                        versionwriter.WriteLine(version);
                    }
                    CreateShortcut();

                }
            }
            else if (!(Directory.Exists(ProgramFiles)))
            {
                ZipFile.ExtractToDirectory(tempfile, ProgramFiles);
            }
        }
    }
}
