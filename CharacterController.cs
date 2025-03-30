using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed for moving left/right
    public float rotateSpeed = 90f; // Speed for rotation (degrees per second)
    public float scaleChange = 0.1f; // Amount to increase/decrease size
    private Vector3 initialScale; // Store the starting scale for reset
    private Vector3 initialPosition; // Store the starting position for reset

    void Start()
    {
        // Store the initial scale and position for the reset function
        initialScale = transform.localScale;
        initialPosition = transform.position;
    }

    // Move the character to the left
    public void MoveLeft()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    // Move the character to the right
    public void MoveRight()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    // Rotate the character to the right
    public void RotateRight()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }

    // Rotate the character to the left
    public void RotateLeft()
    {
        transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
    }
    public void MoveForward() // New function for forward movement
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    public void MoveBackward() // New function for backward movement
    {
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }

    // Increase the character's size
    public void IncreaseSize()
    {
        transform.localScale += new Vector3(scaleChange, scaleChange, scaleChange);
    }

    // Decrease the character's size
    public void DecreaseSize()
    {
        transform.localScale -= new Vector3(scaleChange, scaleChange, scaleChange);
        // Prevent the scale from going below a minimum (e.g., 0.1)
        if (transform.localScale.x < 0.1f)
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
    }

    // Reset the character's position, rotation, and scale
    public void ResetCharacter()
    {
        transform.position = initialPosition;
        transform.rotation = Quaternion.identity; // Reset rotation to 0
        transform.localScale = initialScale;
    }

    // Go back to the menu scene
    public void GoBack()
    {
        SceneManager.LoadScene("MenuScene"); // Assumes your menu scene is named "MenuScene"
    }
}