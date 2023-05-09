using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   [SerializeField] private Text startPanelBestScoreTest;

   private void Start()
   {
      startPanelBestScoreTest.text = "Best Score: " + PlayerPrefs.GetInt("BestScore").ToString();
   }


  
}//class
