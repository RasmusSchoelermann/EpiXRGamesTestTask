using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField]
    private GameObject holyAura;

    [SerializeField]
    private AudioClip collectedSoundEffect;

    [SerializeField]
    private AudioSource audioSource;

    private GameObject particles;

    private void Update()
    {
        EventManager.OnTriggerBoxCollection.AddListener(Collected);
    }

    private void Collected()
    {
        if (particles != null)
            return;

        particles = Instantiate(holyAura, gameObject.transform);
        audioSource.PlayOneShot(collectedSoundEffect);
    }
}
