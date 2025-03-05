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

    [Header("Pick Up P250")]
    [Tooltip("It's in Hierachy: Player => Main Camera => Gun => P250")]
    public GameObject p250Obj;
    public GameObject subArmUI;

    [Header("Pick Up Key")]
    public bool isKey = false;


    private void Awake()
    {
        mainCam = Camera.main;
    }
    private void Start()
    {
        p250Obj.SetActive(false);
        fKey.SetActive(false);
        isShowFkey = false;

        combinedLayerMask = layerMaskP250 | keyLayerMask;
    }

    private void Update()
    {
        ShowFkey();
        P250PickUp();
        KeyPickUp();
    }

    public void ShowFkey()
    {
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, 3f, combinedLayerMask))
        {
            fKey.SetActive(true);
            isShowFkey = true;
        }
        else
        {
            fKey.SetActive(false);
            isShowFkey = false;
        }
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
                fKey.SetActive(false);
                isShowFkey = false;
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
                fKey.SetActive(false);
                isShowFkey = false;
                isKey = true;
            }
        }
    }
}