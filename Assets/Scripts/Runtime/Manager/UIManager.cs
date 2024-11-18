using Runtime.Controller.UI;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Manager
{
    public class UIManager : MonoBehaviour
    {
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            UISignals.Instance.onScoreChange += ScoreController.Instance.ScoreChange;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void UnsubscribeEvents()
        {
            UISignals.Instance.onScoreChange -= ScoreController.Instance.ScoreChange;
        }
    }
}