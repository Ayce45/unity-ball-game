using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class AnimateGirl : MonoBehaviour
{
    [Tooltip("Vitesse max en unité par seconde")]
    public int MaxSpeed = 4;
    Animator animator;
    SpriteRenderer mySpriteRenderer;
    Rigidbody2D rigidbody2D;

    private void Start()
    {
        animator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    static readonly int Speed = Animator.StringToHash("Speed");
    static readonly int Jump = Animator.StringToHash("Jump");
    static readonly int Rool = Animator.StringToHash("Rool");
    void FixedUpdate()
    {
        var maxDisancePerFrame = MaxSpeed;
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.D))
        {
            move += Vector3.right * maxDisancePerFrame;
            mySpriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            move += Vector3.left * maxDisancePerFrame;
            mySpriteRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            move += Vector3.up * maxDisancePerFrame;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            move += Vector3.down * maxDisancePerFrame;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("Roll", true);
        }
        else
        {
            animator.SetBool("Roll", false);
        }

        animator.SetFloat(Speed, move.magnitude * 10f);
        rigidbody2D.velocity = move;
    }
}
