using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Confeti : MonoBehaviour
{

    [SerializeField] private ParticleSystem[] _finishParticles;
    [SerializeField] private AudioClip music;
    // Start is called before the first frame update
    private void Awake()
    {
        foreach (var item in _finishParticles)
        {
            var emmision = item.emission;
            emmision.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            StartCoroutine(sound());
          
            foreach (var item in _finishParticles)
            {
                var emmision = item.emission;
                emmision.enabled = true;
            }
        }
    }

    private IEnumerator sound()
    {
        for(int i =0; i < 3; i++)
        {
            AudioSource.PlayClipAtPoint(music, Camera.main.transform.position);
            yield return new WaitForSeconds(3f);
        }
        
    }

}
