using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Boid/Layer/Boid")]
//create new submenu for layer assets

public class boidLayer : LayerMasking
//inherit layer masking class
{
    //override layer parent method
    public override List<Transform> ObjectsInLayer(Boid_Agent agent, List<Transform> allTransforms)
    {
        //create a new list to filter through only boids from colliders detected
        List<Transform> boids = new List<Transform>();
        //iterate through all transforms
        foreach (Transform transform in allTransforms) 
        {
            //if the agent is a boid it will contain a boid agent class
            Boid_Agent transformAgent = transform.GetComponent<Boid_Agent>();
            //if there is no boid agent class detected
            if (transformAgent != null)
            {
                //add boid to list
                boids.Add(transform);
            }
        }
        //return all boids in environment
        return boids;
    }
}
