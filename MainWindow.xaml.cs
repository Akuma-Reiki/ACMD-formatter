using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace Hitbox_Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string MoveName { get; set; }
        public string Fighter { get; set; }
        public string FrameNumber { get; set; }
        public string ActionCheck { get; set; }
        public string FrameAction { get; set; }
        public int indexNumber { get; set; }
        public string aPart { get; set; }
        public string aBone { get; set; }
        public string aDamage { get; set; }
        public string aAngle { get; set; }
        public string aKBG { get; set; }
        public string aFKB { get; set; }
        public string aBKB { get; set; }
        public string aSize { get; set; }
        public string aX { get; set; }
        public string aY { get; set; }
        public string aZ { get; set; }
        public string aX2 { get; set; }
        public string aY2 { get; set; }
        public string aZ2 { get; set; }
        public string aHitlag { get; set; }
        public string aSDI { get; set; }
        public string aClang_Rebound { get; set; }
        public string aFacingRestrict { get; set; }
        public string aSetWeight { get; set; }
        public string aShieldDamage { get; set; }
        public string aTrip { get; set; }
        public string aRehit { get; set; }
        public string aReflectable { get; set; }
        public string aAbsorable { get; set; }
        public string aFlinchless { get; set; }
        public string aDisableHitLag { get; set; }
        public string aDirect_Hitbox { get; set; }
        public string aGround_or_Air { get; set; }
        public string aHitbits { get; set; }
        public string aCollisionPart { get; set; }
        public string aFriendlyFire { get; set; }
        public string aEffect { get; set; }
        public string aSFXLevel { get; set; }
        public string aSFXType { get; set; }
        public string aType { get; set; }
        public string WorkModule { get; set; }
        public string pathToCompile { get; set; }
        public string aArticle { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            //initializes variables
            WorkModule = "FIGHTER_STATUS_ATTACK_AIR_FLAG_ENABLE_LANDING";
            aPart = "0";
            aBone = "top";
            aDamage = "0.0";
            aAngle = "0";
            aKBG = "0";
            aFKB = "0";
            aBKB = "0";
            aSize = "0.0";
            aX = "0.0";
            aY = "0.0";
            aZ = "0.0";
            aX2 = "None";
            aY2 = "None";
            aZ2 = "None";
            aHitlag = "1.0";
            aSDI = "1.0";
            aShieldDamage = "0";
            aEffect = "collision_attr_normal";
            aTrip = "0.0";
            aRehit = "0";
            aHitbits = "COLLISION_CATEGORY_MASK_ALL";
            aCollisionPart = "COLLISION_PART_MASK_ALL";
            aArticle = "FIGHTER_MARIO_GENERATE_ARTICLE_FIREBALL";
            removeOldCode();
            removeOldMoves();
            boc.Text = File.ReadAllText("mod.rs");
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Fighter = fighter_list.Text;
            ActionCheck = actionCheck.Text;
            FrameAction = frame_action.Text;
            aGround_or_Air = ground_or_air.Text;
            aFlinchless = flinchless.Text;
            aDisableHitLag = disableHitlag.Text;
            aReflectable = reflectable.Text;
            aAbsorable = absorable.Text;
            aFriendlyFire = friendlyFire.Text;
            aSetWeight = setWeight.Text;
            aDirect_Hitbox = directHitbox.Text;
            aSFXLevel = sfxLevel.Text;
            aFacingRestrict = facingRestrictions.Text;
            aClang_Rebound = clangRebound.Text;
            aSFXType = "COLLISION_SOUND_ATTR_" + sfxType.Text;
            aType = "ATTACK_REGION" + type.Text;
            AddLine(FrameAction, indexNumber,  aPart,  aBone,  aDamage,  aAngle,  aKBG,  aFKB,  aBKB,  aSize,  aX,  aY,  aZ,  aX2,  aY2,  aZ2,  aHitlag,  aSDI,  aClang_Rebound,  aFacingRestrict,  aSetWeight,  aShieldDamage,  aTrip,  aRehit,  aReflectable,  aAbsorable,  aFlinchless,  aDisableHitLag,  aDirect_Hitbox,  aGround_or_Air,  aHitbits,  aCollisionPart,  aFriendlyFire,  aEffect,  aSFXLevel,  aSFXType,  aType, WorkModule, aArticle, Fighter);
            boc.Text = File.ReadAllText("mod.rs");
            
        }
        public static async Task removeOldMoves()
        {

            string[] lines =
        {
            ""
        };

            await File.WriteAllLinesAsync("scripts.txt", lines);
        }
        public static async Task addCurrentMove(string MoveName, string Fighter)
        {

            string[] lines =
        {
            Fighter + "_" + MoveName.ToLower() + "_smash_script"
        };

            await File.AppendAllLinesAsync("scripts.txt", lines);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Fighter = fighter_list.Text;
            ActionCheck = actionCheck.Text;
            FrameAction = frame_action.Text;
            StartCode(MoveName, Fighter);
            addCurrentMove(MoveName, Fighter);
            
            boc.Text = File.ReadAllText("mod.rs");
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ActionCheck = actionCheck.Text;
            startAction(ActionCheck, FrameNumber, Fighter);
            
            boc.Text = File.ReadAllText("mod.rs");
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            indexNumber = 0;
            endAction(Fighter);
            
            boc.Text = File.ReadAllText("mod.rs");
        }
        public static async Task removeOldCode()
        {

            string[] lines =
        {
            "use smash::app::lua_bind::*;", "use smash::app::sv_animcmd;", "use smash::lua2cpp::L2CAgentBase;", "use smash::phx::Hash40;", "use smash::lib::lua_const::*;", "use smashline::*;", "use smash_script::*;", ""
        };
            
            await File.WriteAllLinesAsync("mod.rs", lines);
        }
        public static async Task StartCode(string MoveName, string Fighter)
        {
           
                string[] lines =
            {
             // character and move selection
            "#[acmd_script( agent = \"" + Fighter + "\", script = \"game_" + MoveName.ToLower() + "\", category = ACMD_GAME )]" , ""
            ,"unsafe fn " + Fighter +"_" + MoveName.ToLower() + "_smash_script(fighter: &mut L2CAgentBase) {"
        };
            
            await File.AppendAllLinesAsync("mod.rs", lines);

            
        }
        public static async Task startAction(string ActionCheck, string FrameNumber, string Fighter)
        {
            if (ActionCheck == "Attack/Set Flag")
            {
            string[] lines =
            {
            "sv_animcmd::frame(fighter.lua_state_agent, " + FrameNumber + ".0);"
            , "if macros::is_excute(fighter) {"
            };
                
                await File.AppendAllLinesAsync("mod.rs", lines);
            }
            if (ActionCheck == "Wait")
            {
                string[] lines = 
                {
                "sv_animcmd::frame(fighter.lua_state_agent, " + FrameNumber + ".0);" 
                };
            await File.AppendAllLinesAsync("mod.rs", lines);
            }
        }

        public static async Task endAction(string Fighter)
        {
            string[] lines =
            {
            ""
            ,"}"
            };
            
            await File.AppendAllLinesAsync("mod.rs", lines);
        }

        public static async Task AddLine(string FrameAction, int indexNumber, string aPart, string aBone, string aDamage, string aAngle, string aKBG, string aFKB, string aBKB, string aSize, string aX, string aY, string aZ, string aX2, string aY2, string aZ2, string aHitlag, string aSDI, string aClang_Rebound, string aFacingRestrict, string aSetWeight, string aShieldDamage, string aTrip, string aRehit, string aReflectable, string aAbsorable, string aFlinchless, string aDisableHitLag, string aDirect_Hitbox, string aGround_or_Air, string aHitbits, string aCollisionPart, string aFriendlyFire, string aEffect, string aSFXLevel, string aSFXType, string aType, string WorkModule, string aArticle, string Fighter)
        {
            if (aFacingRestrict == "The front")
            {
                aFacingRestrict = "ATTACK_LR_CHECK_F";
            }
            else if (aFacingRestrict == "The back")
            {
                aFacingRestrict = "ATTACK_LR_CHECK_B";
            }
            if (aFacingRestrict == "The side they're on")
            {
                aFacingRestrict = "ATTACK_LR_CHECK_POS";
            }

            if (aClang_Rebound == "Can clang")
            {
                aClang_Rebound = "ATTACK_SETOFF_KIND_ON";
            }
            else if (aClang_Rebound == "Can't clang")
            {
                aClang_Rebound = "ATTACK_SETOFF_KIND_OFF";
            }
            else if (aClang_Rebound == "Can clang, no bounce")
            {
                aClang_Rebound = "ATTACK_SETOFF_KIND_THRU";
            }
            else if (aClang_Rebound == "No stop")
            {
                aClang_Rebound = "ATTACK_SETOFF_KIND_NO_STOP";
            }


            if (aGround_or_Air == "Both")
            {
                aGround_or_Air = "COLLISION_SITUATION_MASK_GA";
            }
            else if (aGround_or_Air == "Ground")
            {
                aGround_or_Air = "COLLISION_SITUATION_MASK_G";
            }
            else if (aGround_or_Air == "Air")
            {
                aGround_or_Air = "COLLISION_SITUATION_MASK_A";
            }

            if(aSFXLevel == "Quiet")
            {
                aSFXLevel = "ATTACK_SOUND_LEVEL_S";
            }
            else if (aSFXLevel == "Medium")
            {
                aSFXLevel = "ATTACK_SOUND_LEVEL_M";
            }
            else if (aSFXLevel == "Loud")
            {
                aSFXLevel = "ATTACK_SOUND_LEVEL_L";
            }
            if (FrameAction == "Add hitbox")
            {
                FrameAction = "macros::ATTACK";
                indexNumber = indexNumber + 1;
                string[] lines =
              {
            FrameAction + "(fighter, " + indexNumber.ToString() + ", " + aPart + ", Hash40::new(\"" + aBone + "\"), " + aDamage + ", " + aAngle + ", " + aKBG + ", " + aFKB + ", " + aBKB + ", " +
            aSize + ", " + aX + ", " + aY + ", " + aZ + ", " + aX2 + ", " + aY2 + ", " + aZ2 + ", " + aHitlag + ", " + aSDI + ", *" + aClang_Rebound + ", *" + aFacingRestrict + ", " + aSetWeight + ", " +
            aShieldDamage + ", " +aTrip + ", " + aRehit + ", " + aReflectable + ", " + aAbsorable + ", " + aFlinchless + ", " + aDisableHitLag + ", " + aDirect_Hitbox + ", *" + aGround_or_Air + ", *" +
            aHitbits + ", *" + aCollisionPart + ", " + aFriendlyFire + ", " + "Hash40::new(\"" + aEffect + "\"), *" + aSFXLevel + ", *" + aSFXType + ", *" + aType + ");"

            };
                
                await File.AppendAllLinesAsync("mod.rs", lines);
            }
            else if (FrameAction == "Clear active hitboxes")
            {
                FrameAction = "AttackModule::clear_all";
                string[] lines =
                {
                    "AttackModule::clear_all(fighter.module_accessor);"
                };
                await File.AppendAllLinesAsync("mod.rs", lines);
            }
            else if (FrameAction == "Turn WorkModule on")
            {
                FrameAction = "WorkModule::on_flag";
                string[] lines =
                 {
                    "WorkModule::on_flag(fighter.module_accessor, *" + WorkModule + ");"
                 };
                
                await File.AppendAllLinesAsync("mod.rs", lines);
            }
            else if (FrameAction == "Turn WorkModule off") 
            {
                FrameAction = "WorkModule::off_flag";
                string[] lines =
                {
                    "WorkModule::off_flag(fighter.module_accessor, *" + WorkModule + ");"
                };
                
                await File.AppendAllLinesAsync("mod.rs", lines);
            }
            else if (FrameAction == "Generate article")
            {
                FrameAction = "ArticleModule::generate_article";
                string[] lines =
                {
                    "ArticleModule::generate_article(fighter.module_accessor, *" + aArticle + ", false, -1);"
                };
                
                await File.AppendAllLinesAsync("mod.rs", lines);
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FinishScript(Fighter, MoveName);
            
            boc.Text = File.ReadAllText("mod.rs");
        }

        public static async Task FinishScript(string Fighter, string MoveName)
        {
        string scripts = await File.ReadAllTextAsync("scripts.txt");
            string[] lines =
            {
            "}", "pub fn install () {", "smashline::install_acmd_scripts{", scripts, "};","}"
            };
            
            await File.AppendAllLinesAsync("mod.rs", lines);

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            
            var startInfo = new System.Diagnostics.ProcessStartInfo
            {
                WorkingDirectory = @pathToCompile,
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal,
                FileName = "cargo",
                RedirectStandardInput = true,
                UseShellExecute = false
            };
            startInfo.Arguments = "skyline build --release";
            System.Diagnostics.Process.Start(startInfo);
        }
    }
}

