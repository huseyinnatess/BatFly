using Runtime.Signals;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Controller.UI
{
    public class GameOverPanelController : MonoBehaviour
    {
        #region Self Variables

        #region Serializefield Variables

        [SerializeField] private Text scoreText;
        [SerializeField] private Text highScoreText;

        #endregion

        #region Private Variables

        private ushort _score;
        private ushort _highScore;

        #endregion

        #endregion

        private void OnEnable()
        {
            _highScore = (ushort)PlayerPrefs.GetInt("HighLevel");
            OnWriteScores();
            WriteHighScore();
        }

        private void OnWriteScores()
        {
            _score = UISignals.Instance.onGetScore?.Invoke() ?? 0;
            scoreText.text = _score.ToString();
        }

        private void WriteHighScore()
        {
            if (_score <= _highScore) return;
            highScoreText.text = _score.ToString();
            CoreGameSignals.Instance.onSaveGame?.Invoke();
        }
    }
}