using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    [SerializeField] private ParticleSystem _hitEffect;

    private void Update()
    {
        transform.Translate(Vector2.up * -_speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out EnemyHealth enemyHealth)) 
        {
            enemyHealth.TakeDamage(_damage);
            Instantiate(_hitEffect, transform.position, Quaternion.identity);
        }

        gameObject.SetActive(false);
    }
}
