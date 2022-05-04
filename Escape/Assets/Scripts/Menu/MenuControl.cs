using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MenuControl : MonoBehaviour
    {
        [SerializeField]
        private TMP_Dropdown selectTime;
        
        public static int value;
        
        public void ButtonStart()
        {
            value = selectTime.value;
            SceneManager.LoadScene(1);
        }
        
        public void ButtonMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void ButtonQuit()
        {
            Application.Quit();
        }
    }
}