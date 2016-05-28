-- millerRabinPrimalityTest.lua
-- 
-- 

local mathUtil = require("utils.mathUtil")

local tests = { 2, 7, 61 }

-- based on [this C# code](http://rosettacode.org/wiki/Miller%E2%80%93Rabin_primality_test#C.23)
local function test(number)
	if number < 2 then return false end
	if number ~= 2 and number % 2 == 0 then return false end
	
	local s = number - 1
	while s % 2 == 0 do
		s = s >> 1
	end
	
	for _, a in pairs(tests) do
		local temp = s
		local mod = mathUtil.modPow(a, temp, number)
		while temp ~= number -1 and mod ~= 1 and mod ~= number - 1 do
			mod = (mod * mod) % number
			temp = temp * 2
		end
		
		if mod ~= number -1 and temp % 2 == 0 then
			return false
		end
	end
	
	return true
end

return test
