using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicateWeight : MonoBehaviour
{
    private float movementSpeed = 50f;
    public float vecX = -715.5f;
    public int weightOverLimit = 0;
    public RectTransform myIndicator;
    public RectTransform maxPosition;
    public RectTransform minPosition;
    public RectTransform tooHeavy;
    public RectTransform tooLight;

    public Warnings warnings;

    void Start()
    {
        myIndicator.SetLocalPositionAndRotation(new Vector3(-715.5f, -405f, 0), new Quaternion(0, 0, 0, 0));
    }

    public void AddIndicateWeight(int weight)
    {
        myIndicator.transform.position = myIndicator.transform.position + new Vector3(weight * movementSpeed * Time.deltaTime, 0, 0);

        if (myIndicator.position.x >= maxPosition.position.x)
        {
            myIndicator.SetLocalPositionAndRotation(new Vector3(715.5f, -405f, 0), new Quaternion(0, 0, 0, 0));
            weightOverLimit = weightOverLimit + weight;
        }

        if (myIndicator.position.x >= tooLight.position.x)
        {
            warnings.StopTooLightWarning();
        }

        if (myIndicator.position.x >= tooHeavy.position.x)
        {
            warnings.StartTooHeavyWarning();
        }
    }

    public void RemoveIndicateWeight(int weight)
    {
        if (weightOverLimit > 0)
        {
            myIndicator.SetLocalPositionAndRotation(new Vector3(715.5f, -405f, 0), new Quaternion(0, 0, 0, 0));
            weightOverLimit = weightOverLimit - weight;
        }

        if (weightOverLimit <= 0)
        {
            myIndicator.transform.position = myIndicator.transform.position - new Vector3(weight * movementSpeed * Time.deltaTime, 0, 0);
        }

        if (myIndicator.position.x <= minPosition.position.x)
        {
            myIndicator.SetLocalPositionAndRotation(new Vector3(-715.5f, -405f, 0), new Quaternion(0, 0, 0, 0));
        }

        if (myIndicator.position.x <= tooLight.position.x)
        {
            warnings.StartTooLightWarning();
        }

        if (myIndicator.position.x <= tooHeavy.position.x)
        {
            warnings.StopTooHeavyWarning();
        }
    }
}
