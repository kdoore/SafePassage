using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{

    Button inventoryDisplayBtn;
    CanvasGroup panelCG, starPanelCG, gemPanelCG, crystalPanelCG;
    Dictionary<PickUpType, int> inventory;
    bool starActive, crystalActive, gemActive;
    // Use this for initialization
    void Start()
    {
        inventoryDisplayBtn = GameObject.Find("InventoryDisplayBtn").GetComponent<Button>();
        inventoryDisplayBtn.onClick.AddListener(ShowHideInventory);

        panelCG = GameObject.Find("InventoryDisplayPanel").GetComponent<CanvasGroup>();

        starPanelCG = GameObject.Find("StarPanel").GetComponent<CanvasGroup>();
        crystalPanelCG = GameObject.Find("CrystalPanel").GetComponent<CanvasGroup>();
        gemPanelCG = GameObject.Find("GemPanel").GetComponent<CanvasGroup>();

        Utility.HideCG(starPanelCG);
        Utility.HideCG(gemPanelCG);
        Utility.HideCG(crystalPanelCG);
        Utility.HideCG(panelCG);

        starActive = false;
        gemActive = false;
        crystalActive = false;

        GameData.instanceRef.onPlayerDataUpdate.AddListener(UpdateDisplay);
        UpdateDisplay(); ///call one time so this works in a scene without 
        //the events happening
    }

    public void ShowHideInventory()
    {
        if (panelCG.alpha > 0)
        { //currently visible
            Utility.HideCG(panelCG);
        }
        else
        {
            Utility.ShowCG(panelCG);
            Debug.Log("ShowPanel");
        }

    }

    // Update is called once per frame
    void UpdateDisplay()
    {
        inventory = GameData.instanceRef.inventory;

        foreach (var item in inventory)
        {
            updateUI(item.Key, item.Value);
        }
    }

    void updateUI(PickUpType type, int value)
    {
        Text itemText;
        switch (type)
        {
            case PickUpType.Peach:  ////YOU NEED TO CHANGE THIS TO MATCH YOUR ENUMS
                if (starActive == false)
                {
                    Utility.ShowCG(starPanelCG);
                    starActive = true;
                }
                itemText = starPanelCG.gameObject.GetComponentInChildren<Text>();
                itemText.text = value.ToString();
                break;
        }
           
    }//end UpdateUI

    //remove listener when scene is ending, so GameData doesn't maintain
    //the list of listeners going into a new scene
    void OnDisable()
    {
        GameData.instanceRef.onPlayerDataUpdate.RemoveListener(UpdateDisplay);
    }

}//end Class