using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionColor : MonoBehaviour
{
    [SerializeField] int levelNumber;
    Text levelNumberText;
    // Start is called before the first frame update
    void Start()
    {
        levelNumberText = GetComponentInChildren<Text>();
        if (PlayerPrefs.GetInt("HighestLevel") < levelNumber - 1)
            levelNumberText.color = Color.red;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
