using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo
{
    public class HtmlAsciiArtist : AsciiArtist
    {
        public override string PaintToString(System.Drawing.Bitmap img, PaintOptions options)
        {
            String s = base.PaintToString(img, options);
            return s.Replace("\r\n", "<br/>");

        }

        public String PaintToTag(String className, String idName, System.Drawing.Bitmap img, PaintOptions options)
        {
            String s = this.PaintToString(img, options);
            return "<div class=\"leonardo-art\"><br/>" + s + "<br/></div>" ;
        }

   

    }
}
