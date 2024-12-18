using System;
using Chess.Game.States;
using UnityEngine;

namespace Chess.Data
{
    [Serializable]
    public class MessageInformation
    {
        [field: SerializeField] public GameStateName StateName { get; private set; }
        [field: SerializeField] public string Message { get; private set; }
    }
}