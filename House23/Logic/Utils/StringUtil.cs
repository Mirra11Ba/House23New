using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace House23.Logic.Utils
{
    public class StringUtil
    {
        public static bool ContainsText(string text1, string text2)
        {
            text1 = text1.ToLower();
            text2 = text2.ToLower();
            return text1.Contains(text2);
        }

        public static void CheckIsNumeric(TextCompositionEventArgs e, string messageText, string messageTitle)
        {
            string pattern = "^[0-9]*$";
            Regex regexNumber = new Regex(pattern);

            if (!regexNumber.IsMatch(e.Text))
            {
                e.Handled = true;
                MessageBox.Show(messageText, messageTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public static void CheckIsLetter(TextCompositionEventArgs e)
        {
            string pattern = "^[а-яА-Яa-zA-Z]*$";
            Regex regexLetter = new Regex(pattern);

            if (!regexLetter.IsMatch(e.Text))
            {
                e.Handled = true;
                MessageBox.Show("Можно вводить только буквы (А-я, A-z)", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
