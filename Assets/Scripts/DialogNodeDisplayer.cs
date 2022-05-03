using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogNodeDisplayer : MonoBehaviour
{
    [SerializeField] private DialogParser dialogParser;
    [SerializeField] private Image speakerImage;
    [SerializeField] private TMP_Text speakerName;
    [SerializeField] private TMP_Text dialogLine;

    private void OnEnable() 
    {
        dialogParser.onDialogNode.AddListener(OnDialogLine);
    }

    private void OnDisable() 
    {
        dialogParser.onDialogNode.RemoveListener(OnDialogLine);
    }

    private void OnDialogLine(DialogNode node)
    {
        if(speakerImage) speakerImage.sprite = node.speakerImage;
        if(speakerName) speakerName.text = node.speakerName;
        if(dialogLine) dialogLine.text = node.dialogLine;
    }
}
