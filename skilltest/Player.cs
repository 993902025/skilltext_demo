using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skilltest
{
    public class Player
    {
        public int mana = 10;
        public int gcd;
        public int skill_1_mana = 10;

        public enum player_state { stand, run, jump };

        
    }
    public class Skill:Player
    {
        bool skill_state = true;
        float skill_cd = 0;
        int damage_val = 100;

        public int skill_1( ref int dmg_val)
        {
            if (skill_state == true)
            {
                if (mana > 15)
                {
                    if (skill_cd <= 0)
                    {
                        dmg_val = damage_val;
                        skill_cd = 10;
                        return 0;
                    }
                    return -1;//skill cd false;技能CD中
                }
                return -2;//not enough mana for skill;魔法不足
            }
            return -3;//当前状态无法施法
        }
    }
}
