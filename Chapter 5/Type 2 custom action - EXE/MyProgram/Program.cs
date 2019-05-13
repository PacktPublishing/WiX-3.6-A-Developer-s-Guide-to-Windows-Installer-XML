using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Windows.Forms.MessageBox.Show("This is from an executable! First argument passed in was: " + args[0]);
        }
    }
}
