using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Animator animator;
    private bool left;
    private float speed;
    public float walk_speed = .9f;
    public float run_speed = 1.6f;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        left = false;
        speed = walk_speed;
	}
	
	// Update is called once per frame
	void Update () {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (x < 0)
            left = true;
        else
            left = false;

        if (x != 0 || y != 0)
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                speed = run_speed;
                animator.Play("Run");
            }
            else
            {
                speed = walk_speed;
                animator.Play("Walk");
            }

            flip_sprite();
            transform.Translate(new Vector3(x * speed * Time.deltaTime, y * speed * Time.deltaTime, 0));
        }
        else
        {
            animator.Play("idle");
        }


        if (Input.GetKey(KeyCode.Space))
        {
            animator.Play("Attack");
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
