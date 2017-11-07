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
            Database database = new Database();
            database.updateDatabase();
            User temp = new User("Tester", "123", "123", "ABC", "13", false, false);
            Receipt tempR = new Receipt("4", "Nha may", "113", "-1", 0, -100000, "4");
            temp.addGoods("123");
            database.receipts.Add(tempR);
            database.users.Add(temp);
            database.writeDatabase();
            Console.ReadLine();
        }
    }
}
