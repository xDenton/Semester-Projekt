using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject leiste;
    public GameObject Levelmusik;
    public GameObject Panel;

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        leiste.SetActive(false);
        Levelmusik.SetActive(false);
        Panel.SetActive(false);
    }
       
}
