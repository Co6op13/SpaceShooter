using UnityEngine;


public interface ISelectable
{
    [SerializeField] GameObject gameObject { get; }
    void Select();
    void Deselect();
}
