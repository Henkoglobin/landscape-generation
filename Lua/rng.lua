-- rng.lua
-- 
-- Provides an abstract Pseudo-Random Number Generator

local integer = require("integer")
local maxInteger = integer.maxValue

local rng = {}
rng.__index = rng
rng.__call = function(self, ...)
	return setmetatable(self.new(...), self)
end
	
function rng:next(min, max)
	min, max = min or 0, max or maxInteger
	return math.ceil(self:sample() * (max - min)) + min
end

return rng
