using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class deaktivierung : MonoBehaviour
{
    private BoxCollider boxcollider;
    public int freezeFrames = 0;  // Zähler für die Anzahl der Frames, die die Eingabe eingefroren werden soll
    public bool isInputFrozen = false;  // Zustand, ob die Eingabe eingefroren ist

    // Start is called before the first frame update
    void Start()
    {
        boxcollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (freezeFrames == 0)
        {
            boxcollider.enabled = true;
        }
        else 
        {
            freezeFrames--;
        }

            
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ship")
        {
            Debug.Log("getroffen");
            boxcollider.enabled = false;
            freezeFrames = 200;
        }
        /*
        if (freezeFrames > 0)
        {
            freezeFrames--;
            if (freezeFrames == 0)
            {
                boxcollider.enabled = true;
                isInputFrozen = false;  // Eingabe wieder freigeben
            }
            return;  // Eingabe wird ignoriert
        }
        if (collision.gameObject.tag == "hindernis")
        {
            boxcollider.enabled = false;
        }
        else
        {

        }*/
    }
}
