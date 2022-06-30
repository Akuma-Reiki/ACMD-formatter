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
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Fighter = fighter_list.Text;
            WriteCode(MoveName, Fighter);
        }

        public static async Task WriteCode(string MoveName, string Fighter)
        {
            string[] lines =
            {
                //the use commands
            "use smash::app::lua_bind::*;", "use smash::app::sv_animcmd;", "use smash::lua2cpp::L2CAgentBase;", "use smash::phx::Hash40;", "use smash::lib::lua_const::*;", "use smashline::*;", "use smash_script::*;", ""
            // character and move selection
            ,"#[acmd_script( agent = \"" + Fighter + "\", script = \"game_" + MoveName + "\", category = ACMD_GAME )]" , ""
            ,"unsafe fn " + Fighter +"_" + MoveName + "_smash_script(fighter: &mut L2CAgentBase) {"







            ,""
            ,"}"
            ,""
            ,"#[installer]"
            ,"pub fn install() {"
            , "smashline::install_acmd_scripts!("
            , Fighter +"_" + MoveName + "_smash_script"
            , ");"
            , "}"
        };

            await File.WriteAllLinesAsync("Code.txt", lines);
        }

    }
}
