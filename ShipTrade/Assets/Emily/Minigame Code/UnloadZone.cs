using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloadZone : MonoBehaviour
{
    public Cargo Cargo;
    public CalculateCargoValue CalculateCargoValue;

    private void OnTriggerEnter(Collider other)
    {
        CalculateCargoValue.AddCargoValue(Cargo.cargoValue);
    }

    private void OnTriggerExit(Collider other)
    {
        CalculateCargoValue.RemoveCargoValue(Cargo.cargoValue);
    }
}
