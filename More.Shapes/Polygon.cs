using System;

namespace More.Shapes
{
	public static class Polygon
	{
		//
		// Create a flat polygon in the xy plane.
		// The vertex data winds counterclockwise in xy (Box2D's convention).
		// Normals are (0, 0, nz). Winding in 3D is clockwise (Urho's convention).
		//
		public static Mesh Create(int sides, float radius = 0.5f, float nz = 1)
		{
			var mesh = new Mesh();

			for (int i = 0; i < sides; ++i)
			{
				var angle = (i * 2 * Math.PI) / sides;
				mesh.AddVertex(
					x: (float)(radius * Math.Cos(angle)),
					y: (float)(radius * Math.Sin(angle)),
					z: 0, nx: 0, ny: 0, nz: nz);
			}

			for (int i = 2; i < sides; ++i)
				mesh.AddTri(0, i - 1, i);

			if (nz < 0)
				mesh.Indices.Reverse();

			return mesh;
		}
	}
}
