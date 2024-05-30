using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class initialScene : MonoBehaviour
{
    public string startScene;
    void Start()
    {
        if(checkInitial.debugSceneName == null){
            SceneManager.LoadScene(startScene);
        }else{
            SceneManager.LoadScene(checkInitial.debugSceneName);
            checkInitial.debugSceneName = null;
        }
    }
}
