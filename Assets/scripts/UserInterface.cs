using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInterface : MonoBehaviour
{
    [SerializeField]
    Number TimeCounter;

    [SerializeField]
    Number ScoreCounter;

    void Start()
    {
        FindObjectOfType<GameManager>().OnRemainingTimeChanged += time =>
            TimeCounter.Value = (int)time;

        FindObjectOfType<GameManager>().OnScoreChanged += score =>
            ScoreCounter.Value = (int)score;
    }
}
