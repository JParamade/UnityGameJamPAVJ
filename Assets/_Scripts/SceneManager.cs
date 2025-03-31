using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void PlayGame(string _sSceneName) { UnityEngine.SceneManagement.SceneManager.LoadScene(_sSceneName); }
    public void QuitGame() { Application.Quit(); }
}
