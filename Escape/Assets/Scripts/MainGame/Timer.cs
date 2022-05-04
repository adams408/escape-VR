using System;
using Menu;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainGame
{
    public class Timer : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text timerText;
        
        public Transform lava;
        private static float lavaDis = 30f;
        private float lavaTravel;
        public float startingTime;
        
        private float currentTime;

        private void Start()
        {
            currentTime = MenuControl.value switch
            {
                2 => 3 * 60f,
                1 => 6 * 60f,
                0 => 9 * 60f,
                _ => startingTime * 60f
            };
            lavaTravel = lavaDis / currentTime;
        }

        private void Update()
        {
            timerText.text = $"{Math.Floor(currentTime / 60f):0}:{Math.Floor(currentTime % 60f):0}";
            currentTime -= 1 * Time.deltaTime;
            lava.Translate(Vector3.up * (lavaTravel * Time.deltaTime), Space.World);

            if (currentTime <= 0)
            {
                currentTime = 0;
                SceneManager.LoadScene(0);
            }
        }
    }
}