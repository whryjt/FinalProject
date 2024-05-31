using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
     [HideInInspector]
    public string startScene;

    // Update is called once per frame
    public void GameStart(){
        SceneManager.LoadScene("choose");
    }
    public void MiniGame(){
        SceneManager.LoadScene("小遊戲");
    }
    public void Main(){
        SceneManager.LoadScene("MainScene");
    }
    public void ExitMiniGame(){
         GameObject playerGo = GameObject.Find("玩家數值顯示");
        if(playerGo != null){
            Destroy(playerGo);
        }
        SceneManager.LoadScene("MainScene");
    }
}
