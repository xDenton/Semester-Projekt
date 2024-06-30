using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadUpZone : MonoBehaviour
{
    public Cargo Cargo;
    public CalculateCargoWeight CalculateCargoWeight;

    private void OnTriggerEnter(Collider other)
    {
        CalculateCargoWeight.AddCargoWeight(Cargo.cargoWeight);
    }

    private void OnTriggerExit(Collider other)
    {
        CalculateCargoWeight.RemoveCargoWeight(Cargo.cargoWeight);
    }
}
