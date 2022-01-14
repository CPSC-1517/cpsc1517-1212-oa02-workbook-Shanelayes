// See https://aka.ms/new-console-template for more information

using OOPGroupDemo01;
using static System.Console; // Allows you to use the static methods in console class directly


//design a class named course that has:
//CourseNo:string
//CourseName:string
//Students:[string]
//Course(courseNo: string, courseName:string)
//AddStudent(student:string)
//DropStudent(student:string)
//StudentCount():int


Course cpsc1517Course = new Course("CPSC1517", "Introduction to application development");

//var Course cpsc1517Course = new Course("CPSC1517", "Introduction to application development"); var is letting the compiler choose a data type. 
                                                                                                //useful if your unsure which data type was used

//Course cpsc1517Course = new ("CPSC1517", "Introduction to application development");

WriteLine($"CourseNo: {cpsc1517Course.CourseNo}");
WriteLine($"CourseName: {cpsc1517Course.CourseName}");
WriteLine("");
//Add students to the course 
//cpsc1517Course.AddStudent("Aaron Fong");
//cpsc1517Course.AddStudent("David L. Mckinley");
//cpsc1517Course.AddStudent("Hamza Said");
//cpsc1517Course.AddStudent("James Skrlj");
//cpsc1517Course.AddStudent("Haseeb Memon");

cpsc1517Course.LoadFromFile(@"");//loads from file


//Display all the students in the course 
foreach (var student in cpsc1517Course.Students)
{
    WriteLine(student);
}
WriteLine("");
//remove 2 students from the course
WriteLine("Enter student name to remove: ");

cpsc1517Course.RemoveStudent("Hamza Said");
cpsc1517Course.RemoveStudent("Haseeb Memon");

cpsc1517Course.SaveToFile("cpsc1517.csv"); //saves to file

//display the number of students 
WriteLine($"There are now {cpsc1517Course.StudentCount} students.");
WriteLine("");
foreach(var student in cpsc1517Course.Students)
{
    WriteLine(student);
}