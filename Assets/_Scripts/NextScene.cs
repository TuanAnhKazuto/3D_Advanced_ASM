using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : LoadingLevel
{
    public LowPickUpItem lowPickUpItem;
    public GameObject information;

    public Animator inforAnim;

    private void Start()
    {
        information.SetActive(false);
    }

    private void Update()
    {
        if (!lowPickUpItem.hasKey)
        {
            information.SetActive(true);
            float time = inforAnim.GetCurrentAnimatorStateInfo(0).length;
            if (time >= 1)
            {
                information.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            lowPickUpItem.fKey.SetActive(true);

            if (lowPickUpItem.hasKey)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    LoadLevel();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lowPickUpItem.fKey.SetActive(false);
        }
    }
}
