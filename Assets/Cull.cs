using UnityEngine;
using System.Collections;

public class Cull : MonoBehaviour {
    bool culling = false;
    public Manager manager;
    // Use this for initialization
    void Start () {
        culling = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
        manager.GetComponent<Manager>().Culling = true;
    }
}
