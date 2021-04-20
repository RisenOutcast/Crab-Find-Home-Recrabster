using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RO.Crab
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject Leaderboard;
        public GameObject Settings;

        private void Update()
        {
            if (Input.GetKeyDown("escape"))
                openSettings();
        }

        public void StartGame()
        {
            SceneManager.LoadScene("CrabHub");
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void openBoard()
        {
            if (Leaderboard.activeSelf)
            {
                Leaderboard.SetActive(false);
            }
            else
            {
                Leaderboard.SetActive(true);
                Settings.SetActive(false);
            }
        }

        public void openSettings()
        {
            if (Settings.activeSelf)
            {
                Settings.SetActive(false);
            }
            else
            {
                Settings.SetActive(true);
                Leaderboard.SetActive(false);
            }
        }
    }
}