using UnityEngine;

namespace Chess.Data
{
    [CreateAssetMenu(fileName = "Messages Config", menuName = "Chess/Messages Config")]
    public class MessagesConfig : ScriptableObject
    {
        [field: Header("Messages"), SerializeField]
        public string CantFindGtlfPath { get; private set; } = "Can't find a glTF model on the path";

        [field: SerializeField] public MessageInformation[] MessageConfigs { get; private set; }
    }
}