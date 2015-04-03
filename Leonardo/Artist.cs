using Leonardo.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo
{
    public abstract class Artist
    {
        public Artist() { }

        public byte[,] Paint(Bitmap img, PaintOptions options)
        {
            /// Validate the arguments
            /// 
            if (img == null || 
                img.Width == 0 || 
                img.Height == 0)
            {
                throw new InvalidImageException();
            }

            if (img.Width < options.GridResolution.Width || 
                img.Height < options.GridResolution.Height)
            {
                throw new ImageResolutionLessThanGridResolutionException();
            }

            /// -
            int gridWidth = options.GridResolution.Width;
            int gridHeight = options.GridResolution.Height;

            int imgWidth = img.Width;
            int imgHeight = img.Height;


            /// Next we will create a grid.
            /// 
            byte[,] grid = _fillGrid(img, gridWidth, gridHeight);

            return grid;

        }

        public virtual String PaintToString(Bitmap img, PaintOptions options)
        {
            byte[,] result = Paint(img, options);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < result.GetLength(1); i++)
            {
                for (int j = 0; j < result.GetLength(0); j++)
                {
                    sb.Append((char)result[j, i]);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public virtual void PaintToFile(Bitmap img, PaintOptions options, String filePath)
        {
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            }
            if (!File.Exists(filePath))
            {
                File.AppendAllText(filePath, PaintToString(img, options), Encoding.UTF8);
            }
        }

        /// <summary>
        /// Create a 2D byte grid
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        protected virtual byte[,] _createGrid(int width, int height)
        {
            byte[,] grid = new byte[width, height];
            return grid;
        }

        protected abstract byte[,] _fillGrid(
            Bitmap img, 
            int gridWidth, 
            int gridHeight);



    }
}
