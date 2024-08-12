using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowValue : MonoBehaviour
{
    public int value = 0;
    public Text ValueText;

    public void UpdateShowValue(int totalValue)
    {
        value = totalValue;
        ValueText.text = value.ToString();
    }
}
