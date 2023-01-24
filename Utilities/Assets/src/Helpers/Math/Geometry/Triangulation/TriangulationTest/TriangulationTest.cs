using System;
using System.Collections.Generic;
using HelperPSR.Math.Geometry;
using UnityEngine;

namespace HelperPSR.Math.Geometry.Triangulation
{
[Serializable]
public class TriangulationTest
{
    public bool pointIsVisible;
    public bool currentTriangleAreVisible;
    public bool trianglesChoosenAreVisible; 
    public bool triangleWhichContainCurrentPointIsVisible;
    public bool filteredTrianglesChoosenAreVisible;
    public bool polygonIsVisible;
    public bool trianglesWithoutTrianglesChoosenAreVisible;
    public bool newTrianglesAreVisible;
    [HideInInspector] public Vector2 point;
    [HideInInspector] public List<Triangle2DPosition> currentTriangles;
    public Dictionary<Triangle2DPosition, Circle> trianglesChoosenWithCircle;
    [HideInInspector]
    public List<Triangle2DPosition> trianglesChoosen;
    [HideInInspector]
    public List<Circle> circlesOfTrianglesChoosen;
    [HideInInspector] public List<Segment> polygon;
    [HideInInspector] public List<Triangle2DPosition> trianglesWithoutTrianglesChoosen;
    [HideInInspector] public List<Triangle2DPosition> newTriangles;
    
    [HideInInspector] public List<Triangle2DPosition> filteredTrianglesChoosen;
    [HideInInspector] public Triangle2DPosition  triangleWhichContainCurrentPoint;
    

    public TriangulationTest()
    {
        pointIsVisible = false;
        currentTriangleAreVisible = false;
        trianglesChoosenAreVisible = false;
        polygonIsVisible = false;
        trianglesWithoutTrianglesChoosenAreVisible = false;
        newTrianglesAreVisible = false;
    }
}
}
