using UnityEngine;

namespace MainGame.TargetGame
{
    public class ShootGun : MonoBehaviour
    {
        public float speed = 40;
        public GameObject bullet;
        public Transform barrel;
        public AudioSource audioSource;
        public AudioClip audioClip;

        public void Fire()
        {
            var spawnedBullet = Instantiate(bullet, barrel.position, barrel.rotation);
            spawnedBullet.GetComponent<Rigidbody>().velocity = speed * barrel.forward;
            audioSource.PlayOneShot(audioClip);
            Destroy(spawnedBullet, 2.0f);
        }
    }
}