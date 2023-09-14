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
        public GameObject Controls;
        public GameObject Wiki;

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
                Controls.SetActive(false);
                Wiki.SetActive(false);
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
                Controls.SetActive(false);
                Wiki.SetActive(false);
            }
        }

        public void openControls()
        {
            if (Controls.activeSelf)
            {
                Controls.SetActive(false);
            }
            else
            {
                Controls.SetActive(true);
                Leaderboard.SetActive(false);
                Settings.SetActive(false);
                Wiki.SetActive(false);
            }
        }

        public void openWiki()
        {
            if (Wiki.activeSelf)
            {
                Wiki.SetActive(false);
            }
            else
            {
                Wiki.SetActive(true);
                Controls.SetActive(false);
                Leaderboard.SetActive(false);
                Settings.SetActive(false);
            }
        }
    }
}