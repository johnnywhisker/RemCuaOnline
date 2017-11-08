using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyMuaBanRemCua
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Dictionary<string, object> seasionInfo = new Dictionary<string, object>();
            Database database = new Database();
            database.updateDatabase();
            seasionInfo["name"] = "";
            seasionInfo["isManager"] = false;
            Console.OutputEncoding = Encoding.UTF8;
            BeginMenu:
            switch (Interface.MainMenu(seasionInfo["name"] as string,Convert.ToBoolean( seasionInfo["isManager"])))
            {
                case 0:
                    database.writeDatabase();
                    return;
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    if (seasionInfo["name"] as string != "") {
                        if (Interface.ShowLogout(seasionInfo) == 1)
                        {
                            goto BeginMenu;
                        }
                        else {
                            break;
                        }
                    }
                    Interface.ShowLogin(database, seasionInfo);
                   // Interface.SignUp(database);
                    break;
            }
            goto BeginMenu;
            
        }
    }
}
