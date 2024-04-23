using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;
    private String activeCombo;
    private bool attacking;
    [SerializeField] private float timerAttack = 0;
    [SerializeField] private float resetTime;

    void Update()
    {
        if (attacking)
        {
            timerAttack += Time.deltaTime;
        }

        AttackReset();

        if (Input.GetButtonDown("Fire1"))
        {   
            switch (activeCombo)
            {
                case "R":
                    weapon1.SetActive(true);
                    activeCombo = "RR";
                    timerAttack = 0;
                    break;
                
                case "RR":
                    weapon1.SetActive(true);
                    activeCombo = "RRR";
                    TimeReset();
                break;

                case "F":
                    weapon1.SetActive(true);
                    activeCombo = "FR";
                    timerAttack = 0;
                break;

                case "FR":
                    weapon1.SetActive(true);
                    activeCombo = "FRR";
                    TimeReset();
                break;

                case "none":
                    weapon1.SetActive(true);
                    activeCombo = "R";
                    attacking = true;
                break;

                default: 
                    weapon1.SetActive(true);
                    activeCombo = "R"; 
                    attacking = true;
                break;
                
            }
        }
        
        if (Input.GetButtonUp("Fire1"))
        {
            weapon1.SetActive(false);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            switch (activeCombo)
            {
                case "FF":
                    weapon2.SetActive(true);
                    activeCombo = "FFF";
                    TimeReset();
                break;
                
                case "R":
                    weapon2.SetActive(true);
                    activeCombo = "RF";
                    timerAttack = 0;
                break;

                case "RF":
                    weapon2.SetActive(true);
                    activeCombo = "RFF";
                    TimeReset();
                break;

                case "RR":
                    weapon2.SetActive(true);
                    activeCombo = "RRF";
                    TimeReset();
                break;

                case "FE":
                    weapon2.SetActive(true);
                    activeCombo = "FEF";
                    TimeReset();
                break;

                case "F":
                    weapon2.SetActive(true);
                    activeCombo = "FF";
                    timerAttack = 0;
                break;

                case "none":
                    weapon2.SetActive(true);
                    activeCombo = "F"; 
                    attacking = true;
                break;

                default: 
                    weapon2.SetActive(true);
                    activeCombo = "F"; 
                    attacking = true;
                break;
            }
        }
        
        if (Input.GetButtonUp("Fire2"))
        {
            weapon2.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (activeCombo)
            {
                case "F":
                    weapon3.SetActive(true);
                    activeCombo = "FE";
                    timerAttack = 0;
                    break;
                
                case "FF":
                    weapon3.SetActive(true);
                    activeCombo = "FFE";
                    TimeReset();
                break;

                case "RR":
                    weapon3.SetActive(true);
                    activeCombo = "RRE";
                    TimeReset();
                break;

                case "none":
                    weapon3.SetActive(true);
                    activeCombo = "E";
                    attacking = true;
                break;

                default: 
                    weapon3.SetActive(true);
                    activeCombo = "E"; 
                    attacking = true;
                break;
            }

            Debug.Log("combo: " + activeCombo);
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            weapon3.SetActive(false);
        }
    }

    private void TimeReset()
    {
        attacking = false;
        timerAttack = 0;
    }

    private void AttackReset()
    {
        if (timerAttack > resetTime)
        {
            attacking = false;
            timerAttack = 0;
            activeCombo = "none";
            //Debug.Log("combo: " + activeCombo);
        }
    }
}
