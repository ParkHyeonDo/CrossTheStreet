using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI GameOverText;
    

    [HideInInspector]
    public int Coins;
    public float Score;
    public bool IsGameOver=false;


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

    private void Start()
    {
        ObjectPool.Instance.CreatePools();
    }

    private void Update()
    {
        if (IsGameOver) 
        {
            return;
        }
        Score += Time.deltaTime*10;
    }

    public void GameOver() 
    {
        GameOverText.gameObject.SetActive(true);
        IsGameOver = true;
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

