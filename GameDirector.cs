using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject pointText;
    int point = 0;

    GameObject clearText;
    GameObject perfectText;

    public void getBronze()
    {
        this.point += 1;
    }
    public void getSilver()
    {
        this.point += 2;
    }
    public void getGold()
    {
        this.point += 3;
    }

    void Start()
    {
        this.pointText = GameObject.Find("Score");
        this.clearText = GameObject.Find("Clear");
        this.perfectText = GameObject.Find("Perfect");
    }

    void Update()
    {
        this.pointText.GetComponent<Text>().text = "Score : " + this.point.ToString();
    }

    public void clearGame()
    {
        if (point >= 56)//코인을 일정량 이상 모았을 경우 Perfect를 붙여서 출력
        {
            this.clearText.GetComponent<Image>().fillAmount = 0;
            this.perfectText.GetComponent<Image>().fillAmount = 1;
        }
        else //일반적인 Game Clear 메시지 출력
        {
            this.perfectText.GetComponent<Image>().fillAmount = 0;
            this.clearText.GetComponent<Image>().fillAmount = 1;
        }
        
    }
}
