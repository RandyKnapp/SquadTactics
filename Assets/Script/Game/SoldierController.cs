using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	private CharacterData _data;
	private Animator _animator;
	private SkinnedMeshRenderer _mesh;

	public void SetData(CharacterData data)
	{
		_data = data;

		RefreshModel();
		RefreshAnimator();
	}

	private void RefreshModel()
	{
		int bodyIndex = (int) _data.Body;
		for (int i = 0; i < _bodyModels.Count; i++)
		{
			_bodyModels[i].SetActive(bodyIndex == i);
		}
		
		_animator = _bodyModels[bodyIndex].GetComponent<Animator>();
		_mesh = _bodyModels[bodyIndex].GetComponentInChildren<SkinnedMeshRenderer>();
		
		int colorIndex = (int) _data.Color;
		_mesh.material = _colorMaterials[bodyIndex].Materials[colorIndex];
	}

	private void RefreshAnimator()
	{
		_animator.SetInteger("Weapon", (int)_data.Weapon);
	}
}
