using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private GameObject obj;
    public float flyPower;
    public AudioClip flyClip;
    public AudioClip gameOverClip;

    private AudioSource audioSource;

    private Animator anim;


    GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        if (gameController == null)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController");
        }
        anim = gameObject.GetComponent<Animator>();
        anim.SetFloat("FlyPower", 0);
 
        obj = gameObject;
        audioSource = obj.GetComponent<AudioSource>();
        audioSource.clip = flyClip;
        flyPower = 15;
        anim.SetBool("IsDead", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!gameController.GetComponent<GameController>().isEndgame) {
                audioSource.Play();
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, flyPower));


            }
            anim.SetFloat("FlyPower", obj.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlusPoint();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EndGame();
    }
    void PlusPoint()
    {
        gameController.GetComponent<GameController>().PlusPoint();
    }

    void EndGame()
    {
        anim.SetBool("IsDead", true);
        audioSource.clip = gameOverClip;
        audioSource.Play();
        gameController.GetComponent<GameController>().EndGame();
    }
}
