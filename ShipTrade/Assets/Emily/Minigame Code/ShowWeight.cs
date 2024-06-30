using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowWeight : MonoBehaviour
{
    public Text WeightText;

    public void UpdateShowWeight(int totalWeight)
    {
        WeightText.text = totalWeight.ToString();
    }
}
