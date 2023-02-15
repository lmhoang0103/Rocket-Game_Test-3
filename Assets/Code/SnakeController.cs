using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float steerSpeed = 180f;
    public Material redMaterial;
    public Material blueMaterial;
    public Material yellowMaterial;
    private bool isAlive = true;

    public logicScript logic;

    // Start is called before the first frame update
    private void Start()
    {
        changeMaterial();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isAlive == true)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;

            float steerDirection = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * steerDirection * steerSpeed * Time.deltaTime);
        }
    }

    public void changeMaterial()
    {
        Renderer[] childRenderers = GetComponentsInChildren<Renderer>();
        Material[] materials = { redMaterial, blueMaterial, yellowMaterial };
        int randomIndex = Random.Range(0, materials.Length);
        foreach (Renderer childRenderer in childRenderers)
        {
            childRenderer.material = materials[randomIndex];
        }
    }

    public void stopMoving()
    {
        isAlive = false;
    }
}