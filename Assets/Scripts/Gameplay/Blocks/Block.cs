using System.Collections;
using UnityEngine;

public abstract class Block : ScriptableObject
{
    public Sprite Icon;

    public abstract bool CheckPossiblity();
    public abstract IEnumerator SuccessAction();
    public virtual IEnumerator FailAction() { yield return new WaitForSeconds(.4f); }
}