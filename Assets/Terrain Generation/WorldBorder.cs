using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBorder : MonoBehaviour
{
    private Dictionary<Transform, Vector3> originalVelocity = new Dictionary<Transform, Vector3>();
    public TerrainGeneration terrainGeneration;
    public BoxCollider boxCollider;
    private void Start()
    {
        Bounds bounds = terrainGeneration.GetMeshColliderBounds();
        Vector3 scale = bounds.size;
        //set position to centre of generated terrain
        boxCollider.transform.position = bounds.center;
        //set scale to size of terrain
        scale.y += 300f;
        //increase height of collider
        boxCollider.transform.localScale = scale;
    }
}
