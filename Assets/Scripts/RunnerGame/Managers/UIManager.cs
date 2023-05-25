using System;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame.Managers
{
    [Serializable]
    public class UIObject
    {
        public GameObject uiObject;
        public GameState state;
    }
    
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private List<UIObject> uIObjects;

        public void SetGameUI(GameState gameState)
        {
            foreach (UIObject uIObject in uIObjects)
            {
                uIObject.uiObject.SetActive(uIObject.state == gameState);
            }
        }
    }
}