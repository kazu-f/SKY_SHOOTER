using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PushButton : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CrossPlatformInputManager.GetButton("Fire1"))
        {
            button.onClick.Invoke();
        }
    }
}
