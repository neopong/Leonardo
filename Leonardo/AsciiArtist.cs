using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo
{
    public class AsciiArtist : Artist
    {
        protected override byte[,] _fillGrid(
            Bitmap img,
            int gridWidth,
            int gridHeight)
        {
            int imgWidth = img.Width;
            int imgHeight = img.Height;

            

            int cellWidth = imgWidth/gridWidth;
            int cellHeight = imgHeight / gridHeight;

            int sectionX = 0;
            int sectionY = 0;

            byte[,] grid = new byte[gridWidth, gridHeight];

            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    sectionX = x * cellWidth;
                    sectionY = y * cellHeight;

                    grid[x, y] = (byte)_mapColorToAscii(
                        _getAverageSectionValue(
                        img, 
                        sectionX, 
                        sectionY, 
                        cellWidth, 
                        cellHeight
                        )
                    );

                }
            }

            return grid;
        }

        private byte _getAverageSectionValue(
            Bitmap bmp, 
            int sectionX, 
            int sectionY, 
            int sectionWidth, 
            int sectionHeight)
        {
            int sum = 0;
            int count = 0;

            for (int x = sectionX; x < sectionX + sectionWidth; x++)
            {
                for (int y = sectionY; y < sectionY + sectionHeight; y++)
                {
                    sum += _getGreyScaleValue(bmp.GetPixel(x, y));
                    count++;
                }
            }
            return (byte)(sum / count);
        }

        private byte _getGreyScaleValue(Color c)
        {
            int color = c.ToArgb();
            //00000000 00000000 00000000 00000000
            //                               0xFF
            int R = (color >> 24) & 0xFF;
            int G = (color >> 16) & 0xFF;
            int B = (color >> 8 ) & 0xFF;

            return (byte)((R + B + G) / 3);

        }

        protected char _mapColorToAscii(byte color)
        {
            switch (color / 24)
            {
                case 0:
                    return '▓';
                case 1:
                    return '@';
                case 2:
                    return '#';
                case 3:
                    return '%';
                case 4:
                    return '&';
                case 5:
                    return 'H';
                case 6:
                    return 'I';
                case 7:
                    return '+';
                case 8:
                    return '*';
                case 9:
                    return '~';
                case 10:
                    return '.';
                //case 11:
                //    return '~';
                //case 12:
                //    return '-';
                //case 13:
                //    return '\'';
                //case 14:
                //    return '.';
                //case 15:
                //    return '.';
                default:
                    return '.';

            }
        }
    }
}
