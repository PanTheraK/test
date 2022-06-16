using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playercontrol : MonoBehaviour
{
    public float num_count;
    public float speed = 10.0f;
    private Animator animator;
    public AudioClip keySfx;
    public AudioClip die;
    private AudioSource audioSource;
    public GameObject keyEffect;
    public GameObject dieEffect;


    [SerializeField]
    private static Playercontrol instance;
    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") < 0 || Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, 0);
            transform.localScale = new Vector2(Input.GetAxisRaw("Horizontal"), 1);

            animator.SetBool("RunStart", true);
        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            animator.SetBool("RunStart", false);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.PlayOneShot(keySfx, 1.0f);
        Vector3 DonutPosition = collision.gameObject.GetComponent<Transform>().position;
        GameObject Effect = Instantiate(keyEffect, DonutPosition, Quaternion.identity);
        Destroy(Effect, 2.0f);
        if (collision.gameObject.CompareTag("bomb"))
        {
            GameManager.instance.GameOver();
            audioSource.PlayOneShot(die, 1.0f);
        }
    }
}
