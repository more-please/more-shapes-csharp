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

			const float yhi = 0.5f;
			const float ylo = -0.5f;

			// Top cap
			{
				int rim = mesh.VertexCount;
				int center = rim + facets;
				for (int i = 0; i < facets; ++i)
					mesh.AddTri(center, rim + i, rim + (i + 1) % facets);

				const float nx = 0, ny = 1, nz = 0;
				for (int i = 0; i < facets; ++i)
					mesh.AddVertex(x[i], yhi, z[i], nx, ny, nz);
				mesh.AddVertex(0, yhi, 0, nx, ny, nz);
			}

			// Sides
			{
				int start = mesh.VertexCount;
				int n = 2 * facets;
				for (int i = 0; i < n; i += 2)
				{
					mesh.AddTri(start + i, start + i + 1, start + (i + 2) % n);
					mesh.AddTri(start + (i + 3) % n, start + (i + 2) % n, start + i + 1);
				}

				var nx = x.Select((_) => 2 * _).ToArray();
				var nz = z.Select((_) => 2 * _).ToArray();
				for (int i = 0; i < facets; ++i)
				{
					mesh.AddVertex(x[i], yhi, z[i], nx[i], 0, nz[i]);
					mesh.AddVertex(x[i], ylo, z[i], nx[i], 0, nz[i]);
				}
			}

			// Bottom cap
			{
				int rim = mesh.VertexCount;
				int center = rim + facets;
				for (int i = 0; i < facets; ++i)
					mesh.AddTri(center, rim + (i + 1) % facets, rim + i);

				const float nx = 0, ny = -1, nz = 0;
				for (int i = 0; i < facets; ++i)
					mesh.AddVertex(x[i], ylo, z[i], nx, ny, nz);
				mesh.AddVertex(0, ylo, 0, nx, ny, nz);
			}

			return mesh;
		}
	}
}
