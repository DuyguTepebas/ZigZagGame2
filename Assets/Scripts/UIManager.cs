using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   [SerializeField] private Text startPanelBestScoreTest;
   [SerializeField] private GameObject wowPanel;
   [SerializeField]private Animator anim;
   

   private void Start()
   {
      startPanelBestScoreTest.text = "Best Score: " + PlayerPrefs.GetInt("BestScore").ToString();
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
