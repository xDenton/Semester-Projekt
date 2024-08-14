using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHeightShip : MonoBehaviour
{
    //[SerializeField] GameObject cargo;
    //[SerializeField] Material heightMaterial;
    //Material originalMaterial;
    //MeshRenderer meshRendererCargo;
    //
    //private void Start()
    //{
    //    meshRendererCargo = GetComponent<MeshRenderer>();
    //    originalMaterial = meshRendererCargo.material;
    //    heightMaterial.mainTextureScale = originalMaterial.mainTextureScale;
    //}

    public GameObject heightWarning;
    public GameObject buttonDriveBack;
    private int trackObjectsInHeightWarning = 0;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            StartHeightWarning();
            trackObjectsInHeightWarning++;
        }
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            trackObjectsInHeightWarning--;

            if (trackObjectsInHeightWarning == 0)
            {
                StopHeightWarning();
            }
        }
    }
    
    public void StartHeightWarning()
    {
        //meshRendererCargo.material = meshRendererCargo.material.name.StartsWith(heightMaterial.name) ? originalMaterial : heightMaterial;

        heightWarning?.SetActive(true);
        buttonDriveBack?.SetActive(false);
    }
    
    public void StopHeightWarning()
    {
        //meshRendererCargo.material = meshRendererCargo.material.name.StartsWith(originalMaterial.name) ? heightMaterial : originalMaterial;

        heightWarning?.SetActive(false);
        buttonDriveBack?.SetActive(true);
    }
}
