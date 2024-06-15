﻿using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

//1つのゲームオブジェクトをon/offするローカルスイッチ
//デフォルトのon/off状態は対象ブジェクトのデフォルト状態と同じになる。

[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
public class simpleIsLocalSwitch : UdonSharpBehaviour{
	[Header("対象オブジェクト")]
	[SerializeField] private GameObject target;
	private bool bActive;

	public void Start(){
		bActive=target.activeSelf;
	}

	public override void Interact(){
		bActive=!bActive;
		target.SetActive(bActive);
	}
}
