using System.Linq;
using Chess.Data;
using Chess.Game.States;
using TMPro;
using UnityEngine;

namespace Chess.Game.Views
{
    public class GameModeView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _aboveText;
        [SerializeField] private TextMeshProUGUI _belowText;

        private MessagesConfig _messagesConfigs;
        private MessageInformation[] _messagesInformation;
        
        public void InitMessages(MessagesConfig messageConfigs)
        {
            _messagesInformation = messageConfigs.MessageConfigs;
        }
        
        public void ShowState(GameStateName gameStateName)
        {
            string message = GetMessage(gameStateName);
            SetText(message, gameStateName != GameStateName.GeometryPlaced);
        }

        private string GetMessage(GameStateName gameStateName)
        {
            return _messagesInformation.First(messageConfig => messageConfig.StateName == gameStateName).Message;
        }

        private void SetText(string text, bool isAbove)
        {
            _aboveText.gameObject.SetActive(isAbove);
            _belowText.gameObject.SetActive(!isAbove);

            if (isAbove)
            {
                _aboveText.text = text;
            }
            else
            {
                _belowText.text = text;
            }
        }
    }
}