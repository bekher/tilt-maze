## Tilt Maze

Name: Greg Bekher
Assignment Name: Programming Assignment 1, Part 1 (Tilt Maze)

A. Required Elements
  - (Part 2):
  - Walls generated automatically on an aprox. 10x10 grid with an offset (my for loop iterates through 9 but only for generation, it is still a 10x10 grid)
  - 6 pickups placed in between walls, they rotate and are destroyed on hit. They will never overlap and will not be placed in the center or top right
  - 2 captured pickups required to win
  - Text added per spec, including lose text
  - Particle system always emits upward

  - (Part 1):
  - User arrow keys or WASD to tilt the board
  - Maneuver the ball to the green circle with the particle generator to win
  - Hit Q or ESC to quit
  - Hit R to restart
  - I allow a maximum tilt of about 22 degrees


B. Additional elements
  - (Part 2): None
  - (Part 1): 
  - I added wood grain textures to the platform and the walls. See `D. External resources` for my sources

  - I added a bump sound whenever the ball collides with a wall, I figured out how to do this through the Unity audio docs
    * I created the bump sound myself by knocking against my desk and recording it with my phone

C. Known Issues
  - None

D. External resources
  - Unity documentation 
  - MSDN documentation for C#
  - ( Part 2)
  - Some help with rotation from this forum post (wall.cs): http://answers.unity3d.com/questions/1093355/rotate-object-smoothly-over-time-when-key-pressed.html
  - Getting the bounds size (tilt.cs): http://answers.unity3d.com/questions/24012/find-size-of-gameobject.html
  - ( Part 1)
  - I used two wood textures from the following sources:
    * http://www.photoshopbuzz.com/wp-content/uploads/2013/06/woodtexture7.jpg
    * http://www.designbolts.com/wp-content/uploads/2013/02/Free-Seamless-Wood-Textures-Patterns-For-3D-Mapping-2.jpg
