using UnityEngine;
using UnityEngine.UIElements;

public class OutlineSelector : MonoBehaviour
{
    public Material mat;

    void Start()
    {
        mat.SetFloat("_Scale", 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseOver()
    {
        mat.SetFloat("_Scale", 1.05f);
    }
    private void OnMouseExit()
    {
        mat.SetFloat("_Scale", 1f);
    }


}
