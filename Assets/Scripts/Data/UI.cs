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
        // ������ �ð����� ���� �ø���� ���־ �׷��� �߽��ϴ�.
    }
}
