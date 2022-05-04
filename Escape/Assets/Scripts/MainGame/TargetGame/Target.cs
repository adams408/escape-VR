using UnityEngine;

namespace MainGame.TargetGame
{
    public class Target : MonoBehaviour
    {
        public bool isTriggered = false;

        public GameObject target;
        public AudioSource audioSource;
        public AudioClip audioClip;
        public Material clear;
        
        private Renderer targetRenderer;

        private void Start()
        {
            targetRenderer = target.GetComponent<Renderer>();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (!isTriggered)
            {
                audioSource.PlayOneShot(audioClip);
                targetRenderer.material = clear;
                isTriggered = true; 
            }
        }
    }
}