using UnityEngine;

public class SetActiveForTenkoku : MonoBehaviour
{
    public GameObject tenkokuDynamicSkyObj;
    private void Start()
    {
        tenkokuDynamicSkyObj.SetActive(true);
    }
}