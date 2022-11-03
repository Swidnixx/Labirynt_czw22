using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal linkedPortal;
    public Renderer myRenderPlane;
    Camera playerCam;
    Camera myCam;
    [HideInInspector] public PortalTeleport myTeleport;

    private void Awake()
    {
        playerCam = Camera.main;
        myCam = GetComponentInChildren<Camera>();

        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 0);
        myCam.targetTexture = rt;
        linkedPortal.myRenderPlane.material.SetTexture("_MainTex", rt);

        myTeleport = GetComponentInChildren<PortalTeleport>();
    }

    private void Start()
    {
        linkedPortal.myTeleport.receiver = myTeleport.transform;
    }

    private void Update()
    {
        Matrix4x4 m = transform.localToWorldMatrix * linkedPortal.transform.worldToLocalMatrix * playerCam.transform.localToWorldMatrix;
        myCam.transform.SetPositionAndRotation(m.GetColumn(3), m.rotation);
    }
}
