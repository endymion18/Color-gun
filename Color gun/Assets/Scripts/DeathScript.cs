using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;
    private AudioSource deathSound;
    void Start()
    {
        deathSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = spawnPoint.transform.position;
            deathSound.time = 0.55f;
            deathSound.Play();
        }
    }
}
