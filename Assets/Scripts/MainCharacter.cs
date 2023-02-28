using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class MainCharacter : MonoBehaviour
{
    [SerializeField] private UnityEvent _damageTaken;
    [SerializeField] private UnityEvent _healed;
    [SerializeField] private UnityEvent _deaded;
    [SerializeField] private UnityEvent _wakedUp;
    [SerializeField] private int _defaultHealth = 100;

    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = _defaultHealth;
    }

    public void TakeDamage(int damage)
    {
        if (_currentHealth > 0 && damage > 0)
        {
            if (damage < _currentHealth)
                _currentHealth -= damage;
            else
                _currentHealth = 0;

            _damageTaken.Invoke();

            if (_currentHealth <= 0)
                _deaded.Invoke();
        }
    }

    public void ToHeal(int amountOfHealthRestored)
    {
        if (amountOfHealthRestored > 0 && _currentHealth < _defaultHealth)
        {
            if (_currentHealth + amountOfHealthRestored >= _defaultHealth)
            {
                _currentHealth = _defaultHealth;
            }
            else
            {
                if (_currentHealth <= 0)
                    _wakedUp.Invoke();
                
                _currentHealth += amountOfHealthRestored;
            }
        
            _healed.Invoke();
        }
    }

    public float GetHealthPercent()
    {
        return (float) _currentHealth / _defaultHealth;
    }
}