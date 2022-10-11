using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    void Update()
    {
        if (PlayerSwitcher.GM.one[0].GetComponent<PlayerHealth>().currentHealth +
            PlayerSwitcher.GM.one[1].GetComponent<PlayerHealth>().currentHealth <= 0)
        {
            print("team one won");
        }


        if (PlayerSwitcher.GM.two[0].GetComponent<PlayerHealth>().currentHealth +
            PlayerSwitcher.GM.two[1].GetComponent<PlayerHealth>().currentHealth <= 0)
        {
            print("team two won");
        }
    }
}