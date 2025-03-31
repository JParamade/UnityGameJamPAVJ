using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void PlayGame() { UnityEngine.SceneManagement.SceneManager.LoadScene("pHABLO"); }
    public void QuitGame() { Application.Quit(); }
}
