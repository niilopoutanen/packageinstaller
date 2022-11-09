using System;
using System.Linq;
using System.IO;
using System.ComponentModel;
using System.IO.Compression;
using IWshRuntimeLibrary;

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

        public void StartInstall(object sender, DoWorkEventArgs e)
        {
            Stream stream = new MemoryStream(Package_installer.Properties.Resources.package);
            
            using (FileStream fileStream = new FileStream(tempfile, FileMode.Create))
            {
                for (int i = 0; i < stream.Length; i++)
                {
                    fileStream.WriteByte((byte)stream.ReadByte());
                }
            }
            stream.Close();
            InstallFromTemp();

            System.IO.File.Delete(tempfile);

        }
        private void InstallFromTemp()
        {
            if (Directory.Exists(programFiles))
            {
                if (Directory.EnumerateFileSystemEntries(programFiles).Any())
                {
                    ClearDirectory();
                    InstallFromTemp();
                }
                else if (!Directory.EnumerateFileSystemEntries(programFiles).Any())
                {
                    ZipFile.ExtractToDirectory(tempfile, programFiles);
                    using (StreamWriter versionwriter = new StreamWriter(programFiles + "\\version.txt"))
                    {
                        versionwriter.WriteLine(appVersion);
                    }
                    CreateShortcut();
                }
            }
            else if (!(Directory.Exists(programFiles)))
            {
                ZipFile.ExtractToDirectory(tempfile, programFiles);
                using (StreamWriter versionwriter = new StreamWriter(programFiles + "\\version.txt"))
                {
                    versionwriter.WriteLine(appVersion);
                }
                CreateShortcut();
            }
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
            string desktopShortcut = Path.Combine(desktop, productName + ".lnk");
            string StartMenu = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
            string StartMenuShortcut = Path.Combine(StartMenu, productName + ".lnk");
            string AppFolder = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\NiiloPoutanen";

            string[] AppDirectories = Directory.GetDirectories(AppFolder);
            foreach (string dir in AppDirectories)
            {
                string folder = Path.Combine(AppFolder, productName);
                if (dir == folder)
                {
                    Directory.Delete(dir, true);
                }
            }
            System.IO.File.Delete(desktopShortcut);
            System.IO.File.Delete(StartMenuShortcut);
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
        private void ClearDirectory()
        {
            DirectoryInfo drinfo = new DirectoryInfo(programFiles);
            DirectoryInfo[] folders = drinfo.GetDirectories();
            FileInfo[] files = drinfo.GetFiles();
            foreach (FileInfo file in files)
            {
                file.Delete();
            }
            foreach (DirectoryInfo folder in folders)
            {
                folder.Delete(true);
            }
        }
        private void CreateShortcut()
        {
            string desktopShortcut = Path.Combine(desktop, productName + ".lnk");
            string startMenu = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
            string startMenuShortcut = Path.Combine(startMenu, productName + ".lnk");

            WshShell shell = new WshShell();
            IWshShortcut desktopShortCut = (IWshShortcut)shell.CreateShortcut(desktopShortcut);
            desktopShortCut.TargetPath = Path.Combine(programFiles, exeName);
            desktopShortCut.Save();

            IWshShortcut menuShortCut = (IWshShortcut)shell.CreateShortcut(startMenuShortcut);
            menuShortCut.TargetPath = Path.Combine(programFiles, exeName);
            menuShortCut.Save();
        }
    }
}
