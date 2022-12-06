using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestConsoleAppForBlog.Test
{
	class Student
	{
		public Student(string name, string groupName)
		{
			this.Name = name;
			this.GroupName = groupName;
		}

		public string Name { get; set; }

		public string GroupName { get; set; }

		public List<string> SubjectList { get; set; }
	}

	class Subject
	{
		public Subject(string subjectName, string groupName)
		{
			this.SujectName = subjectName;
			this.GroupName = groupName;
		}

		public string SujectName { get; set; }

		public string GroupName { get; set; }
	}

	class LinqTest
	{
		public void MakeSubList()
		{
			List<Student> studentList = new List<Student>();
			List<Subject> subjectList = new List<Subject>();

			studentList.Add(new Student("철수", "1"));
			studentList.Add(new Student("영희", "2"));
			studentList.Add(new Student("짱구", "1"));

			subjectList.Add(new Subject("윤리", "1"));
			subjectList.Add(new Subject("사회문화", "1"));
			subjectList.Add(new Subject("윤리", "2"));
			subjectList.Add(new Subject("한국지리", "2"));

			for (int i = 0; i < studentList.Count; i++)
			{
				studentList[i].SubjectList = subjectList.Where(y => y.GroupName == studentList[i].GroupName).Select(x => x.SujectName).ToList();
			}

			Console.WriteLine(studentList);
		}
	}
}
