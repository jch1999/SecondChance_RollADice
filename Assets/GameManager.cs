using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Dice gameDice;
    bool isDiceRolled;

    [SerializeField]
    DiceCheckZone checker;

    [SerializeField]
    UIManager _UIManager;
    public bool IsUserTurn=false;//Turn Check
    public bool IsGameEnd=false;
    public bool IsStarted=false;
    public bool[] isSecondChance=new bool[2];//0 Auto 1 User

    public float AutoScore=0;
    public float UserScore=0;
    
    // Start is called before the first frame update
    void Start()
    {
        // gameDice=GameObject.Find("Dice").GetComponent<Dice>();
        isDiceRolled=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsStarted)return;
        
        // Debug.Log(gameDice.diceStop);
        if(!IsGameEnd)
        {
            //주사위가 실제로 돌아갔는지 확인 -> dice로 이동
            // if(!gameDice.diceStop&&gameDice.isRoll)checkDiceRolled=true;

            if(gameDice.diceStop&&isDiceRolled)
            {
                isDiceRolled=false;
                // gameDice.isStopWaiting=false;
                Debug.Log("DiceStopped");
                TurnCheck();
            }
        }
        else
        {
            if(UserScore>AutoScore)
                _UIManager.TurnTextSwitch("You Win!");
            else if(UserScore==AutoScore)
                _UIManager.TurnTextSwitch("Draw!");
            else 
                _UIManager.TurnTextSwitch("Lose");
        }
    }

    // IEnumerator TurnCheck()
    void TurnCheck()
    {
        // yield return new WaitForSeconds(.3f);
        if(IsUserTurn&&isSecondChance[1])
        {
            UserScore+=checker.number;
            UserScore/=2;
            IsGameEnd=true;
        }
        else if(IsUserTurn&&!isSecondChance[1])
        {
            UserScore+=checker.number;
            isSecondChance[1]=true;
            //유저 턴이 끝나고 유저가 더 큰 값을 얻으면 auto는 주사위를 한 번 더 굴린다.
            CheckScore();
        }
        else if(!IsUserTurn&&isSecondChance[0])
        {
            AutoScore+=checker.number;
            AutoScore/=2;
            CheckScore();
        }
        else if(!IsUserTurn&&!isSecondChance[0])
        {
            AutoScore+=checker.number;
            // isSecondChance[0]=true;
            _UIManager.SwitchUserRollButton(true);
            _UIManager.TurnTextSwitch("Your Turn");
            IsStarted=false;//다음 턴이 진행될 때까지 다시 못 들어오게 막기
        }
        _UIManager.UpdateText(ref AutoScore,ref UserScore);
    }

    public void UserRollDice()
    {
        // gameDice.isRoll=true;
        gameDice.RollADice();
        isDiceRolled=true;
        _UIManager.SwitchUserRollButton(false);
        IsUserTurn=true;
    }

    public void CheckScore()
    {
        //유저가 첫 번째 던지기에서 이긴 경우 auto는 한 번 더 던진다
        if(UserScore>AutoScore && !isSecondChance[0])
        {
            isSecondChance[0]=true;
            // gameDice.diceStop=false;
            gameDice.RollADice();
            isDiceRolled=true;
            IsUserTurn=false;
            // gameDice.isRoll=true;
            _UIManager.TurnTextSwitch("Auto Turn");
        }
        //auto의 두 번째 던지기에서도 auto가 이기지 못햇다면 user의 승리다.
        else if(UserScore>AutoScore)
        {
            IsGameEnd=true;
        }
        else
        {
            IsStarted=false;//다음 턴이 진행될 때까지 다시 못 들어오게 막기
            _UIManager.SwitchUserRollButton(true);
            _UIManager.TurnTextSwitch("Your Turn");
        }
    }

    public void StartGame()
    {
        // gameDice.isRoll=true;
        // Invoke()
        IsStarted=true;
        isDiceRolled=true;
        gameDice.RollADice();
    }

    // public void TurnStart()
    // {
    //     IsStarted=true;
    // }

    public void ResetGame()
    {
        AutoScore=0;
        UserScore=0;
        for(int i=0;i<isSecondChance.Length;i++)
        {
            isSecondChance[i]=false;
        }
    }
}
