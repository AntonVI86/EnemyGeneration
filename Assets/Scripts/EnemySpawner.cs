using System.Collections;
using UnityEngine;

public class EnemySpawner : ObjectPool
{
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private Transform _containerOfSpawnPoints;
    [SerializeField] private Transform _target;
    [SerializeField] private Enemy[] _templates;

    private Transform[] _spawnPoints;

    private void Awake()
    {
        _spawnPoints = new Transform[_containerOfSpawnPoints.childCount];

        for (int i = 0; i < _containerOfSpawnPoints.childCount; i++)
        {
            _spawnPoints[i] = _containerOfSpawnPoints.GetChild(i);
        }

        Initialize(_templates);

        StartCoroutine(CreateEnemy());
    }

    public Transform GetTargetPosition()
    {
        return _target.transform;
    }

    private void SetEnemy(GameObject enemy, Transform spawnPoint) 
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint.position;
    }

    private IEnumerator CreateEnemy() 
    {
        var delay = new WaitForSeconds(_secondsBetweenSpawn);

        while (true) 
        {
            if (TryGetObject(out GameObject enemy))
            {
                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                SetEnemy(enemy, _spawnPoints[spawnPointNumber]);
            }
            
            yield return delay;
        }
    }
}
