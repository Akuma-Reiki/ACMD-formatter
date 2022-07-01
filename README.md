# ult-hitbox-editor info

All fighter names are their internal names  
All move names are their internal names  
  
To find out the internal names, either look at the smash ultimate data viewer https://rubendal.github.io/ssbu/#/Character  
or ask around in the discord

# usage

First, you must select your fighter, and your move that you will be editing  
after that, hit 'Load attack' and you should see code pop up on the right side  
  
  
After that, it's on to the actual frame groups. To start, select the action group Attack/Set Flag, and the frame you want to start it on.  
If it's an aerial attack set the action to be WorkModule::on, and then press Start Frame Group and Add Current Action in that order  
(using the default work module option).  
After that, you can set the action to be macros::ATTACK, and put in the numbers for the first hitbox. When you're done putting them in  
press Add Current Action. Repeat that process for as many hitboxes as you want your character to have on that frame.  
You can also use ArticleModule::generate_article to spawn items / projectiles / whatever  
  
You can use the action group Wait and Frame start to make it wait a certain amount of frames before doing something else, or AttackModule::clear  
to clear all hitboxes currently active. Once you're done with the current frame group, press End Frame Group. You can make another  
to skip ahead to a certain frame, potentially to disable that flag you turned on from earlier with WorkModule::off, or you can press Finish  
to close off the code.  
  
  
You can either take the Code.rs file and use that in your own mods, or you can put the path to your plugin folder in the bottom right  
and press compile to have it automtically create an NRO file for you

# important to know  
if a number has a decimal place, keep it there  
all true or false items must be kept lowercase  
