using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoZoneShip : MonoBehaviour
{
    public IndicateWeight IndicateWeight;
    public Ship myShip;
    public Cargo myBigChest;
    public Cargo myMiddleChest;
    public Cargo mySmallChest;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BigChest"))
        {
            myShip.AddCargoWeight(myBigChest.cargoWeight);
            IndicateWeight.AddIndicateWeight(myBigChest.cargoWeight);
            myShip.AddCargoValue(myBigChest.cargoValue);
            myShip.TrackCargoAmount(1);
        }
        if (other.gameObject.CompareTag("MiddleChest"))
        {
            myShip.AddCargoWeight(myMiddleChest.cargoWeight);
            IndicateWeight.AddIndicateWeight(myMiddleChest.cargoWeight);
            myShip.AddCargoValue(myMiddleChest.cargoValue);
            myShip.TrackCargoAmount(1);
        }
        if (other.gameObject.CompareTag("SmallChest"))
        {
            myShip.AddCargoWeight(mySmallChest.cargoWeight);
            IndicateWeight.AddIndicateWeight(mySmallChest.cargoWeight);
            myShip.AddCargoValue(mySmallChest.cargoValue);
            myShip.TrackCargoAmount(1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("BigChest"))
        {
            myShip.RemoveCargoWeight(myBigChest.cargoWeight);
            IndicateWeight.RemoveIndicateWeight(myBigChest.cargoWeight);
            myShip.RemoveCargoValue(myBigChest.cargoValue);
            myShip.TrackCargoAmount(-1);
        }
        if (other.gameObject.CompareTag("MiddleChest"))
        {
            myShip.RemoveCargoWeight(myMiddleChest.cargoWeight);
            IndicateWeight.RemoveIndicateWeight(myMiddleChest.cargoWeight);
            myShip.RemoveCargoValue(myMiddleChest.cargoValue);
            myShip.TrackCargoAmount(-1);
        }
        if (other.gameObject.CompareTag("SmallChest"))
        {
            myShip.RemoveCargoWeight(mySmallChest.cargoWeight);
            IndicateWeight.RemoveIndicateWeight(mySmallChest.cargoWeight);
            myShip.RemoveCargoValue(mySmallChest.cargoValue);
            myShip.TrackCargoAmount(-1);
        }
    }
}
