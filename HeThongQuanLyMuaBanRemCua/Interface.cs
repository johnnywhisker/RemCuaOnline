using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyMuaBanRemCua
{
    class Interface
    {
        
        public static int MainMenu(string userName,bool isManager)
        {
            BeginMenu:
            Console.Clear();
            if (userName == "")
            { // Menu khach chua dang nhap
                Console.WriteLine("HỆ THỐNG MUA BÁN RÈM CỬA{0,30}", "Khách vãng lai");
                Console.WriteLine("1.Xem mẫu rèm cửa. \n2.Xem đơn đặt hàng \n3.Đăng nhập \n0.Thoát\n");
            }
            else
            {
                if (isManager)
                {
                    //Menu quan ly
                    Console.WriteLine("HỆ THỐNG MUA BÁN RÈM CỬA{0,30}", userName);
                    Console.WriteLine("1.Xem tất cả hàng hóa trong kho. \n2.Xem tất cả đơn đặt hàng\n3.Đăng xuất \n0.Thoát\n");
                }
                else
                {
                    //Menu thuong                    
                    Console.WriteLine("HỆ THỐNG MUA BÁN RÈM CỬA{0,30}", userName);
                    Console.WriteLine("1.Xem mẫu rèm cửa. \n2.Xem đơn đặt hàng\n3.Đăng xuất \n0.Thoát\n");
                }
            }
            Console.WriteLine("---------------------------------------------------------");
            int choice = IO.PromptOption("Nhập vào lựa chọn của mình: ", 3);
            if (choice > -1)
            {
                return choice;
            }
            else
            {
                Console.Clear();
                goto BeginMenu;
            }

        }

        public static void ShowLogin(Database database,Dictionary<string,object> seasionInfo)
        {
            Console.Clear();
            Console.Write("Nhập vào tên đăng nhập: ");
            string tempUsername = Console.ReadLine();
            int index = database.findUser(tempUsername);
            if (index != -1) {
                Console.Write("Nhập vào mật khẩu: ");
                string tempPass = IO.Returnpassword();
                if (database.validateLogin(tempUsername, tempPass, index)) {
                    seasionInfo["name"] = tempUsername;
                    Console.WriteLine("Đăng nhập thành công");
                    IO.PromptOption("trở về màn hình chính", -2);
                    return;
                    // sucess
                }

            }
            Console.WriteLine("Đăng nhập thất bại. Vui lòng kiểm tra lại thông tin và thử lại.");
            IO.PromptOption("trở về màn hình chính", -2);
            return;
            //fail
        }
        public static int ShowLogout(Dictionary<string, object> seasionInfo)
        {
            Console.Clear();
            Console.WriteLine("Bạn có chắc chắn muốn đăng xuất ?\n1.Tôi chắc\n0.Hủy");
            int choice = IO.PromptOption("Nhập vào lựa chọn của mình: ", 1);
            if (choice == 1)
            {
                seasionInfo["name"] = "";
                seasionInfo["isManager"] = false;
            }
            return choice;
        }

        public static void SignUp(Database database) {
            Console.Clear();
            Console.Write("Nhập vào tên đăng nhập: ");
            string tempUsername = Console.ReadLine();
            int index = database.findUser(tempUsername);
            if (index == -1)
            {
                Console.Write("Nhập vào password: ");
                string tempPass = IO.Returnpassword();
                Console.Write("Nhập vào số điện thoại: ");
                string tempPhone = Console.ReadLine();
                Console.Write("Nhập vào địa chỉ: ");
                string tempAdd = Console.ReadLine();
                Console.Write("Nhập vào id: ");
                string tempID = Console.ReadLine();                
                User tempUser = new User(tempUsername, tempPass, tempPhone, tempAdd, tempID, false, false);
                tempUser.addGoods("0");
                database.addUser(tempUser);

            }
            else {
                ShowError("Tên đăng nhập đã tồn tại. ");
            }
        }

        public static void ShowError(string mess)
        {
            Console.Clear();
            Console.WriteLine(mess);
            IO.PromptOption("trở về màn hình chính", -2);
            Console.Clear();
        }
    }
}
