using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public string scenename;
    public void sceneswap()
    {
        SceneManager.LoadScene(scenename);

    }

    public void Quit()
    {
        Application.Quit();
    }

}
