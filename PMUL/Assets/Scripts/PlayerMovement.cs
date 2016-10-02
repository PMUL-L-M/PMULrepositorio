using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    Vector3 movimiento;
    Rigidbody2D rb;
    Animator anim;
    float vel;
	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        vel = 5;
	}
	
	// Update is called once per frame
	void Update () {
        movimiento = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        rb.MovePosition(this.transform.position + movimiento * vel * Time.deltaTime);

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            anim.SetBool("AndarDcha", true);
            anim.SetBool("AndarIzda", false);
        }else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            anim.SetBool("AndarIzda", true);
            anim.SetBool("AndarDcha", false);
        }else
        {
            anim.SetBool("AndarIzda", false);
            anim.SetBool("AndarDcha", false);
        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            anim.SetBool("AndarArriba", true);
            anim.SetBool("AndarAbajo", false);
        }else if (Input.GetAxisRaw("Vertical") < 0)
        {
            anim.SetBool("AndarAbajo", true);
            anim.SetBool("AndarArriba", false);
        }else
        {
            anim.SetBool("AndarAbajo", false);
            anim.SetBool("AndarArriba", false);
        }
	}
}
