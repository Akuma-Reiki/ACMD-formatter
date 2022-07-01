use smash::app::lua_bind::*;
use smash::app::sv_animcmd;
use smash::lua2cpp::L2CAgentBase;
use smash::phx::Hash40;
use smash::lib::lua_const::*;
use smashline::*;
use smash_script::*;

#[acmd_script( agent = "mario", script = "game_attackairlw", category = ACMD_GAME )]

unsafe fn mario_attackairlw_smash_script(fighter: &mut L2CAgentBase) {
sv_animcmd::frame(fighter.lua_state_agent, 5.0);
if macros::is_execute(fighter) {
WorkModule::on_flag(fighter.module_accessor, *FIGHTER_STATUS_ATTACK_AIR_FLAG_ENABLE_LANDING);
macros::ATTACK(fighter, 1, 0, Hash40::new("top"), 800.0, 180, 870, 0, 70, 800.0, 0.0, 0.0, 0.0, None, None, None, 1.0, 1.0, *ATTACK_SETOFF_KIND_ON, *ATTACK_LR_CHECK_POS, false, 0, 0.0, 0, false, false, false, false, true, *COLLISION_SITUATION_MASK_GA, *COLLISION_CATEGORY_MASK_ALL, *COLLISION_PART_MASK_ALL, false, Hash40::new("collision_attr_rush"), *ATTACK_SOUND_LEVEL_S, *COLLISION_SOUND_ATTR_KICK, *ATTACK_REGION_KICK);

}
sv_animcmd::frame(fighter.lua_state_agent, 6.0);
if macros::is_execute(fighter) {
    WorkModule::off_flag(fighter.module_accessor, *FIGHTER_STATUS_ATTACK_AIR_FLAG_ENABLE_LANDING);
}
}
#[installer]
pub fn install() {
smashline::install_acmd_scripts!(
mario_attackairlw_smash_script
);
}
