using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField]
    private Transform[] _sideNumberTransforms;
    [SerializeField]
    private float _rollTime;
    [SerializeField]
    private float _randomRollSpeed;
    [SerializeField]
    [Range(0,1)]
    private float _randomRollCutoff;

    public delegate void RollCallback(int value);

    private int _numberOfSides;
    private Quaternion[] _sideRotations;
    private Quaternion _targetRotation;
    private float _rollStartTime;
    private Quaternion _rollStartRotation;
    private Vector3 _randomRotateDirection;
    private bool _isRolling;
    private int _rollValue;
    private RollCallback _rollCallback;

    // Start is called before the first frame update
    private void Start()
    {
        _numberOfSides = _sideNumberTransforms.Length;
        _sideRotations = new Quaternion[_numberOfSides];
        for(int i = 0; i < _numberOfSides; i++)
        {
            _sideRotations[i] = _sideNumberTransforms[i].rotation;
        }
        _isRolling = false;
        _rollCallback = (int value) => {};

        _rollValue = 6;
        _targetRotation = Quaternion.Inverse(_sideRotations[_rollValue - 1]);
        transform.rotation = _targetRotation;
    }

    // Update is called once per frame
    private void Update()
    {
        if(_isRolling)
        {
            var rollTimeElapsed = Time.time - _rollStartTime;
            var rollTimeElapsedNormalized = (1.0F - (_rollTime - rollTimeElapsed)/_rollTime);
            if(rollTimeElapsedNormalized <= _randomRollCutoff)
            {
                transform.Rotate(_randomRotateDirection, _randomRollSpeed * Time.deltaTime);
                _randomRotateDirection = (
                    _randomRotateDirection + (Random.insideUnitSphere*Time.deltaTime)
                ).normalized;
                _rollStartRotation = transform.rotation;
            }
            else if(rollTimeElapsedNormalized <= 1.0F)
            {
                transform.rotation = Quaternion.Slerp(
                    _rollStartRotation,
                    _targetRotation,
                    (rollTimeElapsedNormalized - _randomRollCutoff)
                        * (1.0F/(1.0F-_randomRollCutoff))
                );
            }
            else
            {
                _rollCallback(_rollValue);
                _isRolling = false;
                transform.rotation = _targetRotation;
            }
        }
    }

    public int Roll(RollCallback rollCallback = null)
    {
        if(rollCallback != null)
        {
            _rollCallback = rollCallback;
        }
        _rollStartTime = Time.time;
        _rollStartRotation = transform.rotation;
        _randomRotateDirection = Random.insideUnitSphere.normalized;
        _isRolling = true;
        _rollValue = Random.Range(1, _numberOfSides+1);
        _targetRotation = Quaternion.Inverse(_sideRotations[_rollValue - 1]);
        return _rollValue;
    }
}
