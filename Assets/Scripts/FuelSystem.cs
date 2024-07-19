using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelSystem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Fuel"))
        {
        PlayerStats.currentFuel += PlayerStats.fuelWorth;

        // Destroying wood
        Destroy(other.gameObject);
        }
    }

}
