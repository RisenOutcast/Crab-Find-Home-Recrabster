using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RO.Menus
{
    public class PauseMenu : MonoBehaviour
    {
        public string MenuScene;
        public string RestartScene;
        public static bool GameIsPaused = false;

        public GameObject pauseMenuUI;

        private void Start()
        {
            if (GameIsPaused)
            {
                Resume();
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Cancel"))
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        public void Resume()
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

        void Pause()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        public void LoadMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(1);
        }

        public void QuitGame()
        {
            Debug.Log("Quitting Game...");
            SceneManager.LoadScene(MenuScene);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(RestartScene);
        }
    }
}