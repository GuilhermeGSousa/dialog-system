using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XNode;

[CreateAssetMenu]
public class DialogTree : NodeGraph 
{ 
    [HideInInspector]
    public BaseDialogNode current;

    public void RestartDialog()
    {
        // Get the node with no inputs as start node
        current = nodes.Find(n => n.Inputs.All(input => !input.IsConnected)) as BaseDialogNode;
    }

    public void ContinueDialog()
    {
        current.ContinueDialog();
    }
}