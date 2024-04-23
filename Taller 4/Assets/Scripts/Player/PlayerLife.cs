using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{

    public Image lifeBar;
    [SerializeField]private float lifeNow;
    [SerializeField] private float lifeMax;

    private void Start()
    {
        lifeNow = lifeMax;
    }

    void Update()
    {   
        lifeBar.fillAmount = lifeNow/lifeMax;
    }

    public void OnHit(float damage)
    {
        lifeNow -= damage;
    }
}
