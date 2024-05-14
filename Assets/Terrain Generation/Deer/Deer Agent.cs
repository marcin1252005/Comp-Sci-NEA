using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerAgent : MonoBehaviour
{
    private BoxCollider objectCollider;
    private Rigidbody rb;
    public float hungerValue;
    public float maxHungerValue;
    public float maxWaterValue;
    public float waterValue;
    public float ageValue;
    public float energyValue;
    public float socialValue;
    public float healthValue;
    public float decayRate;
    private void Update()
    {
        ValueDecay();
    }

    public void ValueDecay()
    {
        //not implemented yet
    }

    //public void eat(DeerAgent deerAgent, foodSource)
    //{
    //    foodType = foodSource.foodType;
    //    foodValue = foodType.foodValue;
    //    while (hungerValue + foodValue <= maxHungerValue || foodSource.foodAmount == 0f)
    //    {
    //        hungerValue += foodValue;
    //        foodAmount -= 1;
    //    }
    //}

    //public void drink(DeerAgent deerAgent, waterSource)
    //{
    //    waterNeeded = deerAgent.maxWaterValue - waterValue;
    //    waterAmount = waterSource.waterAmount;
    //    if (waterNeeded > waterAmount)
    //    {
    //        waterValue += waterAmount;
    //    }
    //    else
    //    {
    //        waterValue = maxWaterValue;
    //    }
    //    waterSource.waterAmount -= waterNeeded;
    //}

}

