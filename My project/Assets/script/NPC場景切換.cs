using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC場景切換 : MonoBehaviour
{
    // Start is called before the first frame update
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
