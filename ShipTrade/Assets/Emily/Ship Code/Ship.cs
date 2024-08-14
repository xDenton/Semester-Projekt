using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

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

    public int cargoAmount = 0;
    public int totalWeight = 0;
    public int currentValue = 0;
    public static int totalValue = 0;
    public IndicateValue indicateValue;

    void Start()
    {
        _currentHealth = GameManager.Instance.playerHealth; // nimmt nun die Anzahl des Lebens vom GameManager
        
        if (_healthbar != null)
        {
            _healthbar.UpdateHealthbar(_maxHealth, _currentHealth);
        }
        UpdateHearts(); // Herzen am Anfang wird überprüft wie viel Leben am Anfang vorhanden ist
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Wenn das Schiff gegen ein hindernis knallt, soll es schaden bekommen
        if (collision.gameObject.tag == "hindernis")
        {
            Debug.Log("getroffen");
            GameManager.Instance.TakeDamage(1);
            _currentHealth -= 1;
            UpdateHearts(); //Herzen werden anhand der Fuktion aktualisiert 
        }
    }
        public void UpdateHearts()
        {
            // Herzen werden weggemacht
            if (_currentHealth < 5)
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
                //GameManager.Instance.TakeDamage(1); // Wird auf den GameManager zugegriffen
                shipIsAlive = false;
                GameManager.Instance.ResetHealth();
            }
            else
            {
                _healthbar.UpdateHealthbar(_maxHealth, _currentHealth);
            }
        }

    public void TrackCargoAmount(int count)
    {
        cargoAmount += count;
    }
    public void AddCargoWeight(int cargoWeight)
    {
        totalWeight += cargoWeight;
    }
    public void RemoveCargoWeight(int cargoWeight)
    {
        totalWeight -= cargoWeight;
    }
    public void AddCargoValue(int cargoValue)
    {
        currentValue += cargoValue;
        indicateValue.UpdateCurrentValue(currentValue);
        totalValue += cargoValue;
    }
    public void RemoveCargoValue(int cargoValue)
    {
        currentValue -= cargoValue;
        indicateValue.UpdateCurrentValue(currentValue);
        totalValue -= cargoValue;
    }
}
