namespace CoreConsoleApp.Test
{
	using System.Reflection;

	class IndexerExample
	{
		public IndexerExample(int studentNumber, string studentName, string studentGrade)
		{
			this.StudentNumber = studentNumber;
			this.StudentName = studentName;
			this.StudentGrade = studentGrade;
		}
		public int StudentNumber { get; set; }  // index: 0

		public string StudentName { get; set; } // index: 1

		public string StudentGrade { get; set; } // index: 2

		public object this[int index]
		{
			get
			{
				PropertyInfo[] properties = this.GetType().GetProperties();
				return properties[index].GetValue(this);
			}
		}
	}
}
