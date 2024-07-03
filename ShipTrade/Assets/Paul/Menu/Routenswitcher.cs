using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Routenswitcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void Levelswitcher()
    {
        SceneManager.LoadScene("Route 2");
    }

}
