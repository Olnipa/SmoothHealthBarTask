using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private MainCharacter _character;

    public void OnDamageButtonClick(int damage)
    {
        _character.TakeDamage(damage);
    }

    public void OnHealButtonClick(int heal)
    {
        _character.ToHeal(heal);
    }
}