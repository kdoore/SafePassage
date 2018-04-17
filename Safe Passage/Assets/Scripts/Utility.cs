using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Utility
{

	public static void ShowCG (CanvasGroup cg)
	{
		cg.alpha = 1;
		cg.blocksRaycasts = true;
		cg.interactable = true;
	}

	public static void HideCG (CanvasGroup cg)
	{
		cg.alpha = 0;
		cg.blocksRaycasts = false;
		cg.interactable = false;
	}

	

}

