using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateCargoValue : MonoBehaviour
{
    public Cargo cargo;
    public int totalValue;
    public ShowValue ShowValue;

    public void AddCargoValue(int cargoValue)
    {
        totalValue += cargoValue;
        ShowValue.UpdateShowValue(totalValue);
    }

    public void RemoveCargoValue(int cargoValue)
    {
        totalValue -= cargoValue;
        ShowValue.UpdateShowValue(totalValue);
    }
}
