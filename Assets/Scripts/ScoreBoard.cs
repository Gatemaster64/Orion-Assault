using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{

    int score;


   // make to score go up by the amount passed into the "amountToIncrease" variable.
    public void IncreaseScore(int amountToIncrease)
    {
        score =+ amountToIncrease;
    }

    
}
