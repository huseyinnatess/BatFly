using Runtime.Keys.Save;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Controller.Save
{
    public class SaveController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public static SaveController Instance;

        #endregion
        

        #endregion

        private void Awake()
        {
            Singleton();
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

        public void OnSaveData()
        {
            SaveGame(
                new SaveGameDataParams()
                {
                    HighScore = UISignals.Instance.onGetScore?.Invoke() ?? 0
                });
        }

        private void SaveGame(SaveGameDataParams saveGameDataParams)
        {
            PlayerPrefs.SetInt("HighLevel", saveGameDataParams.HighScore);
            PlayerPrefs.Save();
        }
    }
}