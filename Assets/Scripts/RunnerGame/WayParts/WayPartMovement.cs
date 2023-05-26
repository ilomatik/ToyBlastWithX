using DG.Tweening;
using Events;
using UnityEngine;

namespace RunnerGame.WayParts
{
    public class WayPartMovement : MonoBehaviour
    {
        [SerializeField] private GameEvent onSnapWayPart;
        private string dotweenId;
        private GameObject previousWayPart;

        private void Start()
        {
            dotweenId = name;
            StartMovement();
        }

        private void StartMovement()
        {
            var startPosition = transform.position.x;
            transform.DOMoveX(-startPosition, 0.75f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo).SetId(dotweenId);
        }

        public void StopMovement()
        {
            DOTween.Kill(dotweenId);

            float lastXPos = previousWayPart != null ? previousWayPart.transform.position.x : 0;
            float hangover = lastXPos - transform.position.x;
            float direction = hangover > 0 ? 1f : -1f;
            onSnapWayPart.RaiseFloats(hangover, direction);
        }

        public void SetPreviousWayPart(GameObject preWay)
        {
            previousWayPart = preWay;
        }
    }
}