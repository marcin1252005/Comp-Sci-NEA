using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Boid/Algorithm/Separation")]
public class Separation : LayerMaskBehaviour
{
    //smoothdamp parameters
    Vector3 currentVelocity;
    [Range(0.1f, 10f)]
    public float boidSmoothTime = 0.4f;
    public override Vector3 calcBoids(Boid_Agent agent, List<Transform> environment, Boids boids)
    {
       //check for boids in range
       if (environment.Count == 0)
        {
            return Vector3.zero;
        }
       int avoidCount = 0;
        Vector3 separationVector = Vector3.zero;
        //initalise separation vector to [0,0,0]
        List<Transform> environmentLayer = (layer == null) ? environment : layer.ObjectsInLayer(agent, environment);
        foreach (Transform boid in environmentLayer)
        //iterate through each boid in visual range
        {
            if (Vector3.SqrMagnitude(boid.position - agent.transform.position) < boids.getSquareAvoidRange)
            //compare magnitude of distance vector between boids to the avoid range
            {
              avoidCount++;
              //increment number of boids to avoid
              separationVector += (agent.transform.position - boid.position);
               //sum up all vectors but in opposite direction
            }
        }
        if (avoidCount > 0)
        {
            separationVector /= avoidCount;
            separationVector = Vector3.SmoothDamp(agent.transform.forward, separationVector, ref currentVelocity, boidSmoothTime);
        }
        //calculate average separation vector
        return separationVector;
    }
}
  
