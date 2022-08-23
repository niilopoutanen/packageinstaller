using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PackageInstaller
{
    internal class UI
    {
        public FontFamily CreateInterBold()
        {
            PrivateFontCollection InterBold = new PrivateFontCollection();
            

            int fontlength = Properties.Resources.Inter_Bold.Length;

            byte[] fontdata = Properties.Resources.Inter_Bold;

            System.IntPtr data = Marshal.AllocCoTaskMem(fontlength);

            Marshal.Copy(fontdata, 0, data, fontlength);

            InterBold.AddMemoryFont(data, fontlength);
            FontFamily Inter = InterBold.Families[0];
            return Inter;
        }
        public FontFamily CreateInterSemiBold()
        {
            PrivateFontCollection InterSemiBold = new PrivateFontCollection();


            int fontlength = Properties.Resources.Inter_SemiBold.Length;

            byte[] fontdata = Properties.Resources.Inter_SemiBold;

            System.IntPtr data = Marshal.AllocCoTaskMem(fontlength);

            Marshal.Copy(fontdata, 0, data, fontlength);

            InterSemiBold.AddMemoryFont(data, fontlength);
            FontFamily Inter = InterSemiBold.Families[0];
            return Inter;
        }

    }
}
