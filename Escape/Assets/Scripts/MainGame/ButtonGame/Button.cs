using UnityEngine;
using UnityEngine.Events;

namespace MainGame.ButtonGame
{
    public class Button : MonoBehaviour
    {
        public bool isTriggered = false;
    
        public bool keepButtonDown;
        public GameObject button;
        public UnityEvent press;
        public UnityEvent release;
        public AudioSource audioSource;
        public AudioClip audioClip;
    
        private GameObject presser;
        private Renderer buttonRenderer;
    
        private void Start()
        {
            buttonRenderer = button.GetComponent<Renderer>();
            buttonRenderer.material.SetColor("_Color", Color.red);
        }
    
        private void OnTriggerEnter(Collider other)
        {
            if (!isTriggered)
            {
                button.transform.localPosition = new Vector3(0, 0.003f, 0);
                presser = other.gameObject;
                buttonRenderer.material.SetColor("_Color", Color.green);
            
                press.Invoke();
                audioSource.PlayOneShot(audioClip);
                isTriggered = true; 
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(keepButtonDown == false)
            {
                if (other.gameObject == presser)
                {
                    button.transform.localPosition = new Vector3(0, 0.06f, 0);
                    buttonRenderer.material.SetColor("_Color", Color.red);
                
                    release.Invoke();
                }   
            }
        }
    }
}
