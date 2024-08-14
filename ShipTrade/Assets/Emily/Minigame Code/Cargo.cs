using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour
{
    public Transform cargo;
    public Transform spawnPoint;
    public int cargoWeight;
    public int cargoValue;

    private void Update()
    {
        if (transform.position.y < -100)
        {
            cargo.position = spawnPoint.position;
        }
    }
}
