using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AnimateBall : MonoBehaviour
{
    SpriteRenderer mySpriteRenderer;
    public AudioSource audioData;

    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Player")
        {
            audioData.Play();
        }
    }
}
