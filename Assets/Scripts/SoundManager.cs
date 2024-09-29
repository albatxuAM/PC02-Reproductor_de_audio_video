using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> audioClips; // Lista de sonidos
    private AudioSource audioSource;
    private bool isPaused = false; // Para detectar si el sonido está pausado

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Reproducir o continuar el sonido cuando se hace clic izquierdo
        if (Input.GetMouseButtonDown(0))
        {
            // Si no está reproduciendo, reproduce un sonido aleatorio
            if (!audioSource.isPlaying)
            {
                PlayRandomSound();
            }
        }

        // Pausar el sonido cuando se hace clic derecho
        if (Input.GetMouseButtonDown(1))
        {
            // Si está pausado, reanuda el sonido actual
            if (isPaused)
            {
                audioSource.UnPause();
                isPaused = false;
            }
            // Si no está reproduciendo, reproduce un sonido aleatorio
            if (audioSource.isPlaying)
            {
                audioSource.Pause();
                isPaused = true;
            }
        }

        // Detener el sonido cuando se hace clic central
        if (Input.GetMouseButtonDown(2))
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
                isPaused = false; // Ya no está pausado si se detiene
            }
        }
    }

    void PlayRandomSound()
    {
        // Seleccionar un sonido aleatorio de la lista
        int randomIndex = Random.Range(0, audioClips.Count);
        audioSource.clip = audioClips[randomIndex];
        audioSource.Play();

        // Asegurarse de que el sonido se repita si termina
        audioSource.loop = true;
        isPaused = false; // No está pausado si empieza a sonar uno nuevo
    }
}
