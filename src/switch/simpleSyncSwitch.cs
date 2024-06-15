using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

//1つのゲームオブジェクトをon/offする同期変数型スイッチ
//デフォルトのon/off状態はoffとなる(サンプルのため)

[UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
public class simpleSyncSwitch : UdonSharpBehaviour{
	[Header("対象オブジェクト")]
	[SerializeField] private GameObject target;
	private bool bActive=false;

	public void Start(){
		UpdateSame();
	}

	public override void Interact(){
		if (!Networking.LocalPlayer.IsOwner(this.gameObject)) {
			Networking.SetOwner(Networking.LocalPlayer, this.gameObject);
			if (!Networking.LocalPlayer.IsOwner(this.gameObject)){
				return;
			}
		}

		bActive=!bActive;
		RequestSerialization();
		UpdateSame();
	}

	public override void OnDeserialization(){
		UpdateSame();
	}

	void UpdateSame(){
		target.SetActive(bActive);
	}
}