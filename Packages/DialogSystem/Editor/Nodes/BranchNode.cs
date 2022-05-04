using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class BranchNode : DialogNode 
{
	[Output(dynamicPortList = true)] public List<string> answers = new List<string>();

	private int chosenLine = 0;
	
	public void SetAnswer(int index)
	{
		if(index >= answers.Count) return;
		chosenLine = index;
	}

	public string GetChosenAnswer()
	{
		return answers[chosenLine];
	}

    public override void ContinueDialog()
    {
        NodePort port = null;

		port = GetOutputPort("answers " + chosenLine);

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