using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    CharacterController character;
    Vector3 moveVector;
    public float speed = 10f;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        character.Move(moveVector * speed * Time.fixedDeltaTime);
    }

    public void OnMovementChanged(InputAction.CallbackContext context)
	{
        Vector2 direction = context.ReadValue<Vector2>();
        moveVector = new Vector3(direction.x, 0, direction.y);
	}

    void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag("Pickup"))
		{
            other.gameObject.SetActive(false);
            score++;
            Debug.Log("Score: " + score);
		}
	}
}
