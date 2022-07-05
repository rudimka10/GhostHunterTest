using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GhostHunter.Game
{
    public class DeathZone : MonoBehaviour
    {
        [Inject]
        [SerializeField] private GameController _gameController;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var enemy = collision.gameObject.GetComponent<Enemy>();
            _gameController.DestroyEnemy(enemy);
        }


    }
}