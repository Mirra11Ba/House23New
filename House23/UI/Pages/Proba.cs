using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using House23.Logic.DataBase;
using House23.Logic.Handlers;

namespace House23.UI.Pages
{
    public class Proba
    {
        public static bool UserAuthorization(string login, string password)
        {
            try
            {
                var emloyee = ContextManager.GetContext().Employees;
                var currentEmployee = emloyee.Where(p => p.Login.Equals(login)).ToList();
                if (currentEmployee.Count == 1)
                    if (currentEmployee[0].Password.Equals(password))
                    {
                        return true;

                    }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                return false;
            }

            return false;
        }
    }
}
