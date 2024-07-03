using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    //[SerializeField] private Image _healthbarSprite;
    [SerializeField] private float _reduceSpeed = 2;
    private float _target = 1;

    public void UpdateHealthbar(float maxHealth, float currentHealth)
    {
        _target = currentHealth / maxHealth;
    }

    void Update()
    {
       // _healthbarSprite.fillAmount = Mathf.MoveTowards(_healthbarSprite.fillAmount, _target, _reduceSpeed * Time.deltaTime);
    }
}
