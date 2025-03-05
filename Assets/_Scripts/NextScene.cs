using UnityEngine;

public class DoorTrigger : LoadingLevel
{
    FkeyFunction fkeyFunction;
    public GameObject information;

    private void Awake()
    {
        fkeyFunction = GameObject.Find("GameManager").GetComponent<FkeyFunction>();
    }
    protected override void Start()
    {
        base.Start();
        information.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (fkeyFunction.isHasKey)
                {
                    LoadLevel();
                }
                else
                {
                    Debug.Log("You need a key to open this door");
                    information.SetActive(true);
                    Invoke(nameof(CloseInformation), 1f);
                }
            }

        }
    }

    public void CloseInformation()
    {
        information.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fkeyFunction.HideFkeyBase();
        }
    }
}
