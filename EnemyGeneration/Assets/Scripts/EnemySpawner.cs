using UnityEngine;

public class EnemySpawner : ObjectPool
{
    [SerializeField] private GameObject[] _templates;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private Transform _spawn;
    private Transform[] _points;
    private float _elapsedTime;

    private void Awake()
    {
        _points = new Transform[_spawn.childCount];

        for (int i = 0; i < _spawn.childCount; i++)
        {
            _points[i] = _spawn.GetChild(i);
        }

        Initialize(_templates);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn) 
        {
            if (TryGetObject(out GameObject enemy)) 
            {
                int spawnPointNumber = Random.Range(0, _points.Length);

                SetEnemy(enemy, _points[spawnPointNumber]);
                _elapsedTime = 0;           
            }
        }
    }

    private void SetEnemy(GameObject enemy, Transform spawnPoint) 
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint.position;
    }
}
