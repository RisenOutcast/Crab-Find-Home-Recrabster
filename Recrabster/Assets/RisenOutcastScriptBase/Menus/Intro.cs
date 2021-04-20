using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RO.Menus
{
    public class Intro : MonoBehaviour
    {
        public string SceneName;

        // Update is called once per frame
        void Update()
        {
            if (Input.anyKey)
                SceneManager.LoadScene(SceneName);

        }
    }
}