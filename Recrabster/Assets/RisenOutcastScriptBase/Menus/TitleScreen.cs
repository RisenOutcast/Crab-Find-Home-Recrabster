using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RO.Menus
{
    public class TitleScreen : MonoBehaviour
    {
        public string LevelName;

        void Update()
        {
            if (Input.anyKey)
                SceneManager.LoadScene(LevelName);

        }
    }
}