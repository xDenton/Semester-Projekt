using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicateValue : MonoBehaviour
{
    public Text ValueText;
    
    public void UpdateCurrentValue(int currentValue)
    {
        ValueText.text = currentValue.ToString();
    }
}
