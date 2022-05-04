using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MainGame.ButtonGame
{
    public class ButtonGameManager : MonoBehaviour
    {
        public List<Button> target;
        public bool triggerStop = false;
        public UnityEvent onTrigger;
        
        private void Update()
        {
            if(checkTriggered() && !triggerStop)
            {
                triggerStop = true;
                onTrigger.Invoke();
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
