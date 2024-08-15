using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ziel : MonoBehaviour
{
    public GameObject panel;
    private bool isPlayerInTrigger = false;


    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false); // Panel zunächst deaktivieren
    }


    // Update is called once per frame
    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log("E wurde gedrückt");
            SceneManager.LoadScene("WellDone");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ziel")
        {
            panel.SetActive(true);
            Debug.Log("test");
            isPlayerInTrigger = true;
        }
        if(isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ziel"))
        {
            panel.SetActive(false);
            isPlayerInTrigger = false;
        }
    }
}
