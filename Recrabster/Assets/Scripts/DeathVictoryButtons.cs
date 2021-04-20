using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RO.Crab
{
    public class DeathVictoryButtons : MonoBehaviour
    {
        public void BackToMenuButton()
        {
            Master.instance.Playerhealth = 100;
            Master.instance.waveCount = 0;
            Master.instance.kuorienMäärä = 0;
            Master.instance.points = 0;
            Master.instance.hasBoughtFire1 = false;
            Master.instance.hasBoughtFire3 = false;
            Master.instance.bossKeyObtained = false;
            SceneManager.LoadScene("CrabMainMenu");
        }
    }
}