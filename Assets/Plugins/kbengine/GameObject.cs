namespace KBEngine
{
  	using UnityEngine; 
	using System; 
	using System.Collections; 
	using System.Collections.Generic;
	
    public class GameObject : if_Entity_error_use______git_submodule_update_____kbengine_plugins_______open_this_file_and_I_will_tell_you 
    {
		public GameObject()
		{
		}

		public virtual void set_HP(object old)
		{
			object v = getDefinedPropterty("HP");
			// Dbg.DEBUG_MSG(className + "::set_HP: " + old + " => " + v); 
			Event.fireOut("set_HP", new object[]{this, v});
		}
		
		public virtual void set_MP(object old)
		{
			object v = getDefinedPropterty("MP");
			// Dbg.DEBUG_MSG(className + "::set_MP: " + old + " => " + v); 
			Event.fireOut("set_MP", new object[]{this, v});
		}
		
		public virtual void set_HP_Max(object old)
		{
			object v = getDefinedPropterty("HP_Max");
			// Dbg.DEBUG_MSG(className + "::set_HP_Max: " + old + " => " + v); 
			Event.fireOut("set_HP_Max", new object[]{this, v});
		}
		
		public virtual void set_MP_Max(object old)
		{
			object v = getDefinedPropterty("MP_Max");
			// Dbg.DEBUG_MSG(className + "::set_MP_Max: " + old + " => " + v); 
			Event.fireOut("set_MP_Max", new object[]{this, v});
		}
		
		public virtual void set_level(object old)
		{
			object v = getDefinedPropterty("level");
			// Dbg.DEBUG_MSG(className + "::set_level: " + old + " => " + v); 
			Event.fireOut("set_level", new object[]{this, v});
		}
		
		public virtual void set_name(object old)
		{
			object v = getDefinedPropterty("name");
			// Dbg.DEBUG_MSG(className + "::set_name: " + old + " => " + v); 
			Event.fireOut("set_name", new object[]{this, v});
		}
		
		public virtual void set_state(object old)
		{
			object v = getDefinedPropterty("state");
			// Dbg.DEBUG_MSG(className + "::set_state: " + old + " => " + v); 
			Event.fireOut("set_state", new object[]{this, v});
		}
		
		public virtual void set_subState(object old)
		{
			// Dbg.DEBUG_MSG(className + "::set_subState: " + getDefinedPropterty("subState")); 
		}
		
		public virtual void set_utype(object old)
		{
			// Dbg.DEBUG_MSG(className + "::set_utype: " + getDefinedPropterty("utype")); 
		}
		
		public virtual void set_uid(object old)
		{
			// Dbg.DEBUG_MSG(className + "::set_uid: " + getDefinedPropterty("uid")); 
		}
		
		public virtual void set_spaceUType(object old)
		{
			// Dbg.DEBUG_MSG(className + "::set_spaceUType: " + getDefinedPropterty("spaceUType")); 
		}
		
		public virtual void set_moveSpeed(object old)
		{
			object v = getDefinedPropterty("moveSpeed");
			// Dbg.DEBUG_MSG(className + "::set_moveSpeed: " + old + " => " + v); 
			Event.fireOut("set_moveSpeed", new object[]{this, v});
		}
		
		public virtual void set_modelScale(object old)
		{
			object v = getDefinedPropterty("modelScale");
			// Dbg.DEBUG_MSG(className + "::set_modelScale: " + old + " => " + v); 
			Event.fireOut("set_modelScale", new object[]{this, v});
		}
		
		public virtual void set_modelID(object old)
		{
			object v = getDefinedPropterty("modelID");
			// Dbg.DEBUG_MSG(className + "::set_modelID: " + old + " => " + v); 
			Event.fireOut("set_modelID", new object[]{this, v});
		}
		
		public virtual void set_forbids(object old)
		{
			// Dbg.DEBUG_MSG(className + "::set_forbids: " + getDefinedPropterty("forbids")); 
		}
		
		public virtual void recvDamage(Int32 attackerID, Int32 skillID, Int32 damageType, Int32 damage)
		{
			// Dbg.DEBUG_MSG(className + "::recvDamage: attackerID=" + attackerID + ", skillID=" + skillID + ", damageType=" + damageType + ", damage=" + damage);
			
			Entity entity = KBEngineApp.app.findEntity(attackerID);

			Event.fireOut("recvDamage", new object[]{this, entity, skillID, damageType, damage});
		}
		
		public virtual void onJump()
		{
			Dbg.DEBUG_MSG(className + "::onJump: " + id);
			Event.fireOut("otherAvatarOnJump", new object[]{this});
		}
		
		public virtual void onAddSkill(Int32 skillID)
		{
			Dbg.DEBUG_MSG(className + "::onAddSkill(" + skillID + ")"); 
			Event.fireOut("onAddSkill", new object[]{this});
			
			Skill skill = new Skill();
			skill.id = skillID;
			skill.name = skillID + " ";
			switch(skillID)
			{
				case 1:
					break;
				case 1000101:
					skill.canUseDistMax = 20f;
					break;
				case 2000101:
					skill.canUseDistMax = 20f;
					break;
				case 3000101:
					skill.canUseDistMax = 20f;
					break;
				case 4000101:
					skill.canUseDistMax = 20f;
					break;
				case 5000101:
					skill.canUseDistMax = 20f;
					break;
				case 6000101:
					skill.canUseDistMax = 20f;
					break;
				default:
					break;
			};

			SkillBox.inst.add(skill);
		}
		
		public virtual void onRemoveSkill(Int32 skillID)
		{
			Dbg.DEBUG_MSG(className + "::onRemoveSkill(" + skillID + ")"); 
			Event.fireOut("onRemoveSkill", new object[]{this});
			SkillBox.inst.remove(skillID);
		}
    }
    
} 
