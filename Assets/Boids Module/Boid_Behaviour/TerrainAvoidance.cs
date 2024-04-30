using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Boid/Algorithm/TerrainAvoidance")]
//create new asset for obstacle avoidance
public class TerrainAvoidance : LayerMaskBehaviour
{
    //smoothdamp parameters
    [Range(10f,300f)]
    public float coneAngle;
    Vector3 currentVelocity;
    [Range(0.1f, 10f)]
    public float boidSmoothTime = 0.4f;
    public override Vector3 calcBoids(Boid_Agent agent, List<Transform> environment, Boids boids)
    {
       //check for obstacles in range
       if (environment.Count == 0)
        {
            return Vector3.zero;
        }
       int avoidCount = 0;
        Vector3 separationVector = Vector3.zero;
        //initalise separation vector to [0,0,0]
        List<Transform> environmentLayer = (layer == null) ? environment : layer.ObjectsInLayer(agent, environment);
        //seperate collider transforms into only that of obstacle layer
        Debug.Log(environmentLayer.Count);
        //
        if (environmentLayer.Count != 0)
        {            
            Debug.Log("obstacle detected");
            //iterate through each obstacle in visual range            
            //raycast out in flat cone
            for (float yaw = -coneAngle / 2; yaw <= coneAngle / 2; yaw += 30f)
            {
                for (float pitch = -coneAngle / 2; pitch <= coneAngle / 2; pitch += 30f)
                {
                    Vector3 direction = Quaternion.Euler(pitch, yaw, 0f) * agent.transform.forward;
                    Ray ray = new Ray(agent.transform.position, direction);
                    Debug.DrawRay(agent.transform.position, direction * boids.visualRange, Color.green, 0.1f);
                    if (Physics.Raycast(ray, out RaycastHit hitinfo, boids.visualRange * 2))
                    {
                        Vector3 obstaclePosition = hitinfo.point;
                        avoidCount++;
                        //increment number of obstacles to avoid
                        separationVector += (agent.transform.position - obstaclePosition);
                        //sum up all vectors but in opposite direction
                        break;                     
                    }
                    
                    
                }
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
  
