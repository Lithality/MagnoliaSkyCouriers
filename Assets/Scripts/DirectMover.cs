using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * A mover which moves the transform directly, ignoring physics
 */
public class DirectMover : AbstractMover
{
	[SerializeField]
	private float _closenessThreshold = 1.0f;
	
	private Vector3 _destination;
	
	void Awake()
	{
		_moveUpdateDelegates = new List<MoveUpdateDelegate>();
		_moveCompleteDelegates = new List<MoveCompleteDelegate>();
	}
	
	void Update()
	{
		if (_isMoving)
		{
			//Debug.Log ("Move!");
			Vector3 displacement = _speed * (_destination - transform.position).normalized * Time.deltaTime;
			transform.position += displacement;
			OnMoveUpdate();
			if (Vector3.Distance(transform.position, _destination) <= _closenessThreshold)
			{
				_isMoving = false;
				OnMoveComplete();
			}
		}
	}
	
	public override void MoveTowards(Vector3 destination)
	{
		_isMoving = true;
		_destination = destination;
	}
	
	public override void MoveTowardsForTime(Vector3 firstDestination, float duration, Vector3 finalDestination)
	{
		throw new System.NotImplementedException();
	}
	
	public override void StopMoving()
	{
		_isMoving = false;
	}
	
	public override void CalculatePath()
	{
	}
}
