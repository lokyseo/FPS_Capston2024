using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PunchKingManager : MonoBehaviour
{
    public Text score_txt;
    public static float curScore;

    void Start()
    {
        curScore = 0;
        score_txt.text = "점수 : " + curScore.ToString("F0");
    }

    void Update()
    {
        score_txt.text = "점수 : " + curScore.ToString("F0");

    }


}
