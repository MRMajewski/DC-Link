using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUserInterface : MonoBehaviour
{
    [SerializeField]
    Number LastGameScore;

    [SerializeField]
    Number RecordScore;

    void Start()
    {
        LastGameScore.Value = PlayerPrefs.GetInt(PlayerPrefsConst.LastGameScore, 0);
        RecordScore.Value = PlayerPrefs.GetInt(PlayerPrefsConst.RecordScore, 0);
    }

    public void LoadGame()
    {
        FindObjectOfType<SceneChanger>().ChangeScene(SceneNames.Game);
    }
}
