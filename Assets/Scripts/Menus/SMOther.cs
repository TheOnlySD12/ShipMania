using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SMOther : MonoBehaviour {
    public void PlayGame(){
        SceneManager.LoadScene("Level");
    }
    public void QuitGame(){
        Application.Quit();
    }
}
