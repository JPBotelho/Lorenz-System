using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lorenz_Attractor
{
	class Lorenz
	{
		public static int sizeX = 2000, sizeY = 2000;
		public static double a = 10, b = 28, c = 8 / 3;
		public static double timeStep = 0.001;
		public static int iterations = 200000;
		public double x = 0.1, y = 0, z = 0;

		private int[] heatmap;
		public static int biggestHit = 0;

		public Lorenz()
		{
			heatmap = new int[sizeX * sizeY];
		}

		//y * width + x
		public int[] Render()
		{
			for (int i = 0; i < iterations; i++)
			{
				x += timeStep * a * (y - x);
				y += timeStep * (x * (b - z) - y);
				z += timeStep * (x * y - c * z);

				ProcessPoint(x, y, z);
				
				//Console.WriteLine("X: " + Math.Round(x*100) + " Y: " + Math.Round(y*100));
			}
			Console.WriteLine(t + " points escaped.");

			return heatmap;
		}
		static int t;
		private void ProcessPoint(double x, double y, double z)
		{
			int xPixel = (int)Math.Round(x * 40) + sizeX/2;
			int yPixel = (int)Math.Round(y * 40) + sizeY/2;
			int zPixel = (int)Math.Round(z * 40) + sizeY/2;
			if (xPixel <= 0 || xPixel >= sizeX)
			{
				t++;
				return;
			}
			if (yPixel <= 0 || yPixel >= sizeY)
			{
				t++;
				return;
			}

			heatmap[yPixel * sizeX + xPixel]++;

			if(heatmap[yPixel * sizeX + xPixel] > biggestHit)
				biggestHit = heatmap[yPixel * sizeX + xPixel];
		}
	}
}
