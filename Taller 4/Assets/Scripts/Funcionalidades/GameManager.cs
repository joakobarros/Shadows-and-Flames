using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    public int TotalPoints { get { return totalPoints; } }
    private int totalPoints;

    private void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
        }    
        else
        {
            Debug.Log("mas de un game manager");
        }
    }

    public void CountPoints (int points)
    {
        totalPoints += points;
    }
}
