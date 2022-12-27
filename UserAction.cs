using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace BTNB_Ass02_Opt1_v02
{
    internal class UserAction
    {
        public Teacher teacher = null;
        public Employee employee = null;

        public Dictionary<int, Teacher> DicTeacher = new Dictionary<int, Teacher>();
        public Dictionary<int, Employee> DicEmployee = new Dictionary<int, Employee>();

        public static UserAction useraction;
        public UserAction() { }
        public static UserAction GetUserAction()
        {
            if (useraction == null)
            {
                useraction = new UserAction();
            }
            return useraction;
        }

        public string InputInfo(string message)
        {
            WriteLine(message);
            return ReadLine();
        }

        public enum Options
        {
            InputEmployee = 1,
            FindEmployee = 2,
            SoftAndDisplay = 3,
            Exit = 4
        };

        public void FindEmploy()
        {
            string name = InputInfo(DisplayConstant.INPUT_FINDNAME);
            string department = InputInfo(DisplayConstant.INPUT_FINDDEPARTMENT);

            foreach(KeyValuePair<int, Teacher> list in DicTeacher)
            {
                if(list.Value.Name == name && list.Value.Department == department)
                {
                    WriteLine($"{list.Key} - {list.Value.Name} - {list.Value.Allowance} - {list.Value.CoefficientSalary} - {list.Value.Income()} - {list.Value.Department}");
                }
            }

            foreach (KeyValuePair<int, Employee> list in DicEmployee)
            {
                if(list.Value.Name == name.ToLower() && list.Value.Department == department.ToLower())
                {
                    WriteLine($"{list.Key} - {list.Value.Name} - {list.Value.Allowance} - {list.Value.CoefficientSalary} - {list.Value.Income()} - {list.Value.Department}");
                }
            }
        }

        public void DisplayEmploy()
        {
            var softListTeacher = DicTeacher.OrderBy(x => x.Value.Name)
                                            .ThenBy(x => x.Value.Income())
                                            .ToList();
            var softListEmploy = DicEmployee.OrderBy(x => x.Value.Name)
                                            .ThenBy(x => x.Value.Income())
                                            .ToList();

            foreach(KeyValuePair<int, Teacher> list in softListTeacher)
            {
                WriteLine($"{list.Key} - {list.Value.Name} - {list.Value.Allowance} - {list.Value.CoefficientSalary} - {list.Value.Income()} - {list.Value.Department}");
            }
            WriteLine();
            foreach (KeyValuePair<int, Employee> list in softListEmploy)
            {
                WriteLine($"{list.Key} - {list.Value.Name} - {list.Value.Allowance} - {list.Value.CoefficientSalary} - {list.Value.Income()} - {list.Value.Department}");
            }
        }

        public void Perform()
        {
            Options option;
            do
            {
                WriteLine(DisplayConstant.INPUT_EMPLOYEE_INFO);
                WriteLine(DisplayConstant.MENU_START);
                WriteLine(DisplayConstant.MENU_CREATE_EMPLOYEE);
                WriteLine();
                WriteLine(DisplayConstant.MENU_INFOR_INCOME_EMPLOYEE);
                WriteLine();
                WriteLine(DisplayConstant.MENU_DETAIL_ALLOWANCE_TEACHER);
                WriteLine();
                WriteLine(DisplayConstant.MENU_DETAIL_ALLOWANCE_MANAGER);
                WriteLine();
                WriteLine(DisplayConstant.MENU_FIND);
                WriteLine();
                WriteLine(DisplayConstant.MENU_DISPLAY_EMPLOYEE);
                WriteLine();
                WriteLine(DisplayConstant.MENU_EXIT);
                WriteLine(DisplayConstant.END_OF_PAGE_MESSAGE);

                Enum.TryParse(ReadLine(), out option);

                switch (option)
                {
                    case Options.InputEmployee:
                        {
                            try
                            {
                                bool choose = Boolean.TryParse(InputInfo(DisplayConstant.INPUT_ROLE), out choose);
                                if (choose == true)
                                {
                                    teacher = new Teacher();
                                    teacher.InputEmployee();
                                    DicTeacher.Add(teacher.Id, teacher);
                                }
                                else if (choose == false)
                                {
                                    employee = new Employee();
                                    employee.InputEmployee();
                                    DicEmployee.Add(employee.Id, employee);
                                }
                            }
                            catch(Exception ex)
                            {
                                WriteLine(ex.ToString());
                            }
                            break;
                        }
                    case Options.FindEmployee:
                        {
                            FindEmploy();
                            break;
                        }
                    case Options.SoftAndDisplay:
                        {
                            DisplayEmploy();
                            break;
                        }
                }
            }
            while (option != Options.Exit);
        }
    }
}
