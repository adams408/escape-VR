using UnityEngine;

namespace MainGame.TargetGame
{
    public class GunMechanics : MonoBehaviour
    {
        public GameObject gunObj;
        public float x, y, z;
        public AudioSource audioSource;
        public AudioClip audioClip;
        
        public void Gun()
        {
            Instantiate(gunObj, new Vector3(x, y, z), new Quaternion(0, 0, 0, 0));
            audioSource.PlayOneShot(audioClip);
        }
    }
}