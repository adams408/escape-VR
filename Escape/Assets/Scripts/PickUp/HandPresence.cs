using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace PickUp
{
    public class HandPresence : MonoBehaviour
    {
        public bool showController;
        public GameObject handModelPrefab;
        public InputDeviceCharacteristics controllerCharacteristics;
        public List<GameObject> controllerPrefabs;

        private Animator handAnimator;
        private GameObject spawnedController;
        private GameObject spawnedHandModel;
        private InputDevice targetDevice;

        private void Start()
        {
            Initialize();
        }

        private void Update()
        {
            if (!targetDevice.isValid)
            {
                Initialize();
            }
            else
            {
                if (showController)
                {
                    spawnedHandModel.SetActive(false);
                    spawnedController.SetActive(true);
                    targetDevice.TryGetFeatureValue(CommonUsages.trigger, out var triggerDebugVal);
                }
                else
                {
                    spawnedHandModel.SetActive(true);
                    spawnedController.SetActive(false);
                    UpdateHandAnimation();
                }
            }
        }

        private void Initialize()
        {
            // this section is used for receiving controller info
            var devices = new List<InputDevice>();
            InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

            foreach (var item in devices) Debug.Log(item.name + item.characteristics);

            if (devices.Count > 0)
            {
                targetDevice = devices[0];
                var prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
                if (prefab)
                {
                    spawnedController = Instantiate(prefab, transform);
                }
                else
                {
                    Debug.LogError("Did not find Controller");
                    spawnedController = Instantiate(controllerPrefabs[0], transform);
                }

                spawnedHandModel = Instantiate(handModelPrefab, transform);
                handAnimator = spawnedHandModel.GetComponent<Animator>();
            }
        }

        private void UpdateHandAnimation()
        {
            if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out var triggerValue))
                handAnimator.SetFloat("Trigger", triggerValue);
            else
                handAnimator.SetFloat("Trigger", 0);

            if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out var gripValue))
                handAnimator.SetFloat("Grip", gripValue);
            else
                handAnimator.SetFloat("Grip", 0);
        }
    }
}