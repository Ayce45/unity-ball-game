using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class AnimateGirl : MonoBehaviour
{
    [Tooltip("Vitesse max en unité par seconde")]
    public int MaxSpeed = 10;
    Animator animator;
    SpriteRenderer mySpriteRenderer;


    private void Start()
    {
        animator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    static readonly int Speed = Animator.StringToHash("Speed");

    void Update()
    {
        var maxDistancePerFrame = MaxSpeed * Time.deltaTime;
        Vector2 speed = Vector2.zero;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetFloat("Speed", 1f);
            mySpriteRenderer.flipX = false;
            speed += Vector2.right * maxDistancePerFrame;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetFloat("Speed", 2f);
            mySpriteRenderer.flipX = true;
            speed += Vector2.left * maxDistancePerFrame;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            animator.SetFloat("Speed", 3f);
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetFloat("Speed", 4f);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetFloat("Speed", 5f);
            speed += Vector2.up * maxDistancePerFrame;
            mySpriteRenderer.flipY = false;

        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetFloat("Speed", 5f);
            speed += Vector2.down * maxDistancePerFrame;
            mySpriteRenderer.flipY = true;

        }
        else
        {
            animator.SetFloat("Speed", 0f);
            mySpriteRenderer.flipY = false;
        }
        this.transform.position = this.transform.position + (Vector3)speed;
    }
}
