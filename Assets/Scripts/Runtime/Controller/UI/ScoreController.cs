using System;
using Runtime.Keys.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Controller.UI
{
    public class ScoreController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public static ScoreController Instance;

        #endregion

        #region SerializeField Variables

        [SerializeField] private Sprite[] numberSprites;
        [SerializeField] private Image[] scoreImages;

        #endregion

        #region Private Variables

        private ScoreParams _scoreParams;

        #endregion

        #endregion

        private void Awake()
        {
            Singleton();
            _scoreParams = new ScoreParams();
        }

        private void Singleton()
        {
            if (Instance != this && Instance != null)
            {
                Destroy(this);
                return;
            }

            Instance = this;
        }

        public void OnScoreChange(ushort score)
        {
            string scoreText = score.ToString();
            _scoreParams.ScoreLenght = (ushort)scoreText.Length;
            if (_scoreParams.ScoreLenght > 1 && _scoreParams.OldLenght != _scoreParams.ScoreLenght)
            {
                SetScoreUI(scoreText, score);
                IncrementDigit(_scoreParams.ScoreLenght);
                SetDigitDefaultPositions(_scoreParams.ScoreLenght);
                SetDigitPositions();
                _scoreParams.OldLenght = _scoreParams.ScoreLenght;
            }
            else
                SetScoreUI(scoreText, score);

            _scoreParams.Score = score;
        }

        public ushort OnGetScore()
        {
            return _scoreParams.Score;
        }

        private void SetScoreUI(string scoreText, ushort score)
        {
            if (_scoreParams.ScoreLenght == 1)
            {
                scoreImages[0].sprite = numberSprites[score];
            }
            else
            {
                byte endDigit = (byte)(scoreText[^1] - '0');
                Sprite zeroSprite = numberSprites[0];

                if (_scoreParams.ScoreLenght != _scoreParams.OldLenght)
                {
                    byte firstDigit = (byte)(scoreText[0] - '0');
                    scoreImages[0].sprite = numberSprites[firstDigit];
                    for (byte i = 1; i < scoreText.Length; i++)
                    {
                        scoreImages[i].sprite = zeroSprite;
                    }
                }
                else if (endDigit == 0)
                {
                    byte digit;
                    for (ushort i = 0; i < _scoreParams.ScoreLenght; i++)
                    {
                        digit = (byte)(scoreText[i] - '0');
                        scoreImages[i].sprite = numberSprites[digit];
                    }
                }
                else
                {
                    scoreImages[_scoreParams.ScoreLenght - 1].sprite = numberSprites[endDigit];
                }
            }
        }

        private void IncrementDigit(ushort digit)
        {
            for (ushort i = 0; i < digit; i++)
            {
                scoreImages[i].gameObject.SetActive(true);
            }
        }

        private void SetDigitDefaultPositions(ushort digit)
        {
            for (ushort i = 0; i < digit; i++)
            {
                scoreImages[i].rectTransform.localPosition = Vector3.zero;
            }
        }

        private void SetDigitPositions()
        {
            bool isOddDigitCount = _scoreParams.ScoreLenght % 2 == 1;
            _scoreParams.RightSpaceCount = isOddDigitCount ? new Vector3(120f, 0f, 0f) : new Vector3(60f, 0f, 0f);
            _scoreParams.LeftSpaceCount = _scoreParams.RightSpaceCount;
            _scoreParams.MiddleDigitIndex = (byte)((_scoreParams.ScoreLenght - Convert.ToByte(isOddDigitCount)) / 2);
            _scoreParams.SpawnMultiplier = isOddDigitCount ? (byte)2 : (byte)3;

            for (byte i = 0; i < _scoreParams.ScoreLenght; i++)
            {
                if (i < _scoreParams.MiddleDigitIndex)
                {
                    scoreImages[i].rectTransform.localPosition -= _scoreParams.LeftSpaceCount;
                    _scoreParams.LeftSpaceCount.x *= _scoreParams.SpawnMultiplier;
                }
                else if ((i > _scoreParams.MiddleDigitIndex && isOddDigitCount)
                         || (i >= _scoreParams.MiddleDigitIndex && !isOddDigitCount))
                {
                    scoreImages[i].rectTransform.localPosition += _scoreParams.RightSpaceCount;
                    _scoreParams.RightSpaceCount.x *= _scoreParams.SpawnMultiplier;
                }
            }
        }
    }
}