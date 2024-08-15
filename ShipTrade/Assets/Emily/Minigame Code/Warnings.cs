using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warnings : MonoBehaviour
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
    public GameObject tooLightWarning;
    public GameObject tooHeavyWarning;
    public GameObject buttonDriveBack;
    private bool driveBackPossibleWeight = false;
    private bool driveBackPossibleHeight = true;
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

    private void CheckIfDriveBackPossible()
    {
        if (driveBackPossibleHeight && driveBackPossibleWeight)
        {
            buttonDriveBack.SetActive(true);
        }
        else
        {
            buttonDriveBack.SetActive(false);
        }
    }

    public void StartTooLightWarning()
    {
        tooLightWarning?.SetActive(true);
        driveBackPossibleWeight = false;
        CheckIfDriveBackPossible();
    }
    
    public void StopTooLightWarning()
    {
        tooLightWarning?.SetActive(false);
        driveBackPossibleWeight = true;
        CheckIfDriveBackPossible();
    }

    public void StartTooHeavyWarning()
    {
        tooHeavyWarning?.SetActive(true);
        driveBackPossibleWeight = false;
        CheckIfDriveBackPossible();
    }

    public void StopTooHeavyWarning()
    {
        tooHeavyWarning?.SetActive(false);
        driveBackPossibleWeight = true;
        CheckIfDriveBackPossible();
    }

    public void StartHeightWarning()
    {
        //meshRendererCargo.material = meshRendererCargo.material.name.StartsWith(heightMaterial.name) ? originalMaterial : heightMaterial;

        heightWarning?.SetActive(true);
        driveBackPossibleHeight = false;
        CheckIfDriveBackPossible();
    }
    
    public void StopHeightWarning()
    {
        //meshRendererCargo.material = meshRendererCargo.material.name.StartsWith(originalMaterial.name) ? heightMaterial : originalMaterial;

        heightWarning?.SetActive(false);
        driveBackPossibleHeight = true;
        CheckIfDriveBackPossible();
    }
}
