using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    public Vector3 moveInput;

    public Animator animator;

    public Vector3 postion;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        animator = GetComponent<Animator>();

        float postionXIndex = PlayerPrefs.GetFloat("postionX");
        float postionYIndex = PlayerPrefs.GetFloat("postionY");
        Debug.Log(postionXIndex);

        if(postionXIndex !=null && postionYIndex != null)
        {
            Vector3 loadedPosition = new Vector3(postionXIndex, postionYIndex, 0);

            transform.position = loadedPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        transform.position += moveInput * moveSpeed * Time.deltaTime;
        postion = transform.position;

        animator.SetFloat("Speed", moveInput.sqrMagnitude);

        if(moveInput.x != 0)
        {
            if(moveInput.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 0);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 0);
            }
        }

        
    }

    public void HandlePauseButtonClick()
    {
          MenuManager.GoToMenu(MenuName.Pause);
    }
}
