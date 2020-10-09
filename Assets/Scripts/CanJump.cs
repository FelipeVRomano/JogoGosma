using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanJump : MonoBehaviour
{
    public bool isGrounded;
    public PersoMolenga pulo;
    public float raio = 4f;
    public LayerMask grounded;
    public Transform check;

    public AudioSource jump;
    public AudioClip[] andandoArray;
    public AudioSource andandoAudio;
    public float x;

    void Start()
    {
        x = -1;
        check = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(check.position, raio, grounded);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            print(x);
            jump.Play();
            pulo.JumpForAll();
            pulo.mudaGrav(x);
            x *= -1;
            print(x);
        }

        if(isGrounded && Input.GetAxis("Horizontal") > 0)
        {
            if (!andandoAudio.isPlaying)
            {
                andandoAudio.clip = andandoArray[Random.Range(0, andandoArray.Length)];
                andandoAudio.Play();
            }
        }
    }
}
