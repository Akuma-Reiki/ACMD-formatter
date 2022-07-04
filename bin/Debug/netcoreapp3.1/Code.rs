use smash::app::lua_bind::*;
use smash::app::sv_animcmd;
use smash::lua2cpp::L2CAgentBase;
use smash::phx::Hash40;
use smash::lib::lua_const::*;
use smashline::*;
use smash_script::*;

#[acmd_script( agent = "bayonetta", script = "game_attackairlw", category = ACMD_GAME )]

unsafe fn bayonetta_attackairlw_smash_script(fighter: &mut L2CAgentBase) {
sv_animcmd::frame(fighter.lua_state_agent, 7.0);
if macros::is_excute(fighter) {
ArticleModule::generate_article(fighter.module_accessor, *FIGHTER_MARIO_GENERATE_ARTICLE_FIREBALL, false, -1);

}
}
pub fn install () {
smashline::install_acmd_scripts{

bayonetta_attackairlw_smash_script

};
}
