using UnityEngine;
using System.Collections;

[System.Serializable] //Makes new class visible in the inspector
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
   /* public AudioSource MusicSource;
    public AudioClip MusicClipOne;
    public AudioClip MusicClipTwo;*/

    public float speed; //These 3 will appear as editable values in the inspector
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private Rigidbody rb;
    private float nextFire;
    private AudioSource audioSource; //Adds audio variable

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); //Gets the audio thats in the game object component
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation); // as GameObject;
            audioSource.Play(); //Plays audio whenever shot
        }

        /*  MusicSource.clip = MusicClipOne;
         MusicSource.Play();
         MusicSource.clip = MusicClipTwo;
         MusicSource.Play();

         MusicSource.Stop();
         MusicSource.loop = true; */
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); //Defines how fast you will go
        rb.velocity = movement * speed; 

        rb.position = new Vector3
        (
             Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), //Sets the player boundary.
             0.0f,
             Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt); 
    }
}
