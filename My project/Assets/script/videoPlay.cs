using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class videoPlay : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoPlayer videoPlayer2;
    // Start is called before the first frame update
    private void Start()
    {
        // 在 VideoPlayer 组件上注册视频播放结束的回调函数
        videoPlayer.loopPointReached += OnVideoFinished;
        videoPlayer2.loopPointReached += OnVideoFinished;
    }

    // Update is called once per frame
    public void showMovie(){
        GameObject r = GameObject.Find("NPCManager");
        GameObject s = GameObject.Find("second");
        r.SetActive(false);
        s.SetActive(false);
        videoPlayer.Play();
    }
    public void showMovie2(){
        GameObject r = GameObject.Find("NPCManager");
        GameObject s = GameObject.Find("second");
        r.SetActive(false);
        s.SetActive(false);
        videoPlayer2.Play();
    }
    void OnVideoFinished(VideoPlayer vp)
    {
        // 加载回主场景
        SceneManager.LoadScene("MainScene");
    }
}
