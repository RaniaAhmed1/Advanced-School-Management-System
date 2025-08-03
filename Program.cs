using System.Xml.Linq;

namespace Advanced_School__Management_System_OOPandSOLID
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t\t\t\t**************************************");
            Console.WriteLine("\t\t\t\t\t* Advanced School managemaent System *");
            Console.WriteLine("\t\t\t\t\t**************************************");
            Console.ForegroundColor = ConsoleColor.White;

            int choice = 10;
            bool invalidChoice;
            StudentManagement student = new StudentManagement();
            do
            {

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1- Add Student");
                Console.WriteLine("2- Enroll in Course");
                Console.WriteLine("3- Remove Course");
                Console.WriteLine("4- Show Student Info");
                Console.WriteLine("5- Delete Student");
                Console.WriteLine("0- Exit");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();

          
           
           
                Console.Write("Enter your choice: ");
                string checkChoice = Console.ReadLine();

                if (int.TryParse(checkChoice, out int num1) && num1 >= 0)
                {
                    choice = int.Parse(checkChoice);
                    invalidChoice = false;
                }
                else
                {
                    invalidChoice = true;
                }


                if (choice == 1 && !(invalidChoice))       // add student   ********
                {
                   
                    student.addStudent();
                   
                }
         

                else if (choice == 2 && !(invalidChoice))   // enroll a course   *******
                {
                    if (student.students.Count == 0)
                    {
                        Console.WriteLine("ther is no students yet, you have to add student first!");
                        continue;
                    }
                    student.enrollCourse();


                }
   

                else if (choice == 3 && !(invalidChoice))     // remove a course ********
                {
                    if (student.students.Count == 0)
                    {
                        Console.WriteLine("ther is no students yet, you have to add student first!");
                        continue;
                    }
                    student.deleteCourse();
                }

     

                else if (choice == 4 && !(invalidChoice))    // show student information   *********
                {
                    if (student.students.Count == 0)
                    {
                        Console.WriteLine("ther is no students yet, you have to add student first!");
                        continue;
                    }
                    student.showStudentInformation();
                }
          

                else if (choice == 5 && !(invalidChoice))    // delete a student  *******
                {
                    if (student.students.Count == 0)
                    {
                        Console.WriteLine("ther is no students yet, you have to add student first!");
                        continue;
                    }
                    student.deleteStudent();
                }
    
                else if (choice == 0 && !(invalidChoice))   // exit program  ********
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Exiting program...");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }

                else if (choice != 0 && choice != 1 && choice != 2 && choice != 3 && choice != 4 && choice != 5 || (invalidChoice))
                {
                    Console.WriteLine("Invalid choice!");
                }
            }
            while (choice != 0);

        }
    }



    class Student
    {
        #region student_data
        internal int Id { get; set; }
        internal string name { get; set; }
        internal int password { get; set; }
        public Student(int Id, string name, int password)
        {
            this.Id = Id;
            this.name = name;
            this.password = password;
        }

        public List<Courses> courses = new List<Courses>();
        #endregion
    }


    class validateInput
    {
        #region validation_input
        public int validationInputId(string checkInput, List<Student> students)  // a metyod to check for valid input and return student index in list
        {
            bool invalidIdInput;
            int IndexStudent;
            do
            {
                invalidIdInput = false;
                bool found = false, invalidFormat = false; 
                IndexStudent = 0;

                if (!(int.TryParse(checkInput, out int num1) && num1 > 0))
                {
                    invalidFormat = true;
                }

                for (int i = 0; i < students.Count && !(invalidFormat); i++)
                {
                    if (students[i].Id == int.Parse(checkInput))
                    {
                        found = true;
                        IndexStudent = i;
                    }
                }

                if (found)
                    break;
                else
                {
                    Console.WriteLine("Invalid Id!");
                    invalidIdInput = true;
                    Console.Write("Enter a valid student ID: ");
                    checkInput = Console.ReadLine();
                    Console.WriteLine();
                }
            } while (invalidIdInput);

            return IndexStudent;
        }
        #endregion

    }

    class StudentManagement :validateInput
    {
       public List<Student> students = new List<Student>();

        #region add_student
        public void addStudent()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            int studentId = 0, studentPassword = 0;
            string studentName = "";
            bool invalidIdId, invalidName, invalidPassword;
            Console.WriteLine();
            do
            {
                invalidIdId = false;
                bool found = false;
                Console.Write("Enter Student ID: ");
                string checkId = Console.ReadLine();
                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].Id == int.Parse(checkId))
                        found = true;
                }
                if (int.TryParse(checkId, out int num2) && num2 > 0 && !(found))
                    studentId = int.Parse(checkId);
                else
                {
                    Console.WriteLine("Invalid Id!");
                    invalidIdId = true;
                }
            } while (invalidIdId);

            do
            {
                invalidName = false;
                Console.Write("Enter Student Name: ");
                string checkName = Console.ReadLine();
                if (!(string.IsNullOrEmpty(checkName)))
                    studentName = checkName;
                else
                {
                    Console.WriteLine("Invalid Name!");
                    invalidName = true;
                }

            } while (invalidName);

            do
            {
                bool found = false;
                invalidPassword = false;
                Console.Write("Enter Student Password: ");
                string checkPassword = Console.ReadLine();

                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].password == int.Parse(checkPassword))
                        found = true;
                }

                if (int.TryParse(checkPassword, out int num2) && num2 > 0 && !(found))
                    studentPassword = int.Parse(checkPassword);
                else
                {
                    Console.WriteLine("Invalid Password!");
                    invalidPassword = true;
                }

            } while (invalidPassword);

            students.Add(new Student(studentId, studentName, studentPassword));
            Console.WriteLine("\nStudent Added Successfully!\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        #endregion


        #region show_info
        public void showStudentInformation()
        {
            Console.Write("Enter student ID to show information: ");
            string checkId = Console.ReadLine();
            Console.WriteLine();
            int IndexStudentToShowInfo = validationInputId(checkId, students);
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            displayStudentInfo studentInfo = new displayStudentInfo();
            studentInfo.print(students[IndexStudentToShowInfo]);
            Console.ForegroundColor = ConsoleColor.White;
        }
        #endregion


        #region delete_student
        public void deleteStudent()
        {

            Console.Write("\nEnter student ID to delete: ");
            string checkId = Console.ReadLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            int IndexStudentToDelete = validationInputId(checkId, students);

            students.Remove(students[IndexStudentToDelete]);
            Console.WriteLine("Student deleted successfully!\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        #endregion


        #region enroll_course
        public void enrollCourse()
        {
            Console.Write("Enter Studend ID to add course: ");
            string checkId = Console.ReadLine();
            Console.WriteLine();

            int IndexStudentToAddCourse = validationInputId(checkId,students);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("ID\t\tCourse Name\t\tDuration\n");
            Console.WriteLine("101\t\tAlgbra\t\t\t50 min");
            Console.WriteLine("105\t\tPhysics\t\t\t60 min");
            Console.WriteLine("108\t\tIT\t\t\t60 min");
            Console.WriteLine("106\t\tCalculus\t\t15 min");
            Console.WriteLine("104\t\tProgramming\t\t30 min");
            Console.WriteLine();

            Console.Write("Enter Course Id To Add: ");
            int IdAddCourse = int.Parse(Console.ReadLine());
            int contiueOrStop = 0;
            bool repeated = false;
            do
            {
                repeated = false;
                for (int i = 0; i < (students[IndexStudentToAddCourse].courses).Count; i++)
                {
                    if (students[IndexStudentToAddCourse].courses[i].courseId == IdAddCourse)
                    {
                        Console.WriteLine("This course is already enrolled!");
                        repeated = true;
                    }
                }

                if (IdAddCourse == 101 && !(repeated))
                {
                    students[IndexStudentToAddCourse].courses.Add(new Algbra());
                    Console.WriteLine("Course Added successfully!");
                }
                else if (IdAddCourse == 105 && !(repeated))
                {
                    students[IndexStudentToAddCourse].courses.Add(new Physics());
                    Console.WriteLine("Course Added successfully!");
                }
                else if (IdAddCourse == 108 && !(repeated))
                {
                    students[IndexStudentToAddCourse].courses.Add(new IT());
                    Console.WriteLine("Course Added successfully!");
                }
                else if (IdAddCourse == 106 && !(repeated))
                {
                    students[IndexStudentToAddCourse].courses.Add(new Calculus());
                    Console.WriteLine("Course Added successfully!");
                }
                else if (IdAddCourse == 104 && !(repeated))
                {
                    students[IndexStudentToAddCourse].courses.Add(new Programming());
                    Console.WriteLine("Course Added successfully!");
                }
                else if (IdAddCourse != 101 && IdAddCourse != 105 && IdAddCourse != 108 && IdAddCourse != 106 && IdAddCourse != 104)
                    Console.WriteLine("Invalid Course Id!");

                Console.Write("\nEnter 1 to add another course , any number to stop: ");
                contiueOrStop = int.Parse(Console.ReadLine());
                Console.WriteLine();
                if (contiueOrStop == 1)
                {
                    Console.Write("Enter Course Id To Add: ");
                    IdAddCourse = int.Parse(Console.ReadLine());
                }

            } while (contiueOrStop == 1);
            Console.ForegroundColor = ConsoleColor.White;
        }

        #endregion


        #region delete_course
        public void deleteCourse()
        {
            Console.Write("Enter student ID to remove course: ");
            string checkId = Console.ReadLine();
            Console.WriteLine();
            int IndexStudentToRemove = validationInputId(checkId, students);
            Console.ForegroundColor = ConsoleColor.Magenta;


            displayStudentInfo studentInfo = new displayStudentInfo();
            studentInfo.print(students[IndexStudentToRemove]);


            if (students[IndexStudentToRemove].courses.Count == 0)
            {
                Console.WriteLine("No courses enrolled yet!");
            }
            else
            {
                Console.Write("Enter course Id to remove: ");
                int IdRemoveCourse = int.Parse(Console.ReadLine());
                int contiueOrStop = 0;

                do
                {
                    bool found = false;
                    int indexCourseToRemove = 0;
                    for (int i = 0; i < students[IndexStudentToRemove].courses.Count; i++)
                    {
                        if (students[IndexStudentToRemove].courses[i].courseId == IdRemoveCourse)
                        {
                            indexCourseToRemove = i;
                            students[IndexStudentToRemove].courses.Remove(students[IndexStudentToRemove].courses[indexCourseToRemove]);
                            Console.WriteLine("\nCourse removed successfully!");
                            found = true;
                        }
                    }


                    if (!(found))
                        Console.WriteLine("Invalid Course Id!");


                    Console.Write("\nEnter 1 to remove another course , any number to stop: ");
                    contiueOrStop = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    if (contiueOrStop == 1 && students[IndexStudentToRemove].courses.Count > 0)
                    {
                        Console.Write("Enter Course Id To remove: ");
                        IdRemoveCourse = int.Parse(Console.ReadLine());
                    }
                    else
                    {
                        if (students[IndexStudentToRemove].courses.Count <= 0)
                        {
                            Console.WriteLine("there is no more courses enrolled!");
                            break;
                        }
                        else
                            break;

                    }

                } while (contiueOrStop == 1);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        #endregion

    }


    class displayStudentInfo
    {
        #region display_student_info
        public void print(Student student)
        {
            Console.WriteLine($"Student Name: {student.name}");
            Console.WriteLine($"Student ID: {student.Id}");
            Console.WriteLine($"Student Password: {student.password}");
            Console.WriteLine("Enrolled courses = " + student.courses.Count + "\n");
            for (int i = 0; i < student.courses.Count; i++)
            {
                Console.Write("ID: " + student.courses[i].courseId + ", " + "Name: " + student.courses[i].courseName + ", " + "Duration: " + student.courses[i].courseCredits + " min");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        #endregion
    }


    interface Courses
    {
        #region courses_data
        public int courseId { get; }
        public string courseName { get; }
        public int courseCredits { get; }
        #endregion
    }

    class Algbra : Courses
    {
        #region algebra_data
        public int courseId
        {
            get { return 101; }
        }
        public string courseName
        {
            get { return "Algebra"; }
        }
        public int courseCredits
        {
            get { return 50; }
        }
        #endregion
    }

    class Physics : Courses
    {
        #region physics_data
        public int courseId
        {
            get { return 105; }
        }
        public string courseName
        {
            get { return "physics"; }
        }
        public int courseCredits
        {
            get { return 60; }
        }
        #endregion
    }

    class IT : Courses
    {
        #region IT_data
        public int courseId
        {
            get { return 108; }
        }
        public string courseName
        {
            get { return "IT"; }
        }
        public int courseCredits
        {
            get { return 90; }
        }
        #endregion
    }

    class Calculus : Courses
    {
        #region calculus_data
        public int courseId
        {
            get { return 106; }
        }
        public string courseName
        {
            get { return "calculus"; }
        }
        public int courseCredits
        {
            get { return 15; }
        }
        #endregion
    }

    class Programming : Courses
    {
        #region programming_data
        public int courseId
        {
            get { return 104; }
        }
        public string courseName
        {
            get { return "programming"; }
        }
        public int courseCredits
        {
            get { return 30; }
        }
        #endregion
    }
}

