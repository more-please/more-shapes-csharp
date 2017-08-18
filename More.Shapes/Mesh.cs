using System;
using System.Collections.Generic;

namespace More.Shapes
{
	public class Mesh
	{
		public int VertexCount => Positions.Count / 3;

		public List<int> Indices = new List<int>();
		public List<float> Positions = new List<float>();
		public List<float> Normals = new List<float>();
		//List<float> TexCoords = new List<float>();

		public void AddTri(int i, int j, int k)
		{
			Indices.Add(i, j, k);
		}

		public void AddVertex(float x, float y, float z, float nx, float ny, float nz)
		{
			Positions.Add(x, y, z);
			Normals.Add(nx, ny, nz);
		}
	}
}
