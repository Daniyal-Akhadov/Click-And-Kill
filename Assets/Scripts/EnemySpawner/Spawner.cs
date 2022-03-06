using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;

    private Wave _currentWave;
    private int _currentWaveNumber;
    private float _timeAfterLastSpawn;
    private int _spawnedObjectCount;

    public event UnityAction AllEnemiesSpawned;
    public event UnityAction<int, int> EnemiesCountChanged;

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _spawnedObjectCount++;
            EnemiesCountChanged.Invoke(_spawnedObjectCount, _currentWave.Count);
            _timeAfterLastSpawn = 0f;
        }

        _timeAfterLastSpawn += Time.deltaTime;

        if (_spawnedObjectCount >= _currentWave.Count)
        {
            if (_waves.Count > _currentWaveNumber + 1)
            {
                AllEnemiesSpawned?.Invoke();
            }

            _currentWave = null;
        }
    }

    public void SetNextWave()
    {
        SetWave(++_currentWaveNumber);
        _spawnedObjectCount = 0;
        EnemiesCountChanged.Invoke(_spawnedObjectCount, _currentWave.Count);
    }

    private void OnEnemyDied(Enemy enemy)
    {
        _player.AddMoney(enemy.Reward);
        enemy.Died -= OnEnemyDied;
    }

    private void InstantiateEnemy()
    {
        var enemy = Instantiate(_currentWave.Template, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint);
        enemy.Init(_player);
        enemy.Died += OnEnemyDied;
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
    }
}

[System.Serializable]
public class Wave
{
    [SerializeField] private Enemy _template;
    [SerializeField] private float _delay;
    [SerializeField] private int _count;

    public Enemy Template => _template;
    public float Delay => _delay;
    public int Count => _count;

}