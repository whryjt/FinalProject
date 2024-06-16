using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 問答場景 : MonoBehaviour
{
    public GameObject Return;
    public void ActivateSpecificNPC(string childName)
    {
        // 查找 NPCManager 对象
        GameObject NPCManager = GameObject.Find("NPCManager");

        if (NPCManager != null)
        {
            // 查找特定的子对象
            Transform child = NPCManager.transform.Find(childName);

            if (child != null)
            {
                // 设置子对象为活跃
                child.gameObject.SetActive(true);
                GameObject background = GameObject.Find("背景");
                Return.SetActive(true);
                
                if (background != null)
                {
                    background.SetActive(false);
                }
            }
        }
    }
}

