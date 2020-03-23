using UnityEngine;
using UnityEngine.Events;

public class ObjectHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public FloatVariable HP;
    
    public bool ResetHP;
    public FloatReference StartingHP;
    public UnityEvent DamageEvent;
    public UnityEvent DeathEvent;

    private void Start()
    {
        if (ResetHP)
            HP.SetValue(StartingHP);
    }

    private void OnTriggerEnter(Collider other)
    {
        DamageDeal damage = other.gameObject.GetComponent<DamageDeal>();
        if (damage != null)
        {
            HP.ApplyChange(-damage.DamageAmount);
            DamageEvent.Invoke();
        }

        if (HP.Value <= 0.0f)
        {
            DeathEvent.Invoke();
        }
    }
}

