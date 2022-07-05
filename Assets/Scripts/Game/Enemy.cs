using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GhostHunter.Game
{
    public class Enemy : MonoBehaviour
    {

        [SerializeField] private Image _skin;

        [Header("Skins")]
        [SerializeField] private Sprite _aliveSkin;
        [SerializeField] private Sprite _deadSkin;

        private float _speed;
        private GameController _gameController;



        public void Construct(GameController gameController, float speed, Vector3 newPos)
        {
            _gameController = gameController;
            _speed = speed;
            gameObject.transform.position = newPos;
            _skin.sprite = _aliveSkin;
        }

        public void OnKill()
        {
            _skin.sprite = _deadSkin;
            _speed = 0;
            _gameController.KillEnemy(this);

        }

        private void Update()
        {
            var aPos = transform.position;
            aPos.x = aPos.z = 0;

            aPos.y = _speed * Time.deltaTime;

            transform.position += aPos;
        }
    }
}