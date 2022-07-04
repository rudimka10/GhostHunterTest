using UnityEngine;
using UnityEngine.SceneManagement;

namespace GhostHunter.UI
{
    public class MainMenu : MonoBehaviour
    {

        public void OnStartClick()
        {
            SceneManager.LoadScene("Game");
        }



    }
}