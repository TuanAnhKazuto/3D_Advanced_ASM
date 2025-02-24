using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : LoadingLevel
{
    protected override void Start()
    {
        base.Start();
    }
    //public LowPickUpItem lowPickUpItem;
    //public GameObject information;

    //public Animator inforAnim;

    //private void Start()
    //{
    //    information.SetActive(false);
    //}

    //private void Update()
    //{
    //    if (!lowPickUpItem.hasKey)
    //    {
    //        information.SetActive(true);
    //        float time = inforAnim.GetCurrentAnimatorStateInfo(0).length;
    //        if (time >= 1)
    //        {
    //            information.SetActive(false);
    //        }
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            LoadLevel();
        }
    }
}
