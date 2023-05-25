using DG.Tweening;
using Events;
using UnityEngine;

namespace RunnerGame.WayParts
{
    public class WayPartMovement : MonoBehaviour
    {
        [SerializeField] private GameEvent onSnapWayPart;
        private string dotweenId;

        private void Start()
        {
            dotweenId = name;
            StartMovement();
        }

        public void StartMovement()
        {
            var startPosition = transform.position.x;
            transform.DOMoveX(-startPosition, 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo).SetId(dotweenId);
        }

        public void StopMovement()
        {
            DOTween.Kill(dotweenId);
            float hangover = 0 - transform.position.x;
            float direction = hangover > 0 ? 1f : -1f;
            onSnapWayPart.RaiseFloats(hangover, direction);
        }
    }
}