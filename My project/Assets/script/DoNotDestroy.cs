using UnityEngine;

public class DoNotDestroy : MonoBehaviour {

    public void Start(){
        DontDestroyOnLoad(this.gameObject);
    }
}
