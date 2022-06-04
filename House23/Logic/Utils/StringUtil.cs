using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
