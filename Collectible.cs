using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float rs;
    public GameObject onCollectEffect;
    public AudioClip collectSound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,rs);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // destroy the collectible
            AudioSource.PlayClipAtPoint(collectSound, transform.position);

            Destroy(gameObject);
            //instantiate the particle effect
            Instantiate(onCollectEffect, transform.position, transform.rotation);



        }



    }



}
