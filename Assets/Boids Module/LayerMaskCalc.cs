using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LayerMasking : ScriptableObject
{
    public abstract List<Transform> ObjectsInLayer(Boid_Agent agent, List<Transform> allTransforms);
    //define layer and pass in current agent and all colliders in environment
}
