using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CrystalController : MonoBehaviour
{
    
    ScoreController Score;
    public  GameObject brokenObject;
    public float magnitudeCol, radius, power, upwards;
    AudioSource breakGlassAudio;

    void Start()
    {
        Score = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreController>();
        breakGlassAudio = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            Score.score += 1;


            //Kırılma Sesi Eklenecek.

            breakGlassAudio.Play();

            Destroy(gameObject);
            Instantiate(brokenObject, transform.position, transform.rotation);
            //brokenObject.transform.localScale = transform.localScale;
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

            foreach (Collider hit in colliders)
            {
                if (hit.GetComponent<Rigidbody>())
                {
                    hit.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius);
                }
            }
        }
    }
}
