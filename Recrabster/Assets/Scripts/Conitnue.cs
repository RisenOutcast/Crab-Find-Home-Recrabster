using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RO.Crab
{
    public class Conitnue : MonoBehaviour
    {
        public void ContinueButton()
        {
            Master.instance.points = 0;
            Master.instance.Playerhealth = 50;
            Master.instance.kuorienMäärä -= 35;
            if(!Master.instance.bossKeyObtained)
                Master.instance.waveCount -= 1;
            SceneManager.LoadScene("CrabHub");
        }
    }
}