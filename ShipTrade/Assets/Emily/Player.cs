using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 3;
    private float _currentHealth;

    [SerializeField] private Healthbar _healthbar;

    public bool playerIsAlive = true;
    public LogicScript logic;

    void Start()
    {
        _currentHealth = _maxHealth;

        _healthbar.UpdateHealthbar(_maxHealth, _currentHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _currentHealth -= Random.Range(0.5f, 1.5f);

        if (_currentHealth <= 0)
        {
            logic.GameOver();
            playerIsAlive = false;
        }
        else
        {
            _healthbar.UpdateHealthbar(_maxHealth, _currentHealth);
        }
    }
}
