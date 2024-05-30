using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class 介面controller : MonoBehaviour
{
    public void GameStart(){
        SceneManager.LoadScene("choose");
    }
}
