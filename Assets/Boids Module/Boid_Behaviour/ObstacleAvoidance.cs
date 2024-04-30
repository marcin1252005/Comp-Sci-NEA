using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Boid/Algorithm/ObstacleAvoidance")]
//creat asset under same submenu as other methods
public class ObstacleAvoidance : LayerMaskBehaviour

{
    //smoothdamp parameters
    Vector3 currentVelocity;
    [Range(0.1f, 10f)]
    public float boidSmoothTime = 0.4f;
    public override Vector3 calcBoids(Boid_Agent agent, List<Transform> environment, Boids boids)
    {
        //check for boids in range
        if (environment.Count == 0)
            //instead of returning [0,0,0], maintain current alignment
            return agent.transform.forward;
        Vector3 sumVelocity = Vector3.zero;
        List<Transform> environmentLayer = (layer == null) ? environment : layer.ObjectsInLayer(agent, environment);
        foreach (Transform boid in environmentLayer)
        {
            sumVelocity += boid.forward;
            //sum all all velocity vectors
        }
        Vector3 alignmentVector = sumVelocity/environment.Count;
        alignmentVector = Vector3.SmoothDamp(agent.transform.forward, alignmentVector, ref currentVelocity, boidSmoothTime);
        //calculate average alignment
        return alignmentVector;
    }
}
