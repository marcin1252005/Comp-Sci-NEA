using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Boid/Layer/TerrainLayer")]
public class TerrainLayer : LayerMasking
{
    //reference to the layer
    public LayerMask mask;

    //override parent method
    public override List<Transform> ObjectsInLayer(Boid_Agent agent, List<Transform> allTransforms)
    {
        //create a new list to filter through only obstacles from colliders detected
        List<Transform> obstacles = new List<Transform>();
        //iterate through all transforms
        foreach (Transform transform in allTransforms)
        {
            //bit shift to the layer of the object
            //and check is same layer
            if (mask == (mask | 1 << transform.gameObject.layer))
            {
                //add transform to obstacles list
                obstacles.Add(transform);
            }
        }
        return obstacles;
    }
}
