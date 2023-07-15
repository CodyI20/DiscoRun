using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenDone : MonoBehaviour
{
    AudioSource m_AudioSource;
    ParticleSystem m_Particles;

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_Particles = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((m_Particles == null || !m_Particles.isPlaying) && (m_AudioSource == null || !m_AudioSource.isPlaying))
        {
            Destroy(gameObject);
        }
    }
}
