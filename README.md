# ult-hitbox-editor info

All fighter names are their internal names  
All move names are their internal names  
  
# Usage

THIS GUIDE ASSUMES YOU HAVE READ AND FOLLOWED THIS GUIDE: https://docs.google.com/document/d/1y_JX5LNsQ8jUBfrghRkL8VkvfMWUIXSrrscM5qj7s6U/edit
THIS TOOL IS ALSO ONLY MEANT TO SPEED UP THE CODE WRITING PROCESS, IT IS NOT PERFECT, IT CANNOT DO EVERYTHING  
  
What this tool does, is generate code for you based on what you put into it, it still requires a little bit of coding knowledge, albeit not much  
  
To use it, you must first make sure you have a .NET 3.1 framework installed, on top of everything else in the guide linked above. Once you are in the app, you will see the code you are writing on the right side, with some code already in it.
To edit a move, you must first pick a character or article from the drop down list, then input the name for the animation you want to apply the hitbox to, and press the Load Attack button. You will see code fill up on the right very frequently this is ok.  
  
There are two "action groups" they're split like this due to how the code works, typically you don't want to use wait outside of pre-existing frame groups, but if you know what you're doing, its up to you.
They use the Frame Start box for you to say how long to wait. The actual action group you want to look at, is attack / set flag. Choose that action group, and then the action you want it to do for you, and the frame you want it to happen on.
You can then press Start Frame Group, and start editing the hitbox(es) you want to add or clear to that frame, as well as turning on and off workmodules, and generating articles. Once you are done with the action you want to add, you press Add Current Action, and repeat.
To add waits, you need to select them at the top under the action groups, choose the frames you want it to wait under frame start. Finally, pressing start frame group" again to add that wait. (You do not need to press end frame group for the waits you add, only the attacks / set flags action groups you make)
After you are done adding everything for that frame press end frame group. You can either make a new frame group (must be a higher frame than last one) where you can clear the hold hitboxes so the're not still active or leave them active and add on top of them.
Or you can press finish, and take the mod.rs in the app's folder and use it in your own skyline projects. If you don't know how to use it, please reread the guide linked at the start of this tutorial  
  
  
# important to know  
if a number has a decimal place, keep it there
If you don't know what changing it will do, probably best to leave it alone
