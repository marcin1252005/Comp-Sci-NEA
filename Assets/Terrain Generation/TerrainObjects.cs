using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TerrainObjects : MonoBehaviour
{
    public TerrainGeneration generatedTerrain;
    public DeerAgent deerPrefab;
    public float spawnRadius;
    public int numGroups;
    public int objectsPerGroup;
 
    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects();
    }
    public float GetTerrainHeight(Vector3 position)
    {
        //get bounds of terrain
        Bounds bounds = generatedTerrain.GetMeshColliderBounds();
        //raycast down infinite length from above x and z position
        //until terrain layer hit
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(position.x, bounds.max.y + 100f, position.z),Vector3.down, out hit, Mathf.Infinity, LayerMask.GetMask("terrain")))
        {
            //return point at which terrain hit
            return hit.point.y;
        }
        return 0f;
    }
    public void SpawnObjects()
    {
        //iterate through num of groups
        for (int i = 0; i < numGroups; i++)
        {
            //get bounds
            Bounds bounds = generatedTerrain.GetMeshColliderBounds();
            //generate random x and z coords within bounds
            float randomX = Random.Range(bounds.min.x + spawnRadius, bounds.max.x - spawnRadius);
            float randomZ = Random.Range(bounds.min.z + spawnRadius, bounds.max.z - spawnRadius);
            //center point of each group
            Vector3 centrePoint = new Vector3(randomX, 0, randomZ);

            //iterate through num objects per group
            for (int j = 0; j < objectsPerGroup; j++)
            {
                //generate randon angle
                float angle = Random.Range(0f, Mathf.PI * 2f);
                //generate random distance magnitude < spawnRadius
                float distance = Mathf.Sqrt(Random.Range(0f, 1f)) * spawnRadius;

                //convert points from polar form to cartesian
                float offsetX = Mathf.Cos(angle) * distance;
                float offsetZ = Mathf.Sin(angle) * distance;

                //add offsets to centre point to create random position
                Vector3 randomPosition = centrePoint + new Vector3(offsetX, 0f, offsetZ);

                //get terrain height at random position
                float terrainHeight = GetTerrainHeight(randomPosition);

                //instantiate object at that point
                DeerAgent deerAgent = Instantiate(deerPrefab, new Vector3(randomPosition.x, terrainHeight, randomPosition.z), Quaternion.identity);

            }
        }
    }
}
