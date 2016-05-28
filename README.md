## Random Landscape Generation

*This project is inspired by and based on [Polygonal Map Generation for Games](http://www-cs-students.stanford.edu/~amitp/game-programming/polygon-map-generation/) from [Redblob Games](http://www.redblobgames.com/).*

The main purpose of this project is to generate random landscapes that can be used for both videogames and Pen & Paper RPGs like [Pathfinder](http://paizo.com/pathfinderRPG). It also allows me to play around with different [Pseudo-Random Number Generators](https://en.wikipedia.org/wiki/Pseudorandom_number_generator), [Primality Tests](https://en.wikipedia.org/wiki/Primality_test) and other algorithms.

I will implement the project in two languages: [Lua 5.3](http://lua.org/) and [C# 6](https://msdn.microsoft.com/en-us/library/kx37x362.aspx). I will try to keep both implementations up-to-date.

### Algorithms

Currently, the following algorithms are implemented:

#### Pseudo-Random Number Generators

* [Blum Blum Shub](https://en.wikipedia.org/wiki/Blum_Blum_Shub) ([Lua](Lua/blumblumshub.lua), [C#](CSharp/RandomNumberGeneration/BlumBlumShub/BlumBlumShub.cs))

#### Primality Tests

* [Iterative (naïve) test](https://en.wikipedia.org/wiki/Primality_test#Simple_methods) ([Lua](Lua/utils/primality/iterativePrimalityTest.lua), [C#](CSharp/RandomNumberGeneration/BlumBlumShub/Utils/Primality/IterativePrimalityTest.cs))
* [Fermat test](https://en.wikipedia.org/wiki/Fermat_primality_test) ([Lua](Lua/utils/primality/fermatPrimalityTest.lua), [C#](CSharp/RandomNumberGeneration/BlumBlumShub/Utils/Primality/FermatPrimalityTest.cs))
* [Miller-Rabin test](https://en.wikipedia.org/wiki/Miller%E2%80%93Rabin_primality_test) ([Lua](Lua/utils/primality/millerRabinPrimalityTest.lua), [C#](CSharp/RandomNumberGeneration/BlumBlumShub/Utils/Primality/MillerRabinPrimalityTest.cs))