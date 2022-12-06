namespace TestConsoleAppForBlog.Test
{
	using System;
	using System.Reflection;

	class TypeTestClass
	{
		public TypeTestClass()
		{
			PropertyClass propertyClass = new PropertyClass();
			PropertyInfo[] properties = propertyClass.GetType().GetProperties();

			Console.WriteLine("Properties...");
			foreach (var property in properties)
			{
				Console.WriteLine(property.Name);
			}

			MemberClass memberClass = new MemberClass();
			MemberInfo[] members = memberClass.GetType().GetMembers();

			Console.WriteLine("\nMembers...");
			foreach (var member in members)
			{
				Console.WriteLine(member.Name);
			}

			FieldClass fieldClass = new FieldClass();
			FieldInfo[] fields = fieldClass.GetType().GetFields();

			Console.WriteLine("\nFields...");
			foreach (var field in fields)
			{
				Console.WriteLine(field.Name);
			}
		}
	}

	class PropertyClass
	{
		public int StudentNo { get; set; }

		public string StudentName { get; set; }

		public string StudentPhone { get; set; }

		public string StudentGender { get; set; }
	}

	class MemberClass
	{
		public int StudentNo { get; set; }

		public string StudentName { get; set; }

		public string StudentPhone { get; set; }

		public string StudentGender { get; set; }

		public int productNo;

		public string productName;

		public DateTime productDate;

		public int productPrice;
	}

	class FieldClass
	{
		public int productNo;

		public string productName;

		public DateTime productDate;

		public int productPrice;
	}
}
