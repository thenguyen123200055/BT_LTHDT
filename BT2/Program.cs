using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT2
{
    class Account
    {
        private string id;
        private string name;
        private int balance;

        public Account (string id, string name, int balance)
        {
            this.id = id;
            this.name = name;
            this.balance = balance;
        }
        public string getID()
        {
            return id;
        }
        public string getName()
        {
            return name;

        }
        public int getBalance()
        {
            return balance;
        }
        public void credit(int amount)
        {
            if (amount > 0)
                balance += amount;
        }
        public void debit(int amount)
        {
            if (amount <= balance)
                balance -= amount;
            else
                Console.WriteLine("So tien vuot qua so du. Rut khong thanh cong");
        }
        public void tranferTo(Account acc, int amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                acc.balance += amount;

            }
            else
            {
                Console.WriteLine("So tien vuot so du. Chuyen khoang khong thanh cong");
            }
        }
        static void Main(string[] args)
        {
            Account my = new Account("12032005", "Nguyen Van B", 4000);
            Account myFriend = new Account("123123", "Le Van A", 1000);

            Console.WriteLine("========Thong tin 2 tai khoan ban dau======");
            Console.WriteLine("My Account :[id :{0}, name: {1} , balance: {2}]",
                    my.getID(), my.getName(), my.getBalance());
            Console.WriteLine("My Friend Account :[id :{0}, name: {1} , balance: {2}]",
                   myFriend.getID(), myFriend.getName(), myFriend.getBalance());


            my.debit(300);
            my.tranferTo(myFriend, 450);

            Console.WriteLine("---------Thong tin 2 tai khoan sau khi ket thuc giao dich---------");
            Console.WriteLine("My Account :[id :{0}, name: {1} , balance: {2}]",
                    my.getID(), my.getName(), my.getBalance());
            Console.WriteLine("My Friend Account :[id :{0}, name: {1} , balance: {2}]",
                   myFriend.getID(), myFriend.getName(), myFriend.getBalance());

            Console.ReadLine();
        }
    }
}
