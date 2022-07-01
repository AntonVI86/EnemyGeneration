using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    private Transform player;

    private void Update()
    {
        Turn();

        transform.Translate(Vector2.down * _speed * Time.deltaTime);
    }

    private void Turn() 
    {
        player = GetComponentInParent<EnemySpawner>().GetTargetPosition();
        var angleX = transform.rotation.eulerAngles.x;
        var angleY = transform.rotation.eulerAngles.y;
        var angleZ = Mathf.Atan2(player.position.y - transform.position.y, player.position.x - transform.position.x) * Mathf.Rad2Deg + 90;

        transform.rotation = Quaternion.Euler(angleX, angleY, angleZ);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health)) 
        {
            health.TakeDamage(_damage);
            gameObject.SetActive(false);
        }
    }
}
