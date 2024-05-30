using UnityEngine;

public class ConveyorBeltUVAnimation : MonoBehaviour
{
    public float scrollSpeed = 0.5f; // 滚动速度
    private Renderer rend;
    private Vector2 savedOffset;

    void Start()
    {
        rend = GetComponent<Renderer>();
        savedOffset = rend.sharedMaterial.GetTextureOffset("_MainTex");
    }

    void Update()
    {
        float x = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(x, savedOffset.y);
        rend.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    void OnDisable()
    {
        rend.sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }
}
