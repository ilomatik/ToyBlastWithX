using GridGame.Managers;
using UnityEngine;

namespace GridGame.Tiles
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] private GameObject xImage;

        private int tileXPosition;
        private int tileYPosition;
        private bool isMatchable;

        private void OnMouseDown()
        {
            ToggleImage();
        }

        internal void ToggleImage()
        {
            xImage.SetActive(!xImage.activeSelf);
            isMatchable = xImage.activeSelf;

            if (xImage.activeSelf)
            {
                MatchManager.Instance.CheckMatch(this);
            }
        }
        
        internal void SetTilePosition(int xPos, int yPos)
        {
            tileXPosition = xPos;
            tileYPosition = yPos;
        }

        internal int GetTileXPosition()
        {
            return tileXPosition;
        }

        internal int GetTileYPosition()
        {
            return tileYPosition;
        }

        internal bool IsMatchable()
        {
            return isMatchable;
        }
    }
}