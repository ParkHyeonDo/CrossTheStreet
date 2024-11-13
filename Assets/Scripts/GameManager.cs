using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private LevelGenerator levelGenerator;
    public TextMeshProUGUI gameOver;
    

    [HideInInspector]
    public int Coins;
    public float Score;


    private static GameManager Instance;

    public static GameManager instance
    {
        get
        {
            if (Instance == null)
            {
                Instance = FindObjectOfType<GameManager>();
            }
            return Instance;
        }

    }

    private void Update()
    {
        Score += Time.deltaTime*10;
    }

    public void GameOver() 
    {
        gameOver.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public int HaveCoin() 
    {
        return Coins;
    }

    public int HaveScore() 
    {
        return (int)Score;
    }
}

