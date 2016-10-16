using UnityEngine;
using System.Collections;

public class Permutation : MonoBehaviour {
    public Manager manager;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnClick()
    {
        manager.GetComponent<Manager>().Permutate= true;
    }
}
