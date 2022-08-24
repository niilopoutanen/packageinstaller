using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PackageInstaller
{
    public class FileManager
    {
        public void ChooseFolder()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(fbd.SelectedPath);
            }
        }
        public void UnzipFIle()
        {
            Stream stream = new MemoryStream(Properties.Resources.Package);
            FileStream fileStream = new FileStream("test.zip", FileMode.CreateNew);
            for (int i = 0; i < stream.Length; i++)
                fileStream.WriteByte((byte)stream.ReadByte());
            fileStream.Close();
        }
    }
}
