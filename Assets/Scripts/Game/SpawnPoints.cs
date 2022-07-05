using UnityEngine;

namespace GhostHunter.Game
{
    public class SpawnPoints : MonoBehaviour
    {
        [SerializeField] private GameObject[] _spawnPoints;

        public GameObject GetRandomSpawnPoint()
        {
            var pointID = Random.Range(0, _spawnPoints.Length);
            return _spawnPoints[pointID];
        }

    }
}