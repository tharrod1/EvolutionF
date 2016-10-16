using UnityEngine;
using System.Collections;

public class Mutate : MonoBehaviour {
    bool mutate;
    public Manager manager;
    // Use this for initialization
    void Start () {
        mutate = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnClick()
    {
        manager.GetComponent<Manager>().Mutating = true;
    }
}
