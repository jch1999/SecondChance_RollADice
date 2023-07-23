using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 diceVelocity;
    // public bool  isRoll;
    public bool isRollAble;
    public bool isRolling;
    public bool  diceStop=true;
    public bool checkDiceRolled=false;
    // public bool isStopWaiting=false;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        isRollAble=true;
    }

    // Update is called once per frame
    void Update()
    {

        // if(isRoll)
        // {
        //     // isRoll=false;
        //     float dirX=Random.Range(0,500);
        //     float dirY=Random.Range(0,500);
        //     float dirZ=Random.Range(0,500);
        //     transform.position=new Vector3(0,2,0);
        //     transform.rotation=Quaternion.identity;
        //     //윗 방향으로 상승
        //     rb.AddForce(transform.up*500);
        //     //각 축으로 회전 넣기
        //     rb.AddTorque(dirX,dirY,dirZ);
        //     diceStop=false;
        //     // isStopWaiting=true;
        //     // StartCoroutine(CheckStop());
        // }
        // diceVelocity=rb.velocity;
        // // diceStop=(diceVelocity.x==0.0f&&diceVelocity.y==0.0f&&diceVelocity.z==0.0f);
        // if((diceVelocity.x==0.0f&&diceVelocity.y==0.0f&&diceVelocity.z==0.0f))
        // {
        //     InvokeRepeating("ReCheck",0.5f,1.0f);
        // }

        // if(!checkDiceRolled)
        // {
        //     checkDiceRolled=isRoll&&!diceStop;//실제로 돌아갔는지 확인
        //     isRoll=false;//돌아갔다는게 확정되면 돌기 명령 중지
        // }

        if(isRolling)
        {
            diceVelocity=rb.velocity;
            if((diceVelocity.x==0.0f&&diceVelocity.y==0.0f&&diceVelocity.z==0.0f))
            {
                InvokeRepeating("ReCheck",0.5f,1.0f);
            }
        }
    }
    void ReCheck()
    {
        diceStop=(diceVelocity.x==0.0f&&diceVelocity.y==0.0f&&diceVelocity.z==0.0f);
        if(diceStop)
        {
            CancelInvoke("ReCheck");
            isRollAble=true;
            isRolling=false;
        }
    }

    public void RollADice()
    {
        float dirX=Random.Range(0,500);
        float dirY=Random.Range(0,500);
        float dirZ=Random.Range(0,500);
        transform.position=new Vector3(0,2,0);
        transform.rotation=Quaternion.identity;
        //윗 방향으로 상승
        rb.AddForce(transform.up*500);
        //각 축으로 회전 넣기
        rb.AddTorque(dirX,dirY,dirZ);
        Debug.Log("Rolling!");
        isRollAble=false;
        isRolling=true;
        diceStop=false;
    }
    // IEnumerator CheckStop()
    // {
    //     while(!diceStop)
    //     {
    //         isStopWaiting=true;
    //         diceStop=(diceVelocity.x==0.0f&&diceVelocity.y==0.0f&&diceVelocity.z==0.0f);
    //         yield return null;
    //     }
    //     isStopWaiting=false;
    // }
}
