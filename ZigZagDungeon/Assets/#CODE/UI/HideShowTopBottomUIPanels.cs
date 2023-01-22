using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZagDungeon
{
    public class HideShowTopBottomUIPanels : MonoBehaviour
    {
          Animator anim;
         const string hideAnimationName = "HideUIAnimation";
         const string showAnimationName = "ShowUIAnimation";

        [SerializeField] GameObject topUIElement;
        [SerializeField] GameObject bottomUIElement;
        private void Start()
        {
            anim = GetComponent<Animator>();

            if (!topUIElement) Debug.LogError("topUIElement hasn't been setup");
            if (!bottomUIElement) Debug.LogError("bottomUIElement hasn't been setup");
        }
        public void HideUIOnNewGameStart() => anim.Play(hideAnimationName);
     
        public void HideUIElementsOnAnimationEnd()
        {
            topUIElement.SetActive(false);
            bottomUIElement.SetActive(false);
        }
        public void ShowUIElementsOnPlayerFail() => anim.Play(showAnimationName);

        public void ShowUIElementsOnAnimationEnd()
        {
            topUIElement.SetActive(true);
            bottomUIElement.SetActive(true);
        }
    }
}
