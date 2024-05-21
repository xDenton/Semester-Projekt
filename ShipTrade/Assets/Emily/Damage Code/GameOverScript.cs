using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverScreen;

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
