using GhostHunter.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameControllerInstaller : MonoInstaller
{
    [SerializeField] private GameObject _gameControllerPrefab;
    [SerializeField] private SpawnPoints _spawnPoints;


    public override void InstallBindings()
    {
        BindSpawnPoints();
        BindGameController();

        
    }

    private void BindSpawnPoints()
    {
        Container.Bind<SpawnPoints>().FromInstance(_spawnPoints).AsSingle();
    }


    private void BindGameController()
    {
        var gameController = Container.InstantiatePrefabForComponent<GameController>(_gameControllerPrefab);

        Container.Bind<GameController>().FromInstance(gameController).AsSingle();
    }
}
