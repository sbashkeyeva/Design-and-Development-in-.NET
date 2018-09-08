using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public enum Genders
    {
        Female,
        Male
    };
    
    public class Person
    {
        public string firstName;
        public string lastName;
        public int age;
        public Genders gender;
        public Person()
        {

        }
        public Person(string fName, string lName, int age)
        {
            this.firstName = fName;
            this.lastName = lName;
            this.age = age;
        }
        public Person(string fName, string lName, int age, Genders g) : this(fName, lName,age) 
        {
            this.gender = g;
        }


        public override string ToString()
        {
            //return "Person: " + firstName + " " + lastName + " " + age+" "+gender;
            return String.Format("FirstName:{0}, LastName:{1}, age:{2} ,gender:{3}",firstName, lastName,age,gender);
        }
        /*public Person(Genders g) 
        {
            this.gender = g;
        }*/ 
    }
    public class Manager : Person
    {
        public string phoneNumber;
        public string officeLocation;
        public Manager()
        {
        }
        public Manager(string fName, string lName, int age, Genders g, string pN, string oL) : base ( fName, lName,  age,  g  )
        {
            this.phoneNumber = pN;
            this.officeLocation = oL;
        }
        public override string ToString()
        {
            return base.ToString() + " Manager's phonenumber: " + phoneNumber + " officeLocation: " + officeLocation;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Maksat", "Issak", 20);
            p1.gender = Genders.Male;
            Manager m1 = new Manager("Maksat", "Issak", 20, Genders.Male, "87777777777", "Al'-Farabi 17");
            
            Console.WriteLine(p1.ToString());
            Console.WriteLine(m1.ToString());
            Console.ReadKey();


        }
    }
}
