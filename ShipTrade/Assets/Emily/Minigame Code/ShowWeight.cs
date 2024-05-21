using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowWeight : MonoBehaviour
{
    public int weight;
    public Text weightText;

    public void addWeight(int weightToAdd)
    {
        weight += weightToAdd;
        weightText.text = weight.ToString();
    }

    public void removeWeight(int weightToRemove)
    {
        weight -= weightToRemove;
        weightText.text = weight.ToString();
    }
}
