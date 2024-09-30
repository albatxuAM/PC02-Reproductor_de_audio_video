using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video; 

public class VideoManager : MonoBehaviour
{
    public List<VideoClip> videoClips; 
    private VideoPlayer videoPlayer;
    private bool isPaused = false;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.isLooping = true; // Que los videos se repitan al finalizar
    }

    void Update()
    {
        // Detectar clic izquierdo
        if (Input.GetMouseButtonDown(0))
        {
            // Convertir la posición del mouse a un punto en el espacio 2D
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            // Verificar si el Raycast impacta con algo
            if (hit.collider != null)
            {
                // Comprobar si se hizo clic en el sprite de "Play"
                if (hit.collider.name == "Sprite_Play")
                {
                    PlayNewVideo(); // Solo reproducir un nuevo vídeo
                }
                // Comprobar si se hizo clic en el sprite de "Pause"
                else if (hit.collider.name == "Sprite_Pause")
                {
                    TogglePause(); // Alternar entre pausar y reanudar
                }
                // Comprobar si se hizo clic en el sprite de "Stop"
                else if (hit.collider.name == "Sprite_Stop")
                {
                    StopVideo();
                }
            }
        }
    }

    // Método para reproducir un nuevo video aleatorio
    void PlayNewVideo()
    {
        // Seleccionamos un nuevo video aleatorio y lo reproducimos
        int randomIndex = Random.Range(0, videoClips.Count);
        videoPlayer.clip = videoClips[randomIndex];
        videoPlayer.Play();
        isPaused = false; // Reiniciamos el estado de pausa
    }

    // Método para alternar entre pausa y reanudar (en el botón Pause)
    void TogglePause()
    {
        if (isPaused)
        {
            // Si el video está pausado, lo reanuda
            videoPlayer.Play();
            isPaused = false;
        }
        else if (videoPlayer.isPlaying)
        {
            // Si el video está reproduciéndose, lo pausa
            videoPlayer.Pause();
            isPaused = true;
        }
    }

    void StopVideo()
    {
        // Detener el vídeo si está reproduciéndose o pausado
        if (videoPlayer.isPlaying || isPaused)
        {
            videoPlayer.Stop();
            isPaused = false;
        }
    }
}
