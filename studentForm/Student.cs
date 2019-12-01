using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace studentForm
{
    class Student
    {
        public string name { get; set; }
        public string ID { get; set; }
        public decimal cgpa { get; set; }
        public int semester { get; set; }
        public string dept { get; set; }
        public string uni { get; set; }
        public string attendance { get; set; }

        public void CreateNewProfile(string filePath)
        {
            StreamWriter newFile;
            newFile = File.AppendText(filePath);
            newFile.WriteLine(name.ToString());
            newFile.WriteLine(ID.ToString());
            newFile.WriteLine(cgpa.ToString());
            newFile.WriteLine(semester.ToString());
            newFile.WriteLine(dept.ToString());
            newFile.WriteLine(uni.ToString());
            newFile.WriteLine(attendance.ToString());
            newFile.Close();
        }

        public void deleteRecord(string filePath, List<Student> newlist)
        {
            File.WriteAllText(filePath, string.Empty);
        }

    }
}
