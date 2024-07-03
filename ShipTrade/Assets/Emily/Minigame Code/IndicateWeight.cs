using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicateWeight : MonoBehaviour
{
    private float movementSpeed = 50f;
    public float vecX = -26.71f;
    public CalculateCargoWeight CalculateCargoWeight;
    public RectTransform RectTransform;

    //Werte vorher (-810/-455/0)
    void Start()
    {
        RectTransform.SetLocalPositionAndRotation(new Vector3(-26.71f, -16.3f, 0), new Quaternion(0, 0, 0, 0));
    }

    public void AddIndicateWeight(int weight)
    {
        vecX += weight * movementSpeed * Time.deltaTime;

        if (vecX < 809)
        {
            RectTransform.transform.position = RectTransform.transform.position + new Vector3(weight * movementSpeed * Time.deltaTime, 0, 0);
        }
        else
        //x 810/ -455/0
        {
            RectTransform.SetLocalPositionAndRotation(new Vector3(-26.71f, -16.3f, 0), new Quaternion(0, 0, 0, 0));
            //vorher 810
            vecX = -26.71f;
        }
    }

    public void RemoveIndicateWeight(int weight)
    {
        vecX -= weight * movementSpeed * Time.deltaTime;

        //Werte vorher (-810/-455/0)
        if (vecX > -809)
        {
            RectTransform.transform.position = RectTransform.transform.position - new Vector3(weight * movementSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            RectTransform.SetLocalPositionAndRotation(new Vector3(-26.71f, -16.3f, 0), new Quaternion(0, 0, 0, 0));
            vecX = -26.71f;
        }
    }
}
