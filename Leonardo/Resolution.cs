using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leonardo
{
    public class Resolution
    {
        public int Height
        {
            get;
            set;
        }
        public int Width
        {
            get;
            set;
        }

        public Resolution(int w, int h)
        {
            this.Height = h;
            this.Width = w;
        }
    }
}
