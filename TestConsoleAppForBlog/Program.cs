namespace TestConsoleAppForBlog
{
	using System;
	using System.Collections.Generic;
	using System.Threading;
	using System.Threading.Tasks;
	using System.Linq;
	using System.Xml.Linq;
	using System.Xml;

	class LargeDataClass
	{
		private long[] data = new long[100000000];

		public void Set(long index, long value)
		{
			data[index] = value;
		}
	}

	class GarbageCollectionTest
	{
		public void MakeSomeGarbage()
		{
			Version vt;

			for (int i = 0; i < 5000; i++)
			{
				// Create objects and release them to fill up memory
				// with unused objects.
				vt = new Version();
			}
		}

	}

	public class UILayout
	{
		public event EventHandler LayoutChanged;
	}

	public class UIElement
	{
		public void Layout_LayoutChanged(object sender, EventArgs e)
		{
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			string UserList = "<Root>" +
				"<UserInfo name=\"KES\" uid=\"1\" cid=\"1\" />" +
				"<UserInfo name=\"KDH\" uid=\"2\" cid=\"1\" />" +
				"<UserInfo name=\"CDK\" uid=\"3\" cid=\"2\" />" +
				"<UserInfo name=\"NDW\" uid=\"4\" cid=\"3\" />" +
				"</Root>";
			string BrandList = "<Root>" +
				"<BrandInfo bid=\"1\" name=\"Hyundai\" />" +
				"<BrandInfo bid=\"2\" name=\"KIA\" />" +
				"<BrandInfo bid=\"3\" name=\"BMW\" />" +
				"<BrandInfo bid=\"4\" name=\"Tesla\" />" +
				"</Root>";
			string CarList = "<Root>" +
				"<CarInfo cid=\"1\" name=\"Genesis G90\" bid=\"1\" />" +
				"<CarInfo cid=\"2\" name=\"스포티지R\" bid=\"2\" />" +
				"<CarInfo cid=\"3\" name=\"Model Y\" bid=\"4\" />" +
				"<CarInfo cid=\"4\" name=\"iX\" bid=\"3\" />" +
				"</Root>";

			string input = "KES";
			XmlDocument xdoc = new XmlDocument();
			xdoc.LoadXml(UserList);
			XmlAttributeCollection xmlAttribute = xdoc.SelectSingleNode("/descendant::Root/UserInfo").Attributes;
			Console.WriteLine($"{xmlAttribute.GetNamedItem("name").Value} {xmlAttribute.GetNamedItem("uid").Value} {xmlAttribute.GetNamedItem("cid").Value}");
		}

		void Test1()
		{
			string input = Console.ReadLine();
			string[] splitInputs = input.Split(",");
			HashSet<int> hashSet = new HashSet<int>();

			foreach (string character in splitInputs)
			{
				int number;

				if (int.TryParse(character, out number))
				{
					if (number % 2 != 0)
					{
						// 홀수
						hashSet.Add(number);
					}
				}
			}
		}

		void Test222()
		{
			string input = Console.ReadLine();
			string[] inputs = input.Split("$");
			int count = 0;

			while (true)
			{
				int index = inputs[0].IndexOf(inputs[1]);

				if (index > -1)
				{
					inputs[0] = inputs[0].Remove(index, inputs[1].Length);
					count++;
				}
				else
				{
					break;
				}
			}

			Console.WriteLine(count + " " + inputs[0]);
		}


		void Test333()
		{
			string input = Console.ReadLine();
			string[] inputs = input.Split(",");
			string result = "true";

			string[] splitInputs = inputs[1].Split(inputs[0]);

			for (int i = 0; i < splitInputs.Length; i++)
			{
				if (i == 0 || i == splitInputs.Length - 1)
				{
					if (!inputs[0].Contains(splitInputs[i]))
					{
						result = "false";
						break;
					}
					continue;
				}

				if (!string.IsNullOrEmpty(splitInputs[i]))
				{
					result = "false";
					break;
				}
			}

			Console.WriteLine(result);
		}































		static void garbargeTest()
		{
			GarbageCollectionTest myGCCol = new GarbageCollectionTest();

			// Determine the maximum number of generations the system
			// garbage collector currently supports.
			Console.WriteLine("The highest generation is {0}", GC.MaxGeneration);

			myGCCol.MakeSomeGarbage();

			// Determine which generation myGCCol object is stored in.
			Console.WriteLine("Generation: {0}", GC.GetGeneration(myGCCol));

			// Determine the best available approximation of the number
			// of bytes currently allocated in managed memory.
			Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(true));

			// Perform a collection of generation 0 only.
			GC.Collect(0);

			// Determine which generation myGCCol object is stored in.
			Console.WriteLine("Generation: {0}", GC.GetGeneration(myGCCol));

			Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(true));

			// Perform a collection of all generations up to and including 2.
			GC.Collect(2);

			// Determine which generation myGCCol object is stored in.
			Console.WriteLine("Generation: {0}", GC.GetGeneration(myGCCol));
			Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(true));
		}

		static void Run()
		{
			var obj = new LargeDataClass();
			obj.Set(1, 10);
		}

		public static void Total()
		{
			Task task1 = Task.Run(() => Test11231323());
			Task task2 = Task.Run(() => Test2());

			List<Task> tasks = new List<Task>();
			tasks.Add(task1);
			tasks.Add(task2);
			Task t = Task.WhenAll(tasks.ToArray());
		}

		public static void Test11231323()
		{
			Thread.Sleep(3000);
			Console.WriteLine("This is Test1 function");
		}

		public static void Test2()
		{
			Thread.Sleep(1000);
			Console.WriteLine("Hello, I'm Test2");
		}



		static List<int> result = new List<int>();
		static int answer = 0;
		static int min = 9;

		public static void calc(int N, int number, int count, int result)
		{
			Console.WriteLine($"{N}, {number}, {count}, {result}");
			if (min < count)
			{
				return;
			}

			if (result == number)
			{
				if (count < min)
				{
					min = count;
				}

				return;
			}

			if (count == 8)
			{
				return;
			}
			else
			{
				int rest = 8 - count;

				for (int i = 1; i <= rest; i++)
				{
					int tailMax = i / 2;

					for (int j = 0; j <= tailMax; j++)
					{
						int head = 0;

						for (int k = 1; k <= i - j; k++)
						{
							head = head * 10 + N;
						}
						int next = head;
						int tail = 0;

						for (int k = 1; k <= j; k++)
						{
							tail = tail * 10 + N;
						}

						if (tail > 0)
						{
							next /= tail;
						}

						calc(N, number, count + i, result + next);
						calc(N, number, count + i, result - next);
						calc(N, number, count + i, result * next);
						calc(N, number, count + i, result / next);
						calc(N, number, count + i, result * -1 * next);
						calc(N, number, count + i, result * -1 / next);
					}

					if (i > 2)
					{
						calc(N, number, count + i, result);
						calc(N, number, count + i, 0);
					}
				}
			}
		}

		public static bool IsPrime(int n)
		{
			int nr = (int)Math.Sqrt(n);
			for (int i = 2; i <= nr; i++)
			{
				if (n % i == 0)
				{
					return false;
				}
			}

			return true;
		}

		public static void RecursionCombination(char[] numberChar, bool[] used, char[] combinationNumChar, int count, int length, int maxCombination)
		{
			if (count == maxCombination)
			{
				result.Add(Int32.Parse(new string(combinationNumChar)));

				return;
			}

			for (int i = 0; i < length; i++)
			{
				if (used[i])
					continue;

				used[i] = true;
				combinationNumChar[count] = numberChar[i];
				RecursionCombination(numberChar, used, combinationNumChar, count + 1, length, maxCombination);
				used[i] = false;
			}
		}

		class StockPrice
		{
			public int KeepTime { get; set; }
			public int Price { get; set; }

			public StockPrice(int price)
			{
				this.Price = price;
			}
		}

		//public static void IndexerExample()
		//{
		//	IndexerExample indexerExample = new IndexerExample(6245, "Gildong Hong", "Third");

		//	PropertyInfo[] properties = indexerExample.GetType().GetProperties();

		//	for (int i = 0; i < properties.Length - 1; i++)
		//	{
		//		Console.WriteLine(indexerExample[i]);
		//	}
		//}
	}
}
