using System;
using System.Collections;
using UnityEngine;

public class BallRight : MonoBehaviour
{
    public SpriteRenderer ball;
    public Sprite white;
    public Sprite black;

    private void Start()
    {
        ball.sprite = white;
    }

    private void Update()
    {
        checkTouches();
    }

    public void checkTouches()
    {
        if (Input.touchCount > 0)
        {
            try
            {
                Touch touch1 = Input.touches[0];
                Vector3 pos1 = touch1.position;

                if (pos1.x > 250 && pos1.y>25 && touch1.phase == TouchPhase.Began)
                    ball.sprite = black;
                if (touch1.phase == TouchPhase.Ended)
                    ball.sprite = white;

                Touch touch2 = Input.touches[1];
                Vector3 pos2 = touch2.position;

                if (pos2.x > 250 && pos2.y>50 && touch2.phase == TouchPhase.Began)
                    ball.sprite = black;
                if (touch2.phase == TouchPhase.Ended)
                    ball.sprite = white;
            }
            catch (Exception e)
            { }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ball.sprite == white &&
            collision.gameObject.tag == "WhitePoint")
        {
            GameManager.score += 1;
            collision.gameObject.GetComponent<Animator>().SetTrigger("Shrink");
            Destroy(collision.gameObject, 1f);
        }
        if (ball.sprite == black &&
            collision.gameObject.tag == "BlackPoint")
        {
            GameManager.score += 1;
            collision.gameObject.GetComponent<Animator>().SetTrigger("Shrink");
            Destroy(collision.gameObject, 0.1f);
        }


        if (ball.sprite == white &&
            collision.gameObject.tag == "BlackPoint")
        {
            collision.gameObject.GetComponent<Point>().speed = 0f;
            collision.gameObject.GetComponent<Animator>().SetTrigger("DestroyBlack");
            GameManager.isGameOver = true;
        }
        if (ball.sprite == black &&
            collision.gameObject.tag == "WhitePoint")
        {
            collision.gameObject.GetComponent<Point>().speed = 0f;
            collision.gameObject.GetComponent<Animator>().SetTrigger("DestroyWhite");
            GameManager.isGameOver = true;
        }
    }
}
