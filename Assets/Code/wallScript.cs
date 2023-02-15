using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallScript : MonoBehaviour
{
    public logicScript logic;
    public SnakeController snake;

    // Start is called before the first frame update
    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        snake = GameObject.FindGameObjectWithTag("Snake").GetComponent<SnakeController>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            logic.gameOver();
            //stopMoving();
            snake.stopMoving();
        }
    }
}