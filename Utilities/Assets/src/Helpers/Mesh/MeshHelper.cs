using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelperPSR.Mesh
{
static public class MeshHelper 
{
    public static void RecalBoundsNormals(UnityEngine.Mesh mesh)
    {
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }
}

}
