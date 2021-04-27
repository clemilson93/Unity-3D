using UnityEngine;
using System.Collections;

public class Stage1MissionsScript : MonoBehaviour {

	public CurrentMission currentMission;

	public void startMission1(){
		currentMission = new Mission1();
	}

	public class Mission1 : CurrentMission{

		public Mission1(){
			setDescription( "Find the hidden items and\n defeat all the enemies." );
			setItemsToCollect( 7 );
			setEnemiesToDefeat( 20 );
			setMissionCompleted(false);

		}
	}

	public abstract class CurrentMission{
		public string description;
		public int itemsToCollect;
		public int enemiesToDefeat;
		public bool missionCompleted;
		
		public int getItemsToCollect(){
			return itemsToCollect;
		}
		public int getEnemiesToDefeat(){
			return enemiesToDefeat;
		}
		public string getDescription(){
			return description;
		}
		public bool isMissionCompleted(){
			return missionCompleted;
		}
		
		public void setItemsToCollect(int value){
			this.itemsToCollect = value;
		}
		public void setMissionCompleted(bool value){
			this.missionCompleted = value;
		}
		public void setEnemiesToDefeat(int value){
			this.enemiesToDefeat = value;
		}
		public void setDescription(string value){
			this.description = value;
		}
		public bool checkMission(){
			bool missionCompleted = false;
			if( enemiesToDefeat == 0 && itemsToCollect == 0){
				missionCompleted = true;
			}
			
			return missionCompleted;
		}
	}

	public void itemsCollected(){
		if( currentMission.itemsToCollect > 0){
			currentMission.itemsToCollect--;
		}
	}
	public void enemyDefeated(){
		if( currentMission.enemiesToDefeat > 0){
			currentMission.enemiesToDefeat--;
		}

	}
}
