using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Path/PathSO", fileName = "Path_")]
public class PathSO : ScriptableObject
{
    [HideInInspector] public List<Vector3> waypointsPositions = new List<Vector3>();
    public  GameObject[] gameObjectArray;
    public float minSpeed;
    public float maxSpeed;
    [Min(0f)] public float interval;

    [Tooltip("If true, the path will move back and forth")]
    public bool pingPong = false;
    public bool infiniteSpawning = true;
    public int maxSpawnedObjects;

    public void InitializeWaypointsPositions(List<Transform> waypointsTransforms){
        waypointsPositions.Clear();
        foreach(Transform waypointTransform in waypointsTransforms){
            waypointsPositions.Add(waypointTransform.position);
        }
    }
}
