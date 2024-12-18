using UnityEngine;

namespace Chess.Data
{
    [CreateAssetMenu(fileName = "Messages Config", menuName = "Chess/Messages Config")]
    public class MessagesConfig : ScriptableObject
    {
        [field: Header("Messages"), SerializeField]
        public string CantFindGtlfPath { get; private set; } = "Can't find a glTF model on the path";
        [field: SerializeField] public string CantFindPivotObject { get; private set; } = "Can't find the object with name: ";
        [field: SerializeField] public string SceneCantBeLoaded { get; private set; } = "Something happened during loading model from glTF.";

        [field: SerializeField] public MessageInformation[] MessageConfigs { get; private set; }
    }
}