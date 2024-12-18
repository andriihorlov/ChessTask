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
            MessageInformation messageInformation = GetMessage(gameStateName);
            _aboveText.text = messageInformation.MainMessage;
            _belowText.text = messageInformation.AdditionalMessage;
        }

        private MessageInformation GetMessage(GameStateName gameStateName)
        {
            return _messagesInformation.First(messageConfig => messageConfig.StateName == gameStateName);
        }
    }
}