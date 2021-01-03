using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
	interface IAction
	{
		void Move();
	}
	class Base : IAction
	{
		public void Move()
		{
			Console.WriteLine("Move in Base");
		}
	}
	class Hero : Base, IAction
	{
		public new void Move()
		{
			Console.WriteLine("Move in Hero");
		}
		void IAction.Move()
		{
			Console.WriteLine("Move in IAction");
		}
	}



	public interface IPrint
	{
		void CanPrint();
	}

	public interface IScan
	{
		void CanScan();
	}

	public interface IShow
	{
		void CanShow();
	}

	public interface ISensory
	{
		void CanTap();
	}

	public interface ITech
	{
		void CanRun();
	}

	public abstract class Product
	{
		public string Manufacturer { get; set; }

		public string MinInfo()
		{
			return Manufacturer;
		}
	}

	public abstract class Technics : Product, ITech
	{
		public string Model { get; set; }

		public Technics(string manufacturer, string model)
		{
			Manufacturer = manufacturer;
			Model = model;
		}

		public void CanRun()
		{
			Console.WriteLine(MinInfo() + " is running...");
		}

		public string Info()
		{
			return Manufacturer + " " + Model;
		}
	}

	class Printer : Technics, IPrint
	{
		public int Ppm { get; set; } //pages per minute

		public Printer(string manufacturer, string model, int ppm)
			: base(manufacturer, model)
		{
			Ppm = ppm;
		}

		public void CanPrint()
		{
			Console.WriteLine(this.Info() + " is printing...");
		}

		public override string ToString()
		{
			return "Printer: " + Manufacturer + " " + Model + ", " + Ppm + " pages per minute.";
		}
	}

	class Scaner : Technics, IScan
	{
		public int Resolution { get; set; }

		public Scaner(string manufacturer, string model, int resolution)
			: base(manufacturer, model)
		{
			Resolution = resolution;
		}

		public void CanScan()
		{
			Console.WriteLine(this.Info() + " is scanning...");
		}

		public override string ToString()
		{
			return "Scaner: " + Manufacturer + " " + Model + ", " + Resolution + " pixels.";
		}
	}

	class Computer : Technics, IShow
	{
		public int Noc { get; set; } //number of cores

		public Computer(string manufacturer, string model, int noc)
			: base(manufacturer, model)
		{
			Noc = noc;
		}

		public void CanShow()
		{
			Console.WriteLine(this.Info() + " is working...");
		}

		public override string ToString()
		{
			return "Computer: " + Manufacturer + " " + Model + ", " + Noc + " cores.";
		}
	}

	sealed class Tablet : Technics, IShow, ISensory
	{
		public int Diagonal { get; set; } //screen diagonal

		public Tablet(string manufacturer, string model, int diagonal)
			: base(manufacturer, model)
		{
			Diagonal = diagonal;
		}

		public void CanShow()
		{
			Console.WriteLine(this.Info() + " is working...");
		}

		public void CanTap()
		{
			Console.WriteLine(this.Info() + " is used...");
		}

		public override string ToString()
		{
			return "Tablet: " + Manufacturer + " " + Model + ", " + Diagonal + "\".";
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Base a1 = new Hero();
			a1.Move();

			IAction a2 = new Hero();
			a2.Move();

			Hero a3 = new Hero();
			a3.Move();

			Console.WriteLine();

			Printer Epson = new Printer("Epson", "L355", 15);
			Console.WriteLine(Epson.ToString());

			Scaner HP = new Scaner("HP", "ScanJet", 1080);
			Console.WriteLine(HP.ToString());

			Computer Intel = new Computer("Epson", "L355", 8);
			Console.WriteLine(Intel.ToString());

			Tablet Huawei = new Tablet("Huawei", "MediaPad", 10);
			Console.WriteLine(Huawei.ToString());

			Console.WriteLine();

			Epson.CanRun();
			Epson.CanPrint();
			HP.CanRun();
			HP.CanScan();
			Intel.CanRun();
			Intel.CanShow();
			Huawei.CanRun();
			Huawei.CanShow();
			Huawei.CanTap();

			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();

			Technics[] tech = new Technics[] { Epson, HP, Intel, Huawei };

			foreach (Technics elem in tech)
			{
				Console.WriteLine(elem.ToString());
				Console.WriteLine("Is product: " + (elem is Product));
				Console.WriteLine("Is technics: " + (elem is Technics));
				Console.WriteLine("Is printer: " + (elem is Printer));
				Console.WriteLine("Is scaner: " + (elem is Scaner));
				Console.WriteLine("Is computer: " + (elem is Computer));
				Console.WriteLine("Is tablet: " + (elem is Tablet));
				Console.WriteLine();
			}
		}
	}
}
