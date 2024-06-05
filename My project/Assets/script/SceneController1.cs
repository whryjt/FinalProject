using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController1 : MonoBehaviour
{
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
        SceneManager.LoadScene("問答場景");
    }

    public void NPCinteract(){
        SceneManager.LoadScene("NPC互動場景");
    }
    public void ExitrequestGame(){
        SceneManager.LoadScene("MainScene");
    }

    public void checkNPC(){
        SceneManager.LoadScene("check NPC");
    }
    public void FinalScene(){
        SceneManager.LoadScene("FinalScene");
    }
}