using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BranchNodeDisplayer : MonoBehaviour
{
    [SerializeField] private DialogParser dialogParser;
    [SerializeField] private Image speakerImage;
    [SerializeField] private TMP_Text speakerName;
    [SerializeField] private TMP_Text dialogLine;
    [SerializeField] private TMP_Text anwserOptions;

    private void OnEnable() 
    {
        dialogParser.onBranchNode.AddListener(OnBranchNode);
    }

    private void OnDisable() 
    {
        dialogParser.onBranchNode.RemoveListener(OnBranchNode);
    }

    private void OnBranchNode(BranchNode node)
    {
        if(speakerImage) speakerImage.sprite = node.speakerImage;
        if(speakerName) speakerName.text = node.speakerName;
        if(dialogLine) dialogLine.text = node.dialogLine;
        if(anwserOptions)
        {
            // TODO Something waaay better here, with slider views and button prefabs
            // It serves well as an example though
            anwserOptions.text = "";
            foreach (var answer in node.answers)
            {
                anwserOptions.text += answer + "\n";
            }

            // This should be done by a button or something, again this is a simple example
            node.SetAnswer(1);
        }
    }
}
