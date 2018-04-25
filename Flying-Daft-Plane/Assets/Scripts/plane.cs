using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plane : MonoBehaviour {

    public float upForce = 150f;
    public bool isDead = false;

    public float tiltSmooth = 0.3f;
    Quaternion downRotation;
    Quaternion ForwardRotation;

    private Rigidbody2D rb2d;
    private Animator anim;

    public AudioSource tapAudio;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // Zwraca rotację która obracana jest względem osi Z, x dla x a y dla y
        // Quaternion.Euler(x, y, z);
        downRotation = Quaternion.Euler(0, 0, -20);
        ForwardRotation = Quaternion.Euler(0, 0, 15);
    }
	// Update is called once per frame
	void Update () {
        if (isDead) { return; }

        if (Input.GetMouseButtonDown(0))
        {
            tapAudio.Play();
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0, upForce));
            anim.SetTrigger("Flap");
               
            //po kliknięciu wracamy wyżej do forwarfRotation
            transform.rotation = ForwardRotation;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            // po kazdym kliknięciu dodajemy siłę podbicia (zadeklarowaną wyżej) do Vectora2 - up
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * upForce, ForceMode2D.Force);
            anim.SetTrigger("Flap");
        }
        // Quaternion.Lerp = idziemy od pobranej wartości do docelowej w określonym czasie
        // downRotation zadeklarowana wyżej "-20" i tiltSmooth prędkość rotacji - 0,4f
        transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime * 3);
    }   
    private void OnCollisionEnter2D()
    {
        
        isDead = true;
        rb2d.velocity = Vector2.zero;
       // anim.SetTrigger("Die");
        GameControl.Instance.Die();
    }
    
}
