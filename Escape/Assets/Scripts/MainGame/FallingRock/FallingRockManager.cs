using System.Collections;
using UnityEngine;

namespace MainGame.FallingRock
{
    public class FallingRockManager : MonoBehaviour
    {
        public Transform spawn1;
        public Transform spawn2;
        public GameObject rock;
        public float speed = 20;
        public float RandomTime;
        int rockCount = 0;
        
        public void Awake()
        {
            StartCoroutine(RandomSpawn());
        }
        
        private void Update()
        {
            RandomTime = Random.Range(1, 8);
        }
        
        IEnumerator RandomSpawn()
        {
            while(true)
            {
                GameObject spawnRock1 = Instantiate(rock, spawn1.position, spawn1.rotation);
                GameObject spawnRock2 = Instantiate(rock, spawn2.position, spawn2.rotation);
                spawnRock1.GetComponent<Rigidbody>().velocity = speed * spawn1.forward;
                spawnRock2.GetComponent<Rigidbody>().velocity = speed * spawn2.forward;
                Destroy(spawnRock1, Random.Range(1.0f,20.0f));
                Destroy(spawnRock2, Random.Range(1.0f,20.0f));
                yield return new WaitForSeconds(RandomTime);
            }
        }
    }
}
