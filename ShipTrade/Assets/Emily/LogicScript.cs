using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicScript : MonoBehaviour
{
    public GameObject gameOverScreen;

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
