using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCargoWeight : MonoBehaviour
{
    public Cargo cargo;
    public int totalWeight;

    private void OnTriggerEnter(Collider other)
    {
        totalWeight += cargo.cargoWeight;
    }

    private void OnTriggerExit(Collider other)
    {
        totalWeight -= cargo.cargoWeight;
    }
}
