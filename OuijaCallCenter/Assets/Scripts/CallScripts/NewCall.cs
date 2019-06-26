using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCall : MonoBehaviour {

    public Caller[] callers;

    public Caller GetNewCaller()
    {
        int callerID = Random.Range(0, callers.Length);
        return callers[callerID];
    }

}
