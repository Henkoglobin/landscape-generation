-- program.lua
-- 
--

local shub = require("blumblumshub")
local util = require("utils.primeNumberUtil")
local iterativeTest = require("utils.primality.iterativePrimalityTest")
local fermatTest = require("utils.primality.fermatPrimalityTest")
local millerRabinTest = require("utils.primality.millerRabinPrimalityTest")

local generatePrimes, testBlumBlumShub, benchmarkPrimalityTests, comparePrimalityTests
local function main(...)
	generatePrimes()
	testBlumBlumShub()
	benchmarkPrimalityTests()
	comparePrimalityTests()
end

local getPrime
generatePrimes = function()
	p, q = getPrime(3500), getPrime(17500)
	print(("p = %d, q = %d"):format(p, q))
end

getPrime = function(min)
	local it = util.getPrimes(iterativeTest)
	while(true) do
		local number = it()
		if number > min and number % 4 == 3 then
			return number
		end
	end
end

testBlumBlumShub = function()
	local rng = shub(12);
	local nums = {}
	
	for i = 1, 10 do
		nums[i] = rng:next(1, 100)
	end
	
	for i = 1, 10 do
		print(nums[i])
	end
end

benchmarkPrimalityTests = function()
	local limit = 1e6
	
	local startIterative = os.clock()
	local it = util.getPrimes(iterativeTest)
	while it() < limit do end
	local endIterative = os.clock()
	
	print(("Iterative test took    %f seconds for %d iterations."):format(endIterative - startIterative, limit))
	
	local startFermat = os.clock()
	local it = util.getPrimes(fermatTest)
	while it() < limit do end
	local endFermat = os.clock()
	
	print(("Fermat test took       %f seconds for %d iterations."):format(endFermat - startFermat, limit))
	
	local startMillerRabin = os.clock()
	local it = util.getPrimes(millerRabinTest)
	while it() < limit do end
	local endMillerRabin = os.clock()
	
	print(("Miller-Rabin test took %f seconds for %d iterations"):format(endMillerRabin - startMillerRabin, limit))
end

comparePrimalityTests = function()
	local limit = 1e3
	
	local itIterative = util.getPrimes(iterativeTest)
	local itFermat = util.getPrimes(fermatTest)
	local itMillerRabin = util.getPrimes(millerRabinTest)
	local iterativeResult = {}
	local fermatResult = {}
	local millerRabinResult = {}
	
	local index = 1
	
	while(true) do
		local numIterative, numFermat, numMillerRabin = itIterative(), itFermat(), itMillerRabin()
		
		if numIterative > limit and numFermat > limit and numMillerRabin > limit then
			break
		end
		
		if numIterative < limit then
			iterativeResult[index] = numIterative
		end
		
		if numFermat < limit then
			fermatResult[index] = numFermat
		end
		
		if numMillerRabin < limit then
			millerRabinResult[index] = numMillerRabin
		end
		
		index = index + 1
	end
	
	print(("Iterative method yielded    %d primes < %d"):format(#iterativeResult, limit))
	
	for _, prime in ipairs(iterativeResult) do
		io.write(prime .. ", ")
	end
	
	print(("Fermat method yielded       %d primes < %d"):format(#fermatResult, limit))
	
	for _, prime in ipairs(fermatResult) do
		io.write(prime .. ", ")
	end
	
	print(("Miller-Rabin method yielded %d primes < %d"):format(#millerRabinResult, limit))
	
	for _, prime in ipairs(millerRabinResult) do
		io.write(prime .. ", ")
	end
end

main(...)
