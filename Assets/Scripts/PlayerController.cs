using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Out Component")]
    [SerializeField] float speed;
    [SerializeField] Text scoreText, bestScoreText,restartPanelScoreText ;
    [SerializeField] GameObject restartPanel, playGamePanel;

    [Header("Public Variable")]
    public GroundSpawner groundSpawner;
    public float hizlanmaZorlugu;
    public static bool isDead = true;


    Vector3 yon = Vector3.left;
    public static float score = 0f;
    float artisMiktari = 1f;
    public static int bestScore = 0;

    private void Start()
    {
        if (RestartGame.isRestart)
        {
            isDead = false;
            playGamePanel.SetActive(false);
        }
        bestScore = PlayerPrefs.GetInt("BestScore");
        bestScoreText.text = "Best: " + PlayerPrefs.GetInt("BestScore");
    }

    private void Update()
    {
        if (isDead)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (yon.x == 0)
            {
                yon = Vector3.left;
            }
            else
            {
                yon = Vector3.back;
            }
        }

        if (transform.position.y < -1f)
        {
            isDead = true;
            if (bestScore < score)
            {
                bestScore = (int) score;
                PlayerPrefs.SetInt("BestScore", bestScore);
            }
            restartPanel.SetActive(true);
            Destroy(this.gameObject, 2f);
            score = 0;
        }
    }

    private void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }

        Vector3 hareket = yon * speed * Time.deltaTime;
        AccelerateTheGame();
        transform.position += hareket;

        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            StartCoroutine(YokEt(collision.gameObject));
            groundSpawner.ZeminOlustur();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            score += 5;
            Destroy(other.gameObject);
            scoreText.text = "Score: " +((int)score);
            restartPanelScoreText.text = "Score: " + score;
        }
    }

    void AccelerateTheGame()
    {
        if (score%2 == 0 && score%3 == 0 && score%5 == 0)
        {
            speed += hizlanmaZorlugu * Time.deltaTime;
            Debug.Log(speed);
        }
    }

    IEnumerator YokEt(GameObject zemin)
    {
        yield return new WaitForSeconds(0.2f);
        zemin.AddComponent<Rigidbody>();
        yield return new WaitForSeconds(0.5f);
        Destroy(zemin);
    }

    public void PlayGame()
    {
        isDead = false;
        playGamePanel.SetActive(false);
    }

}//class
