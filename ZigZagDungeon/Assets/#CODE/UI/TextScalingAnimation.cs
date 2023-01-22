using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZigZagDungeon
{
    public class TextScalingAnimation : MonoBehaviour
    {
        float originalScale;
        [SerializeField] [Tooltip("Value for x and y")] float targetScale;
        [Range(0.01f, 1f)] [SerializeField] float animationSpeedModifier = 0.5f;
        float valueToAdd = 0.0125f;
        enum ScaleDirection { Down, Up };
        ScaleDirection scaleDirection;

        [SerializeField] [Tooltip("Activate scaling effect")] bool activateScalingEffect = true;
        private void Start()
        {
            float textScaleX = gameObject.transform.localScale.x;
            float textScaleY = gameObject.transform.localScale.y;

            if (textScaleX == textScaleY) originalScale = textScaleX;
            else
            {
                originalScale = textScaleX;
                Debug.LogWarning("text X and Y scale does not match, X scale used as a referance value");
            }

            valueToAdd *= animationSpeedModifier;

            if (originalScale < targetScale) scaleDirection = ScaleDirection.Up;
            else if (originalScale > targetScale) scaleDirection = ScaleDirection.Down;
            else activateScalingEffect = false;
        }
        void Update()
        {
            if (!activateScalingEffect) return;

            float time = Time.fixedUnscaledDeltaTime;
            float currentScale = gameObject.transform.localScale.x;
          
          if(scaleDirection == ScaleDirection.Up) ScaleUp(currentScale);
          else ScaleDown(currentScale);
        }
        void ScaleUp(float currentScale)
        {
            if (currentScale < targetScale) gameObject.transform.localScale = new Vector3(currentScale + valueToAdd, currentScale + valueToAdd, 1);
            else scaleDirection = ScaleDirection.Down;
        }
        void ScaleDown(float currentScale)
        {
            if(currentScale > originalScale) gameObject.transform.localScale = new Vector3(currentScale - valueToAdd, currentScale - valueToAdd, 1);
                 else scaleDirection = ScaleDirection.Up;
        }
    }
}