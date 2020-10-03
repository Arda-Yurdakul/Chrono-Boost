using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.E))
                this.gameObject.SetActive(false);
        #else
            if (Input.touchCount > 0)
                this.gameObject.SetActive(false);
        #endif
    }
}
