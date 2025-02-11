using UnityEngine;

[System.Serializable]
public class RangedState
{
    [SerializeField] private Behaviour _behaviour;
    [SerializeField] private float _range;
    [SerializeField] private string _animationName;
    private float _rangeSqr = -1;

    public float rangeSqr
    {
        get
        {
            if (_rangeSqr <= 0)
                _rangeSqr = _range * _range;

            return _rangeSqr;
        }
    }

    public Behaviour behaviour { get => _behaviour; }
    public string animationName { get => _animationName; }

    public RangedState(float rangeSqr, Behaviour state)
    {
        _rangeSqr = rangeSqr;
        _behaviour = state;
    }

    public bool Check(float distSqr)
    {
        if (distSqr < _rangeSqr)
            return true;
        return false;
    }

    public string GenerateName()
    {
        return _behaviour != null ? _behaviour.ToString() : "Unnamed State";
    }
}