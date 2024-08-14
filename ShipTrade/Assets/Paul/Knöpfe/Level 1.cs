using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    //Knopf um das erste Level zu starten

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void back()
    {
        SceneManager.LoadScene(0);
    }
    public void Route1()
    {
        SceneManager.LoadScene("Route 1");
    }
    public void Route2()
    {
        SceneManager.LoadScene("Route 2");
    }
    public void Route3()
    {
        SceneManager.LoadScene("Route 3.1");
    }
}
