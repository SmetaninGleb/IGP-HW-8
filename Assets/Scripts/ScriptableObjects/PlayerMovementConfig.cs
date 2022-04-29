using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMovementConfig", menuName = "Configs/Player Movement Config")]
public class PlayerMovementConfig : ScriptableObject
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private int _startDirectionIndex = 0;
    [SerializeField] 
    private List<Vector3> _directions = new List<Vector3>(
        new Vector3[] {
            new Vector3(0, 0, 1), 
            new Vector3(1, 0, 0)
        });

    public float Speed => _speed;
    public int StartDirectionIndex => _startDirectionIndex;
    public List<Vector3> Directions => _directions;
}