using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _healthAmount = 10f;

    private float _maxHealth = 10f;
    private float _minHealth = 0f;


    public void Heal(float amount)
    {
        _healthAmount += amount;
        _healthAmount = Mathf.Min(_healthAmount, _maxHealth);
    }

    public void TakeDamage(float damage)
    {
        _healthAmount -= damage;
        _healthAmount = Mathf.Max(_healthAmount, _minHealth);

        if(_healthAmount <= 0)
        {
            Die();
        }
    }

    public void ShowInfo()
    {
        Debug.Log(_healthAmount);
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
