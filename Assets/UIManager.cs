using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI AutoScoreText;
    string autoText="Auto's Score: ";
    
    [SerializeField]
    TextMeshProUGUI UserScoreText;
    string userText="User's Score: ";

    [SerializeField]
    TextMeshProUGUI turnText;
    [SerializeField]
    GameObject UserRollButton;

    public void TurnTextSwitch(string comment)
    {
        turnText.text=comment;
        turnText.gameObject.SetActive(true);
    }

    public void UpdateText(ref float autoScore,ref float UserScore)
    {
        AutoScoreText.text=autoText+autoScore;
        UserScoreText.text=userText+UserScore;
    }

    public void SwitchUserRollButton(bool state)
    {
        UserRollButton.SetActive(state);
    }
}
