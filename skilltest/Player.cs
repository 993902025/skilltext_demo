﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skilltest
{
    public class Player
    {
        public static float mana = 10.00f;
        public float gcd;
        public float skill_1_mana = 10.00f;
        const float per_milsec_remana = 0.0020f;
        public enum player_state { stand, run, jump };

        public double RestoreMana(double ts)
        {
            DateTime this_dt = DateTime.Now;

            
                if (Re_Event != null)
                {
                    Re_Event(mana);
                    if (mana < 100)
                    {
                    
                    
                        mana += (float)ts * per_milsec_remana;
                        if (mana >= 100)
                        {
                            mana = 100;
                            return mana;
                        }
                        return mana;
                    }
                }
                return -1;
            
        }
        public event Action<float> Re_Event;

    }


    public class Skill : Player
    {
        bool skill_state = true;
        static float skill_cd = 2;
        int damage_val = 100;

        public int skill_1(ref string skill_str)
        {
            if (skill_state == true)
            {
                if (mana > 15)
                {
                    if (skill_cd <= 0)
                    {
                        //dmg_val = damage_val;
                        skill_cd = 2;
                        mana -= skill_1_mana;
                        Re_Event(mana);
                        skill_str = damage_val.ToString() + "\r\n";
                        return 0;
                    }
                    skill_str = string.Format("[{0:HH:MM:ss.fff}]: ", DateTime.Now) + "技能CD中！" + "\r\n";
                    return -1;//skill cd false;技能CD中
                }
                skill_str = string.Format("[{0:HH:MM:ss.fff}]: ", DateTime.Now) + "魔法不足！" + "\r\n";
                return -2;//not enough mana for skill;魔法不足
            }
            skill_str = string.Format("[{0:HH:MM:ss.fff}]: ", DateTime.Now) + "当前状态无法施法！" + "\r\n";
            return -3;//当前状态无法施法
        }

        public float RestoreCD(float dt_to_cd)
        {
            //if (Re_Event_CD != null)
            //{
             //   Re_Event_CD(skill_cd);
                if (skill_cd > 0)
                {
                    skill_cd -= dt_to_cd;
                    if (skill_cd <= 0)
                    {
                        skill_cd = 0;
                        return skill_cd;
                    }
                    return skill_cd;
                }
                return -13;
            // }
            //
        }
        public event Action<float> Re_Event;


    }
}
