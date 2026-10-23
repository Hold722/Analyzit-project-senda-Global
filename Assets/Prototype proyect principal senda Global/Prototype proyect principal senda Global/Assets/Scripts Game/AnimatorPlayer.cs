
using UnityEngine;

public class AnimatorPlayer : MonoBehaviour
{
    public Animator animator;

    public float walkSpeed = 0.5f;
    public float runSpeed = 1.5f;
    public float jumpforce = 2.5f;
    public float groundistance = 0.2f;

    void Update()
    {
        // Run Settings 
        if (Input.GetKey(KeyCode.LeftShift) &&
            Input.GetKey(KeyCode.W))
        {
            Run();
        }
        //Jump settings
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }
     


        // Walk Settings
        else if (Input.GetKey(KeyCode.W))
        {
            WalkSpeed();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            WalkSpeed();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            WalkSpeed();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            WalkSpeed();
        }

        // IDLE
        else
        {
            Idle();
        }
        void jump()
        {
            animator.SetTrigger("Jump");
        }

    }

    void Idle()
    {
        animator.SetFloat("Speed", 0f);
    }

    void WalkSpeed()
    {
        animator.SetFloat("Speed", walkSpeed);
    }

    void Run()
    {
        animator.SetFloat("Speed", 1f);
    }




}
