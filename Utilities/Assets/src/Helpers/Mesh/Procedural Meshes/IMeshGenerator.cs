using UnityEngine;

namespace HelperPSR.Mesh.Generator {
	public interface IMeshGenerator
	{
		public Bounds Bounds { get; }
		public int VertexCount
		{
			get;
		}
		public int IndexCount
		{
			get;
		}
		public int JobLength { get; }
		public void Execute (int i, MeshJobTrianglesAndVertices _trianglesAndVertices);
	}
	}