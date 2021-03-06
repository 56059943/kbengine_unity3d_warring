using UnityEngine;
using KBEngine;
using System.Collections;
using System;
using System.Xml;
using System.Collections.Generic;

public class TargetManger
{
	public static TargetManger inst = null;
	public static SceneEntityObject target = null;
	public static bool isStartedAutoAttack = false;
	
	public TargetManger()
	{
		TargetManger.inst = this;
	}
	
	public static void setTarget(SceneEntityObject seo)
	{
		Common.DEBUG_MSG("TargetManger::setTarget: current=" + seo.kbentity.id);
		
		if(target == seo)
		{
			startAutoAttack();
			return;
		}
			
		target = seo;
		onChangeTarget();
	}
	
	public static void onChangeTarget()
	{
		if(game_ui_autopos.target_bar != null)
		{
			game_ui_autopos.showTargetBar(target);
		}
	}

	public static void startAutoAttack()
	{
		if(isStartedAutoAttack == false)
			loader.inst.InvokeRepeating("autoAttackProxy", 0, 2);
		
		isStartedAutoAttack = true;
	}
	
	public static void cancelAutoAttack()
	{
		loader.inst.CancelInvoke("autoAttackProxy"); 
		isStartedAutoAttack = false;
	}
	
	public static void autoAttack()
	{
		if(target == null || target.kbentity == null)
			return;
		
		KBEngine.Entity player = KBEngineApp.app.player();
		if(player == null || player == target.kbentity)
			return;
			
		float dist = Vector3.Distance(new Vector3(target.position.x, 0f, target.position.z), 
					new Vector3(player.position.x, 0f, player.position.z));
		
		if(dist >= 30.0f)
		{
			cancelAutoAttack();
			target = null;
			CameraTargeting.inst.setTarget(null);
			return;
		}
		
		object combatv = target.kbentity.getDefinedPropterty("HP_Max");

		// 可战斗entity， 我们判断它当前可被攻击标记是否开放， 开放则攻击
		if(combatv != null)
		{
			/*
			SceneEntityObject playerseo = ((SceneEntityObject)player.renderObj);
			Vector3 dir = playerseo.position - target.position;
			dir.y = 0f;
			dir.Normalize();
			
			if(RPG_Controller.instance != null)
				RPG_Controller.instance.transform.Rotate(dir);
			*/
			((KBEngine.Avatar)player).useTargetSkill(1, target.kbentity.id);
		}
		else // 否则只是跑到其跟前
		{
			
		}
	}
}

