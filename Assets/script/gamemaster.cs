using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamemaster : MonoBehaviour
{
    public int points = 0;
    public int highscore = 0;

    public Text pointtext;
    public Text Hightext;
    public Text Inputtext;
   
    // Use this for initialization
    void Start()
    {
        Hightext.text = ("HighScore : " + PlayerPrefs.GetInt("highscore"));
        // dat lai diem bang khong khi qua ve man dau tien
        highscore = PlayerPrefs.GetInt("highscore", 0);

        if (PlayerPrefs.HasKey("points"))
        {
            Scene ActiveScene = SceneManager.GetActiveScene();
            if (ActiveScene.buildIndex == 0)
            {
                PlayerPrefs.DeleteKey("points");
                points = 0;
            }
            else
            {
                // lay points hien tai
                points = PlayerPrefs.GetInt("points");
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        pointtext.text = ("Points: " + points);
    }
}
