using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainGame
{
    public class Finish : MonoBehaviour
    {
        public AudioSource audioSource;
        public AudioClip audioClip;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name is "XR Origin" or "Left Hand Ray Interactor" or "Right Hand Ray Interactor" or "Left Hand Controller" or "Right Hand Controller")
            {
                audioSource.PlayOneShot(audioClip);
                SceneManager.LoadScene(2);
            }
        }
    }
}