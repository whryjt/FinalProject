using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
   public static PlayerManager Instance { get; private set; }
    public GameObject playerPrefab;  // 拖动玩家數值顯示的预制件到这个字段

    private GameObject playerGo;

    private void Awake() {
        // 单例模式确保只有一个实例存在
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            CreatePlayer();
        } else {
            Destroy(gameObject);
        }
    }

    private void CreatePlayer() {
        if (playerGo == null) {
            playerGo = GameObject.Find("玩家數值顯示");
            if (playerGo == null) {
                playerGo = Instantiate(playerPrefab);
                playerGo.name = "玩家數值顯示";
            }
            DontDestroyOnLoad(playerGo);
        }
    }
}
