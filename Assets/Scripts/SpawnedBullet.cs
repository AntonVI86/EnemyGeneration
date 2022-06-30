using UnityEngine;
using UnityEngine.Events;

public class SpawnedBullet : ObjectPool
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _tower;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _clip;
    [SerializeField] private UnityEvent _playedShot;

    private void Start()
    {
        Initialize(_bullet);
    }

    public void PlaySound()
    {
        int clipIndex = Random.Range(0, _clip.Length);

        _audioSource.PlayOneShot(_clip[clipIndex]);
    }

    public void Shot()
    {
        if (TryGetObject(out GameObject bullet)) 
        {
            SetObject(bullet);
            _playedShot?.Invoke();
            bullet.transform.rotation = _tower.rotation;
        }
    }

    private void SetObject(GameObject bullet) 
    {
        bullet.SetActive(true);
        bullet.transform.position = transform.position;       
    }
}
