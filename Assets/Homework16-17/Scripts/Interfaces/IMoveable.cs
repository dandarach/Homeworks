using UnityEngine;

namespace Homework17.Interfaces
{
    public interface IMoveable
    {
        Transform InitialTransfom { get; }

        void Move(Vector3 direction);
    }
}