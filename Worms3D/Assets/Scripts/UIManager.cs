using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider teamOneHP;
    public Slider teamTwoHP;
    private void Start()
    {

        teamOneHP.maxValue = 200;
        teamTwoHP.maxValue = 200;

    }

    private void Update()
    {
        teamOneHP.value = PlayerSwitcher.GM.one[0].GetComponent<PlayerHealth>().currentHealth +
                          PlayerSwitcher.GM.one[1].GetComponent<PlayerHealth>().currentHealth;
        teamTwoHP.value = PlayerSwitcher.GM.two[0].GetComponent<PlayerHealth>().currentHealth +
                             PlayerSwitcher.GM.two[1].GetComponent<PlayerHealth>().currentHealth;
    }
}