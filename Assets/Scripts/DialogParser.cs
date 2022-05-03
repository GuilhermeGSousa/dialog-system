using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DialogParser : MonoBehaviour
{
    [SerializeField] private DialogTree dialogTree;
    public UnityEvent<DialogNode> onDialogNode;
    public UnityEvent<BranchNode> onBranchNode;
    public UnityEvent onDialogOver;

    private bool canContinue = false;

    private void Start() {
        dialogTree.RestartDialog();

        StartCoroutine(RunDialog());
    }

    public void ContinueDialog()
    {
        canContinue = true;
    }

    private IEnumerator RunDialog()
    {
        while(dialogTree.current != null)
        {
            if(dialogTree.current is BranchNode)
            {
                onBranchNode.Invoke(dialogTree.current as BranchNode);
            }
            else if(dialogTree.current is DialogNode)
            {
                onDialogNode.Invoke(dialogTree.current as DialogNode);
            }
            // Add other node types here

            yield return WaitDialog();
            
            dialogTree.ContinueDialog();
        }

        onDialogOver.Invoke();
    }

    private IEnumerator WaitDialog()
    {
        yield return new WaitUntil(() => canContinue);
        canContinue = false;
    }
}
