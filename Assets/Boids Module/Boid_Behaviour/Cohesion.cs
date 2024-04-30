using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Boid/Algorithm/Cohesion")]
//Creates submenus and allows to create new asset in unity editor
public class Cohesion :LayerMaskBehaviour
//inherits from boid algorithm
{
    //smoothdamp parameters

    Vector3 currentVelocity;
    [Range(0.1f,10f)]
    public float boidSmoothTime = 0.4f;
    public override Vector3 calcBoids(Boid_Agent agent, List<Transform> environment, Boids boids)
    //overrides calcboids method from boid algorithm for cohesion calculation
    {
        //check for any boids in range
        if (environment.Count == 0)
            return Vector3.zero;
        //set sumCentre to zero
        Vector3 sumCentre = Vector3.zero;
        //create a new list for a specific layer (if there is a specified layer)
        //otherwise pass through enviroment
        List<Transform> environmentLayer = (layer == null)? environment : layer.ObjectsInLayer(agent,environment);
        //call the parent class override method
        foreach(Transform boid in environmentLayer)
        {
            sumCentre += boid.transform.position;
            //sum up all the position vectors of every boid in range
        }
        Vector3 avgCentre = sumCentre/environment.Count;
        //calculate the average
        Vector3 cohesionVector = avgCentre - agent.transform.position;
        cohesionVector = Vector3.SmoothDamp(agent.transform.forward, cohesionVector, ref currentVelocity, boidSmoothTime);
        //find the distance vector from the boid to its perceived centre of mass
        return cohesionVector;
    }

   
}
