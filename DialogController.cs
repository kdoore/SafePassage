using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events; //must include this statement

public class DialogController : MonoBehaviour
{
    //Panel Broadcasts notification that it's closing, so listeners can do something
    public UnityEvent onPanelClosing; //define the custom event

    CanvasGroup cg;
    Button nextBtn;
    Text dialogText;

    [TextArea]
    public List<string> dialogList = new List<string>();
    private Queue<string> queue = new Queue<string>(); //declare, initialize

    // Use this for initialization
    void Start()
    {
        //if event hasn't been initialized
        if (onPanelClosing == null)
        {
            onPanelClosing = new UnityEvent();
        }

        cg = GetComponent<CanvasGroup>();

        nextBtn = GetComponentInChildren<Button>();
        nextBtn.onClick.AddListener(GetNextDialog);

        dialogText = GetComponentInChildren<Text>();

        //put each string in the list into the queue
        foreach (string curString in dialogList)
        {
            queue.Enqueue(curString);
        }

        if (queue.Count != 0)
        {
            dialogText.text = queue.Dequeue();
        }

        //make sure panel is showing
        Utility.ShowCG(cg);
    }

    public void GetNextDialog()
    {
        if (queue.Count != 0)
        {
            dialogText.text = queue.Dequeue();
        }
        else
        {  //No more dialog in the queue
            Utility.HideCG(cg); //hide panel

            //check to see if anyone is listening
            if (onPanelClosing != null)
            {
                onPanelClosing.Invoke(); //invoke event        
            }
        }

    }

}