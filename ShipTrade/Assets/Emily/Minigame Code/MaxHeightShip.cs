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

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CargoName")
            StartHeightWarning();
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "CargoName")
            StopHeightWarning();
    }
    
    public void StartHeightWarning()
    {
        //meshRendererCargo.material = meshRendererCargo.material.name.StartsWith(heightMaterial.name) ? originalMaterial : heightMaterial;

        heightWarning.SetActive(true);
    }
    
    public void StopHeightWarning()
    {
        //meshRendererCargo.material = meshRendererCargo.material.name.StartsWith(originalMaterial.name) ? heightMaterial : originalMaterial;

        heightWarning?.SetActive(false);
    }
}
