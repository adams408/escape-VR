using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainGame.FallingRock
{
    public class RockScript : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name is "XR Origin" or "Left Hand Ray Interactor" or "Right Hand Ray Interactor" or "Left Hand Controller" or "Right Hand Controller")
                SceneManager.LoadScene(0);
        }
    }
}