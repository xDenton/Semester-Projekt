using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 5;
    private float _currentHealth;

    [SerializeField] private Healthbar _healthbar;

    public bool shipIsAlive = true;
    public GameOverScript gameOver;

    public GameObject LeeresHerz1;
    public GameObject LeeresHerz2;
    public GameObject LeeresHerz3;
    public GameObject LeeresHerz4;
    public GameObject LeeresHerz5;



    void Start()
    {
        _currentHealth = _maxHealth;
        if(_healthbar != null)
        {
            _healthbar.UpdateHealthbar(_maxHealth, _currentHealth);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Wenn das Schiff gegen ein hindernis knallt, soll es schaden bekommen
        if (collision.gameObject.tag == "hindernis")
        {
            Debug.Log("getroffen");
            _currentHealth -= 1;
        }
        // Herzen werden weggemacht
        if (_currentHealth == 4)
        {
            LeeresHerz1.SetActive(true);
        }
        if (_currentHealth < 4)
        {
            LeeresHerz2.SetActive(true);
        }
        if (_currentHealth < 3)
        {
            LeeresHerz3.SetActive(true);
        }
        if (_currentHealth < 2)
        {
            LeeresHerz4.SetActive(true);
        }

        if (_currentHealth <= 0)
        {
            LeeresHerz5.SetActive(true);
            gameOver.GameOver();
            shipIsAlive = false;
        }
        else
        {
            _healthbar.UpdateHealthbar(_maxHealth, _currentHealth);
        }
    }
}
