using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.XRRedefinition
{
    public interface IInteractable<T>
        where T : Component
    {
        UnityEvent<T> HoverEvent { get; }
        UnityEvent<T> DehoverEvent { get; }
        UnityEvent<T> SelectEvent { get; }
        UnityEvent<T> DeselectEvent { get; }

        void Hover(T component);
        void Dehover(T component);
        void Select(T component);
        void Deselect(T component);
    }
}