using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    private int result;
    private int finalScore;
    private int enemiesCount;
    private int roomsCount;

    [SerializeField] private Text resultTxt;
    [SerializeField] private Text scoreTxt;
    [SerializeField] private Text roomsTxt;
    [SerializeField] private Text enemiesTxt;
    [SerializeField] private GameObject highScorePopUp;


    [SerializeField] private AudioSource audiosource;
    [SerializeField] private AudioClip victoryMusic;
    [SerializeField] private AudioClip defeatMusic;

    // Start is called before the first frame update
    void Start()
    {
        finalScore = PlayerPrefs.GetInt("LastScore");
        enemiesCount = PlayerPrefs.GetInt("SlainedEnemies");
        roomsCount = PlayerPrefs.GetInt("Rooms");
        result = PlayerPrefs.GetInt("ResultID");
        if (result == 0)
        {
            resultTxt.text = "VICTORY";
            resultTxt.color = Color.green;

            audiosource.clip = victoryMusic;
            audiosource.Play();
        }
        if (result == 1)
        {
            resultTxt.text = "DEFEAT";
            resultTxt.color = Color.red;

            audiosource.clip = defeatMusic;
            audiosource.Play();
        }
        if (PlayerPrefs.GetInt("HSBool") == 1)
        {
            //EffectAudioController.PlaySound("HighScore");
            StartCoroutine(HighScoreEffect());
        }
        scoreTxt.text = "SCORE: " + finalScore + " PTS";
        roomsTxt.text = "WIPED ROOMS: " + roomsCount;
        enemiesTxt.text = "SLAINED ENEMIES: " + enemiesCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator HighScoreEffect()
    {
        highScorePopUp.SetActive(true);
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < 3; i++)
        {
            highScorePopUp.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            highScorePopUp.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            highScorePopUp.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            highScorePopUp.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
