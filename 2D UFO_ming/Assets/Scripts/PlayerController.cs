using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;

    private int count;
    private int scoreCnt;
    private int pickupCnt;
       
    public TMP_Text countText;
    public TMP_Text scoreText;
    public TMP_Text winText;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        count = 0;
        scoreCnt = 0; // 시작 스코어 0
        winText.text = "";

        GameObject[] pickups = GameObject.FindGameObjectsWithTag("Pickup");
        pickupCnt = pickups.Length;
      
        SetCountText();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); 
        float moveVertical = Input.GetAxis("Vertical"); 
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical); 
       
        rb2d.AddForce (movement * speed);         
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pickup"))
        {
            Destroy(collision.gameObject); // Pickup 사라짐

            PickupScore ps = collision.GetComponent<PickupScore>();
            scoreCnt += ps.score;

            count++;
            // Debug.Log(count);

            SetCountText();
        }

        else if (collision.CompareTag("Enemy"))
        {
            scoreCnt = -100;
            SetCountText();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
           WallScore ws = collision.gameObject.GetComponent<WallScore>();
           scoreCnt -= ws.scoreOff;
           SetCountText();
        }        
    }

    public void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        scoreText.text = "Score: " + scoreCnt.ToString();

        if (count >= pickupCnt)
        {
            winText.text = "You Win!";
            Time.timeScale = 0;
        }

        if (scoreCnt < 0)
        {
            countText.text = "";
            scoreText.text = "";
            winText.color = Color.red;
            winText.text = "Game Over!";
            Time.timeScale = 0;
        }
    }
}
