using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZone : MonoBehaviour
{
    public float number;
    
    void OnTriggerStay(Collider other)
    {
        number=CheckNumber(other.gameObject.name);
    }
    
    float CheckNumber(string name)
    {
        switch(name){
            case "Side 1":
                return 6f;
            case "Side 2":
                return 5f;
            case "Side 3":
                return 4f;
            case "Side 4":
                return 3f;
            case "Side 5":
                return 2f;
            case "Side 6":
                return 1f;
            default:
                return 0f;
        }
    }
}
