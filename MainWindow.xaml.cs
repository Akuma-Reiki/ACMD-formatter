using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO;
using System.Windows.Shapes;

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
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Fighter = fighter_list.Text;
            ActionCheck = actionCheck.Text;
            FrameAction = frame_action.Text;
            MessageBox.Show("Added");
            AddLine(FrameAction, indexNumber,  aPart,  aBone,  aDamage,  aAngle,  aKBG,  aFKB,  aBKB,  aSize,  aX,  aY,  aZ,  aX2,  aY2,  aZ2,  aHitlag,  aSDI,  aClang_Rebound,  aFacingRestrict,  aSetWeight,  aShieldDamage,  aTrip,  aRehit,  aReflectable,  aAbsorable,  aFlinchless,  aDisableHitLag,  aDirect_Hitbox,  aGround_or_Air,  aHitbits,  aCollisionPart,  aFriendlyFire,  aEffect,  aSFXLevel,  aSFXType,  aType);
            indexNumber++;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Fighter = fighter_list.Text;
            ActionCheck = actionCheck.Text;
            FrameAction = frame_action.Text;
            MessageBox.Show("Started");
            StartCode(MoveName, Fighter, ActionCheck, FrameNumber, FrameAction);
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Started");
            ActionCheck = actionCheck.Text;
            startAction(ActionCheck, FrameNumber);      
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ended");
            indexNumber = 0;
            endAction();
        }

        public static async Task StartCode(string MoveName, string Fighter, string ActionCheck, string FrameNumber, string FrameAction)
        {
           
                string[] lines =
            {
                //the use commands
            "use smash::app::lua_bind::*;", "use smash::app::sv_animcmd;", "use smash::lua2cpp::L2CAgentBase;", "use smash::phx::Hash40;", "use smash::lib::lua_const::*;", "use smashline::*;", "use smash_script::*;", ""
            // character and move selection
            ,"#[acmd_script( agent = \"" + Fighter + "\", script = \"game_" + MoveName + "\", category = ACMD_GAME )]" , ""
            ,"unsafe fn " + Fighter +"_" + MoveName + "_smash_script(fighter: &mut L2CAgentBase) {"
        };

            await File.WriteAllLinesAsync("Code.txt", lines);
        }

        public static async Task startAction(string ActionCheck, string FrameNumber)
        {
            if (ActionCheck == "Attack/Set Flag")
            {
            string[] lines =
            {
            "sv_animcmd::frame(fighter.lua_state_agent, " + FrameNumber + ".0);" , ""
            , "if macros::is_execute(fighter) {"
            };
            await File.AppendAllLinesAsync("Code.txt", lines);
            }
            if (ActionCheck == "Wait")
            {
                string[] lines = 
                {
                "sv_animcmd::frame(fighter.lua_state_agent, " + FrameNumber + ".0);" 
                };
            await File.AppendAllLinesAsync("Code.txt", lines);
            }
        }

        public static async Task endAction()
        {
            string[] lines =
            {
            ""
            ,"}"
            };
            await File.AppendAllLinesAsync("Code.txt", lines);
        }

        public static async Task AddLine(string FrameAction, int indexNumber, string aPart, string aBone, string aDamage, string aAngle, string aKBG, string aFKB, string aBKB, string aSize, string aX, string aY, string aZ, string aX2, string aY2, string aZ2, string aHitlag, string aSDI, string aClang_Rebound, string aFacingRestrict, string aSetWeight, string aShieldDamage, string aTrip, string aRehit, string aReflectable, string aAbsorable, string aFlinchless, string aDisableHitLag, string aDirect_Hitbox, string aGround_or_Air, string aHitbits, string aCollisionPart, string aFriendlyFire, string aEffect, string aSFXLevel, string aSFXType, string aType)
        {
            string[] lines =
            {
            FrameAction + "(fighter, " + indexNumber.ToString() + ", " + aPart + ", Hash40::new(\"" + aBone + "), " + aDamage + ", " + aAngle + ", " + aKBG + ", " + aFKB + ", " + aBKB + ", " +
            aSize + ", " + aX + ", " + aY + ", " + aZ + ", " + aX2 + ", " + aY2 + ", " + aZ2 + ", " + aHitlag + ", " + aSDI + ", *" + aClang_Rebound + ", *" + aFacingRestrict + ", " + aSetWeight + ", " +
            aShieldDamage + ", " +aTrip + ", " + aRehit + ", " + aReflectable + ", " + aAbsorable + ", " + aFlinchless + ", " + aDisableHitLag + ", " + aDirect_Hitbox + ", *" + aGround_or_Air + ", *" +
            aHitbits + ", *" + aCollisionPart + ", " + aFriendlyFire + ", " + "Hash40::new(\"" + aEffect + "\", *" + aSFXLevel + ", *" + aSFXType + ", *" + aType
              
            };
            await File.AppendAllLinesAsync("Code.txt", lines);
        }
        public static async Task AddWait(string FrameNumber)
        {
            string[] lines =
            {
                
            };
            await File.AppendAllLinesAsync("Code.txt", lines);
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Finished");
            FinishScript(Fighter, MoveName);
        }

        public static async Task FinishScript(string Fighter, string MoveName)
        {
                string[] lines =
                {
            //installer code
            ""
            ,"#[installer]"
            ,"pub fn install() {"
            , "smashline::install_acmd_scripts!("
            , Fighter + "_" + MoveName + "_smash_script"
            , ");"
            , "}"
            };
            await File.AppendAllLinesAsync("Code.txt", lines);
        }

    }
}
