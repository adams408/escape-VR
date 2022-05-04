using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainGame.TargetGame
{
    public class TargetGameManager : MonoBehaviour
    {
        public List<Target> target;
        private bool triggerStop = false;
        public Transform origin;
        
        private void Update()
        {
            if (checkTriggered() && !triggerStop)
            {
                triggerStop = true;
                origin.transform.position = new Vector3(516, 100, 498);
                //SceneManager.LoadScene(0);
            }
        }
        
        private bool checkTriggered()
        {
            foreach (var child in target)
            {
                if (!child.isTriggered)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
