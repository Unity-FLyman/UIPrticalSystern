using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// URP
// UICANVAS 需要设置成Screen Space - Camera
// ParticalSystern 修改rotation = 0 保证所有Partical 朝向UI  可以设置Gravity 
// 如何播放 Partical Systerm  GameObject SETActTure 即可


public class Timer: MonoBehaviour

{
  public Text timerText;
  private float timer = 30;
  private bool isTimeouts = false;
  public GameObject WinCanvas;
  public GameObject[] Start;
  private int coinNum;
  //  coinNum < 4   1->Start
  //  coinNum <= x <8  2->Start
  //  coinNum x>=8    3->Start

  private void Update()
  {
    TheTimer();
  }

  private void TheTimer()
  {
    if (isTimeouts==false)
    {
      timer -= Time.deltaTime;
      timerText.text =string.Format("{0:F2}",timer); // 保留2位小数
      if (timer <= 0)
      {
        isTimeouts = true; 
        timerText.text = "00:00";
        
      }
    }
  }

  IEnumerator ShowStarts()
  {
    WinCanvas.SetActive(true);
    if (coinNum<4)
    {
      Start[0].SetActive(true);
    }
    else if (coinNum < 0)
    {
      Start[0].SetActive(true);
      yield return  new WaitForSeconds(1f);
      Start[1].SetActive(true);
    }
    else
    {
      Start[0].SetActive(true);
      yield return  new WaitForSeconds(1f);
      Start[1].SetActive(true);
      yield return  new WaitForSeconds(1f);
      Start[2].SetActive(true);
    }


  }
}