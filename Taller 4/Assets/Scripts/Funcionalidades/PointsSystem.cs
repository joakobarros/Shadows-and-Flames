using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointsSystem : MonoBehaviour
{   
    public static PointsSystem Instance {get; private set;}
    public TextMeshProUGUI totalPoints;
    public TextMeshProUGUI totalHits;
    public TextMeshProUGUI comboCalif;
    private int hitsCounter;
    private float countPoints;
    private char combo;
    private float multiplicator = 1f;
    private bool fighting;
    [SerializeField] private float timerMarker = 0;
    [SerializeField] private float timerReset = 5f;

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

    void Update()
    {
        PointCalculator();
        totalPoints.text = ("puntos: " + (countPoints).ToString());
        totalHits.text = ("Golpes: " + hitsCounter);
        comboCalif.text = (combo.ToString());

        if (fighting && timerMarker < timerReset)
        {
            timerMarker += Time.deltaTime;
        }
        else
        {
            CounterReset();
        }
    }

    public void HitMarker()
    {
        hitsCounter++;
        timerMarker = 0;
        fighting = true;
        ActiveComboMarker(fighting);
    }

    private void PointCalculator()
    {
        switch (hitsCounter)
        {
            case 2:
                combo = 'C';
                multiplicator = 1.2f;
            break;

            case 6:
                combo = 'B';
                multiplicator = 1.5f;
            break;

            case 8:
                combo = 'A';
                multiplicator = 1.7f;
            break;

            case 10:
                combo = 'S';
                multiplicator = 2f;
            break;

            default:
            break;
        }
    }

    public void CounterReset()
    {
        hitsCounter = 0;
        combo = ' ';
        multiplicator = 1f;
        timerMarker = 0;
        fighting = false;
        ActiveComboMarker(fighting);
    }

    public void ActiveComboMarker(bool active)
    {
        totalHits.enabled = active;
        comboCalif.enabled = active;
    }

    public void CountPoints (int points)
    {
        countPoints += points * multiplicator;
    }

}
