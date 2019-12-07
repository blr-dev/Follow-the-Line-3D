using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DisplayScore : MonoBehaviour {
    [SerializeField] Text score;
    void Start ()
    {
        score = GetComponent<Text>();
        score.text = "Score: 0";
    }

    void Update()
    {
        score.text = "Score: " + PlayerPrefs.GetInt("Score", 0);
    }

}
