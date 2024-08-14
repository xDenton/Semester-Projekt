using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    Vector3 mousePosition;
    private bool isFront = true;
    private bool isBack = false;

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }
    private void OnMouseDown()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("W Pressed");
            if (isFront)
            {
                transform.position += new Vector3(0, 0, 75);
                isBack = true;
                isFront = false;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("S Pressed");
            if (isBack)
            {
                transform.position -= new Vector3(0, 0, 75);
                isFront = true;
                isBack = false;
            }
        }
        mousePosition = Input.mousePosition - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }
}
