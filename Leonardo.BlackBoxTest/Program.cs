using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leonardo;
using System.Drawing;

namespace Leonardo.BlackBoxTest
{
    class Program
    {
        static void Main(string[] args)
        {
            AsciiArtist artist = new AsciiArtist();
            PaintOptions options = new PaintOptions();
            options.GridResolution = new Resolution(100,80);

            Bitmap bmp = new Bitmap(@"C:\Users\Tyler\Documents\Visual Studio 2013\Projects\Leonardo\Leonardo.BlackBoxTest\head.jpeg");
            //Bitmap bmp = new Bitmap(@"C:\Users\Tyler\Documents\Visual Studio 2013\Projects\Leonardo\Leonardo.BlackBoxTest\Posted-On-Shock-Mansion1.jpg");
            //Bitmap bmp = new Bitmap(@"C:\Users\Tyler\Documents\Visual Studio 2013\Projects\Leonardo\Leonardo.BlackBoxTest\doge.png");
            //Bitmap bmp = new Bitmap(@"C:\Users\Tyler\Documents\Visual Studio 2013\Projects\Leonardo\Leonardo.BlackBoxTest\SNOOP-640x512.jpg");
            //Bitmap bmp = new Bitmap(@"C:\Users\Tyler\Documents\Visual Studio 2013\Projects\Leonardo\Leonardo.BlackBoxTest\Starbucks-Logo-051711.gif");
            String s = artist.PaintToString(bmp, options);
            String s2 = new HtmlAsciiArtist().PaintToTag(bmp, options);


            Console.WriteLine(s2);
            Console.ReadLine();
        }
    }
}
