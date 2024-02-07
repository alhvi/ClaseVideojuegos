using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private float rotationSpeed = 40f;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void Update()
    {
        transform.Rotate(transform.up, rotationSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(audioSource.clip);
            GameManager.Instance.GrabCoin();
            StartCoroutine(DelayDestroy());
        }
    }

    private IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
