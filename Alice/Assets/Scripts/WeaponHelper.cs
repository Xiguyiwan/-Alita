using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHelper : MonoBehaviour
{
    int score;

    public int Score { get
        {
            return score;
        }
        set { score = value; }
        }

    Text uiScore;
    // Start is called before the first frame update
    void Start()
    {
        uiScore = GameObject.Find("TextScore").GetComponent<Text>();
    }

    public void GetScore(int _score)
    {
        score += _score;
        uiScore.text = "Score: " + score;
        //print("Score: " + score);
        // represent in UI:

    }
}
