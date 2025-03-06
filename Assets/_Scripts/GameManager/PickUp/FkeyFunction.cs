using UnityEngine;

public class FkeyFunction : MonoBehaviour
{
    Camera mainCam;
    RaycastHit hit;

    [Header("F Key")]
    public GameObject fKey;

    public bool isShowFkey;

    [Header("Layer Mask")]
    LayerMask combinedLayerMask;
    public LayerMask layerMaskP250;
    public LayerMask keyLayerMask;
    public LayerMask firstAid;
    public LayerMask doorInOpenScene;
    public LayerMask notePaper;

    [Header("Pick Up P250")]
    [Tooltip("It's in Hierachy: Player => Main Camera => Gun => P250")]
    public GameObject p250Obj;
    public GameObject subArmUI;

    [Header("Pick Up Key")]
    public bool isHasKey = false;

    [Header("Read Note")]
    public GameObject noteUI;
    public GameObject noteObj;
    bool isReadNote = false;

    private void Awake()
    {
        mainCam = Camera.main;
    }
    private void Start()
    {
        fKey.SetActive(false);
        isShowFkey = false;
        noteUI.SetActive(false);

        combinedLayerMask = layerMaskP250 | keyLayerMask | doorInOpenScene | notePaper;
    }

    private void Update()
    {
        ShowFkey();
        P250PickUp();
        KeyPickUp();
        OpenDoorInSceneOpen();
    }

    public void ShowFkey()
    {
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, 3f, combinedLayerMask))
        {
            ShowFkeyBase();
        }
        else
        {
            HideFkeyBase();
        }
    }

    public void ShowFkeyBase()
    {
        fKey.SetActive(true);
        isShowFkey = true;
    }
    public void HideFkeyBase()
    {
        fKey.SetActive(false);
        isShowFkey = false;
    }

    public void P250PickUp()
    {
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, 3f, layerMaskP250))
        {
            if (Input.GetKeyDown(KeyCode.F) && isShowFkey)
            {
                subArmUI.SetActive(true);
                Destroy(hit.transform.gameObject);
                p250Obj.SetActive(true);
                HideFkeyBase();
            }
        }
    }

    public void KeyPickUp()
    {
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, 3f, keyLayerMask))
        {
            if (Input.GetKeyDown(KeyCode.F) && isShowFkey)
            {
                Destroy(hit.transform.gameObject);
                HideFkeyBase();
                isHasKey = true;
            }
        }
    }

    public void OpenDoorInSceneOpen()
    {
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, 3f, doorInOpenScene))
        {
            if (Input.GetKeyDown(KeyCode.F) && isShowFkey)
            {
                HideFkeyBase();
            }
        }
    }
}