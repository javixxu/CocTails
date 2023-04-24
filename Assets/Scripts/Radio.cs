using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    //public float angle;
    public AudioSource audioSource;
    public AudioClip[] songs;
    public GameObject powerButton;
    public GameObject changeSongButton;
    public int index;

    Vector3 previousPosition;

    void Start()
    {
        index = 0;
    }

    void Update()
    {
        // Calcula la rotación actual del dial
        //Vector3 direction = transform.position - previousPosition;
        //float currentAngle = Vector3.SignedAngle(direction, Vector3.forward, Vector3.up);
        //angle += currentAngle;
        //previousPosition = transform.position;

        //// Asegúrate de que el ángulo no sea negativo
        //if (angle < 0)
        //{
        //    angle += 360;
        //}

        //// Calcula el índice de la canción actual
        //int songIndex = Mathf.FloorToInt(angle / 360f * songs.Length);

        //// Si la canción actual es diferente de la anterior, cámbiala y reprodúcela
        //if (audioSource.clip != songs[songIndex])
        //{
        //    audioSource.Stop();
        //    audioSource.clip = songs[songIndex];
        //    audioSource.Play();
        //}
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    // Si el usuario está agarrando el dial, actualiza su posición
    //    //if (other.CompareTag("Hand"))
    //    //{
    //    //    //previousPosition = other.transform.position;
    //    //}
    //}
}
