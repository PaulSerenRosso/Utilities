using System.Collections;
using System.Collections.Generic;
using HelperPSR.Math.Geometry;
using HelperPSR.Mesh.Generator;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace HelperPSR.Mesh.Generator
{
    public struct QuadGridMeshGenerator : IMeshGenerator
    {
        // index count c'est le nombre de vertices et vertexcount c'est le nombre de point 
        [NativeDisableParallelForRestriction] private NativeArray<QuadID> quadsId;
        [NativeDisableParallelForRestriction] private NativeArray<float3> points;

        //   const float2 firstUVCoord; 
        //   const float2 secondUVCoord; 
        //   const float2 thirdUVCoord; 
        public void SetUp(Vector3[] _points, QuadID[] _quadsId, Bounds _bounds)
        {
            quadsId = new NativeArray<QuadID>(_quadsId.Length, Allocator.TempJob);
            for (int i = 0; i < _quadsId.Length; i++)
            {
                quadsId[i] = _quadsId[i];
            }

            points = new NativeArray<float3>(_points.Length, Allocator.TempJob);
            for (int i = 0; i < _points.Length; i++)
            {
                points[i] = _points[i];
            }

            bounds = _bounds;
        }


        private Bounds bounds;

        public Bounds Bounds
        {
            get => bounds;
        }

        public int VertexCount
        {
            get => quadsId.Length * 4;
        }

        public int IndexCount
        {
            get => quadsId.Length * 6;
        }

        public int JobLength
        {
            get => quadsId.Length;
        }

        public void Execute(int i, MeshJobTrianglesAndVertices _trianglesAndVertices)
        {
            Vertex vertexA = new Vertex();
            QuadID quadID = quadsId[i];

            var quadIDVerticesIndex = quadID.VerticesIndex;
            var pointA = points[quadIDVerticesIndex.x];
            vertexA.Position = pointA;
            vertexA.TexCoord0 = new float2(0, 1);
            vertexA.Normal = new float3(0, 1, 0);
            var indexA = i * 4;
            _trianglesAndVertices.SetVertex(indexA, vertexA);

            Vertex vertexB = new Vertex();
            var pointB =  points[quadIDVerticesIndex.y];
            vertexB.Position = pointB;
            vertexB.TexCoord0 = new float2(1, 1);
            vertexB.Normal = new float3(0, 1, 0);
            var indexB = i * 4 + 1;
            _trianglesAndVertices.SetVertex(indexB, vertexB);

            Vertex vertexC = new Vertex();
            var pointC =  points[quadIDVerticesIndex.z];
            vertexC.Position = pointC;
            vertexC.TexCoord0 = new float2(1, 0);
            vertexC.Normal = new float3(0, 1, 0);
            var indexC = i * 4 + 2;
            _trianglesAndVertices.SetVertex(indexC, vertexC);

            Vertex vertexD = new Vertex();
            var pointD =  points[quadIDVerticesIndex.w];
            vertexD.Position = pointD;
            vertexD.TexCoord0 = new float2(0, 0);
            vertexD.Normal = new float3(0, 1, 0);
            var indexD = i * 4 + 3;
            _trianglesAndVertices.SetVertex(indexD, vertexD);
            
            _trianglesAndVertices.SetTriangle(i * 2,
                new int3(indexA, indexB, indexD));
            _trianglesAndVertices.SetTriangle(i * 2 + 1,
                new int3(indexC, indexD, indexB));
        }
    }
}