using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 問答場景 : MonoBehaviour
{
    private GameObject Return;
    public void Start(){
        Return = GameObject.Find("返回");
        Return.SetActive(false);
    }
    public void ActivateSpecificNPC(string childName)
    {
        // 查找 NPCManager 对象
        GameObject NPCManager = GameObject.Find("NPCManager");
        Debug.Log("查找 NPCManager: " + (NPCManager != null ? "找到" : "未找到"));

        if (NPCManager != null)
        {
            // 查找特定的子对象
            Transform child = NPCManager.transform.Find(childName);
            Debug.Log("查找子对象 " + childName + ": " + (child != null ? "找到" : "未找到"));

            if (child != null)
            {
                // 设置子对象为活跃
                child.gameObject.SetActive(true);
                Debug.Log("激活子对象 " + childName);
                
                // 查找并关闭背景对象
                GameObject background = GameObject.Find("背景");
                Return.SetActive(true);
                Debug.Log("查找 背景: " + (background != null ? "找到" : "未找到"));
                
                if (background != null)
                {
                    background.SetActive(false);
                    Debug.Log("背景已关闭");
                }
                else
                {
                    Debug.LogWarning("Background object not found!");
                }
            }
            else
            {
                Debug.LogWarning("Child object not found: " + childName);
            }
        }
        else
        {
            Debug.LogWarning("NPCManager object not found!");
        }
    }
}

