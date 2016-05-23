-- blumblumshup.lua
-- 
-- 

local p, q = 3881, 17977

local mt
mt = setmetatable({}, {
	__call = function(self, seed)
		return setmetatable({ state = seed }, mt)
	end	
})

mt.__index = mt

function mt:next()
	local value = (self.state * self.state) % (p * q)
	self.state = value
	
	return value / (p * q - 1)
end

return mt