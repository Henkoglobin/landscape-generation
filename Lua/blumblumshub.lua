-- blumblumshub.lua
-- 
-- 

local rng = require("rng")

local defaultP, defaultQ = 3511, 17519

local blumblumshub = setmetatable({}, rng)
blumblumshub.__index = blumblumshub

local validatePrime, validateSeed
function blumblumshub.new(p, q, seed)
	if p and not q and not seed then
		p, q, seed = defaultP, defaultQ, p
	elseif not (p and q and seed) then
		error("blum-blum-shub requires either one or three parameters.")
	end
	
	if not validatePrime(p) or not validatePrime(q) then
		error("blum-blum-shub requires p and q to be primes congruent to 3 (mod 4).")
	end
	
	if not validateSeed(s) then
		error("blum-blum-shub requires the seed to be greater than 1.")
	end
	
	return { state = seed, pq = p * q }
end

function validatePrime(p)
	return p % 4 == 3
end

function validateSeed(seed)
	return seed ~= 0 and seed ~= 1
end

function blumblumshub:sample()
	local value = (self.state * self.state) % (self.pq)
	print("update, state = " .. self.state .. ", new state = " .. value)
	self.state = value
	return value / (self.pq - 1)
end

return blumblumshub
