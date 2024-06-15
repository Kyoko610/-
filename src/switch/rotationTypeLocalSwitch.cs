﻿using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

//ゲームオブジェクトを順番にon/offするローカルスイッチ
//初期動作：0番目のオブジェクトon＆その他オブジェクトはoff状態になる。
[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
public class rotationTypeLocalSwitch : UdonSharpBehaviour{
	[Header("対象オブジェクト")]
	[SerializeField] private GameObject[] target;
	private int iActive=0;

	public void Start(){
		setActive();
	}

	public override void Interact(){
		iActive++;
		if(iActive>=target.Length){
			iActive=0;
		}
		setActive();
	}

	public void setActive(){
		for(int i=0;i<target.Length;i++){
			if(i==iActive){
				target[i].SetActive(true);
			}else{
				target[i].SetActive(false);
			}
		}
	}
}
