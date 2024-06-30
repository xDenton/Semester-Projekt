using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipZone : MonoBehaviour
{
    public Cargo Cargo;
    public CalculateCargoWeight CalculateCargoWeight;
    public IndicateWeight IndicateWeight;

    private void OnTriggerEnter(Collider other)
    {
        CalculateCargoWeight.AddCargoWeight(Cargo.cargoWeight);
        IndicateWeight.AddIndicateWeight(Cargo.cargoWeight);
    }

    private void OnTriggerExit(Collider other)
    {
        CalculateCargoWeight.RemoveCargoWeight(Cargo.cargoWeight);
        IndicateWeight.RemoveIndicateWeight(Cargo.cargoWeight);
    }
}
