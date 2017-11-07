using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyMuaBanRemCua
{
    class Database
    {
        public List<User> users = new List<User>();
        public List<Curtain> curtains = new List<Curtain>();
        public List<Receipt> receipts = new List<Receipt>();

        public void updateDatabase() {
            string[] usertexts = System.IO.File.ReadAllLines(@"Users.txt");
            foreach (string text in usertexts)
            {
                string[] processText = text.Split('-');
                User tempUser = new User(processText[1],Security.Decrypt(processText[2],"HLG123"), processText[3], processText[4], processText[0], bool.Parse(processText[5]), bool.Parse(processText[6]));
                string[] listProcess = processText[7].Split('|');
                foreach (string item in listProcess) {
                    tempUser.addGoods(item);
                }
                users.Add(tempUser);
                //Dictionary<string, Object> test = new Dictionary<string, object>();
                //test = tempUser.getInfo();
                //foreach (string key in test.Keys) {
                //    if (key == "list")
                //    {
                //        List<string> temp = test[key] as List<string>; //as : ep kieu
                //        foreach (string element in temp)
                //        {
                //            Console.Write("{0} ", element);
                //        }
                //    }
                //    else
                //    {
                //        Console.Write("{0}\t", test[key]);
                //    }
                //}
                //Console.WriteLine()
            }

            string[] curtaintexts = System.IO.File.ReadAllLines(@"Curtains.txt");
            foreach (string text in curtaintexts)
            {
                string[] processText = text.Split('/');
                Curtain tempCurtain = new Curtain(processText[1], processText[2], processText[0], float.Parse(processText[3]), int.Parse(processText[4]), bool.Parse(processText[5]));
                curtains.Add(tempCurtain);
            }


            string[] receipttexts = System.IO.File.ReadAllLines(@"Receipts.txt");
            foreach (string text in receipttexts)
            {
                string[] processText = text.Split('/');
                Receipt tempReceipt = new Receipt(processText[0], processText[1], processText[2], processText[3], int.Parse(processText[4]), float.Parse(processText[5]), processText[6]);
                receipts.Add(tempReceipt);
            }
        }
        public void writeDatabase()
        {
            List<string> lineUsers = new List<string>();
            foreach (User user in users) {
                Dictionary<string, Object> tempUser = user.getInfo();
                List<string> listBought = tempUser["list"] as List<string>;
                string listLine = "";
                foreach (string item in listBought) {
                    listLine += item + "|";
                }
                string line = String.Format("{0} - {1} - {2} - {3} - {4} - {5} - {6} - {7}",tempUser["id"],tempUser["username"],Security.Encrypt(tempUser["password"] as string,"HLG123"),tempUser["phone"],tempUser["address"],tempUser["isManager"],tempUser["isVIP"],listLine);
                lineUsers.Add(line);
            }
            System.IO.File.WriteAllLines(@"Users.txt", lineUsers.ToArray());


            List<string> listLineCurtains = new List<string>();
            foreach (Curtain curtain in curtains)
            {
                Dictionary<string, Object> tempCurtain = curtain.getInfo();
                string lineCurtains= String.Format("{0} - {1} - {2} - {3} - {4} - {5}", tempCurtain["id"], tempCurtain["name"], tempCurtain["color"], tempCurtain["price"], tempCurtain["amount"], tempCurtain["isSale"]);
                listLineCurtains.Add(lineCurtains);
            }
            System.IO.File.WriteAllLines(@"Curtains.txt", listLineCurtains.ToArray());


            List<string> listLineReceipts = new List<string>();
            foreach (Receipt receipt in receipts)
            {
                Dictionary<string, Object> tempReceipt = receipt.getInfo();
                string line = String.Format("{0} - {1} - {2} - {3} - {4} - {5} - {6} - {7} - {8}", tempReceipt["userid"], tempReceipt["address"], tempReceipt["phone"], tempReceipt["curtainid"], tempReceipt["ammout"], tempReceipt["id"], tempReceipt["isDeliver"],Convert.ToDateTime(tempReceipt["createdDay"]).ToFileTime(), Convert.ToDateTime(tempReceipt["deliverDay"]).ToFileTime() );
                listLineReceipts.Add(line);
            }
            System.IO.File.WriteAllLines(@"Receipts.txt", listLineReceipts.ToArray());
        }
    }
}
