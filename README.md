                                                               "ONE-SHOT"  
Inspired by Angry birds, a different version of the same idea.
Where player can throw a rock towards the birds sitting over a setup to destroy them both.
Player has only one shot in any given level, but there were no "game-win" or "lose" conditions.
Player could just press the space-bar and move through the levels and take that one shot.

Only thing which was missing to make/call it a complete game was "Game Loop", So here's what I have done.

-There are 3 levels, which is expandable without any coding.
-Player will have a 15 sec timer starting as the level starts.
-Player can select a normal rock or a fireball to shoot towards the setup.
-Now player has to take that one shot and make those birds fall off the ground under those 10 sec to qualify for next level.
-And if player looses in level 2 or 3 or n, then he has to start all over again, because C'mon! there's only "One Shot".
.
Used spring-joint component
single responsibility principle as code architecture.
.


POWER-UPS
 1) When the countdown timer reaches 3 seconds or less, Player will get a 10 seconds increase power card.
 2) If player fails to take a good shot over the setup and if countdown timer reaches 8 seconds or below, player will get a power card where he will get another shot  to shoot at the setup with 3 seconds increase in timer as well.
->Only one Power-up card will be available at any given level according to the situation in the game.
.
https://youtu.be/kd0havIwQj8

-INFINITE MODE, created using "Object Pooling", where player can endlessly throw any number of fireballs to take down the bird.

-Used "Queue" to pool the objects and perform first-in-first-out operations.
-When the scene loads, the fireball gameobject prefab gets Instantiated and Enqueued(inserted into the queue) and then Dequeued to use it in the scene until its defined lifespan.
-Upon releasing that ball from catapult we will have another fireball prefab getting instantiated over the catapult where we check the count of the queue, If the count is greater than zero which means if there is any object inside the queue then we will Dequeue(take out from the queue) it and use it for instantiation.
-Every fireball will have lifespan of 8 seconds after which they will get disabled and return back to the pool(Enqueue).
-So upon aggressive attacking of fireball by the player, at max 3-4 fireball gameobject will get created and then It will go on reusing(enabling/disabling) those 3-4 gameobjects using queue till the player stops.
-Same concept is applied for Bird's object pool.
-Apart from setting the lifespan, code performs Enqueue operation if bird gameobject dies(upon colliding with fireball) and then it waits for 3 seconds after which it Dequeue's the same bird's gameobject and instantiate over the scene.

https://youtu.be/i-p75elfwhI

If Object Pool pattern was not used here then
-We would be instantiating the fireball gameobject when scene loads and when that gameobject gets destroyed or maybe hits the ground then we have to specify a condition where that same game object is getting reused again to instantiate it over the catapult (also changing the animation state of fireball gameobject from blasted to idle).
-The problem here would be player cannot throw one after the other, he would have to wait for the current fireball released to get destroyed or collide with the ground.
-But if we introduced one more copy of that fireball gameobject in the scene and disable it first then the moment player releases first fireball the other fireball gameobject should get enabled.
-After which, the logic should be if first fireball gameobject gets destroyed it should be ready to get instantiated again over the catapult upon releasing of second fireball gameobject.
-I think it is also a type of Object pooling but not completly, as the core idea behind it is re using the same gameobjects.

-This is beautifully solved using the queue operations and above discussed Object Pool pattern.
-As we can see over the inspector that 3 gameobjects are being created and then it is using only those 3 gameobjects to instantiate.
The reason it gone to 3 is when first one got created, it got enqueued and then dequeued from the queue then when we release it the second one came into the scene as there were no objects inside the queue and when second one also got released third one got into the scene, because the first and second one was not yet disabled and Enqueued back to the pool queue(which happens when lifespan reaches to 8 seconds). The moment the life span of any gameObject reaches 8 seconds it gets Enqueued.
-And then the code uses those objects which got enqueued to instantiate.
