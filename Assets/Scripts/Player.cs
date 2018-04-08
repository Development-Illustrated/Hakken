using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Animator animator;
    private bool left;
    private float running;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        left = false;
        running = 1f;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(0))
        {
            animator.Play("Attack");
        }
        else
        {

            if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
            {
                running = 2f;
                animator.Play("Run");
            }

            else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                running = 1f;
                animator.Play("Walk");
            }


            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector2.up * Time.deltaTime * running);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                left = true;
                flip_sprite();
                transform.Translate(Vector2.left * Time.deltaTime * running);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector2.down * Time.deltaTime * running);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                left = false;
                flip_sprite();
                transform.Translate(Vector2.right * Time.deltaTime * running);
            }
            else
            {
                animator.Play("idle");
            }
        }
    }

    private void flip_sprite()
    {
        SpriteRenderer r = GetComponent<SpriteRenderer>();

        if (left)
            r.flipX = true;
        else
            r.flipX = false;
    }
}
