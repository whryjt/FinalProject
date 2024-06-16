using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC場景切換 : MonoBehaviour
{
    private GameObject canvas1;
    private GameObject canvas2;
    private void Start(){
        canvas1 = GameObject.Find("first");
        canvas2 = GameObject.Find("second");
    }
    // Start is called before the first frame update
    public void ActivateSpecificNPC(string childName)
    {
        // 查找 NPCManager 对象
        GameObject NPCManager = GameObject.Find("NPCManager");
        if (NPCManager != null)
        {
            canvas1.SetActive(false);
            canvas2.SetActive(true);
            // 查找特定的子对象
            Transform child = NPCManager.transform.Find(childName);
            
            if (child != null)
            {
                // 设置子对象为活跃
                child.gameObject.SetActive(true);
            }
        }
    }
}
