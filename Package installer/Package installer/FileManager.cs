using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Windows;
using IWshRuntimeLibrary;


namespace WPFinstaller
{
    public class FileManager
    {

        //Path for desktop
        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //Path to temp file with the zip for moving
        string tempfile = Path.GetTempPath() + "\\temp.zip";
        //Version of the program being installed
        float version = 1.0f;
        //Name of the program being installed
        static string ProductName = "Template";
        //Path to Program files folder with product name
        string ProgramFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\NiiloPoutanen\\" + ProductName;
        //Name of the main .EXE of the program. Will be used in creating the shortcut to the app.
        string Exename = "Template.exe";




        /// <summary>
        /// Checks if app is installed to the computer. Runs when launching the app.
        /// </summary>
        /// <returns></returns>
        public bool IsAppInstalled()
        {
            //0 = same version exists = false
            //1 = older version exists but installed is newer = true
            //2 = older version is newer than installed = false
            if (Directory.Exists(ProgramFiles))
            {
                int versioncompare = CompareVersion(version);
                
                if(versioncompare == 0)
                {
                    return true;
                }
                else if (versioncompare == 1 || versioncompare == 2)
                {
                    return false;
                }
            }
            else if (!(Directory.Exists(ProgramFiles)))
            {
                return false;

            }
            return false;
        }

        /// <summary>
        /// Returns the installation path of the app.
        /// </summary>
        /// <returns></returns>
        public string GetInstallPath()
        {

            return ProgramFiles;
        }

        /// <summary>
        /// Returns the name of the app being installed.
        /// </summary>
        /// <returns></returns>
        public string GetProductName()
        {
            return ProductName;
        }
        /// <summary>
        /// Adds the given ZIP file to temp folder for later moving.
        /// </summary>
        public int UnZipResource(bool forceinstall)
        {
            if (forceinstall == true)
            {
                ExtractZip();
            }
            else if (forceinstall == false)
            {
                //0 = same version exists = false
                //1 = older version exists but installed is newer = true
                //2 = older version is newer than installed = false
                Stream stream = new MemoryStream(Package_installer.Properties.Resources.Package);
                FileStream fileStream = new FileStream(tempfile, FileMode.Create);
                for (int i = 0; i < stream.Length; i++)
                    fileStream.WriteByte((byte)stream.ReadByte());
                fileStream.Close();

                if (CompareVersion(version) == 1)
                {
                    ExtractZip();

                }
                else if (CompareVersion(version) == 2)
                {
                    return 2;
                }
                else if (CompareVersion(version) == 0)
                {
                    return 0;
                }
            }
            return 1;
        }

        /// <summary>
        /// Gets the version app.
        /// </summary>
        /// <param name="IsLocal"></param>
        /// <returns></returns>
        public float GetVersion(bool IsLocal)
        {
            if (IsLocal == false)
            {
                string[] oldversionstring;
                try
                {
                    oldversionstring = System.IO.File.ReadAllLines(ProgramFiles + "\\version.txt");
                    float oldversion = Convert.ToSingle(oldversionstring[0]);

                    return oldversion;
                }
                catch (Exception)
                {
                    return 0.0f;
                }
            }
            return version;


        }
        /// <summary>
        /// Checks if there is a earlier version installed and compares it to the version that is being installed.
        /// </summary>
        /// <param name="newversion">Version of currently installed package. This has to be declared in top of FileManager.cs class</param>
        /// <returns>True if install can be continued, false if same version is alreay present</returns>
        public int CompareVersion(float newversion)
        {
            //0 = same version exists = false
            //1 = older version exists but installed is newer = true
            //2 = older version is newer than installed = false
            float oldversion = GetVersion(false);


            if (oldversion == newversion)
            {
                return 0;
            }
            else if (oldversion < newversion)
            {
                return 1;
            }
            else if (newversion < oldversion)
            {
                return 2;
            }
            return 0;
        }

        /// <summary>
        /// Clears the install directory before new version gets installed.
        /// </summary>
        public void ClearDirectory()
        {
            DirectoryInfo drinfo = new DirectoryInfo(ProgramFiles);
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

        /// <summary>
        /// Creates a shortcut to the installed program to Desktop and Start Menu.
        /// </summary>
        public void CreateShortcut()
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string desktopShortcut = Path.Combine(desktop, ProductName + ".lnk");
            string StartMenu = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
            string StartMenuShortcut = Path.Combine(StartMenu, ProductName + ".lnk");

            WshShell shell = new WshShell();
            IWshShortcut link = (IWshShortcut)shell.CreateShortcut(desktopShortcut);
            link.TargetPath = ProgramFiles + "\\" + Exename;
            link.Save();

            IWshShortcut menulink = (IWshShortcut)shell.CreateShortcut(StartMenuShortcut);
            menulink.TargetPath = ProgramFiles + "\\" + Exename;
            menulink.Save();
            DeleteTemp();
        }

        /// <summary>
        /// Deletes the temporary .ZIP file after install.
        /// </summary>
        public void DeleteTemp()
        {
            System.IO.File.Delete(tempfile);
        }

        /// <summary>
        /// Extracts the package.ZIP file to the program's folder.
        /// </summary>
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
                using (StreamWriter versionwriter = new StreamWriter(ProgramFiles + "\\version.txt"))
                {
                    versionwriter.WriteLine(version);
                }
                CreateShortcut();
            }
        }

        /// <summary>
        /// Uninstalls all the related data to the app.
        /// </summary>
        public void UninstallApp()
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string desktopShortcut = Path.Combine(desktop, ProductName + ".lnk");
            string StartMenu = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
            string StartMenuShortcut = Path.Combine(StartMenu, ProductName + ".lnk");
            string AppFolder = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\NiiloPoutanen";

            string[] AppDirectories = Directory.GetDirectories(AppFolder);
            foreach (string dir in AppDirectories)
            {
                string folder = Path.Combine(AppFolder, ProductName);
                if (dir == folder)
                {
                    Directory.Delete(dir, true);
                }
            }
            System.IO.File.Delete(desktopShortcut);
            System.IO.File.Delete(StartMenuShortcut);
        }
    }
}