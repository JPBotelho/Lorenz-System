using System;
using System.Drawing;
namespace Lorenz_Attractor
{
	class Program
	{
		static void Main(string[] args)
		{
			Lorenz lorenz = new Lorenz();
			int[] histogram = lorenz.Render();

			Bitmap bitmap = new Bitmap(Lorenz.width, Lorenz.height);
			for(int height = 0; height < Lorenz.height; height++)
			{
				for (int width = 0; width < Lorenz.width; width++)
				{
					int hitCount = Math.Min(255, histogram[height * Lorenz.width + width]);
					Color color;

					if (hitCount != 0)
					{
						color = Color.FromArgb(255, hitCount, hitCount, hitCount);
					}
					else
					{
						color = Color.FromArgb(255, 255, 255, 255);
					}

					bitmap.SetPixel(width, height, color);
				}
			}
			bitmap.Save("image.png");
			Console.WriteLine("Exported. Press Any Key to Open.");
			Console.ReadKey();
			System.Diagnostics.Process.Start("image.png");
		}
	}
}
