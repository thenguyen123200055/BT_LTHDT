using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT3
{
    namespace BT03
    {
        class PhanSo
        {
            private int tuso;
            private int mauso;

            public PhanSo()
            {
                tuso = 0;
                mauso = 1;
            }

            public PhanSo(int tuso, int mauso)
            {
                this.tuso = tuso;
                if (mauso != 0)
                    this.mauso = mauso;
                else
                    throw new ArgumentException("Mau khong dc bang 0.");
            }

            public void setTuso(int tuso)
            {
                this.tuso = tuso;
            }

            public int getTuso()
            {
                return tuso;
            }

            public void setMauso(int mauso)
            {
                if (mauso != 0)
                    this.mauso = mauso;
                else
                    throw new ArgumentException("mau khong duoc bang 0.");
            }

            public int getMauso()
            {
                return mauso;
            }

            public void toiGian()
            {
                int ucln = UCLN(tuso, mauso);
                tuso /= ucln;
                mauso /= ucln;
            }

            public PhanSo cong(PhanSo ps)
            {
                int tongTuso = tuso * ps.getMauso() + ps.getTuso() * mauso;
                int tongMauso = mauso * ps.getMauso();
                PhanSo tong = new PhanSo(tongTuso, tongMauso);
                tong.toiGian();
                return tong;
            }

            public PhanSo tru(PhanSo ps)
            {
                int hieuTuso = tuso * ps.getMauso() - ps.getTuso() * mauso;
                int hieuMauso = mauso * ps.getMauso();
                PhanSo hieu = new PhanSo(hieuTuso, hieuMauso);
                hieu.toiGian();
                return hieu;
            }

            public PhanSo nhan(PhanSo ps)
            {
                int tichTuso = tuso * ps.getTuso();
                int tichMauso = mauso * ps.getMauso();
                PhanSo tich = new PhanSo(tichTuso, tichMauso);
                tich.toiGian();
                return tich;
            }

            public PhanSo chia(PhanSo ps)
            {
                int thuongTuso = tuso * ps.getMauso();
                int thuongMauso = mauso * ps.getTuso();
                PhanSo thuong = new PhanSo(thuongTuso, thuongMauso);
                thuong.toiGian();
                return thuong;
            }

            private int UCLN(int a, int b)
            {
                a = Math.Abs(a);
                b = Math.Abs(b);
                while (a > 0 && b > 0)
                {
                    if (a > b)
                        a %= b;
                    else
                        b %= a;
                }
                return a + b;
            }
        }

        class Program
        {
            static void Main(string[] args)
            {

                Console.WriteLine("Nhap phan so thu 1:");
                Console.Write("Tu so: ");
                int tuso1 = int.Parse(Console.ReadLine());
                Console.Write("Mau so: ");
                int mauso1 = int.Parse(Console.ReadLine());

                Console.WriteLine("Nhap phan so thu 2:");
                Console.Write("Tu so: ");
                int tuso2 = int.Parse(Console.ReadLine());
                Console.Write("Mau so: ");
                int mauso2 = int.Parse(Console.ReadLine());

                PhanSo ps1 = new PhanSo(tuso1, mauso1);
                PhanSo ps2 = new PhanSo(tuso2, mauso2);


                PhanSo tong = ps1.cong(ps2);
                Console.WriteLine("Tong: {0}/{1}", tong.getTuso(), tong.getMauso());


                PhanSo hieu = ps1.tru(ps2);
                Console.WriteLine("Hieu: {0}/{1}", hieu.getTuso(), hieu.getMauso());

                PhanSo tich = ps1.nhan(ps2);
                Console.WriteLine("Tich: {0}/{1}", tich.getTuso(), tich.getMauso());


                PhanSo thuong = ps1.chia(ps2);
                Console.WriteLine("Thuong: {0}/{1}", thuong.getTuso(), thuong.getMauso());


                Console.Write("Nhap n: ");
                int n = int.Parse(Console.ReadLine());


                PhanSo tongDaySo = new PhanSo();
                for (int i = 1; i <= n; i++)
                {
                    tongDaySo = tongDaySo.cong(new PhanSo(1, i));
                }
                Console.WriteLine("Tong cua day so tu 1 den {0}: {1}/{2}", n, tongDaySo.getTuso(), tongDaySo.getMauso());
                Console.ReadKey();
            }
        }
    }
}
