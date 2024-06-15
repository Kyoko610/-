﻿using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

//ゲームオブジェクトを順番にon/offするローカルスイッチ

[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
public class rotationTypeLocalSwitch : UdonSharpBehaviour{
	[Header("対象オブジェクト")]
	[SerializeField] private GameObject[] target;
	private int iActive=0;

	public override void Interact(){
		iActive++;
		if(iActive>=target.Length){
			iActive=0;
		}

		for(int i=0;i<target.Length;i++){
			if(i==iActive){
				target[i].SetActive(true);
			}else{
				target[i].SetActive(false);
			}
		}
	}
}
