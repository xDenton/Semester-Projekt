using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoZoneShip : MonoBehaviour
{
    public IndicateWeight IndicateWeight;
    public Ship myShip;
    public Cargo myCargo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CargoName"))
        {
            myShip.AddCargoWeight(myCargo.cargoWeight);
            IndicateWeight.AddIndicateWeight(myCargo.cargoWeight);
            myShip.AddCargoValue(myCargo.cargoValue);
            myShip.TrackCargoAmount(1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CargoName"))
        {
            myShip.RemoveCargoWeight(myCargo.cargoWeight);
            IndicateWeight.RemoveIndicateWeight(myCargo.cargoWeight);
            myShip.RemoveCargoValue(myCargo.cargoValue);
            myShip.TrackCargoAmount(-1);
        }
    }
}
