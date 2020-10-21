using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class AnimateGirl2 : MonoBehaviour
{
    [Tooltip("Vitesse max en unité par seconde")]
    public int MaxSpeed = 4;
    Animator animator;
    SpriteRenderer mySpriteRenderer;


    private void Start()
    {
        animator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    static readonly int Speed = Animator.StringToHash("Speed");
    static readonly int Jump = Animator.StringToHash("Jump");
    static readonly int Rool = Animator.StringToHash("Rool");



    void Update()
    {
        var maxDisancePerFrame = MaxSpeed * Time.deltaTime;
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            move += Vector3.right * maxDisancePerFrame;
            mySpriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            move += Vector3.left * maxDisancePerFrame;
            mySpriteRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            move += Vector3.up * maxDisancePerFrame;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            move += Vector3.down * maxDisancePerFrame;
        }

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            animator.SetBool("Roll", true);
        }
        else
        {
            animator.SetBool("Roll", false);
        }

        animator.SetFloat(Speed, move.magnitude * 10f);
        this.transform.position = this.transform.position + move;
    }
}
