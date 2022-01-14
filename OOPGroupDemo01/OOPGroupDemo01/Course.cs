using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;
namespace OOPGroupDemo01
{
    internal class Course
    {
        #region Readonly data fields
        
        public readonly string CourseNo;
        public readonly string CourseName;
        public readonly List<string> Students = new List<string>();
       

        #endregion

        #region Readonly property
        public int StudentCount
        {
            get { return Students.Count; }
        }
        #endregion

        #region Constructors
        public Course(string courseNo, string courseName)
        {
            
            //validate that courseNo is not null, 
            //or an empty string
            //must contain exactly 8 characters
            //where the first four characters are letters and the last 4 are numbers
            if(string.IsNullOrEmpty(courseNo))
            {
                throw new ArgumentNullException("CourseNo is required. ");
            }
            if(courseNo.Length != 8)
            {
                throw new ArgumentException("CourseNo must contain exactly 8 charaters. ");
            }


            CourseNo = courseNo;

            //validate that courseNAme is not null or an empty string,
            //
            if(string.IsNullOrEmpty(courseName))
            {
                throw new ArgumentNullException("Course name is required. ");
            }

            CourseName = courseName;
        }
        #endregion

        #region Instance level methods
        public void AddStudent(string name)
        {
            Students.Add(name);
        }
        public void RemoveStudent(string name)
        {
            Students.Remove(name);
        }

        public bool SaveToFile(string filePath)
        {
            bool success = false;
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))    //"using" will auto close the writer but a good habit to get into is to manually close writer
                {
                    //Write the course number and name to a file
                    writer.WriteLine($"{CourseNo}");
                    writer.WriteLine($"{CourseName}");
                    //Write the name of all students in the course
                    foreach (var student in Students)
                    {
                        writer.WriteLine(student);
                    }
                    writer.Close(); //manually closing writer
                    success = true;
                }
            }
            catch
            {
                success = false;
            }
            

            return success;

        }
        

        public bool LoadFromFile(string filePath)
        {
            bool success = false;
            //Read from file 
            try
            {
                using(StreamReader reader = new StreamReader(filePath))
                {
                    //Read the CourseNo and CourseName from the file
                    var CourseNo = reader.ReadLine();
                    var CourseName = reader.ReadLine();
                    //read the student names from the list
                    while(reader.EndOfStream == false)
                    {
                        string? lineData = reader.ReadLine();
                        if(lineData!=null)
                        {
                            Students.Add(lineData);
                        }
                        //Students.Add(reader.ReadLine());
                    }
                }
                success = true;
            }
            catch
            {
                success=false;
            }
            return success;
        }

        #endregion

    }


}

