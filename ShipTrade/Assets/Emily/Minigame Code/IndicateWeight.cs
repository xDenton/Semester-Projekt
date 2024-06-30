using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicateWeight : MonoBehaviour
{
    private float movementSpeed = 50f;
    public float vecX = -810f;
    public CalculateCargoWeight CalculateCargoWeight;
    public RectTransform RectTransform;

    void Start()
    {
        RectTransform.SetLocalPositionAndRotation(new Vector3(-810, -455, 0), new Quaternion(0, 0, 0, 0));
    }

    public void AddIndicateWeight(int weight)
    {
        vecX += weight * movementSpeed * Time.deltaTime;

        if (vecX < 809)
        {
            RectTransform.transform.position = RectTransform.transform.position + new Vector3(weight * movementSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            RectTransform.SetLocalPositionAndRotation(new Vector3(810, -455, 0), new Quaternion(0, 0, 0, 0));
            vecX = 810;
        }
    }

    public void RemoveIndicateWeight(int weight)
    {
        vecX -= weight * movementSpeed * Time.deltaTime;

        if (vecX > -809)
        {
            RectTransform.transform.position = RectTransform.transform.position - new Vector3(weight * movementSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            RectTransform.SetLocalPositionAndRotation(new Vector3(-810, -455, 0), new Quaternion(0, 0, 0, 0));
            vecX = -810;
        }
    }
}
