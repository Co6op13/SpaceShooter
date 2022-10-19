
using UnityEngine;

internal partial class WeaponData: MonoBehaviour, IArmed
{

    [SerializeField] [Tooltip("Is it shooting at the moment?")] private FireKey fireKey = FireKey.Fire1;
    [SerializeField] [Tooltip("Is it shooting at the moment?")] private bool isDefaultShooting = false;
    [SerializeField] private GameObject prefabDefaultWeapon;
    [SerializeField] private Transform currentWeapon;

    //[SerializeField] [Tooltip("Is it shooting at the moment?")] private bool isAdditionalShooting = false;
    //[SerializeField] private GameObject additionalWeapon;
    //[SerializeField] [Tooltip("Is it shooting at the moment?")] private Transform pivotAdditionaltWeapon;
    [SerializeField] [Tooltip("Is it shooting at the moment?")] private Transform pivotDefaultWeapon;
    public bool IsDefaultShooting { get => isDefaultShooting; set => isDefaultShooting = value; }
    //public bool IsAdditionalShooting { get => isAdditionalShooting; set => isAdditionalShooting = value; }
   

    public Transform PivotDefaultWeapon => pivotDefaultWeapon;

    public Transform CurrentWeapon { get => currentWeapon; set => currentWeapon = value; }

    //public Transform PivotAdditionaltWeapon => pivotAdditionaltWeapon;

    private void Awake()
    {
        SetDefaultWeapon(prefabDefaultWeapon);
        
        //SetAdditionalWeapon(defaultWeapon);
    }

    //public void SetAdditionalWeapon(GameObject weapon)
    //{
        
    //    additionalWeapon = Instantiate(additionalWeapon, pivotAdditionaltWeapon);
    //}

    public void SetDefaultWeapon(GameObject weapon)
    {
        prefabDefaultWeapon = Instantiate(prefabDefaultWeapon , pivotDefaultWeapon);
        currentWeapon = prefabDefaultWeapon.transform;
    }


    
}