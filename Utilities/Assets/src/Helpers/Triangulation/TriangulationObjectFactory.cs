
using System;
using HelperPSR.Math.Geometry;
using HelperPSR.Mesh.Generator;
using UnityEngine;

namespace HelperPSR.Math.Geometry.Triangulation
{
public class TriangulationObjectFactory : MonoBehaviour
{
    [SerializeField] private int innerloopBatchCount;
    [SerializeField] private GameObject triangulationObjectPrefab;
    private Bounds bounds;
    public void CreateObjectTriangulation(Triangle2DPosition[] _triangles, Vector2[] _points, Vector3[] _points3D, Bounds _bounds,Vector3 _offset )
    {
      TriangleID[]  finalTrianglesId = MeshGeneratorHelper.GetTrianglesID(_triangles, _points);
       UnityEngine.Mesh mesh = MeshGeneratorHelper.GenerateTriangleGridMesh(finalTrianglesId, _points3D, _bounds, innerloopBatchCount);
       GameObject triangulationObject = Instantiate(triangulationObjectPrefab, _offset+_bounds.center, Quaternion.identity, transform);
      triangulationObject.GetComponent<MeshFilter>().mesh = mesh;
    }
}
}
