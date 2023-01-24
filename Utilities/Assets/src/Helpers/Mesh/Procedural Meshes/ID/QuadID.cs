using System;
using System.Collections;
using System.Collections.Generic;
using HelperPSR.Math.Geometry;
using HelperPSR.Mesh.Generator;
using Unity.Mathematics;
using UnityEngine;
[Serializable]

public struct QuadID
{
   
    public int4 VerticesIndex;

    public QuadID( int4 verticesIndex)
    {
        VerticesIndex = verticesIndex;
    }

}
