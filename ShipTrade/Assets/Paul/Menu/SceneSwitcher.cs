using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
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
            Debug.Log("Space wurde gedrückt");
            SceneManager.LoadScene(1);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hafen")
        {
            panel.SetActive(true);
            //Debug.Log("test");
            isPlayerInTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("hafen"))
        {
            panel.SetActive(false);
            isPlayerInTrigger = false;
        }
    }
}
