using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;



public class Teleport_modi : MonoBehaviour
{
    [SerializeField] private XRRayInteractor ray;
    [SerializeField] private XRInteractorLineVisual linerenderer;

    [SerializeField] private TeleportationProvider teleportationProvider;

    [Header("Layer - teleport Area")]
    [SerializeField] private InteractionLayerMask Teleport_area;

    [Header("Layer - teleport Anchor")]
    [SerializeField] private InteractionLayerMask Teleport_anchor;



    [SerializeField] private InputActionProperty TeleportModeAcitve;
    [SerializeField] private InputActionProperty TeleportModeCancel;
    [SerializeField] private InputActionProperty GripmodeAcitve;
    [SerializeField] private InputActionProperty Trigger;

    public bool isRayActive = false;
    private bool isactive;
    private InteractionLayerMask interactionLayer;
    private List<IXRInteractable> interactables=new List<IXRInteractable>();


    private void Start()
    {
        //Action . Enable -> ������ ���� ��(Performed) �̺�Ʈ �߰�
        
        //action Ȱ��ȭ
        TeleportModeAcitve.action.Enable();
        TeleportModeCancel.action.Enable();
        //Action  �̺�Ʈ �߰�
        TeleportModeAcitve.action.performed += onTeleportActive;
        TeleportModeCancel.action.performed += onTeleportCancel;

        interactionLayer = ray.interactionLayers;
        linerenderer = ray.gameObject.GetComponent<XRInteractorLineVisual>();

        if(!isRayActive)
        {
            linerenderer.enabled = isRayActive;
        }
    }

    private void Update()
    {
        if (!isactive) return;

        if(Trigger.action.IsPressed()||TeleportModeAcitve.action.IsPressed())
        {
            if (!linerenderer.enabled)
            {
                linerenderer.enabled = true;
            }
            return;
        }
        ray.GetValidTargets(interactables);
        if(interactables.Count<=0)
        {
            Turnoff_Teleport();
            return;
        }
        ray.TryGetCurrent3DRaycastHit(out RaycastHit hit);
        TeleportRequest request = new TeleportRequest();
        if (interactables[0].interactionLayers.Equals(Teleport_area))
        {
            //teleport Area
            Vector3 pos =
                new Vector3(hit.point.x, request.destinationPosition.y, hit.point.z);
            request.destinationPosition = pos;

            linerenderer.enabled = false;
        }
        else if (interactables[0].interactionLayers.Equals(Teleport_anchor))
        {
            request.destinationPosition = 
                hit.transform.GetChild(0).transform.position;
            linerenderer.enabled = false;
        }
        teleportationProvider.QueueTeleportRequest(request);
        Turnoff_Teleport();

    }

    private void onTeleportActive(InputAction.CallbackContext obj)
    {
        if(GripmodeAcitve.action.phase!=InputActionPhase.Performed
            ||TeleportModeCancel.action.phase!=InputActionPhase.Performed)
        {
            isactive = true;
            ray.lineType = XRRayInteractor.LineType.ProjectileCurve;
            ray.interactionLayers = Teleport_area;
            ray.interactionLayers |= Teleport_anchor;//Layer Mix... ���� ���
        }
    }
    private void onTeleportCancel(InputAction.CallbackContext obj)
    {
        Turnoff_Teleport();
    }


    private void Turnoff_Teleport()
    {
        isactive = false;
        ray.lineType = XRRayInteractor.LineType.StraightLine;
        ray.interactionLayers = interactionLayer;
    }

}
