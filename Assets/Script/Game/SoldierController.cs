using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
internal struct ColorMaterials
{
	public List<Material> Materials;
}

public class SoldierController : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> _bodyModels;
	[SerializeField]
	private List<ColorMaterials> _colorMaterials;
	[SerializeField]
	private bool _autoInitialize;

	private CharacterData _data;
	private Animator _animator;
	private SkinnedMeshRenderer _mesh;
	private NavMeshAgent _agent;

	private void Start()
	{
		_agent = GetComponent<NavMeshAgent>();

		if (_autoInitialize)
		{
			CharacterData data = GameDataManager.GetGameData().Roster.Soldiers[0].Data;
			SetData(data);
		}
	}

	public void SetData(CharacterData data)
	{
		_data = data;

		RefreshModel();
		RefreshAnimator();
	}

	private void RefreshModel()
	{
		int bodyIndex = (int)_data.Body;
		for (int i = 0; i < _bodyModels.Count; i++)
		{
			_bodyModels[i].SetActive(bodyIndex == i);
		}
		
		_animator = _bodyModels[bodyIndex].GetComponent<Animator>();
		_mesh = _bodyModels[bodyIndex].GetComponentInChildren<SkinnedMeshRenderer>();
		
		int colorIndex = (int)_data.Color;
		_mesh.material = _colorMaterials[bodyIndex].Materials[colorIndex];
	}

	private void RefreshAnimator()
	{
		_animator.SetInteger("Weapon", (int)_data.Weapon);
	}

	private void Update()
	{
		if (_agent != null)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			RaycastHit hit;
			if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 100))
			{
				_agent.destination = hit.point;
			}

			if (_animator != null)
			{
				if (_agent.velocity.sqrMagnitude >= (5 * 5))
				{
					_animator.SetInteger("Movement", 3);
				}
				else if (_agent.velocity.sqrMagnitude > 0.1)
				{
					_animator.SetInteger("Movement", 2);
				}
				else
				{
					_animator.SetInteger("Movement", 0);
				}
			}
		}
	}
}
