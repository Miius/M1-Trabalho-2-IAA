using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField] private MazeSpawner mazeSpawner;

    [SerializeField] private Transform playerTarget;
    public Transform PlayerTarget
    {
        get { return playerTarget; }
        set { playerTarget = value; }
    }
    [SerializeField] private Transform scapeTarget;
    [SerializeField] private int powerUps = 0;
    [SerializeField] private TextMeshProUGUI powerUpsText;


    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // foreach (var navMeshMoviment in FindObjectsOfType<NavMeshMovement>())
        //     // navMeshMoviment.ReciveTarget(scapeTarget);
    }
    public void AddPowerUps(){
        powerUps++;
        if (powerUps >= 5)
        {
            SceneManager.LoadScene("Win");
        }
        AddPowerUpsText();
    }
    public void AddPowerUpsText(){
        powerUpsText.gameObject.SetActive(true);
        powerUpsText.text = powerUps.ToString();
        Invoke("HideText", 3.0f);
    }
    void HideText(){
        powerUpsText.gameObject.SetActive(false);
    }
}
