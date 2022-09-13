using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace lab1.ex1._2
{
    internal class CheckInput
    {
        public static void ChechInputWord(TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (
                    c < 'A' || c > 'Z' &&
                    c < 'a' || c > 'z' &&
                    c < 'А' || c > 'Я' &&
                    c < 'а' || c > 'я'
                    )
                {
                    e.Handled = true;
                    break;
                }
            }
        }

        public static void IsOnlyDigit(TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if ( !Char.IsDigit(c) && c != ',' )
                {
                    e.Handled = true;
                    break;
                }
            }
        }
    }
}
