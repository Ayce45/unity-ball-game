using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GoalPoint2 : MonoBehaviour
{
    SpriteRenderer mySpriteRenderer;
    public AudioSource GoalAudioData;
    public AudioSource WelcomeAudioData;
    [Tooltip("Target element")]
    public GameObject target;
    private float x = 7f;
    private float y = 3.5f;
    public GameObject[] players;
    public GameObject[] balls;

    public GameObject[] points;

    private int point = 0;

    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Ball")
        {
            playSound();
            addPoint();
            restartPosition();
            StartCoroutine(PauseGame(3f));
        }
    }

    void playSound()
    {
        GoalAudioData.Play();
    }

    void addPoint()
    {
        var instance = Instantiate(target);
        instance.transform.position = new Vector3(x, y, 1);
        x--;
        point++;
        if (point == 5)
        {
            points = GameObject.FindGameObjectsWithTag("Point");
            foreach (GameObject point in points)
            {
                Destroy(point);
            }
            x = 7f;
            y = 3.5f;
        }
    }

    void restartPosition()
    {
        restartPositionPlayers();
        restartPositionBalls();
        restartSizeCamera();
    }

    void restartPositionPlayers()
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in players)
        {
            player.GetComponent<TrailRenderer>().Clear();
            if (player.name.Equals("Player 1"))
            {
                player.transform.position = new Vector3(-0.7f, 0.9f, 0);
            }
            else
            {
                player.transform.position = new Vector3(0.8f, 0.9f, 0);
            }
        }
    }

    void restartPositionBalls()
    {
        balls = GameObject.FindGameObjectsWithTag("Ball");

        foreach (GameObject ball in balls)
        {
            ball.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            ball.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            if (ball.name.Equals("Ball 1"))
            {
                ball.transform.position = new Vector3(-0.2f, 0.35f, 0);
            }
            else
            {
                ball.transform.position = new Vector3(0.4f, 0.35f, 0);
            }
        }
    }

    public IEnumerator PauseGame(float pauseTime)
    {
        Time.timeScale = 0f;
        float pauseEndTime = Time.realtimeSinceStartup + pauseTime;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1f;
        WelcomeAudioData.Play();

    }

    void restartSizeCamera()
    {
        Camera.main.orthographicSize = 4.487658f;
    }
}
