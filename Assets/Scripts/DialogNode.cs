using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class DialogNode : BaseDialogNode 
{
	public Sprite speakerImage;
	public string speakerName;
	public string dialogLine;

    public override void ContinueDialog()
    {
        NodePort port = null;

		port = GetOutputPort("output");

		if(port.Connection == null)
		{
			(graph as DialogTree).current = null;
		}
		else
		{
			(graph as DialogTree).current = port.Connection.node as BaseDialogNode;
		}
    }
}