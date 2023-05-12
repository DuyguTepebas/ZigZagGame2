using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   [SerializeField] private Text startPanelBestScoreTest, restartPanelBestScoreText;
   [SerializeField] private GameObject wowPanel;
   [SerializeField]private Animator anim;
   

   private void Start()
   {
      startPanelBestScoreTest.text = "Best Score: " + PlayerPrefs.GetInt("BestScore");
      restartPanelBestScoreText.text = "Best Score: " + PlayerPrefs.GetInt("BestScore");
   }

   private void Update()
   {
      if (PlayerController.score > PlayerController.bestScore )
      {
         wowPanel.SetActive(true);
         anim.SetTrigger("IsBest"); 
      }
   }
}//class
