using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public abstract class  Human
    {
        public abstract string Name { get; set; }
        public abstract int Age { get; set; }
        public abstract string Gender { get; set; }
        public abstract void Print();
    }
    ///////////////////////////////////////
    public abstract class Employee : Human
    {
        private string name;
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int age;
        public override int Age
        {
            get { return age; }
            set { if (value > 18) age = value; }
        }

        private string gender;
        public override string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        private int salary;
        public int Salary
        {
            get { return salary; }
            set { if (value >= 0) salary = value; }
        }

        private int experience;
        public int Experience
        {
            get { return experience; }
            set { if (value >= 0) experience = value; }
        }

        public abstract int Calc_Salary();

        public override void Print()
        {
            Console.WriteLine($"Имя - [{name}] | Возраст - [{age}] | Пол - [{gender}] | Стаж - [{experience}] | Оклад - [{salary}]");
        }
    }
    public class Director : Employee
    {
        public Director()
        {
            Name = "Undefined";
            Age = 100;
            Gender = "Undefined";
            Patronymic = "Undefined";
            Salary = 0;
            Experience = 0;
        }
        public Director(string name, string patronymic, int age, string gender, int salary, int experience)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Patronymic = patronymic;
            Salary = salary;
            Experience = experience;
        }

        private string patronymic;
        public string Patronymic
        {
            get { return patronymic; }
            set { patronymic = value; }
        }
        public override void Print()
        {
            Console.WriteLine($"Имя - {Name} | Отчество - [{patronymic}] | Возраст - [{Age}] | Пол - [{Gender}] | Стаж - [{Experience}] | Оклад - [{Salary}]");
        }
        public override int Calc_Salary()
        {
            double period_of_service = this.Experience > 20 ? 0.20 : this.Experience * 0.01;
            return (int)Math.Round(period_of_service * this.Salary + this.Salary);
        }
    }
    public class Worker : Employee
    {
        public Worker()
        {
            Name = "Undefined";
            Age = 100;
            Gender = "Undefined";
            Post = "undefined";
            Salary = 0;
            Experience = 0;
        }
        public Worker(string name, int age, string gender, string post, int salary, int experience)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Post = post;
            Salary = salary;
            Experience = experience;
        }

        private string post;
        public string Post
        {
            get { return post; }
            set { post = value; }
        }
        public override void Print()
        {
            Console.WriteLine($"Имя - {Name} | Возраст - [{Age}] | Пол - [{Gender}] | Должность - [{Post}] | Стаж - [{Experience}] | Оклад - [{Salary}]");
        }
        public override int Calc_Salary()
        {
            double period_of_service;
            if (this.Experience < 5)
                period_of_service = this.Experience * 0.01;
            else if (this.Experience == 5)
                period_of_service = 0.05;
            else if (this.Experience > 5 && this.Experience < 10)
                period_of_service = this.Experience * 0.01 + 0.05;
            else
                period_of_service = 0.1;
            return (int)Math.Round(period_of_service * this.Salary + this.Salary);
        }
    }
    ///////////////////////////////////////
    public abstract class Learner : Human
    {
        private string name;
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int age;
        public override int Age
        {
            get { return age; }
            set { if (value > 7) age = value; }
        }

        private string gender;
        public override string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public override void Print()
        {
            Console.WriteLine($"Имя - [{name}] | Возраст - [{age}] | Пол - [{gender}] | Специальность - [{specialization}]");
        }
    }
    public class Schoolboy : Learner
    {
        public Schoolboy()
        {
            Name = "Undefined";
            Age = 100;
            Gender = "Undefined";
            Clas = 0;
        }
        public Schoolboy(string name, int age, string gender, int clas)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Clas = clas;
        }

        public override int Age
        {
            get { return Age; }
            set { if (value > 7 && value < 18) Age = value; }
        }
        private int clas;
        public int Clas
        {
            get { return clas; }
            set { if(value >= 0 && value < 11) clas = value; }
        }
        public override void Print()
        {
            Console.WriteLine($"Имя - [{Name}] | Возраст - [{Age}] | Пол - [{Gender}] | Класс - [{Clas}]");
        }
    }
    public class Student : Learner
    {

    }
}
