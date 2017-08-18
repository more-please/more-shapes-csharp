using System;
using System.Collections.Generic;

namespace More.Shapes
{
	public class Mesh
	{
		public List<int> Indices = new List<int>();
		public List<float> Positions = new List<float>();
		public List<float> Normals = new List<float>();
		//List<float> TexCoords = new List<float>();

		public void Add(float x, float y, float z, float nx, float ny, float nz)
		{
			Indices.Add(Indices.Count);
			Positions.Add(x, y, z);
			Normals.Add(nx, ny, nz);
		}
	}
}
