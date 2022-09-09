using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Address address = new Address();
            address.Index = 441005;
            address.Country = "Ukraine";
            address.City = "Zhytomyr";
            address.Street = "Shevchenko 5";
            address.House = "4a";
            address.Apartment = "55";
            Console.WriteLine($"Index: {address.Index}, Country: {address.Country}, City: {address.City}, Street: {address.Street}, House: {address.House}, Apartment: {address.Apartment}.");

            Converter converter = new Converter(40.0, 40.0, 0.00001);
            converter.ConvertChooseStart();

            Employee employee = new Employee("Ivan", "Franko");
            employee.AboutEmployee();

            User user = new User();
            user.AboutUser();
        }
    }
    class Address
    {
        private int index;
        private string country = "";
        private string city = "";
        private string street = "";
        private string house = "";
        private string apartment = "";

        public int Index 
        {
            get { return index; }
            set { if (value.GetType() == typeof(int))
                    index = value;
                else
                    Console.WriteLine("Wrong type.");
            }
        }
        public string Country
        {
            get { return country; }
            set { if (value.GetType() == typeof(string)) 
                    country = value;
                else
                    Console.WriteLine("Wrong type.");
            }
        }
        public string City
        {
            get { return city; }
            set { if (value.GetType() == typeof(string)) 
                    city = value;
                else
                    Console.WriteLine("Wrong type.");
            }
        }
        public string Street
        {
            get { return street; }
            set { if (value.GetType() == typeof(string))
                    street = value;
                else
                    Console.WriteLine("Wrong type.");
            }
        }
        public string House
        {
            get { return house; }
            set { if (value.GetType() == typeof(string))
                    house = value;
                else
                    Console.WriteLine("Wrong type.");
            }
        }
        public string Apartment
        {
            get { return apartment; }
            set { if (value.GetType() == typeof(string))
                    apartment = value;
                else
                    Console.WriteLine("Wrong type.");
            }
        }
    }
    
    class Converter
    {
        private double usd;
        private double eur;
        private double rub;
        public Converter(double usd, double eur, double rub)
        {

            this.usd = usd;
            this.eur = eur;
            this.rub = rub;
        }
        public void ConvertChooseStart()
        {
            int choose = 0;
            do
            {
                Console.WriteLine("(0 to exit) Choose: 1 - UAH to USD/EUR/RUB, 2 - USD/EUR/RUB to UAH: ");
                choose = Convert.ToInt32(Console.ReadLine());
                if (choose < 0 || choose > 3)
                    Console.WriteLine("Wrong choose");
                else if (choose == 0)
                {
                    Console.WriteLine("Exit.");
                    break;
                }
                else
                    break;
            } while (true);
            switch (choose)
            {
                case 1:
                    double uaht = 0;
                    int chooseCur = 0;

                    while (true)
                    {

                        Console.Write("UAH: ");
                        uaht = Convert.ToDouble(Console.ReadLine());
                        if (uaht < 0)
                        {
                            Console.WriteLine("Wrong value.");
                            continue;
                        }

                        Console.Write("USD - 1, EUR - 2, RUB - 3: ");
                        chooseCur = Convert.ToInt32(Console.ReadLine());
                        if (chooseCur < 1 || chooseCur > 3)
                        {
                            Console.WriteLine("Wrong choose.");
                            continue;
                        }
                        break;
                    }
                    switch (chooseCur)
                    {
                        case 1:
                            Console.WriteLine($"Converted to USD:{UAHToSome(uaht, chooseCur)}");
                            break;
                        case 2:
                            Console.WriteLine($"Converted to EUR:{UAHToSome(uaht, chooseCur)}");
                            break;
                        case 3:
                            Console.WriteLine($"Converted to RUB:{UAHToSome(uaht, chooseCur)}");
                            break;
                    }
                    break;
                case 2:
                    int chooseCur2 = 0;
                    double valueCur = 0;

                    while (true)
                    {
                        Console.Write("USD - 1, EUR - 2, RUB - 3: ");
                        chooseCur2 = Convert.ToInt32(Console.ReadLine());
                        if (chooseCur2 < 1 || chooseCur2 > 3)
                        {
                            Console.WriteLine("Wrong choose.");
                            continue;
                        }
                        Console.Write("Value: ");
                        valueCur = Convert.ToDouble(Console.ReadLine());
                        if (valueCur < 0)
                        {
                            Console.WriteLine("Wrong value.");
                            continue;
                        }
                        break;
                    }
                    switch (chooseCur2)
                    {
                        case 1:
                            Console.WriteLine($"Converted from USD:{SomeToUAH(valueCur, chooseCur2)}");
                            break;
                        case 2:
                            Console.WriteLine($"Converted from EUR:{SomeToUAH(valueCur, chooseCur2)}");
                            break;
                        case 3:
                            Console.WriteLine($"Converted from RUB:{SomeToUAH(valueCur, chooseCur2)}");
                            break;
                    }
                    break;
            }
        }
        public double UAHToSome(double uah, int currency)
        {
            double converted = 0;
            switch (currency)
            {
                case 0:
                    Console.WriteLine("Exit.");
                    break;
                case 1:
                    converted = uah / usd;
                    break;
                case 2:
                    converted = uah / eur;
                    break;
                case 3:
                    converted = uah / eur;
                    break;
                default:
                    Console.WriteLine("Something went wrong.");
                    break;
            }
            return converted;
        }
        public double SomeToUAH(double cur, int currency)
        {
            double converted = 0;
            switch (currency)
            {
                case 0:
                    Console.WriteLine("Wrong choose.");
                    break;
                case 1:
                    converted = cur * usd;
                    break;
                case 2:
                    converted = cur * eur;
                    break;
                case 3:
                    converted = cur * rub;
                    break;
                default:
                    Console.WriteLine("Something went wrong.");
                    break;
            }
            return converted;
        }
    }
    class Employee 
    {
        private string name = "";
        private string forname = "";
        private Position position = Position.Third;
        private int seniority = 4;
        private const int minsalary = 1500;
        private const float pdw = 0.2f;
        enum Position : byte
        {
            First = 3,
            Second = 2,
            Third = 1
        }

        public Employee(string name, string forname)
        {
            this.name = name;
            this.forname = forname;
        }

        public double Salary()
        {
            double salary = 0;
            salary = minsalary * (int)position * seniority * pdw;
            return salary;
        }

        public void AboutEmployee()
        {
            Console.WriteLine($"Name: {name}\nForname: {forname}\nPosition: {position}\nTax: {pdw}\nSalary: {Salary()}\n");
        }

    }
    class User
    {

        private string login = "Kobzar";
        private string name = "Taras";
        private string forname = "Shevchenko";
        private int age = 47;
        private DateTime currentDateTime = DateTime.Now;
        public void AboutUser()
        {
            Console.WriteLine($"Login: {login}\nName: {name}\nForname: {forname}\nAge: {age}\n Date of filling in the questionnaire: {currentDateTime}\n");
        }
    }
}