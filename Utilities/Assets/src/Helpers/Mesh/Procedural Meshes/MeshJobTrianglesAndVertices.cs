using System.Runtime.CompilerServices;
using HelperPSR.Math.Geometry;
using HelperPSR.Jobs;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;

namespace HelperPSR.Mesh.Generator
{
    public struct MeshJobTrianglesAndVertices
    {
        [NativeDisableContainerSafetyRestriction]
        NativeArray<Vertex> vertices;

        [NativeDisableContainerSafetyRestriction]
        NativeArray<TriangleID> triangles;

        [NativeDisableContainerSafetyRestriction]
        private UnityEngine.Mesh.MeshData meshData;
        public void Setup(UnityEngine.Mesh.MeshData _meshData)
        {
            meshData = _meshData;
            vertices = _meshData.GetVertexData<Vertex>();
            triangles = _meshData.GetIndexData<ushort>().Reinterpret<TriangleID>(2);
        //    JobHelper.Log(triangles.Length);
         //   JobHelper.Log(vertices.Length);
 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetVertex(int _index, Vertex _vertex)
        {
            vertices[_index] = new Vertex()
            {
                Position = _vertex.Position,
                Normal = _vertex.Normal,
                Tangent = _vertex.Tangent,
                TexCoord0 = _vertex.TexCoord0
            };
        }

        public void SetTriangle(int _index, int3 _indices)
        {
            triangles[_index] = _indices;
        //    NativeArray<ushort> nativeArray = meshData.GetIndexData<ushort>();
          //  JobHelper.Log("settriangle"+nativeArray[_index]);
        }
            
    }
}