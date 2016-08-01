using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent (typeof(GameObject))]
public class Movement : NetworkBehaviour {

    private Vector3 pos;

	// Use this for initialization
	void Start () {
        GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));

        pos = Vector3.zero;
	}

    // Update is called once per frame
    [ClientCallback]
    void Update () {
        if (!isLocalPlayer)
            return;

        pos.x += Input.GetAxis("Horizontal") * Time.deltaTime;
        pos.y += Input.GetAxis("Vertical")   * Time.deltaTime;

        CmdMove(pos);
        //transform.position = pos;

	}

    [Command]
    void CmdMove(Vector3 posn)
    {
        transform.position = posn;
    }

   
}
