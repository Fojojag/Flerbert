   using System.Collections;
    using UnityEngine;
    using Unity.Cinemachine;
using NUnit.Framework.Internal;

public class camerafix : MonoBehaviour
    {
        private void OnEnable()
        {
            var confiner = GetComponent<CinemachineConfiner2D>(); // Or CinemachineConfiner
            if (confiner != null)
            {
                StartCoroutine(InvalidateConfinerCache(confiner));
            }
        }

        private IEnumerator InvalidateConfinerCache(CinemachineConfiner2D confiner)
        {
            Debug.Log("Test");
            yield return new WaitForEndOfFrame();
            confiner.InvalidateBoundingShapeCache();
            // If lens properties are changed, also call:
            confiner.InvalidateLensCache(); 
        }
    }