using System;

namespace Lorenz_Attractor
{
	//Renders XY or XZ axes.
	//We need to separate these two cases because we need to adjust the position of the Y values to fit the bitmap, but the Z values are already adjusted.
	public enum RenderType
	{
		XY,
		XZ
	}

	class Lorenz
	{
		public static int width = 2000, height = 2000;
		public static double a = 10, b = 28, c = 8 / 3;
		public static double timeStep = 0.001;
		public static int iterations = 25000000;
		public double x = 0.1, y = 0, z = 0;

		private int[] histogram;
		public static int biggestHit = 0;

		public Lorenz()
		{
			histogram = new int[width * height];
		}

		public int[] Render()
		{
			DateTime startTime = System.DateTime.Now;
			for (int i = 0; i < iterations; i++)
			{
				x += timeStep * a * (y - x);
				y += timeStep * (x * (b - z) - y);
				z += timeStep * (x * y - c * z);

				//Second parameter is either Z or Y, depending on RenderType param
				ProcessPoint(x, y, RenderType.XY);
			}
			Console.WriteLine(t + " points were out of bounds.");
			double secondsElapsed = DateTime.Now.Subtract(startTime).TotalSeconds;
			Console.WriteLine(iterations + " points computed in " + secondsElapsed + "s");
			Console.WriteLine("Biggest hit: " + biggestHit);

			return histogram;
		}
		static int t;
		private void ProcessPoint(double x, double y, RenderType type)
		{
			//37 is a magic number to scale the values to the image bounds
			//Since i'm not quite sure the variation of values of the lorenz system, I eyeballed it and saw that 37 works well for a 2000*2000 image.
			int isXY = Convert.ToInt32(type == RenderType.XY);
			int xPixel = (int)Math.Round(x * 37) + width/2;
			//Only scale if rendering XY axes.
			int yPixel = (int)Math.Round(y * 37) + (height/2) * isXY;

			//Bounds check
			if (xPixel <= 0 || xPixel >= width)
			{
				t++;
				return;
			}
			if (yPixel <= 0 || yPixel >= height)
			{
				t++;
				return;
			}

			//Storing 2D of data in a 1D array, y * width + x
			int index = yPixel * width + xPixel;
			histogram[index]++;

			int currentHitCount = histogram[index] + 1;
			if (currentHitCount > biggestHit)
				biggestHit = currentHitCount;
		}
	}
}
