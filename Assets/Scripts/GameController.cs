using GhostHunter.Game;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unils;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private int _maxGhostsCount;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private SpawnPoints _spawnPoints;

    public ReactiveProperty<int> CurrentScore = new ReactiveProperty<int>();
    public ReactiveProperty<int> GhostsCount = new ReactiveProperty<int>();

    private void Awake()
    {
        StartGame();
        SpawnEnemyisTillLimit();
        GhostsCount.ValueChanged += SpawnEnemyisTillLimit;
    }

    public void StartGame()
    {
        CurrentScore.Value = 0;
       
    }

    public void KillEnemy(Enemy enemy)
    {
        StartCoroutine(DestroyEnemyRoutine(enemy));

    }

    private IEnumerator DestroyEnemyRoutine(Enemy enemy)
    {
        yield return new WaitForSeconds(3f);
        CurrentScore.Value++;
        DestroyEnemy(enemy);
    }

    public void DestroyEnemy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
        GhostsCount.Value--;

    }

    private void SpawnEnemyisTillLimit()
    {
        while (GhostsCount.Value < _maxGhostsCount)
        {
            SpawnNewEnemy();
            GhostsCount.Value++;
        }

    }

    public void SpawnNewEnemy()
    {
        float speed = Random.Range(60f, 85f);
        var spawnPointRect = _spawnPoints.GetRandomSpawnPoint().transform;
        
        var enemy = Instantiate(_enemyPrefab, spawnPointRect, false);
        enemy.Construct(this, speed, spawnPointRect.position);



    }

    private void OnDestroy()
    {
        GhostsCount.ValueChanged -= SpawnEnemyisTillLimit;

    }

}
