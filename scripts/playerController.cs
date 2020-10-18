using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody rig;
    private AudioSource audioSource;
    public float jumpForce;

    void Awake()
    {
        rig = GetComponent<Rigidbody>();

audioSource = GetComponent<AudioSource>();
        //Time.timeScale = 1.0f;
    }


    void Update()
    {
        if (GameManager.instance.paused)
            return;
        Move ();
        if (Input.GetButtonDown("Jump"))
        {
            TryJump();

        }

    }
    // move the character here:
    void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(xInput, 0, zInput) * moveSpeed;
        dir.y = rig.velocity.y;

        rig.velocity = dir;

        Vector3 facingdir = new Vector3(xInput, 0, zInput);
        if (facingdir.magnitude >0)
                transform.forward = facingdir;
    }

    // Jump here:

    void TryJump()
    {
        Ray ray1 = new Ray(transform.position + new Vector3(0.5f, 0, 0.5f), Vector3.down); 
        Ray ray2 = new Ray(transform.position + new Vector3(-0.5f,0,0.5f) , Vector3.down);
        Ray ray3 = new Ray(transform.position + new Vector3(0.5f, 0, -0.5f), Vector3.down);
        Ray ray4 = new Ray(transform.position + new Vector3(-0.5f, 0, -0.5f), Vector3.down);
        bool cast1 = Physics.Raycast(ray1, 0.7f);
        bool cast2 = Physics.Raycast(ray2, 0.7f);
        bool cast3 = Physics.Raycast(ray3, 0.7f);
        bool cast4 = Physics.Raycast(ray4, 0.7f);
        if (cast1 || cast2|| cast3|| cast4)
        {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        


    }

    // Check the collider conditions here:
      void OnTriggerEnter (Collider other)
    {
        
    if (other.CompareTag("Enemy"))
        {
          
            GameManager.instance.GameOver();
           
        }

    else if (other.CompareTag("Coin"))
        {
            ///add score
            GameManager.instance.AddScore(1);
            audioSource.Play();
            Destroy(other.gameObject);
        }

        else if (other.CompareTag("Goal"))
        {
            GameManager.instance.LevelEnd();
        }
    }

   
    
}


