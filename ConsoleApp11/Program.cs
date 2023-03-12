using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    internal class Program
    {
        enum Type { Marketing, IT, Restaurant, Car_sale }
        class Rab
        {
            public string Imya { get; set; }
            public string Rabota { get; set; }
            public string Telephone { get; set; }
            public string Email { get; set; }
            public double Oplata { get; set; }
            public Rab(string imya, string rabota, string telephone, string email, double pay)
            {
                Imya = imya;
                Rabota = rabota;
                Telephone = telephone;
                Email = email;
                Oplata = pay;
            }
            public Rab() { }
            public override string ToString() { return $"Имя{Imya}Работа{Rabota}Телефон{Telephone}Имэил{Email}Способ,оплаты{Oplata}"; }
        }
        class Firma
        {
            public string Imya { get; set; }
            public int Data_osnov { get; set; }
            public Type Profil { get; set; }
            public string Glava_Rabov { get; set; }
            public int Rab_Kolvo { get; set; }
            public string Address { get; set; }
            public List<Rab> Rabs { get; set; }
            public Firma()
            {
                Imya = null;
                Data_osnov = 0;
                Profil = Type.IT;
                Glava_Rabov = null;
                Rab_Kolvo = 0;
                Address = null;
                Rabs = new List<Rab>();
            }
            public Firma(string imya, int data_osnov, string glava_rab, Type profil, int rab_kolvo, string address)
            {
                Imya = imya;
                Data_osnov = data_osnov;
                Profil = profil;
                Glava_Rabov = glava_rab;
                Rab_Kolvo = rab_kolvo;
                Address = address;
            }
            public Firma(string imya, int data_osnov, string glava_rab, Type profil, int rab_kolvo,
                string address, List<Rab> Rab) : this(imya, data_osnov, glava_rab, profil, rab_kolvo, address)
            => Rab = new List<Rab>();

            public override string ToString()
            {
                return $"Имя{Imya}\nТип{Profil}\nДата Основания{Data_osnov}\nИмя директора{Glava_Rabov}\nКоличество работающих{Rab_Kolvo}\nАдресс{Address}\n";
            }
        }
        static void Main(string[] args)
        {
            Rab Rab1 = new Rab("Jemes", "Seller", "2521-5012-0821", "Jemes21@ukr.net", 15000);
            Rab Rab2 = new Rab("Susan", "Manager", "3012-4125-1942", "Susan63@ukr.net", 29000);
            Rab Rab3 = new Rab("Nikolas", "Seller", "3016-4173-19411", "Nikolas@ukr.net", 35000);
            List<Rab> Rab = new List<Rab> { Rab1, Rab2, Rab3 };
            Firma Firma1 = new Firma("Samsung", 1976, "Li Ben Chol", Type.IT, 100, "Buy a new system, Yakogama, FERA2", Rab);
            Firma Firma2 = new Firma("Sandora", 1979, "Is't lieben caffe", Type.Marketing, 100, "Parij", Rab);
            List<Firma> firma = new List<Firma> { Firma1, Firma2 };

            #region Первое
            var Info_firma = from i in firma
                             select i.ToString();
            var Eda_Firma = firma.Where(i => i.Imya.Contains("Sandora"));

            var Marketing_Firma = firma.Where(i => i.Profil == Type.IT);

            var Marketing_FirmaIT = firma.Where(i => i.Profil == Type.IT || i.Profil == Type.IT);

            var Number_Firma = firma.Where(i => i.Rab_Kolvo > 100);

            var Number100_Firma = firma.Where(i => i.Rab_Kolvo > 100 && i.Rab_Kolvo < 300);

            var Director = firma.Where(i => i.Glava_Rabov.Contains("Rad"));

            var Year = firma.Where(i => i.Data_osnov < DateTime.Now.Year - 2);

            var Rad_Blue = firma.Where(i => i.Glava_Rabov.Contains("Blue") && i.Imya.Contains("Blue"));
            #endregion

            #region 2
            var Rab_Firma = from e in Rab
                                  from f in firma
                            where f.Imya == "Samsung"
                                  select e;

            var Rab_seller = from e in Rab
                                from f in firma
                                where f.Imya == "Samsung"
                                where e.Oplata > 30000
                                select e;

            var Rab_Manager = from e in Rab
                                   from f in firma
                                   where e.Rabota == "Samsung"
                                   select e;

            var Rab_seller_phone = from e in Rab
                                 from f in firma
                                 where f.Imya == "Samsung"
                                 where e.Telephone.StartsWith("26")
                                 select e;

            var Rab_email = from e in Rab
                                 from f in firma
                                 where f.Imya == "Samsung"
                                 where e.Email.StartsWith("FE")
                                 select e;

            var Rab_name = from e in Rab
                                from f in firma
                                where f.Imya == "Samsung"
                                where e.Imya.Contains("Li Ben Chol")
                                select e;

            foreach (Rab temp in Rab_name)
                Console.WriteLine(temp);
            #endregion
        }
    }
}