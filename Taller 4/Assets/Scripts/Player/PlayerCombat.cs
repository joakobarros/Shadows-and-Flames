using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{   
    public PlayerController pC;
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;
    private String activeCombo;
    public bool onCombo;
    private Animator anim;
    [SerializeField] private float timerAttack = 0;
    [SerializeField] private float resetTime;

    private void Start() 
    {
        anim = GetComponent<Animator>();    
    }

    void Update()
    {
        if (onCombo)
        {
            timerAttack += Time.deltaTime;
        }

        AttackReset();

        if (Input.GetButtonDown("Fire1") && !onCombo && pC.jumping)
        {   
            pC.attacking = true;

            switch (activeCombo)
            {
                case "R":
                    weapon1.SetActive(true);
                    activeCombo = "RR";
                    PointsSystem.Instance.SetCombo("Combo: " + activeCombo);
                    timerAttack = 0;
                    break;
                
                case "RR":
                    weapon1.SetActive(true);
                    activeCombo = "RRR";
                    PointsSystem.Instance.SetCombo("Combo: " + activeCombo);
                    TimeReset();
                break;

                case "F":
                    weapon1.SetActive(true);
                    activeCombo = "FR";
                    PointsSystem.Instance.SetCombo("Combo: " + activeCombo);
                    timerAttack = 0;
                break;

                case "FR":
                    weapon1.SetActive(true);
                    activeCombo = "FRR";
                    PointsSystem.Instance.SetCombo("Combo: " + activeCombo);
                    TimeReset();
                break;

                case "none":
                    weapon1.SetActive(true);
                    activeCombo = "R";
                    PointsSystem.Instance.SetCombo("Combo: " + activeCombo);
                    onCombo = true;
                break;

                default: 
                    weapon1.SetActive(true);
                    activeCombo = "R"; 
                    PointsSystem.Instance.SetCombo("Combo: " + activeCombo);
                    onCombo = true;
                break;
            }
        }
        
        if (Input.GetButtonUp("Fire1"))
        {
            weapon1.SetActive(false);
        }

        if (Input.GetButtonDown("Fire2") && !onCombo && pC.jumping)
        {
            pC.attacking = true;
            
            switch (activeCombo)
            {
                case "FF":
                    weapon2.SetActive(true);
                    activeCombo = "FFF";
                    PointsSystem.Instance.SetCombo("Combo: " + activeCombo);
                    TimeReset();
                break;
                
                case "R":
                    weapon2.SetActive(true);
                    activeCombo = "RF";
                    PointsSystem.Instance.SetCombo("Combo: " + activeCombo);
                    timerAttack = 0;
                break;

                case "RF":
                    weapon2.SetActive(true);
                    activeCombo = "RFF";
                    PointsSystem.Instance.SetCombo("Combo: " + activeCombo);
                    TimeReset();
                break;

                case "RR":
                    weapon2.SetActive(true);
                    activeCombo = "RRF";
                    PointsSystem.Instance.SetCombo("Combo: " + activeCombo);
                    TimeReset();
                break;

                case "FE":
                    weapon2.SetActive(true);
                    activeCombo = "FEF";
                    PointsSystem.Instance.SetCombo("Combo: " + activeCombo);
                    TimeReset();
                break;

                case "F":
                    weapon2.SetActive(true);
                    activeCombo = "FF";
                    PointsSystem.Instance.SetCombo("Combo: " + activeCombo);
                    timerAttack = 0;
                break;

                case "none":
                    weapon2.SetActive(true);
                    activeCombo = "F"; 
                    PointsSystem.Instance.SetCombo("Combo: " + activeCombo);
                    onCombo = true;
                break;

                default: 
                    weapon2.SetActive(true);
                    activeCombo = "F"; 
                    PointsSystem.Instance.SetCombo("Combo: " + activeCombo);
                    onCombo = true;
                break;
            }
        }
        
        if (Input.GetButtonUp("Fire2"))
        {
            weapon2.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && !onCombo && pC.jumping)
        {
            pC.attacking = true;

            switch (activeCombo)
            {
                case "F":
                    weapon3.SetActive(true);
                    activeCombo = "FE";
                    PointsSystem.Instance.SetCombo("Combo: " + activeCombo);
                    timerAttack = 0;
                    break;
                
                case "FF":
                    weapon3.SetActive(true);
                    activeCombo = "FFE";
                    PointsSystem.Instance.SetCombo("Combo: " + activeCombo);
                    TimeReset();
                break;

                case "RR":
                    weapon3.SetActive(true);
                    activeCombo = "RRE";
                    PointsSystem.Instance.SetCombo("Combo: " + activeCombo);
                    TimeReset();
                break;

                case "none":
                    weapon3.SetActive(true);
                    activeCombo = "E";
                    PointsSystem.Instance.SetCombo("Combo: " + activeCombo);
                    onCombo = true;
                break;

                default: 
                    weapon3.SetActive(true);
                    activeCombo = "E"; 
                    PointsSystem.Instance.SetCombo("Combo: " + activeCombo);
                    onCombo = true;
                break;
            }
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            weapon3.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetTrigger("Golpeo");
            pC.attacking = true;
        }
        
    }

    private void TimeReset()
    {
        onCombo = false;
        timerAttack = 0;
    }

    private void AttackReset()
    {
        if (timerAttack > resetTime)
        {
            onCombo = false;
            timerAttack = 0;
            activeCombo = "none";
            //Debug.Log("combo: " + activeCombo);
        }
    }
}
