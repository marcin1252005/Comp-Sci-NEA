using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Boid/Algorithm/StayWithinWorldBorder")]

    public class StayWithinWorldBorder : Boids_Algorithm
{
    Vector3 spawnPoint = new Vector3(0f, 80f,0f);
    //set a value for the centre
    //default to zero
    [Range(15f, 500f)]
    public float radius = 50f;
    //configure a radius value
    public override Vector3 calcBoids(Boid_Agent agent, List<Transform> environment, Boids boids)
    {
        //Vector3 terrainCentre = new Vector3(terrain.size, 0f, terrain.size/2);
        Vector3 DistToCentre = spawnPoint - agent.transform.position;
        //float radius = terrain.size/2;

        //check how close to edge boids are
        float ratio = DistToCentre.magnitude/ radius;
        //if less than 90% of the radius
        if (ratio < 0.9f)
        {
            //return zero
            return Vector3.zero;
        }
        //as the ratio approaches 1 this value increases polynomially
        return  DistToCentre * ratio * ratio;
    }
}
