using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Vector3 yon = Vector3.left;
    [SerializeField] float speed;
    [SerializeField] Text scoreText, bestScoreText;
    public GroundSpawner groundSpawner;
    public static bool isDead = false;
    public float hizlanmaZorlugu;
    float score = 0f;
    float artisMiktari = 1f;
    int bestScore = 0;

    private void Start()
    {
        bestScoreText.text = "Best: " + PlayerPrefs.GetInt("BestScore").ToString();
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

        if (transform.position.y < -2f)
        {
            isDead = true;
            if (bestScore < score)
            {
                bestScore = (int) score;
                PlayerPrefs.SetInt("BestScore", bestScore);
            }
            Destroy(this.gameObject, 2f);
        }
    }

    private void FixedUpdate()
    {
        Vector3 hareket = yon * speed * Time.deltaTime;
        speed += Time.deltaTime * hizlanmaZorlugu;
        transform.position += hareket;

        score += artisMiktari * speed * Time.deltaTime;
        
        scoreText.text = "Score: " +((int)score).ToString();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            StartCoroutine(YokEt(collision.gameObject));
            groundSpawner.ZeminOlustur();
        }
    }

    IEnumerator YokEt(GameObject zemin)
    {
        yield return new WaitForSeconds(0.2f);
        zemin.AddComponent<Rigidbody>();
        yield return new WaitForSeconds(0.5f);
        Destroy(zemin);
    }


}//class
