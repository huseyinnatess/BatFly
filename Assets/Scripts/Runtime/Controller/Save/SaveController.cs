using Runtime.Keys.Save;
using Runtime.MonoSingleton;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Controller.Save
{
    public class SaveController : MonoSingleton<SaveController>
    {
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