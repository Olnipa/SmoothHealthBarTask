using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private MainCharacter _mainCharacter;
    [SerializeField] private float _healthBarChangeUnitPerSleep = 0.1f;
    [SerializeField] private float _TimeToSleep = 0.5f;
    
    private Slider _healthBar;
    private float _targetValue;
    private WaitForSeconds _sleepTime;
    private Coroutine _healthBarFillingCoroutine;

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
        _sleepTime = new WaitForSeconds(_TimeToSleep);
        _healthBar.value = _mainCharacter.GetHealthPercent();
    }

    public void UpdateSliderValue()
    {
        _healthBarFillingCoroutine = StartCoroutine(HealthBarFillJob());
    }

    private IEnumerator HealthBarFillJob()
    {
        if (_healthBarFillingCoroutine != null)
        {
            StopCoroutine(_healthBarFillingCoroutine);
        }

        _targetValue = _mainCharacter.GetHealthPercent();

        while (_healthBar.value != _targetValue)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _targetValue, _healthBarChangeUnitPerSleep * Time.deltaTime);

            yield return _sleepTime;
        }

        _healthBarFillingCoroutine = null;
    }
}