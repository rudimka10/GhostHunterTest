using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GhostHunter.Game
{
    public class DeathZone : MonoBehaviour
    {
        [SerializeField] private GameController _gameController;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var enemy = collision.gameObject.GetComponent<Enemy>();
            _gameController.DestroyEnemy(enemy);
        }


    }
}