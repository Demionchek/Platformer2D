using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Healths : MonoBehaviour
{
    [SerializeField] private AnimationClip diedAnim;
    [SerializeField] private float maxHealth;
    private bool isAlive;
    private float currHealth;
    private Animator animator;


    public bool IsAlive => isAlive;
    public float CurrHealth => currHealth;
    public float MaxHealth => maxHealth;

    public delegate void HealthEvents();
    public static event HealthEvents IsDamagedEvent;
    public static event HealthEvents IsDeadEvent;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        currHealth = maxHealth;
        isAlive = true;
    }

    private void Update()
    {
        if (!isAlive)
            Invoke("Died",diedAnim.length);

    }

    private void Died()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        currHealth -= damage;
        IsDamagedEvent();
        animator.SetTrigger("Damaged");

        CheckIsAlive();
    }

    private void CheckIsAlive()
    {
        if (currHealth > 0)
            isAlive = true;
        else
        {
            IsDeadEvent();
            isAlive = false;
            animator.SetTrigger("Dead");
        }
    }
}
