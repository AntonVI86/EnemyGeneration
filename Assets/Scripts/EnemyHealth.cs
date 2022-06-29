using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _maxArmorPoints;
    [SerializeField] private AudioClip[] _deathSound;
    [SerializeField] private AudioClip[] _hitSound;
    [SerializeField] private ParticleSystem _destroyEffect;
    
    private EnemyAudioSource _audioSource;
    private float _armorPoint;

    private void Awake()
    {
        _audioSource = FindObjectOfType<EnemyAudioSource>();
    }

    private void OnEnable()
    {
        _armorPoint = _maxArmorPoints;
    }

    public void TakeDamage(float damage) 
    {
        _armorPoint -= damage;
        _audioSource.PlayClip(_hitSound);

        if (_armorPoint <= 0) 
        {
            _audioSource.PlayClip(_deathSound);
            Instantiate(_destroyEffect, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
