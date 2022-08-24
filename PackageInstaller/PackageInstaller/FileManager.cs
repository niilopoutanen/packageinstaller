using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PackageInstaller
{
    public class FileManager
    {
        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string desktopfile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\test.zip";
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
            ExtractZip();
        }
        public void ExtractZip()
        {
            string ProgramFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            ZipFile.ExtractToDirectory(desktopfile, ProgramFiles);
        }
    }
}
