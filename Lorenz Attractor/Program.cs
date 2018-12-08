using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Lorenz_Attractor
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] info;
			Lorenz lorenz = new Lorenz();
			info = lorenz.Render();

			Bitmap bitmap = new Bitmap(Lorenz.sizeX, Lorenz.sizeY);
			for(int height = 0; height < Lorenz.sizeY; height++)
			{
				for (int width = 0; width < Lorenz.sizeX; width++)
				{
					int hitCount = Math.Min(255, info[height * Lorenz.sizeX + width]);
					Color color;
					if (hitCount != 0)
					{
						color = Color.FromArgb(255, (int)hitCount, (int)hitCount, (int)hitCount);
					}
					else
					{
						color = Color.FromArgb(255, 255, 255, 255);
					}

					bitmap.SetPixel(width, height, color);
				}
			}
			Console.WriteLine("Biggest hit: "+Lorenz.biggestHit);
			bitmap.Save("image.png");
			Console.WriteLine("Exported.");
			Console.ReadKey();
			System.Diagnostics.Process.Start("image.png");

		}
	}
}
