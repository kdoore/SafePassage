using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleDialogManager : MonoBehaviour {


    public SimpleConversationList convList;
    private Button  openDialogBtn, nextButton;
    private CanvasGroup cg;
    private Text dialogText, speakerName; //speakerName;
                             //private Image speakerImage;
    private GameObject dialogPanel;
    public int conversationIndex;
    private Animator animator;

	// Use this for initialization
	void Start () {
        cg = GameObject.Find("SimpleDialogPanel").GetComponent<CanvasGroup>();
        //get the scriptable object from the Resources folder
        //convList = Resources.Load ("BeginConversation") as ConversationList;
        conversationIndex = 0;

        dialogText = GameObject.Find("DialogText").GetComponent<Text>();
        speakerName = GameObject.Find("NameText").GetComponent<Text>();
       
        animator = this.GetComponent<Animator>();

        openDialogBtn = GameObject.Find("OpenDialogButton").GetComponent<Button>();
        openDialogBtn.onClick.AddListener(openDialog);

        nextButton = GameObject.Find("NextButton").GetComponent<Button>();
        nextButton.onClick.AddListener(getNextDialog);

        Utility.HideCG(cg);
    }

    void getNextDialog()
    {
        bool moreDialog = NextDialog();
        if (!moreDialog)
        {
            Utility.HideCG(cg); // close panel
            openDialogBtn.gameObject.SetActive(true);
            closeDialog();
        }
    }
	
    public void openDialog()
    {
        Utility.ShowCG(cg);
        animator.SetBool("IsOpen", true);
        NextDialog();
        openDialogBtn.gameObject.SetActive(false);
    }

    public void closeDialog()
    {

        Utility.HideCG(cg);
        animator.SetBool("IsOpen", false);
        openDialogBtn.gameObject.SetActive(true);
    }

    public bool NextDialog()
    {
        if (conversationIndex < convList.Conversation.Count)
        {
            ConversationEntry.imagePosition imgPos = convList.Conversation[conversationIndex].imgPosition;

            if (imgPos == ConversationEntry.imagePosition.left)
            {
                Debug.Log("Left Text Color");
                Color textColor = convList.speaker_leftTextColor;
                dialogText.color = textColor;
                speakerName.color = textColor;
                speakerName.text = convList.Conversation[conversationIndex].speakerName;
            }
            else
            { //use right panel
                Debug.Log("Right Text Color");
                Color textColor = convList.speaker_rightTextColor;
                dialogText.color = textColor;
                speakerName.color = textColor;
                speakerName.text = convList.Conversation[conversationIndex].speakerName;
        
            }

            //start converstion
            StopAllCoroutines();
            StartCoroutine(TypeSentence(convList.Conversation[conversationIndex].dialogTxt));
            conversationIndex++;
        }
        else
        {
            conversationIndex = 0;
            return false;  //if no more list elements return false
        }

        return true;
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = ""; //clear previous sentance
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.05f); ;
        }


    }
}
