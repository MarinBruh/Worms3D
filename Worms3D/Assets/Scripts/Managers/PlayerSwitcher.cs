using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public enum GameState
{
    Movement,
    Weapon,
    Observing,
    Damage,
    Killing,
    Drop,
    EndOfRound,
    StartOfRound
}


public class PlayerSwitcher : MonoBehaviour
{
    public bool teamOneActive;
    public bool teamTwoActive;
    public bool roundEnd;
    public GameObject[] players;
    public GameObject[] cameras;
    public GameObject[] teamOne;
    public GameObject[] teamTwo;
    private int currentPlayerIndex;
    private int currentCameraIndex;
    public bool isActive;
    public static PlayerSwitcher GM;
    public GameState State { get; private set; }
    public float roundTimer;
    public float maxRoundTime = 20;
    public TMP_Text roundTimerText; 
    
    public Slider teamOneHealth;
    public Slider teamTwoHealth;

    
    // Start is called before the first frame update
    void Start()
    {
        GM = this;
        State = GameState.Movement;
        roundTimer = maxRoundTime;
        currentPlayerIndex = 0;
        currentCameraIndex = 0;
        
        teamOneHealth.maxValue = 200;
        teamTwoHealth.maxValue = 200;

        for (int i = 1; i < players.Length; i++)
        {
            players[i].GetComponent<PlayerController>().playerActive = false;
            
        }

        if (players.Length > 0)
        {
            players[0].GetComponent<PlayerController>().playerActive = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerSwitcher.GM.State != GameState.StartOfRound)
        {
            HandleRound();
        }
        
        //print(State);
        
        teamOneHealth.value = PlayerSwitcher.GM.teamOne[0].GetComponent<PlayerHealth>().currentHealth +
                          PlayerSwitcher.GM.teamOne[1].GetComponent<PlayerHealth>().currentHealth;
        teamTwoHealth.value = PlayerSwitcher.GM.teamTwo[0].GetComponent<PlayerHealth>().currentHealth +
                             PlayerSwitcher.GM.teamTwo[1].GetComponent<PlayerHealth>().currentHealth;

        //teamOneHealthSlider.value = playerHealth PlayerHealth.currentHealth;
        //teamTwoHealthSlider.value = playerHealth PlayerHealth.currentHealth;
    }

    void HandleRound()
    {
        roundTimer -= Time.deltaTime;
        roundTimerText.SetText(roundTimer.ToString("F0"));

        if (players[currentPlayerIndex].GetComponent<PlayerHealth>().isDead == true)
        {
            print("A player died");
            roundTimer = 0;
        }
        
        if (roundTimer <= 0)
        {
            if (roundEnd)
            {

                roundTimer = 5;
                GM.State = GameState.EndOfRound;
                roundEnd = false;

            }
            else
            {
                if (GM.State == GameState.Movement)
                {
                    currentPlayerIndex++;
                    currentCameraIndex++;
                    if (currentPlayerIndex < players.Length && currentCameraIndex < cameras.Length)
                    {
                        players[currentPlayerIndex - 1].GetComponent<PlayerController>().playerActive = false;
                        players[currentPlayerIndex].GetComponent<PlayerController>().playerActive = true;

                        cameras[currentCameraIndex - 1].gameObject.SetActive(false);
                        cameras[currentCameraIndex].gameObject.SetActive(true);


                        players[currentPlayerIndex].GetComponent<BazookaScript>().rocketAmmo = 1;
                    }
                    else
                    {
                        players[currentPlayerIndex - 1].GetComponent<PlayerController>().playerActive = false;
                        currentPlayerIndex = 0;
                        players[currentPlayerIndex].GetComponent<PlayerController>().playerActive = true;
                        
                        cameras[currentCameraIndex - 1].gameObject.SetActive(false);
                        currentCameraIndex = 0;
                        cameras[currentCameraIndex].gameObject.SetActive(true);

                        players[currentPlayerIndex].GetComponent<BazookaScript>().rocketAmmo = 1;
                    }
                    
                    roundTimer = maxRoundTime;
                }
                else
                {
                    roundTimer = 0;
                }


                if (GM.State == GameState.Movement)
                {
                    if (teamOneActive)
                    {
                        teamOneActive = false;
                        teamTwoActive = true;
                    }
                    else
                    {
                        teamOneActive = true;
                        teamTwoActive = false;
                    }
                }
                else
                {
                    //roundTimer = 0;
                }
            }
        }
    }

    public void Observing()
    {
        State = GameState.Observing;
    }

    public void Movement()
    {
        State = GameState.Movement;
    }
    
    public void Damage()
    {
        State = GameState.Damage;
    }

    public void Killing()
    {
        State = GameState.Killing;
    }

    public void StartOfRound()
    {
        State = GameState.StartOfRound;
    }

}
