using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerNameController : MonoBehaviour
{
    private NameInput nameInput;

    // Start is called before the first frame update
    void Start()
    {
        // Find the GameObject that holds the NameInput component
        GameObject nameManager = GameObject.Find("NameManager");
        if (nameManager != null)
        {
            nameInput = nameManager.GetComponent<NameInput>();
            if (nameInput == null)
            {
                Debug.LogError("NameInput component not found on NameManager GameObject.");
                return;
            }
        }
        else
        {
            Debug.LogError("NameManager GameObject not found.");
            return;
        }

        // Find the GameObject that has the player's name TextMeshPro component
        GameObject playerNameObject = GameObject.Find("玩家名字");
        if (playerNameObject != null)
        {
            TextMeshProUGUI textComponent = playerNameObject.GetComponent<TextMeshProUGUI>();
            if (textComponent != null)
            {
                textComponent.text = nameInput.playerName;
            }
            else
            {
                Debug.LogError("TextMeshProUGUI component not found on 玩家名字 GameObject.");
            }
        }
        else
        {
            Debug.LogError("玩家名字 GameObject not found.");
        }
    }
}
