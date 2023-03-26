using UnityEngine;

public class GeneratorEnemys : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _timeSpawn;

    private Transform[] _spawnPoints;
    private float _runnigTime = 0;
    private int _spawnTarget = 0;

    void Start()
    {
        _spawnPoints = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            _spawnPoints[i] = transform.GetChild(i);
    }


    private void Update()
    {
        _runnigTime += Time.deltaTime;

        if (_runnigTime >= _timeSpawn)
        {
            _runnigTime = 0;
            Spawn(_spawnTarget);
            _spawnTarget++;

            if (_spawnTarget >= _spawnPoints.Length)
                _spawnTarget = 0;
        }
    }

    private void Spawn(int indexPoint)
    {
        Instantiate(_enemy, _spawnPoints[indexPoint].position, _spawnPoints[indexPoint].rotation);
    }
}
