using System.Collections;
using System.Collections.Generic;
using HelperPSR.Math.Geometry;
using HelperPSR.Mesh.Generator;
using UnityEngine;

namespace HelperPSR.Math.Geometry.SubdividerInQuads
{
public class SubdividerInQuadsObjectFactory : MonoBehaviour
{
    [SerializeField] private int innerloopBatchCountForQuadGridJob;
    [SerializeField] private GameObject subdividerInQuadsGridPrefab;
    [SerializeField] QuadID[] finalQuadsID;
    public void CreateSubdividerInQuadsObject(Vector3[] _points3D, Bounds _gridBounds, Vector3 _offset,
        Quad2DPosition[] _finalQuads, Vector2[] _points)
    {
        QuadID[] finalQuadsId = MeshGeneratorHelper.GetQuadsID(_finalQuads, _points);
        finalQuadsID = finalQuadsId;
        UnityEngine.Mesh quadGridMesh = MeshGeneratorHelper.GenerateQuadGridMesh(finalQuadsId, _points3D, _gridBounds,
            innerloopBatchCountForQuadGridJob);
        GameObject subdividerInQuadsObject =
            Instantiate( subdividerInQuadsGridPrefab, _gridBounds.center + _offset, Quaternion.identity, transform);
      subdividerInQuadsObject.GetComponent<MeshFilter>().mesh = quadGridMesh;
    }

    public QuadID[] GetFinalQuadID()
    {
        return finalQuadsID;
    }
}
    
}
