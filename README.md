# AloneInMusic
Short game, showcase of OOP (SOLID, DRY) principles
This game encapsulates efficient way of structuring and keeping the code clean, reusable and intuitive

### About The Game
In this game you are in a test chamber, filled with several obstacles and surrounded with walls from all sides

![image](https://github.com/Romanumo/AloneInMusic/assets/79278079/46b9279a-50a1-4009-b44f-e4d2743ed5f9)

Periodically higher ups are going to send waves of evil entites, each with different abilities and behaviour

### Behaviour OOP System
Due to principles of OOP, behaviour building for enemies is very flexible and easy
**Shortly**: Enemies have central behaviour script. Enemy state is mostly defined by how close player is to him

![image](https://github.com/Romanumo/AloneInMusic/assets/79278079/a5cd39be-d9ae-4f49-9de5-881e03fdcc96)

As you see in the example above, this entity has 2 states (Technically 3 if we include idle state, which most of the time is default), for each state we assign behaviour script, range of state activation and animation name associated with that state. In this case there are 2 behaviours

![image](https://github.com/Romanumo/AloneInMusic/assets/79278079/d82e6183-908d-4dc2-b028-5f60cf10939a)
This is the first state. This behaviour is associated with seeker movement, meaning entity will move toward the player if activated

![image](https://github.com/Romanumo/AloneInMusic/assets/79278079/1095d243-d022-442c-a405-2f1dfa68818d)
This is the second state. This behaviour is associated with targeted attack, meaning it will have an instant, non projectile based attack

Put together it will look like this
