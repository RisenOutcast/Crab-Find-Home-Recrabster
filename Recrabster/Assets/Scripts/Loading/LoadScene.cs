using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Author M.J.Metsola @RisenOutcast

public class LoadScene : MonoBehaviour
{
    public Slider LoadingBar;

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);


        while (!operation.isDone)
        {
            LoadingBar.value = operation.progress;

            yield return null;
        }
    }
}
