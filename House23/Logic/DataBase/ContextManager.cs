using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House23.Logic.DataBase
{
    public class ContextManager
    {
        private static House23Entities _context;
        public static House23Entities GetContext()
        {
            if (_context == null)
            {
                _context = new House23Entities();
            }
            return _context;
        }
    }
}
