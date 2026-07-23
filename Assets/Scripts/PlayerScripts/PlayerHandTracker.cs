using UnityEngine;

public class PlayerHandTracker : MonoBehaviour
{
    [SerializeField] Transform _tranckerObject;

    void Update()
    {
        this.transform.position = _tranckerObject.position;
    }
}
