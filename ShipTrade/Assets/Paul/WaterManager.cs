using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class WaterManager : MonoBehaviour
{
    private MeshFilter meshfilter;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        meshfilter = GetComponent<MeshFilter>();
    }

    private void Update()
    {
        Vector3[] vertictes = meshfilter.mesh.vertices;
        for (int i = 0; i < vertictes.Length; i++)
        {
            vertictes[i].y = WaveManager.instance.GetWaveHeight(transform.position.x + vertictes[i].x);
        }

        meshfilter.mesh.vertices = vertictes;
        meshfilter.mesh.RecalculateNormals();
    }
}
