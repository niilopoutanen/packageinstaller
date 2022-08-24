using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using IWshRuntimeLibrary;


namespace PackageInstaller
{
    public class FileManager
    {
        //Path for desktop
        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //Path to temp file with the zip for moving
        string tempfile = Path.GetTempPath() + "\\temp.zip";
        //Version of the program being installed
        float version = 0.5f;
        //Name of the program being installed
        static string ProductName = "Testi";
        //Path to Program files folder with product name
        string ProgramFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\NiiloPoutanen\\" + ProductName;
        //Name of the main .EXE of the program. Will be used in creating the shortcut to the app.
        string Exename = "Tetris.exe";


        /// <summary>
        /// Test method if user prompt for install folder will be implemented.
        /// </summary>
        public void ChooseFolder()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(fbd.SelectedPath);
            }
        }

        /// <summary>
        /// Adds the given ZIP file to temp folder for later moving.
        /// </summary>
        public bool UnZipResource()
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
            else if (CompareVersion(version) == false)
            {
                return false;
            }
            return true;

        }
        public float GetVersion(bool IsLocal)
        {
            if(IsLocal == false)
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
        public bool CompareVersion(float newversion)
        {
            float oldversion = GetVersion(true);


            if(oldversion == newversion)
            {
                return false;
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
            foreach(DirectoryInfo folder in folders)
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
            link.TargetPath = ProgramFiles + "\\" +Exename;
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
            }
        }
    }
}
