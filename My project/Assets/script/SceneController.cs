using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{

    // Update is called once per frame
    public void GameStart(){
        SceneManager.LoadScene("choose");
    }
    public void MiniGame(){
        SceneManager.LoadScene("initialScene");
    }
    public void Main(){
        SceneManager.LoadScene("MainScene");
    }
}
