using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // 引入TextMeshPro的命名空间
public class NameInput : MonoBehaviour
{
    public Button inputButton;
    public TMP_InputField nameInputField; // 使用TMP_InputField
    public string playerName;
    // Start is called before the first frame update
    void Start()
    {
        inputButton.onClick.AddListener(OnInputButtonClick);
        nameInputField.onSubmit.AddListener(OnNameSubmit);
        nameInputField.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void OnInputButtonClick(){
        nameInputField.gameObject.SetActive(true);
        nameInputField.ActivateInputField();
    }

    void OnNameSubmit(string name)
    {
        // 存储玩家名字
        playerName = name;
        Debug.Log("Player Name: " + playerName);
        
        // 隐藏输入字段
        nameInputField.gameObject.SetActive(false);
        inputButton.gameObject.SetActive(false);
    }

}
