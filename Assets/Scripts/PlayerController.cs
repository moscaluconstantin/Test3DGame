using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] [Range(-1f, 1f)] private float xSpeed = 0;
    [SerializeField] [Range(-1f, 1f)] private float zSpeed = 0;

    private int xSpeedHashedName;
    private int zSpeedHashedName;

    private Animator animator;

    private void Awake()
    {
        xSpeedHashedName = Animator.StringToHash("X Speed");
        zSpeedHashedName = Animator.StringToHash("Z Speed");

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetFloat(xSpeedHashedName, xSpeed);
        animator.SetFloat(zSpeedHashedName, zSpeed);
    }
}