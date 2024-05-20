using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCargoValue : MonoBehaviour
{
    public Cargo cargo;
    public int totalValue;

    private void OnTriggerEnter(Collider other)
    {
        totalValue += cargo.cargoValue;
    }

    private void OnTriggerExit(Collider other)
    {
        totalValue -= cargo.cargoValue;
    }
}
