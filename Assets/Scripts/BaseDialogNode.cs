using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public abstract class BaseDialogNode : Node {

	[Input(backingValue = ShowBackingValue.Never)] public BaseDialogNode input;
	[Output(backingValue = ShowBackingValue.Never)] public BaseDialogNode output;

	public override object GetValue(NodePort port) {
		return null;
	}

	abstract public void ContinueDialog();
}