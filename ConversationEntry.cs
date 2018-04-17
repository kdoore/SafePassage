using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class ConversationEntry
{
    public enum imagePosition { left, right }

	public Sprite speakerImg;
	public string dialogTxt;
	public string speakerName;
    public imagePosition imgPosition;
  

}
