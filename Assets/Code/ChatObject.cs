using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ChatObject : ScriptableObject
{
    public ChatByte[] say;

}
[System.Serializable]
public struct ChatByte
{
    public int Type;
    public string[] words;
    public int[] ToLine;
    public bool endConvo;
}
