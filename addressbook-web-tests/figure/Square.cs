using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    class Square: Figure
    {
        private int size;
        private bool colored = false;

        public Square(int size)
        { 
            this.size = size;
        }
        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }

       
        // public int getSize()
        // {
        //      return size;
        // }
        //  public void setSize(int size)
        //  {
        //      this.size = size;
        //  }


    }
}
