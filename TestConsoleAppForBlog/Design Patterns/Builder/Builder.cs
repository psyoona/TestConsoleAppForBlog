using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsoleAppForBlog.Design_Patterns.Builder
{
	public interface IBedBuilder
	{
		public void MakeFrame();
		public void MakeMattress();
		public void MakeSheet(string sheet);
		public void MakePillow(int size);

		public Bed Build();
	}

	// Concrete Builder class
	public class Simons : IBedBuilder
	{
		private Bed bed = new Bed();
		private int pillowSize = 0;
		private string sheetName;

		public Bed Build()
		{
			bed.Pillow = "Pillow Size#" + pillowSize;
			bed.Sheet = "Sheet " + sheetName;
			return bed;
		}

		public void MakeFrame()
		{
			bed.Frame = (DateTime.Now.Month > 5 && DateTime.Now.Month < 9) ? "Simons Summer Frame" : "Simons Wood Frame";
		}

		public void MakeMattress()
		{
			bed.Mattress = "Simons Mattress";
		}

		public void MakePillow(int size)
		{
			this.pillowSize = size;
		}

		public void MakeSheet(string sheet)
		{
			this.sheetName = sheet;
		}
	}

	// Product class
	public class Bed
	{
		public string Frame { get; set; }

		public string Mattress { get; set; }

		public string Pillow { get; set; }

		public string Sheet { get; set; }

		public override string ToString()
		{
			return $"{Frame}, {Mattress}, {Pillow}, {Sheet}";
		}
	}

	// Director class
	public class Director
	{
		public Bed Construct(IBedBuilder builder)
		{
			builder.MakeFrame();
			builder.MakeMattress();
			builder.MakeSheet("White");

			return builder.Build();
		}
	}

	// Client
	public class Client
	{
		public void HowToTest()
		{
			IBedBuilder builder = new Simons();
			var director = new Director();
			var bed = director.Construct(builder);
			Console.WriteLine(bed.ToString());
		}
	}
}
