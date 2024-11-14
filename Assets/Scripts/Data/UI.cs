using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI CoinsText;
    [SerializeField] TextMeshProUGUI ScoreText;



    // Update is called once per frame
    void Update()
    {
        CoinsText.text = $"{GameManager.instance.HaveCoin()}";
        ScoreText.text = $"{GameManager.instance.HaveScore()}";
        // 발제에 시간마다 점수 올리라고 되있어서 그렇게 했습니다.
    }
}
