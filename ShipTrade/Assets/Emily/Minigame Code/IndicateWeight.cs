using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicateWeight : MonoBehaviour
{
    private float movementSpeed = 50f;
    public float vecX = -715.5f;
    public CalculateCargoWeight CalculateCargoWeight;
    public RectTransform RectTransform;

    void Start()
    {
        RectTransform.SetLocalPositionAndRotation(new Vector3(-715.5f, -405f, 0), new Quaternion(0, 0, 0, 0));
        //Werte vorher (-810/-455/0)
    }

    public void AddIndicateWeight(int weight)
    {
        vecX += weight * movementSpeed * Time.deltaTime;

        if (vecX < 715f)
        {
            RectTransform.transform.position = RectTransform.transform.position + new Vector3(weight * movementSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            RectTransform.SetLocalPositionAndRotation(new Vector3(-715.5f, -405f, 0), new Quaternion(0, 0, 0, 0));
            //x 810/ -455/0
            vecX = 715.5f;
            //vorher 810
        }
    }

    public void RemoveIndicateWeight(int weight)
    {
        vecX -= weight * movementSpeed * Time.deltaTime;

        if (vecX > -715f)
        {
            RectTransform.transform.position = RectTransform.transform.position - new Vector3(weight * movementSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            RectTransform.SetLocalPositionAndRotation(new Vector3(-715.5f, -405f, 0), new Quaternion(0, 0, 0, 0));
            //Werte vorher (-810/-455/0)
            vecX = -715.5f;
        }
    }
}
