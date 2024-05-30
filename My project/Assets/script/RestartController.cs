using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartController : MonoBehaviour
{
    private GameObject player;
    private GameObject Canvas;
    public void Restart()
    {
        player = GameObject.Find("Player");
        Canvas = GameObject.Find("Canvas");
        Time.timeScale = 1f;
        if (player != null){
            Destroy(player);
        } 

        if (Canvas != null){
            Destroy(Canvas);
        }
        SceneManager.LoadScene("initialScene");
    }
}
