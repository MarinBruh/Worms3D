using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public GameObject[] players;
    private int currentPlayerIndex;
    public bool isActice;
    public float timer = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        currentPlayerIndex = 0;

        for (int i = 1; i < players.Length; i++)
        {
            players[i].gameObject.SetActive(false);
        }

        if (players.Length > 0)
        {
            players[0].gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        
        if (timer <= 0.0f)
        {
            currentPlayerIndex++;
            if (currentPlayerIndex < players.Length)
            {
                players[currentPlayerIndex - 1].gameObject.SetActive(false);
                players[currentPlayerIndex].gameObject.SetActive(true);
            }
            else
            {
                players[currentPlayerIndex - 1].gameObject.SetActive(false);
                currentPlayerIndex = 0;
                players[currentPlayerIndex].gameObject.SetActive(true);
            }

            timer = 5.0f;
        }
    }
}
