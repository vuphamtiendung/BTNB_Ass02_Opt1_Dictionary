using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace BTNB_Ass02_Opt1_v02
{
    internal abstract class Employeer
    {
        private int _id;
        private string _name;
        private double _allowance;
        private double _coefficientSalary;
        private string _department;
        private bool _role;

        public int Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } } 
        public double Allowance { get { return _allowance; } set { _allowance = value; } }
        public double CoefficientSalary { get { return _coefficientSalary; } set { _coefficientSalary = value; } }  
        public string Department { get { return _department; } set { _department = value; } } 
        public bool Role { get { return _role; } set { _role = value; } }

        public Employeer()
        {
            _id = 0;
            _name = " ";
            _allowance = 0;
            _coefficientSalary = 0;
            _department = " ";
        }

        public Employeer(int id, string name, double allowance, double coefficient, string department)
        {
            _id = id;
            _name = name;
            _allowance = allowance;
            _coefficientSalary = coefficient;
            _department = department;
        }

        public virtual string InputInfo(string message)
        {
            WriteLine(message);
            return ReadLine();
        }

        public virtual void InputEmployee()
        {
            _id = Convert.ToInt32(InputInfo(DisplayConstant.INPUT_ID));
            _name = InputInfo(DisplayConstant.INPUT_NAME);
            _allowance = Convert.ToDouble(InputInfo(DisplayConstant.INPUT_ALLOWANCE));
            _coefficientSalary = Convert.ToDouble(InputInfo(DisplayConstant.INPUT_COEFFICIENTSALARY));
            _department = InputInfo(DisplayConstant.INPUT_DEPARTMENT);
        }
        public abstract double Income();

        public virtual void DisplayEmployee()
        {
            WriteLine(DisplayConstant.OUTPUT_ID, _id);
            WriteLine(DisplayConstant.OUTPUT_NAME, _name);
            WriteLine(DisplayConstant.OUTPUT_ALLOWANCE, _allowance);
            WriteLine(DisplayConstant.OUTPUT_COEFFICIENT_SALARY, _coefficientSalary);
            WriteLine(DisplayConstant.OUTPUT_INCOME, Income());
            WriteLine(DisplayConstant.OUTPUT_DEPARTMENT, _department);
        }

    }
}
