using TMPro;
using UnityEngine;
using Zenject;

namespace GhostHunter.UI
{
    public class GameCanvas : MonoBehaviour
    {
        [Inject]
        [SerializeField] private GameController _gameController;
        [SerializeField] private TMP_Text _pointsLabel;

        private void Awake()
        {
            _gameController.CurrentScore.ValueChanged += UpdateLabel;
        }

        private void UpdateLabel()
        {
            _pointsLabel.text = $"Current score: {_gameController.CurrentScore.Value}";
        }

        private void OnDestroy()
        {
            _gameController.CurrentScore.ValueChanged -= UpdateLabel;

        }

    }
}