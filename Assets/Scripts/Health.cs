using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _healthValue;
    [SerializeField] private float _maxHealth;
    [SerializeField] private ParticleSystem _hitEffect;
    [SerializeField] private UnityEvent _damaged;

    private float _currentHealth;
    private float _healthFillSpeed = 0.02f;
    private float _speed = 1;
    private bool isAlive => _currentHealth > 0;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _healthValue.value = _maxHealth;
        _healthValue.maxValue = _maxHealth;

        StartCoroutine(ChangeHealth());
    }

    public void TakeDamage(float damage) 
    {
        _currentHealth -= damage;
        _damaged?.Invoke();
        Instantiate(_hitEffect, transform.position, Quaternion.identity);
        StartCoroutine(ChangeHealth());

        if (isAlive == false) 
        {
            SceneManager.LoadScene(0);
        }
    }

    private IEnumerator ChangeHealth() 
    {
        var delay = new WaitForSeconds(_healthFillSpeed);

        while (_healthValue.value != _currentHealth)
        {
            _healthValue.value = Mathf.MoveTowards(_healthValue.value, _currentHealth, _speed);
            yield return delay;
        }
    }
}
