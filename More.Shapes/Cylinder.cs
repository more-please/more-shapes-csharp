using System;
using System.Collections.Generic;
using System.Linq;

namespace More.Shapes
{
	public static class Cylinder
	{
		public static Mesh Create(int facets)
		{
			Mesh mesh = new Mesh();

			// Calculate x/z coordinates around the rim
			var x = new List<float>();
			var z = new List<float>();
			for (int i = 0; i < facets; ++i)
			{
				var phi = (i * 2 * Math.PI) / facets;
				x.Add((float)Math.Sin(phi) / 2);
				z.Add((float)Math.Cos(phi) / 2);
			}
			x.Add(x[0]);
			z.Add(z[0]);

			float yhi = 0.5f;
			float ylo = -0.5f;

			// Top cap
			{
				float nx = 0, ny = 1, nz = 0;
				for (int i = 0; i < facets; ++i)
				{
					mesh.Add(0, yhi, 0, nx, ny, nz);
					mesh.Add(x[i], yhi, z[i], nx, ny, nz);
					mesh.Add(x[i + 1], yhi, z[i + 1], nx, ny, nz);
				}
			}

			// Sides
			{
				var nx = x.Select((_) => 2 * _).ToArray();
				var nz = z.Select((_) => 2 * _).ToArray();
				for (int i = 0; i < facets; ++i)
				{
					mesh.Add(x[i], yhi, z[i], nx[i], 0, nz[i]);
					mesh.Add(x[i], ylo, z[i], nx[i], 0, nz[i]);
					mesh.Add(x[i + 1], yhi, z[i + 1], nx[i + 1], 0, nz[i + 1]);

					mesh.Add(x[i + 1], ylo, z[i + 1], nx[i + 1], 0, nz[i + 1]);
					mesh.Add(x[i + 1], yhi, z[i + 1], nx[i + 1], 0, nz[i + 1]);
					mesh.Add(x[i], ylo, z[i], nx[i], 0, nz[i]);
				}
			}

			// Bottom cap
			{
				float nx = 0, ny = -1, nz = 0;
				for (int i = 0; i < facets; ++i)
				{
					mesh.Add(0, ylo, 0, nx, ny, nz);
					mesh.Add(x[i + 1], ylo, z[i + 1], nx, ny, nz);
					mesh.Add(x[i], ylo, z[i], nx, ny, nz);
				}
			}
			return mesh;
		}
	}
}
