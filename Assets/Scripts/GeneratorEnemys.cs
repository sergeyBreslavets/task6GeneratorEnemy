using System.Collections;
using UnityEngine;

public class GeneratorEnemys : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _timeSpawn = 2f;
    [SerializeField] private int _maxCountEnemies = 100;

    private int _countEnemies = 0;
    private Transform[] _spawnPoints;
    private int _spawnTarget = 0;

    private void Start()
    {
        _spawnPoints = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            _spawnPoints[i] = transform.GetChild(i);

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (_countEnemies < _maxCountEnemies)
        {
            Instantiate(_enemy, _spawnPoints[_spawnTarget].position, _spawnPoints[_spawnTarget].rotation);
            _countEnemies++;
            _spawnTarget++;

            if (_spawnTarget >= _spawnPoints.Length)
                _spawnTarget = 0;

            yield return new WaitForSeconds(_timeSpawn);
        }
    }
}
