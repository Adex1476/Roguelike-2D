using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    [SerializeField]
    private Text[] scoreTexts;

    // Start is called before the first frame update
    void Start()
    {
        ShowScores();
    }

    void ShowScores()
    {
        if (scoreTexts[0] != null)
        {
            scoreTexts[0].text = "LastScore: " + PlayerPrefs.GetInt("LastScore") + " pts";
        }
        if (scoreTexts[1] != null)
        {
            scoreTexts[1].text = "HighScore: " + PlayerPrefs.GetInt("HighScore") + " pts";
        }
    }

}
