using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    //Lebenbestimmen
    public float playerHealth = 5;
    //Scenebestimmen
    public int currentScene;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        if (playerHealth < 0) playerHealth = 0;
        Debug.Log("Player Health: " + playerHealth);
    }

    public void Heal(float amount)
    {
        if(playerHealth == 0)
        {
            playerHealth = 5;
        }
    }
    public void ResetHealth()
    {
        playerHealth = 5;
        //Debug.Log("Player Health Reset to: " + playerHealth);
    }
    public void setCurrentScene(int sceneid)
    {
        currentScene = sceneid;
    }
}
