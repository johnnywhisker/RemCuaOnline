using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HeThongQuanLyMuaBanRemCua
{
    class User {
        private string username,password,phone,address,id;
        private bool isManager, isVIP;
        private List<string> boughtList;

        public User(string username,string password, string phone, string address, string id, bool isManager, bool isVIp) {
            if (isManager == isVIp && isManager == true)
            {
                return;
            }
            else {
                this.username = username;
                this.password = password;
                this.phone = phone;
                this.address = address;
                this.id = id;
                this.isManager = isManager;
                this.isVIP = isVIp;
            }
        }

        public bool ValidateLogin(string username, string password) {
            if (this.username == username && this.password == password)
                return true;
            return false;
        }

        public Dictionary<string, Object> getInfo() {
            Dictionary<string, Object> processInfo = new Dictionary<string, object>();
            processInfo["id"] = id;
            processInfo["username"] = username;
            processInfo["password"] = password;
            processInfo["phone"] = phone;
            processInfo["address"] = address;          
            processInfo["isManager"] = isManager;
            processInfo["isVIP"] = isVIP;
            processInfo["list"] = boughtList;
            return processInfo;
        }

        public void addGoods(string id) {
            if (boughtList == null) {
                boughtList = new List<string>();
            }
            boughtList.Add(id);
        }

    }

    class Curtain {
        private string name, type, color,id;
        private float price;
        private int amount; // so luong hang ton kho
        private bool isSale;

        public Curtain(string name, string color, string id, float price, int amount, bool isSale )
        {
            this.name = name;
            this.color = color;
            this.id = id;
            this.price = price;
            this.amount = amount;
            this.isSale = isSale;
        }

        public Dictionary<string, Object> getInfo()
        {
            Dictionary<string, Object> processInfo = new Dictionary<string, object>();
            processInfo["id"] = id;
            processInfo["name"] = name;
            processInfo["color"] = color;
            processInfo["price"] = price;
            processInfo["amount"] = amount;
            processInfo["isSale"] = isSale;
            return processInfo;
        }

        public bool isMe(string input)
        {
            if (name.Contains(input)||color.Contains(input)||id.Contains(input)||price.ToString().Contains(input)||amount.ToString().Contains(input))
            {
                return true;
            }
            return false;
        }
    }

    class Receipt {
        private string userid, address, phone, curtainid,id;
        private DateTime createdDay = DateTime.Now;
        private DateTime deliverDay = DateTime.Now;
        private float price;
        private int ammout;
        private bool isDeliver;

        public Receipt(string userid,string address, string phone, string curtainid,int ammout, float price,string id) {
            isDeliver = false;
            this.userid = userid;
            this.address = address;
            this.phone = phone;
            this.curtainid = curtainid;
            this.ammout = ammout;
            this.price = price;
            this.id = id;

        }

        public Dictionary<string, Object> getInfo() {
            Dictionary<string, Object> processInfo = new Dictionary<string, object>();
            processInfo["userid"] = userid;
            processInfo["address"] = address;
            processInfo["phone"] = phone;
            processInfo["curtainid"] = curtainid;
            processInfo["createdDay"] = createdDay;
            processInfo["deliverDay"] = deliverDay;
            processInfo["price"] = price;
            processInfo["ammout"] = ammout;
            processInfo["isDeliver"] = isDeliver.ToString();
            processInfo["id"] = id;
            return processInfo;
        }

        public bool isMe(string input) {
            Regex rgx = new Regex(@"\d{2}-\d{2}-\d{4}");
            Match mat = rgx.Match(input);
            if (mat.ToString() != "")
            {
                DateTime timeInput = DateTime.Parse(mat.ToString());
                if (createdDay.Date == timeInput || deliverDay.Date == timeInput)
                {
                    return true; ;
                }
            }
            else
            {
                if (userid.Contains(input) || phone.Contains(input) || address.Contains(input) || curtainid.Contains(input) || price.ToString().Contains(input) || ammout.ToString() == input || id.Contains(input))
                    return true;
            }

            return false;
        }
    }
}
