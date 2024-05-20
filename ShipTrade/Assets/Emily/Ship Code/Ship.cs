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

    void Start()
    {
        _currentHealth = _maxHealth;

        _healthbar.UpdateHealthbar(_maxHealth, _currentHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _currentHealth -= 1;

        if (_currentHealth <= 0)
        {
            gameOver.GameOver();
            shipIsAlive = false;
        }
        else
        {
            _healthbar.UpdateHealthbar(_maxHealth, _currentHealth);
        }
    }
}
