using System;
using HelperPSR.Jobs;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine;

namespace HelperPSR.Mesh.Generator
{

	[BurstCompile(FloatPrecision.Standard, FloatMode.Fast, CompileSynchronously = true)]
	public struct MeshJob<T> : IJobFor where T :struct, IMeshGenerator
	{
		
		private T generator ;
		
		[WriteOnly]
		MeshJobTrianglesAndVertices trianglesAndVertices;
	

		public MeshJob(T _generator,
			UnityEngine.Mesh _mesh, UnityEngine.Mesh.MeshData _meshData)
		{
			generator = _generator;
			SingleStreamHelper.SetupMeshDataForJobs(
				_meshData,
				_mesh.bounds = generator.Bounds,
				generator.VertexCount,
				generator.IndexCount
			);
	
			trianglesAndVertices = new MeshJobTrianglesAndVertices();
			trianglesAndVertices.Setup(_meshData);
		}
		
		// mettre le constructeur du generator dans le helper

		public void Execute(int i)
		{
			generator.Execute(i, trianglesAndVertices);
		//	NativeArray<Vertex> nativeArray = meshData.GetVertexData<Vertex>();
//			JobHelper.Log("in job"+nativeArray[nativeArray.Length-1].Position);
		} 
		
	}
}
