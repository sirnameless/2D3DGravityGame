# 2D3DGravityGame
A Unity example game using spaceships, a mix of 2D and 3D, and object-attracting gravity. Displays game object parenting concepts.

Examples included in this project:

##### A 3D object colliding with a 2D object
How can you achieve this? By using clever parenting! Make a 3D object the child of a 2D collider.

##### Gravity mimicking a spaceship landing on an asteroid large enough to assert its gravity on the ship
How can you do this without the ship constantly ramming itself into the asteroid? Parenting! Let the ship become a child of the asteroid when it lands. Use two separate colliders on the asteroid to achieve this as well as a gravity pull effect on the ship.

##### 3D text on a 2D object?
A TextMesh can be a child of a Sprite - no problem.