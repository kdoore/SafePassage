using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// https://gist.github.com/unitycoder/19625fed364a39cb278f#file-uitexttypewriter-cs
/// </summary>

public class DialogManager : MonoBehaviour
{
    public UnityEvent onPanelClosing; 
	public ConversationList convList;
	private Button nextButton, openDialogBtn;
	private CanvasGroup cg;
    private Text dialogText;  
	private GameObject leftSpeakerPanel, rightSpeakerPanel, dialogButton;
    public  int conversationIndex;
    private bool showButton = true;


	void Awake ()
	{
        if(onPanelClosing == null){
            onPanelClosing = new UnityEvent();
        }
		cg = GameObject.Find ("ConvPanel").GetComponent<CanvasGroup> ();
        //get the scriptable object from the Resources folder
		//convList = Resources.Load ("BeginConversation") as ConversationList;
        conversationIndex = 0;

		nextButton = GameObject.Find ("NextButton").GetComponent<Button> ();
		nextButton.onClick.AddListener (getNextDialog);

		dialogText = GameObject.Find ("DialogText").GetComponent<Text> ();
         
        leftSpeakerPanel = GameObject.Find("SpeakerPanelLeft");
        rightSpeakerPanel = GameObject.Find("SpeakerPanelRight");

        dialogButton = GameObject.Find("OpenDialogButton");

		openDialogBtn = GameObject.Find ("OpenDialogButton").GetComponent<Button> ();
		openDialogBtn.onClick.AddListener (openDialog);

		Utility.HideCG (cg);
	}

	void getNextDialog ()
	{   
        
		bool moreDialog = NextDialog ();
		if (!moreDialog) {
			Utility.HideCG (cg); // close panel
            if (showButton == true)  
            {
                openDialogBtn.gameObject.SetActive(true);
            }
		}
	}

   
    public void HideButton(){
        showButton = false;
        dialogButton.SetActive(false);
    }

	public void openDialog ()
	{
		Utility.ShowCG (cg);
		NextDialog ();
		openDialogBtn.gameObject.SetActive (false);
	}

    public bool NextDialog()
    {
        int counter = conversationIndex;

       if (counter < convList.Conversation.Count)
        {
            ConversationEntry.imagePosition imgPos = convList.Conversation[counter].imgPosition;
            //use left panel
            Text sName;
            Image sImage; 
            if(imgPos == ConversationEntry.imagePosition.left){
                leftSpeakerPanel.SetActive(true);
                rightSpeakerPanel.SetActive(false);
                sName = leftSpeakerPanel.GetComponentInChildren<Text>();
                Image[] images = leftSpeakerPanel.GetComponentsInChildren<Image>();
                sImage = images[1]; //first child img
                sName.color = convList.speakerLeftColor;
                dialogText.color = convList.speakerLeftColor;
            }else{ //use right panel
                leftSpeakerPanel.SetActive(false);
                rightSpeakerPanel.SetActive(true);
                sName = rightSpeakerPanel.GetComponentInChildren<Text>();
                Image[] images = rightSpeakerPanel.GetComponentsInChildren<Image>();
                sImage = images[1]; //first child img
               
                sName.color = convList.speakerRightColor;
                dialogText.color = convList.speakerRightColor;
            }
            sName.text = convList.Conversation[counter].speakerName;
            sImage.sprite = convList.Conversation[counter].speakerImg;
            conversationIndex++;

            //start converstion
            StopAllCoroutines();
            StartCoroutine(TypeSentence(convList.Conversation[counter].dialogTxt));
           
        }
        else
        {
            conversationIndex = 0;
            if (onPanelClosing != null)
            {
                onPanelClosing.Invoke();
            return false;  //if no more list elements return false
           
            }
        }

        return true;
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = ""; //clear previous sentance
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.10f);;
        }

       
    }

}
