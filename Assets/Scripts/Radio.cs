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
        // Calcula la rotaci�n actual del dial
        //Vector3 direction = transform.position - previousPosition;
        //float currentAngle = Vector3.SignedAngle(direction, Vector3.forward, Vector3.up);
        //angle += currentAngle;
        //previousPosition = transform.position;

        //// Aseg�rate de que el �ngulo no sea negativo
        //if (angle < 0)
        //{
        //    angle += 360;
        //}

        //// Calcula el �ndice de la canci�n actual
        //int songIndex = Mathf.FloorToInt(angle / 360f * songs.Length);

        //// Si la canci�n actual es diferente de la anterior, c�mbiala y reprod�cela
        //if (audioSource.clip != songs[songIndex])
        //{
        //    audioSource.Stop();
        //    audioSource.clip = songs[songIndex];
        //    audioSource.Play();
        //}
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    // Si el usuario est� agarrando el dial, actualiza su posici�n
    //    //if (other.CompareTag("Hand"))
    //    //{
    //    //    //previousPosition = other.transform.position;
    //    //}
    //}
}
